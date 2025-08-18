Imports System.Threading
Imports System.Drawing
Imports System.Drawing.Imaging
Imports DPUruNet
Imports DPUruNet.Constants

Public Class Stream
    ''' <summary>
    ''' Holds the main form with many functions common to all of SDK actions.
    ''' </summary>
    Public _sender As Form_Main

    Private reset As Boolean = False

    Private Sub Stream_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Application.DoEvents()

        pbFingerprint.Image = Nothing

        If Not _sender.OpenReader() Then
            MessageBox.Show("This reader cannot stream in this environment.")
            Me.Close()
            Return
        End If

        If Not _sender.CurrentReader.Capabilities.CanStream Then
            MessageBox.Show("This reader cannot stream in this environment.")
            Return
        End If

        _sender.CurrentReader.StartStreaming()

        Dim _captureResult As CaptureResult = Nothing

        reset = False
        While (Not reset)
            Try
                Dim result = _sender.CurrentReader.GetStatus()

                _captureResult = _sender.CurrentReader.GetStreamImage(Formats.Fid.ANSI,
                                                   CaptureProcessing.DP_IMG_PROC_DEFAULT,
                                                   _sender.CurrentReader.Capabilities.Resolutions(0))
            Catch ex As Exception
                _captureResult = New CaptureResult(ResultCode.DP_FAILURE, CaptureQuality.DP_QUALITY_NO_FINGER, 0, Nothing)
            End Try

            Application.DoEvents()

                If _captureResult.ResultCode <> ResultCode.DP_SUCCESS Then
                If (_sender.CurrentReader IsNot Nothing) Then
                    _sender.CurrentReader.Dispose()
                    _sender.CurrentReader = Nothing
                End If
                reset = True
                MessageBox.Show("Error:  " + _captureResult.ResultCode.ToString())
            End If

            If _captureResult.Data IsNot Nothing Then
                For Each fiv As Fid.Fiv In _captureResult.Data.Views
                    SendMessage(_sender.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height))
                Next
            End If
        End While
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        reset = True

        Me.Close()
    End Sub

    Private Sub Stream_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        For i As Integer = 1 To 20
            Thread.Sleep(25)
            Application.DoEvents()
        Next

        reset = True

        For i As Integer = 1 To 20
            Thread.Sleep(25)
            Application.DoEvents()
        Next

        If _sender.CurrentReader IsNot Nothing Then
            _sender.CurrentReader.StopStreaming()
            _sender.CurrentReader.Dispose()
        End If
    End Sub

#Region "SendMessage"
    Private Delegate Sub SendMessageCallback(ByVal payload As Object)
    Private Sub SendMessage(ByVal payload As Object)
        On Error Resume Next

        If Me.pbFingerprint.InvokeRequired Then
            Dim d As New SendMessageCallback(AddressOf SendMessage)
            Me.Invoke(d, New Object() {payload})
        Else
            pbFingerprint.Image = DirectCast(payload, Bitmap)
            pbFingerprint.Refresh()
        End If
    End Sub
#End Region
End Class