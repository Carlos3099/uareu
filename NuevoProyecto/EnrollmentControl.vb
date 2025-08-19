Imports System
Imports System.Windows.Forms
Imports DPUruNet

Partial Public Class EnrollmentControl
    Inherits Form
    ''' <summary>
    ''' Holds the main form with many functions common to all of SDK actions.
    ''' </summary>
    Public _sender As Form_Main

    Private WithEvents enrollmentControl As DPCtlUruNet.EnrollmentControl

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Initialize the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EnrollmentControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If enrollmentControl IsNot Nothing Then
            _enrollmentControl.Reader = _sender.CurrentReader
        Else
            enrollmentControl = New DPCtlUruNet.EnrollmentControl(_sender.CurrentReader, Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)
            enrollmentControl.BackColor = System.Drawing.SystemColors.Window
            enrollmentControl.Location = New System.Drawing.Point(3, 3)
            enrollmentControl.Name = "ctlEnrollmentControl"
            enrollmentControl.Size = New System.Drawing.Size(482, 346)
            enrollmentControl.TabIndex = 0
        End If

        Me.Controls.Add(enrollmentControl)
    End Sub

#Region "Enrollment Control Events"
    Private Sub enrollment_OnCancel(ByVal enrollmentControl As DPCtlUruNet.EnrollmentControl, ByVal result As Constants.ResultCode, ByVal fingerPosition As Integer) Handles enrollmentControl.OnCancel

        If enrollmentControl.Reader IsNot Nothing Then
            SendMessage("OnCancel:  " & Convert.ToString(enrollmentControl.Reader.Description.Name) & ", finger " & fingerPosition)
        Else
            SendMessage("OnCancel:  No Reader Connected, finger " & fingerPosition)
        End If

        btnCancel.Enabled = False
    End Sub

    Private Sub enrollment_OnCaptured(ByVal enrollmentControl As DPCtlUruNet.EnrollmentControl, ByVal captureResult As CaptureResult, ByVal fingerPosition As Integer) Handles enrollmentControl.OnCaptured
        If enrollmentControl.Reader IsNot Nothing Then
            SendMessage(("OnCaptured:  " & Convert.ToString(enrollmentControl.Reader.Description.Name) & ", finger " & fingerPosition & ", quality ") + captureResult.Quality.ToString())
        Else
            SendMessage("OnCaptured:  No Reader Connected, finger " & fingerPosition)
        End If

        If captureResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
            If _sender.CurrentReader IsNot Nothing Then
                _sender.CurrentReader.Dispose()
                _sender.CurrentReader = Nothing
            End If

            ' Disconnect reader from enrollment control
            _enrollmentControl.Reader = Nothing
            MessageBox.Show("Error:  " & captureResult.ResultCode.ToString())
            btnCancel.Enabled = False
        Else
            If captureResult.Data IsNot Nothing Then
                For Each fiv As Fid.Fiv In captureResult.Data.Views
                    pbFingerprint.Image = _sender.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height)
                Next
            End If
        End If
    End Sub

    Private Sub enrollment_OnDelete(ByVal enrollmentControl As DPCtlUruNet.EnrollmentControl, ByVal result As Constants.ResultCode, ByVal fingerPosition As Integer) Handles enrollmentControl.OnDelete
        If enrollmentControl.Reader IsNot Nothing Then
            SendMessage("OnDelete:  " & Convert.ToString(enrollmentControl.Reader.Description.Name) & ", finger " & fingerPosition)
            SendMessage("Enrollment Finger Mask: " & _enrollmentControl.EnrolledFingerMask)
        Else
            SendMessage("OnDelete:  No Reader Connected, finger " & fingerPosition)
        End If

        _sender.Fmds.Remove(fingerPosition)

        If _sender.Fmds.Count = 0 Then
            _sender.btnIdentificationControl.Enabled = False
        End If
    End Sub

    Private Sub enrollment_OnEnroll(ByVal enrollmentControl As DPCtlUruNet.EnrollmentControl, ByVal result As DataResult(Of Fmd), ByVal fingerPosition As Integer) Handles enrollmentControl.OnEnroll
        If enrollmentControl.Reader IsNot Nothing Then
            SendMessage("OnEnroll:  " & Convert.ToString(enrollmentControl.Reader.Description.Name) & ", finger " & fingerPosition)
            SendMessage("Enrollment Finger Mask: " & _enrollmentControl.EnrolledFingerMask)
        Else
            SendMessage("OnEnroll:  No Reader Connected, finger " & fingerPosition)
        End If

        ' Save the enrollment to file.
        If result IsNot Nothing AndAlso result.Data IsNot Nothing Then
            _sender.Fmds.Add(fingerPosition, result.Data)
        End If

        btnCancel.Enabled = False

        _sender.btnIdentificationControl.Enabled = True
    End Sub

    Private Sub enrollment_OnStartEnroll(ByVal enrollmentControl As DPCtlUruNet.EnrollmentControl, ByVal result As Constants.ResultCode, ByVal fingerPosition As Integer) Handles enrollmentControl.OnStartEnroll
        If enrollmentControl.Reader IsNot Nothing Then
            SendMessage("OnStartEnroll:  " & Convert.ToString(enrollmentControl.Reader.Description.Name) & ", finger " & fingerPosition)
        Else
            SendMessage("OnStartEnroll:  No Reader Connected, finger " & fingerPosition)
        End If

        btnCancel.Enabled = True
    End Sub
#End Region

    ''' <summary>
    ''' Cancel enrollment when window is closed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult

        result = MessageBox.Show("Are you sure you want to cancel this enrollment?", "Are You Sure?", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If result = System.Windows.Forms.DialogResult.Yes Then
            enrollmentControl.Cancel()
        End If
    End Sub

    ''' <summary>
    ''' Close window.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Cancel enrollment when window is closed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EnrollmentControl_FormClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        enrollmentControl.Cancel()
    End Sub

    Private Sub SendMessage(ByVal message As String)
        txtMessage.Text += message & vbCr & vbLf & vbCr & vbLf
        txtMessage.SelectionStart = txtMessage.TextLength
        txtMessage.ScrollToCaret()
    End Sub
End Class
