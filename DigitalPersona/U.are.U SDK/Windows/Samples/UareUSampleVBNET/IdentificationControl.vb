Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Text
Imports System.Windows.Forms
Imports DPUruNet

Partial Public Class IdentificationControl
    Inherits Form
    Public _sender As Form_Main
    Private Const DPFJ_PROBABILITY_ONE As Integer = &H7FFFFFFF
    Private WithEvents identificationControl As DPCtlUruNet.IdentificationControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub identificationControl_OnIdentify(ByVal IdentificationControl As DPCtlUruNet.IdentificationControl, ByVal IdentificationResult As IdentifyResult) Handles identificationControl.OnIdentify
        If IdentificationResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
            If IdentificationResult.Indexes Is Nothing Then
                If IdentificationResult.ResultCode = Constants.ResultCode.DP_INVALID_PARAMETER Then
                    MessageBox.Show("Warning: Fake finger was detected.")
                ElseIf IdentificationResult.ResultCode = Constants.ResultCode.DP_NO_DATA Then
                    MessageBox.Show("Warning: No finger was detected.")
                Else
                    If _sender.CurrentReader IsNot Nothing Then
                        _sender.CurrentReader.Dispose()
                        _sender.CurrentReader = Nothing
                    End If
                End If
            Else
                If _sender.CurrentReader IsNot Nothing Then
                    _sender.CurrentReader.Dispose()
                    _sender.CurrentReader = Nothing
                End If
                MessageBox.Show("Error:  " & IdentificationResult.ResultCode.ToString())
            End If
        Else
            _sender.CurrentReader = IdentificationControl.Reader
            txtMessage.Text = txtMessage.Text + "OnIdentify:  " & (If(IdentificationResult.Indexes.Length.Equals(0), "No ", "One or more ")) & "matches.  Try another finger." & vbCr & vbLf & vbCr & vbLf
        End If

            txtMessage.SelectionStart = txtMessage.TextLength
            txtMessage.ScrollToCaret()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub IdentificationControl_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If identificationControl IsNot Nothing Then
            identificationControl.Reader = _sender.CurrentReader
        Else
            ' See the SDK documentation for an explanation on threshold scores.
            Dim thresholdScore As Integer = DPFJ_PROBABILITY_ONE * 1 / 100000

            identificationControl = New DPCtlUruNet.IdentificationControl(_sender.CurrentReader, _sender.Fmds.Values, thresholdScore, 10, Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)
            identificationControl.Location = New System.Drawing.Point(3, 3)
            identificationControl.Name = "identificationControl"
            identificationControl.Size = New System.Drawing.Size(397, 128)
            identificationControl.TabIndex = 0

            ' Be sure to set the maximum number of matches you want returned.
            identificationControl.MaximumResult = 10

            Me.Controls.Add(identificationControl)
        End If

        identificationControl.StartIdentification()
    End Sub

    Private Sub IdentificationControl_FormClosed(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Closed
        identificationControl.StopIdentification()
    End Sub
End Class
'! @endcond
