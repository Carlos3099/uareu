Imports System.Threading
Imports DPUruNet
Imports DPUruNet.Constants

Public Class Verification
    ''' <summary>
    ''' Holds the main form with many functions common to all of SDK actions.
    ''' </summary>
    Public _sender As Form_Main

    Private Const PROBABILITY_ONE As Integer = &H7FFFFFFF
    Private firstFinger As Fmd
    Private secondFinger As Fmd
    Private count As Integer

    ''' <summary>
    ''' Initialize the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Verification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtVerify.Text = String.Empty
        firstFinger = Nothing
        secondFinger = Nothing
        count = 0

        SendMessage(Action.SendMessage, "Place a finger on the reader.")

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

            SendMessage(Action.SendMessage, "A finger was captured.")

            Dim resultConversion As DataResult(Of Fmd) = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Formats.Fmd.ANSI)

            If resultConversion.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                If resultConversion.ResultCode <> Constants.ResultCode.DP_TOO_SMALL_AREA Then
                    _sender.Reset = True
                End If
                Throw New Exception("" & resultConversion.ResultCode.ToString())
            End If

            If count = 0 Then
                firstFinger = resultConversion.Data
                count += 1
                SendMessage(Action.SendMessage, "Now place the same or a different finger on the reader.")
            ElseIf count = 1 Then
                secondFinger = resultConversion.Data
                Dim compareResult = Comparison.Compare(firstFinger, 0, secondFinger, 0)

                If compareResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                    _sender.Reset = True
                    Throw New Exception("" & compareResult.ResultCode.ToString())
                End If

                SendMessage(Action.SendMessage, "Comparison resulted in a dissimilarity score of " & compareResult.Score.ToString() & IIf(compareResult.Score < (PROBABILITY_ONE / 100000), " (fingerprints matched)", " (fingerprints did not match)"))
                SendMessage(Action.SendMessage, "Place a finger on the reader.")
                count = 0
            End If
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
    Private Sub Verification_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        _sender.CancelCaptureAndCloseReader(AddressOf Me.OnCaptured)
    End Sub

#Region "SendMessage"
    Public Enum Action
        SendMessage
    End Enum
    Private Delegate Sub SendMessageCallback(ByVal action As Action, ByVal payload As String)
    Private Sub SendMessage(ByVal action As Action, ByVal payload As String)
        On Error Resume Next

        If Me.txtVerify.InvokeRequired Then
            Dim d As New SendMessageCallback(AddressOf SendMessage)
            Me.Invoke(d, New Object() {action, payload})
        Else
            Select Case action
                Case action.SendMessage
                    txtVerify.Text += payload & vbCrLf & vbCrLf
                    txtVerify.SelectionStart = txtVerify.TextLength
                    txtVerify.ScrollToCaret()
            End Select
        End If
    End Sub
#End Region
End Class