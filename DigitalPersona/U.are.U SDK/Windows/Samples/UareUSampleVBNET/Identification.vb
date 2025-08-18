Imports System.Threading
Imports DPUruNet
Imports DPUruNet.Constants

Public Class Identification
    ''' <summary>
    ''' Holds the main form with many functions common to all of SDK actions.
    ''' </summary>
    Public _sender As Form_Main

    Private Const DPFJ_PROBABILITY_ONE As Integer = &H7FFFFFFF
    Private rightIndex As Fmd
    Private rightThumb As Fmd
    Private anyFinger As Fmd
    Private count As Integer

    ''' <summary>
    ''' Initialize the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Identification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtIdentify.Text = String.Empty
        rightIndex = Nothing
        rightThumb = Nothing
        anyFinger = Nothing
        count = 0

        SendMessage(Action.SendMessage, "Place your right index finger on the reader.")

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
                rightIndex = resultConversion.Data
                count += 1
                SendMessage(Action.SendMessage, "Now place your right thumb on the reader.")
            ElseIf count = 1 Then
                rightThumb = resultConversion.Data
                count += 1
                SendMessage(Action.SendMessage, "Now place any finger on the reader.")
            ElseIf count = 2 Then
                anyFinger = resultConversion.Data
                Dim fmds(1) As Fmd
                fmds(0) = rightIndex
                fmds(1) = rightThumb

                ' See the SDK documentation for an explanation on threshold scores.
                Dim thresholdScore As Integer = DPFJ_PROBABILITY_ONE * 1 / 100000

                Dim identifyResult = Comparison.Identify(anyFinger, 0, fmds, thresholdScore, 2)

                If identifyResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                    _sender.Reset = True
                    Throw New Exception("" & identifyResult.ResultCode.ToString())
                End If

                SendMessage(Action.SendMessage, "Identification resulted in the following number of matches: " & identifyResult.Indexes.Length.ToString())
                SendMessage(Action.SendMessage, "Place your right index finger on the reader.")
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
    Private Sub Identification_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        _sender.CancelCaptureAndCloseReader(AddressOf Me.OnCaptured)
    End Sub

#Region "SendMessage"
    Public Enum Action
        SendMessage
    End Enum
    Private Delegate Sub SendMessageCallback(ByVal action As Action, ByVal payload As String)
    Private Sub SendMessage(ByVal action As Action, ByVal payload As String)
        On Error Resume Next

        If Me.txtIdentify.InvokeRequired Then
            Dim d As New SendMessageCallback(AddressOf SendMessage)
            Me.Invoke(d, New Object() {action, payload})
        Else
            Select Case action
                Case action.SendMessage
                    txtIdentify.Text += payload & vbCrLf & vbCrLf
                    txtIdentify.SelectionStart = txtIdentify.TextLength
                    txtIdentify.ScrollToCaret()
            End Select
        End If
    End Sub
#End Region
End Class