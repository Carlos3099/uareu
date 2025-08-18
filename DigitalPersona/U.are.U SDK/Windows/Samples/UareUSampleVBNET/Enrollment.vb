Imports System.Threading
Imports System.Collections.Generic
Imports DPUruNet
Imports DPUruNet.Constants

Public Class Enrollment
    ''' <summary>
    ''' Holds the main form with many functions common to all of SDK actions.
    ''' </summary>
    Public _sender As Form_Main

    Dim preenrollmentFmds As List(Of Fmd)
    Private count As Integer

    ''' <summary>
    ''' Initialize the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Enrollment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtEnroll.Text = String.Empty
        preenrollmentFmds = New List(Of Fmd)
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

            count += 1

            Dim resultConversion As DataResult(Of Fmd) = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Formats.Fmd.ANSI)

            If resultConversion.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                _sender.Reset = True
                Throw New Exception("" & resultConversion.ResultCode.ToString())
            End If

            preenrollmentFmds.Add(resultConversion.Data)

            SendMessage(Action.SendMessage, "A finger was captured.  " & vbCrLf & "Count:  " & (count.ToString()))

            If count >= 4 Then
                Dim resultEnrollment As DataResult(Of Fmd) = DPUruNet.Enrollment.CreateEnrollmentFmd(Formats.Fmd.ANSI, preenrollmentFmds)

                If resultEnrollment.ResultCode = ResultCode.DP_SUCCESS Then
                    SendMessage(Action.SendMessage, "An enrollment FMD was successfully created.")
                    SendMessage(Action.SendMessage, "Place a finger on the reader.")
                    count = 0
                    preenrollmentFmds.Clear()
                    Return
                ElseIf (resultEnrollment.ResultCode = Constants.ResultCode.DP_ENROLLMENT_INVALID_SET) Then
                    SendMessage(Action.SendMessage, "Enrollment was unsuccessful.  Please try again.")
                    SendMessage(Action.SendMessage, "Place a finger on the reader.")
                    count = 0
                    preenrollmentFmds.Clear()
                    Return
                End If
            End If
            
            SendMessage(Action.SendMessage, "Now place the same finger on the reader.")
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
    Private Sub Enrollment_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        _sender.CancelCaptureAndCloseReader(AddressOf Me.OnCaptured)
    End Sub

#Region "SendMessage"
    Public Enum Action
        SendMessage
    End Enum
    Private Delegate Sub SendMessageCallback(ByVal action As Action, ByVal payload As String)
    Private Sub SendMessage(ByVal action As Action, ByVal payload As String)
        On Error Resume Next

        If Me.txtEnroll.InvokeRequired Then
            Dim d As New SendMessageCallback(AddressOf SendMessage)
            Me.Invoke(d, New Object() {action, payload})
        Else
            Select Case action
                Case action.SendMessage
                    txtEnroll.Text += payload & vbCrLf & vbCrLf
                    txtEnroll.SelectionStart = txtEnroll.TextLength
                    txtEnroll.ScrollToCaret()
            End Select
        End If
    End Sub
#End Region
End Class