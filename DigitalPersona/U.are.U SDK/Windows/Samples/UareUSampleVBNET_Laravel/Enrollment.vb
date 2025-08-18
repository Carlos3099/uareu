Imports System
Imports System.Net.Http
Imports System.Text
Imports System.Text.Json
Imports System.Windows.Forms
Imports DPUruNet

Partial Public Class Enrollment
    Inherits Form

    ' ====== CONFIG API ======
    Private Const BASE_URL As String = "http://127.0.0.1:8000/api"

    ' ====== SI TU CONTROL TIENE OTRO NOMBRE ======
    ' En la mayoría de samples es "EnrollmentControl1".
    ' Si en tu Designer se llama distinto, cambia "EnrollmentControl1"
    ' en este archivo por el nombre real.

    Public Sub New()
        InitializeComponent()
    End Sub

    ' ===========================
    ' Helpers HTTP a Laravel
    ' ===========================

    ' Crea empleado y devuelve su ID
    Private Async Function CrearEmpleadoAsync(nombre As String, telefono As String, email As String) As Task(Of Integer)
        Dim payload = New With {.nombre = nombre, .telefono = telefono, .email = email}
        Dim json = JsonSerializer.Serialize(payload)
        Using client As New HttpClient()
            Dim resp = Await client.PostAsync($"{BASE_URL}/empleados", New StringContent(json, Encoding.UTF8, "application/json"))
            Dim body = Await resp.Content.ReadAsStringAsync()
            If Not resp.IsSuccessStatusCode Then
                Throw New Exception("Error creando empleado: " & body)
            End If

            ' Respuesta esperada: { message, empleado: { id, ... } }
            Using doc = JsonDocument.Parse(body)
                Dim root = doc.RootElement
                If root.TryGetProperty("empleado", Nothing) Then
                    Return root.GetProperty("empleado").GetProperty("id").GetInt32()
                End If
                ' Alternativa por si tu endpoint devuelve directo el empleado
                If root.TryGetProperty("id", Nothing) Then
                    Return root.GetProperty("id").GetInt32()
                End If
            End Using

            Throw New Exception("No se pudo obtener el ID del empleado del JSON de respuesta.")
        End Using
    End Function

    ' Guarda la huella para un empleado
    Private Async Function PostHuellaAsync(empleadoId As Integer, fmdXml As String, formato As String) As Task
        Dim payload = New With {.fmd_xml = fmdXml, .formato = formato}
        Dim json = JsonSerializer.Serialize(payload)
        Using client As New HttpClient()
            Dim resp = Await client.PostAsync($"{BASE_URL}/empleados/{empleadoId}/huellas", New StringContent(json, Encoding.UTF8, "application/json"))
            Dim body = Await resp.Content.ReadAsStringAsync()
            If Not resp.IsSuccessStatusCode Then
                Throw New Exception("Error guardando huella: " & body)
            End If
        End Using
    End Function

    ' ===========================
    ' Enganchar evento al cargar
    ' ===========================
    Private Sub Enrollment_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            ' Desengancha por si ya estaba, y vuelve a enganchar
            RemoveHandler EnrollmentControl1.FinishEnrollment, AddressOf Enrollment_FinishEnrollment ' <-- CAMBIA EL NOMBRE SI TU CONTROL ES OTRO
            AddHandler EnrollmentControl1.FinishEnrollment, AddressOf Enrollment_FinishEnrollment ' <-- CAMBIA EL NOMBRE SI TU CONTROL ES OTRO

            ' Inicia el proceso de enrolamiento
            EnrollmentControl1.StartEnrollment() ' <-- CAMBIA EL NOMBRE SI TU CONTROL ES OTRO
        Catch ex As Exception
            MessageBox.Show("Error iniciando Enrollment: " & ex.Message)
        End Try
    End Sub

    ' ===========================
    ' Al cerrar, detén el control
    ' ===========================
    Private Sub Enrollment_FormClosed(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Closed
        Try
            EnrollmentControl1.StopEnrollment() ' <-- CAMBIA EL NOMBRE SI TU CONTROL ES OTRO
        Catch
        End Try
    End Sub

    ' ===========================
    ' Handler: terminó el enrolamiento
    ' ===========================
    Private Async Sub Enrollment_FinishEnrollment(
        ByVal senderCtl As DPCtlUruNet.EnrollmentControl,
        ByVal result As DPUruNet.DataResult(Of DPUruNet.Fmd),
        ByVal fingerPosition As Integer)

        Try
            If result Is Nothing OrElse result.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                MessageBox.Show("Enrolamiento falló: " & If(result Is Nothing, "NULL", result.ResultCode.ToString()))
                Exit Sub
            End If

            ' 1) Huella (FMD) generada por el SDK
            Dim fmd As DPUruNet.Fmd = result.Data

            ' 2) Serializar a XML (formato del SDK recomendado)
            Dim fmdXml As String = DPUruNet.Fmd.SerializeXml(fmd)
            Dim formato As String = fmd.Format.ToString()

            ' 3) Pedir datos del empleado
            Dim nombre As String = InputBox("Nombre del empleado:", "Crear empleado")
            If String.IsNullOrWhiteSpace(nombre) Then
                MessageBox.Show("Operación cancelada.")
                Exit Sub
            End If

            Dim telefono As String = InputBox("Teléfono:", "Crear empleado")
            If telefono Is Nothing Then telefono = "" ' permite vacío

            Dim email As String = InputBox("Email (opcional):", "Crear empleado")
            If email Is Nothing Then email = "" ' permite vacío

            ' 4) Crear empleado en Laravel
            Dim empleadoId As Integer = Await CrearEmpleadoAsync(nombre, telefono, email)

            ' 5) Enviar huella asociada al empleado recién creado
            Await PostHuellaAsync(empleadoId, fmdXml, formato)

            MessageBox.Show($"Empleado #{empleadoId} creado y huella guardada ✅")

        Catch ex As Exception
            MessageBox.Show("Error en FinishEnrollment: " & ex.Message)
        End Try
    End Sub

End Class
