Imports DPUruNet

Public Class Capture
    ''' <summary>
    ''' Holds the main form with many functions common to all of SDK actions.
    ''' </summary>
    Public _sender As Form_Main

    ''' <summary>
    ''' Initialize the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Capture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbFingerprint.Image = Nothing

        If Not _sender.OpenReader() Then
            Me.Close()
        End If

        If Not _sender.StartCaptureAsync(AddressOf Me.OnCaptured) Then
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' Handler for when a fingerprint is captured.
    ''' </summary>
    ''' <param name="captureResult">contains info and data on the fingerprint capture</param>
    Public Sub OnCaptured(ByVal captureResult As CaptureResult)
        Try
            ' Check capture quality and throw an error if bad.
            If Not _sender.CheckCaptureResult(captureResult) Then Return

            For Each fiv As Fid.Fiv In captureResult.Data.Views
                SendMessage(Action.SendBitmap, _sender.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height))
            Next
        Catch ex As Exception
            SendMessage(Action.SendMessage, "Error:  " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Close window.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Close window.
    ''' </summary>
    Private Sub Capture_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        _sender.CancelCaptureAndCloseReader(AddressOf Me.OnCaptured)
    End Sub

#Region "SendMessage"
    Public Enum Action
        SendBitmap
        SendMessage
    End Enum
    Private Delegate Sub SendMessageCallback(ByVal action As Action, ByVal payload As Object)
    Private Sub SendMessage(ByVal action As Action, ByVal payload As Object)
        On Error Resume Next

        If Me.pbFingerprint.InvokeRequired Then
            Dim d As New SendMessageCallback(AddressOf SendMessage)
            Me.Invoke(d, New Object() {action, payload})
        Else
            Select Case action
                Case action.SendBitmap
                    pbFingerprint.Image = DirectCast(payload, Bitmap)
                    pbFingerprint.Refresh()
                Case action.SendMessage
                    MessageBox.Show(DirectCast(payload, String))
            End Select

        End If
    End Sub
#End Region
End Class