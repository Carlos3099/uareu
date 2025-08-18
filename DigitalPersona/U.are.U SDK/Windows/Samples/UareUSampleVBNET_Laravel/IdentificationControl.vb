Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Text
Imports System.Windows.Forms
Imports System.Net.Http
Imports System.Text.Json
Imports System.Threading.Tasks
Imports DPUruNet

Partial Public Class IdentificationControl
    Inherits Form

    ' ====== CONFIG ======
    Private Const BASE_URL As String = "http://127.0.0.1:8000/api"
    Private Const DPFJ_PROBABILITY_ONE As Integer = &H7FFFFFFF

    ' ====== SDK / UI ======
    Public _sender As Form_Main
    Private WithEvents identificationControl As DPCtlUruNet.IdentificationControl

    ' ====== GALERÍA (Laravel) ======
    ' Mantenemos el mismo orden entre FMDs y empleado_ids para mapear el índice que devuelve el control
    Private empleadoIds As New List(Of Integer)()

    ' ====== Tipos auxiliares ======
    Private Class CatalogoItem
        Public Property empleado_id As Integer
        Public Property fmd_xml As String
    End Class

    Public Sub New()
        InitializeComponent()
    End Sub

    ' ===========================
    ' CARGA DE CATÁLOGO DESDE LARAVEL
    ' ===========================
    Private Async Function CargarCatalogoFmdsAsync() As Task(Of Fmd())
        Using client As New HttpClient()
            Dim resp = Await client.GetAsync($"{BASE_URL.Replace("/api", "")}/api/catalogo-fmds")
            resp.EnsureSuccessStatusCode()
            Dim json = Await resp.Content.ReadAsStringAsync()

            Dim items = JsonSerializer.Deserialize(Of List(Of CatalogoItem))(json, New JsonSerializerOptions With {
                .PropertyNameCaseInsensitive = True
            })

            empleadoIds.Clear()
            Dim fmds As New List(Of Fmd)()
            If items IsNot Nothing Then
                For Each it In items
                    Dim fmd = fmd.DeserializeXml(it.fmd_xml)
                    fmds.Add(fmd)
                    empleadoIds.Add(it.empleado_id)
                Next
            End If

            Return fmds.ToArray()
        End Using
    End Function

    ' ===========================
    ' OBTENER SIGUIENTE TIPO (entrada/salida) SEGÚN LA ÚLTIMA
    ' ===========================
    Private Async Function GetSiguienteTipoAsync(empleadoId As Integer) As Task(Of String)
        Using client As New HttpClient()
            Dim resp = Await client.GetAsync($"{BASE_URL}/empleados/{empleadoId}/asistencias/ultima")
            resp.EnsureSuccessStatusCode()
            Dim json = Await resp.Content.ReadAsStringAsync()
            Using doc = JsonDocument.Parse(json)
                If doc.RootElement.TryGetProperty("ultima", Nothing) AndAlso
                   doc.RootElement.GetProperty("ultima").ValueKind <> JsonValueKind.Null Then

                    Dim tipoUltima = doc.RootElement.GetProperty("ultima").GetProperty("tipo").GetString()
                    Return If(tipoUltima = "entrada", "salida", "entrada")
                Else
                    Return "entrada"
                End If
            End Using
        End Using
    End Function

    ' ===========================
    ' REGISTRAR ASISTENCIA EN LARAVEL
    ' ===========================
    Private Async Function RegistrarAsistenciaAsync(empleadoId As Integer, tipo As String) As Task
        Using client As New HttpClient()
            Dim payload = New With {.empleado_id = empleadoId, .tipo = tipo}
            Dim json = JsonSerializer.Serialize(payload)
            Dim content = New StringContent(json, Encoding.UTF8, "application/json")
            Dim resp = Await client.PostAsync($"{BASE_URL}/asistencias", content)
            resp.EnsureSuccessStatusCode()
        End Using
    End Function

    ' ===========================
    ' EVENTO: AL IDENTIFICAR
    ' ===========================
    Private Async Sub identificationControl_OnIdentify(ByVal IdentificationControl As DPCtlUruNet.IdentificationControl,
                                                      ByVal IdentificationResult As IdentifyResult) Handles identificationControl.OnIdentify
        Try
            If IdentificationResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                If IdentificationResult.Indexes Is Nothing Then
                    If IdentificationResult.ResultCode = Constants.ResultCode.DP_INVALID_PARAMETER Then
                        MessageBox.Show("Warning: Se detectó dedo falso.")
                    ElseIf IdentificationResult.ResultCode = Constants.ResultCode.DP_NO_DATA Then
                        MessageBox.Show("Warning: No se detectó dedo.")
                    Else
                        If _sender IsNot Nothing AndAlso _sender.CurrentReader IsNot Nothing Then
                            _sender.CurrentReader.Dispose()
                            _sender.CurrentReader = Nothing
                        End If
                    End If
                Else
                    If _sender IsNot Nothing AndAlso _sender.CurrentReader IsNot Nothing Then
                        _sender.CurrentReader.Dispose()
                        _sender.CurrentReader = Nothing
                    End If
                    MessageBox.Show("Error:  " & IdentificationResult.ResultCode.ToString())
                End If
            Else
                _sender.CurrentReader = IdentificationControl.Reader

                If IdentificationResult.Indexes IsNot Nothing AndAlso IdentificationResult.Indexes.Length > 0 Then
                    ' Tomamos el primer match
                    Dim idx As Integer = IdentificationResult.Indexes(0)(0)

                    If idx >= 0 AndAlso idx < empleadoIds.Count Then
                        Dim empleadoId = empleadoIds(idx)

                        ' Alternar entrada/salida según la última en Laravel
                        Dim tipo As String = Await GetSiguienteTipoAsync(empleadoId)

                        ' Registrar asistencia
                        Await RegistrarAsistenciaAsync(empleadoId, tipo)

                        txtMessage.AppendText($"OnIdentify: match → Empleado {empleadoId}, asistencia {tipo} registrada ✅{vbCrLf}{vbCrLf}")
                    Else
                        txtMessage.AppendText("OnIdentify: índice fuera de rango. No se pudo mapear a empleado." & vbCrLf & vbCrLf)
                    End If
                Else
                    txtMessage.AppendText("OnIdentify: No hubo coincidencias. Intenta con otro dedo." & vbCrLf & vbCrLf)
                End If
            End If

            txtMessage.SelectionStart = txtMessage.TextLength
            txtMessage.ScrollToCaret()

        Catch ex As Exception
            MessageBox.Show("Error en OnIdentify: " & ex.Message)
        End Try
    End Sub

    ' ===========================
    ' CARGA DEL FORM: ARMA EL CONTROL CON GALERÍA DESDE LARAVEL
    ' ===========================
    Private Async Sub IdentificationControl_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            ' 1) Cargar galería desde Laravel
            Dim galeria As Fmd() = Await CargarCatalogoFmdsAsync()

            If galeria Is Nothing OrElse galeria.Length = 0 Then
                MessageBox.Show("No hay huellas en Laravel. Enrola primero.")
                Me.Close()
                Return
            End If

            ' 2) Configurar reader
            If identificationControl IsNot Nothing Then
                identificationControl.Reader = _sender.CurrentReader
            Else
                ' Threshold (probabilidad). 1e-5 es un buen punto de inicio.
                Dim thresholdScore As Integer = CInt(DPFJ_PROBABILITY_ONE / 100000)

                identificationControl = New DPCtlUruNet.IdentificationControl(
                    _sender.CurrentReader,
                    galeria,
                    thresholdScore,
                    10,
                    Constants.CapturePriority.DP_PRIORITY_COOPERATIVE
                )

                identificationControl.Location = New System.Drawing.Point(3, 3)
                identificationControl.Name = "identificationControl"
                identificationControl.Size = New System.Drawing.Size(397, 128)
                identificationControl.TabIndex = 0

                ' Máximo de resultados devueltos por el control
                identificationControl.MaximumResult = 10

                Me.Controls.Add(identificationControl)
            End If

            ' 3) Iniciar identificación
            identificationControl.StartIdentification()

        Catch ex As Exception
            MessageBox.Show("Error al iniciar identificación: " & ex.Message)
        End Try
    End Sub

    Private Sub IdentificationControl_FormClosed(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Closed
        Try
            If identificationControl IsNot Nothing Then
                identificationControl.StopIdentification()
            End If
        Catch
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
