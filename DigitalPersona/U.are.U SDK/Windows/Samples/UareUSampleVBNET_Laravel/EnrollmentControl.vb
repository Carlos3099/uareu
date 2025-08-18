Imports System
Imports System.Net.Http
Imports System.Text
Imports System.Text.Json
Imports System.Windows.Forms
Imports DPUruNet

Partial Public Class EnrollmentControl
    Inherits Form

    ' ====== CONFIG ======
    Private Const BASE_URL As String = "http://127.0.0.1:8000/api"
    Private Const DPFJ_PROBABILITY_ONE As Integer = &H7FFFFFFF

    ' ====== SDK/UI ======
    Public _sender As Form_Main
    Private WithEvents enrollmentControl As DPCtlUruNet.EnrollmentControl

    Public Sub New()
        InitializeComponent()
    End Sub

    ' ============= Helper HTTP: POST huella a Laravel =============
    Private Async Function PostHuellaAsync(empleadoId As Integer, fmdXml As String, formato As String) As Task
        Dim payload = New With {.fmd_xml = fmdXml, .formato = formato}
        Dim json = JsonSerializer.Serialize(payload)
        Using client As New HttpClient()
            Dim content = New StringContent(json, Encoding.UTF8, "application/json")
            Dim resp = Await client.PostAsync($"{BASE_URL}/empleados/{empleadoId}/huellas", content)
            Dim body = Await resp.Content.ReadAsStringAsync()
            If Not resp.IsSuccessStatusCode Then
                Throw New Exception("Error guardando huella: " & body)
            End If
        End Using
    End Function
    ' =============================================================

    ' ============= Evento: termina enrolamiento ===================
    Private Async Sub enrollmentControl_FinishEnrollment(ByVal senderCtl As DPCtlUruNet.EnrollmentControl,
                                                         ByVal result As DPUruNet.DataResult(Of DPUruNet.Fmd),
                                                         ByVal fingerPosition As Integer) _
                                                         Handles enrollmentControl.FinishEnrollment
        Try
            If result Is Nothing OrElse result.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                MessageBox.Show("Enrolamiento falló: " & If(result Is Nothing, "NULL", result.ResultCode.ToString()))
                Exit Sub
            End If

            ' 1) FMD resultante
            Dim fmd As DPUruNet.Fmd = result.Data

            ' 2) Serializar FMD a XML (recomendado por el SDK)
            Dim fmdXml As String = DPUruNet.Fmd.SerializeXml(fmd)
            Dim formato As String = fmd.Format.ToString() ' etiqueta informativa

            ' 3) Preguntar el empleado_id (rápido para pruebas)
            Dim txt As String = InputBox("ID del empleado en Laravel:", "Enrolar huella", "1")
            If String.IsNullOrWhiteSpace(txt) Then Exit Sub
            Dim empleadoId As Integer = CInt(txt)

            ' 4) Enviar a Laravel
            Await PostHuellaAsync(empleadoId, fmdXml, formato)

            MessageBox.Show("Huella guardada en Laravel ✅")
        Catch ex As Exception
            MessageBox.Show("Error en FinishEnrollment: " & ex.Message)
        End Try
    End Sub
    ' =============================================================

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub EnrollmentControl_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If enrollmentControl IsNot Nothing Then
            enrollmentControl.Reader = _sender.CurrentReader
        Else
            ' Probabilidad recomendada (1e-5) para el proceso de enrolamiento
            Dim thresholdScore As Integer = CInt(DPFJ_PROBABILITY_ONE / 100000)

            enrollmentControl = New DPCtlUruNet.EnrollmentControl(_sender.CurrentReader,
                                                                  thresholdScore,
                                                                  Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)
            enrollmentControl.Location = New Drawing.Point(3, 3)
            enrollmentControl.Name = "enrollmentControl"
            enrollmentControl.Size = New Drawing.Size(397, 128)
            enrollmentControl.TabIndex = 0
            Me.Controls.Add(enrollmentControl)
        End If

        enrollmentControl.StartEnrollment()
    End Sub

    Private Sub EnrollmentControl_FormClosed(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Closed
        Try
            If enrollmentControl IsNot Nothing Then
                enrollmentControl.StopEnrollment()
            End If
        Catch
        End Try
    End Sub
End Class
