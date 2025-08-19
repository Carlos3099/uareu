Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json  ' ← Instala el paquete NuGet "Newtonsoft.Json"

Public Module ApiClient
    Private _http As HttpClient

    Public Sub Init()
        ' TLS moderno si usas HTTPS
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim baseUrl = System.Configuration.ConfigurationManager.AppSettings("ApiBaseUrl")
        Dim token = System.Configuration.ConfigurationManager.AppSettings("ApiToken")

        _http = New HttpClient()
        If Not baseUrl.EndsWith("/") Then baseUrl &= "/"
        _http.BaseAddress = New Uri(baseUrl)
        _http.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
        _http.DefaultRequestHeaders.Add("X-PUENTE-TOKEN", token)
    End Sub

    Public Async Function PingAsync() As Task(Of String)
        Dim r = Await _http.GetAsync("ping")
        r.EnsureSuccessStatusCode()
        Return Await r.Content.ReadAsStringAsync()
    End Function

    Public Async Function EnrolarAsync(empleadoId As Integer, fmdXmlOrB64 As String, Optional formato As String = "DP/ANSI") As Task(Of String)
        Dim body = New With {.fmd_xml = fmdXmlOrB64, .formato = formato}
        Dim json = JsonConvert.SerializeObject(body)
        Dim r = Await _http.PostAsync($"empleados/{empleadoId}/huellas", New StringContent(json, Encoding.UTF8, "application/json"))
        Return Await r.Content.ReadAsStringAsync()
    End Function

    Public Async Function MarcarAsync(empleadoId As Integer, esEntrada As Boolean) As Task(Of String)
        Dim body = New With {.empleado_id = empleadoId, .tipo = If(esEntrada, "entrada", "salida")}
        Dim json = JsonConvert.SerializeObject(body)
        Dim r = Await _http.PostAsync("asistencias", New StringContent(json, Encoding.UTF8, "application/json"))
        Return Await r.Content.ReadAsStringAsync()
    End Function
End Module
