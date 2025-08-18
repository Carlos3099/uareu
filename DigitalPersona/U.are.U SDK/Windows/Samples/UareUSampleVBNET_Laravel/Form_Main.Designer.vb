<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnReaderSelect = New System.Windows.Forms.Button
        Me.btnCapture = New System.Windows.Forms.Button
        Me.btnStreaming = New System.Windows.Forms.Button
        Me.btnVerify = New System.Windows.Forms.Button
        Me.btnIdentify = New System.Windows.Forms.Button
        Me.btnEnroll = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtReaderSelected = New System.Windows.Forms.TextBox
        Me.btnIdentificationControl = New System.Windows.Forms.Button
        Me.btnEnrollmentControl = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnReaderSelect
        '
        Me.btnReaderSelect.Location = New System.Drawing.Point(12, 53)
        Me.btnReaderSelect.Name = "btnReaderSelect"
        Me.btnReaderSelect.Size = New System.Drawing.Size(115, 23)
        Me.btnReaderSelect.TabIndex = 1
        Me.btnReaderSelect.Text = "Reader Selection"
        '
        'btnCapture
        '
        Me.btnCapture.Enabled = False
        Me.btnCapture.Location = New System.Drawing.Point(133, 53)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(115, 23)
        Me.btnCapture.TabIndex = 2
        Me.btnCapture.Text = "Capture"
        '
        'btnStreaming
        '
        Me.btnStreaming.Enabled = False
        Me.btnStreaming.Location = New System.Drawing.Point(133, 111)
        Me.btnStreaming.Name = "btnStreaming"
        Me.btnStreaming.Size = New System.Drawing.Size(115, 23)
        Me.btnStreaming.TabIndex = 17
        Me.btnStreaming.Text = "Streaming"
        '
        'btnVerify
        '
        Me.btnVerify.Enabled = False
        Me.btnVerify.Location = New System.Drawing.Point(12, 82)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(115, 23)
        Me.btnVerify.TabIndex = 3
        Me.btnVerify.Text = "Verification"
        '
        'btnIdentify
        '
        Me.btnIdentify.Enabled = False
        Me.btnIdentify.Location = New System.Drawing.Point(133, 82)
        Me.btnIdentify.Name = "btnIdentify"
        Me.btnIdentify.Size = New System.Drawing.Size(115, 23)
        Me.btnIdentify.TabIndex = 4
        Me.btnIdentify.Text = "Identification"
        '
        'btnEnroll
        '
        Me.btnEnroll.Enabled = False
        Me.btnEnroll.Location = New System.Drawing.Point(12, 111)
        Me.btnEnroll.Name = "btnEnroll"
        Me.btnEnroll.Size = New System.Drawing.Size(115, 23)
        Me.btnEnroll.TabIndex = 5
        Me.btnEnroll.Text = "Enrollment"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 15)
        Me.Label1.Text = "Selected Reader:"
        '
        'txtReaderSelected
        '
        Me.txtReaderSelected.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtReaderSelected.Location = New System.Drawing.Point(15, 27)
        Me.txtReaderSelected.Name = "txtReaderSelected"
        Me.txtReaderSelected.Size = New System.Drawing.Size(233, 19)
        Me.txtReaderSelected.TabIndex = 0
        Me.txtReaderSelected.ReadOnly = True
        '
        'btnIdentificationControl
        '
        Me.btnIdentificationControl.Enabled = False
        Me.btnIdentificationControl.Location = New System.Drawing.Point(133, 150)
        Me.btnIdentificationControl.Name = "btnIdentificationControl"
        Me.btnIdentificationControl.Size = New System.Drawing.Size(115, 23)
        Me.btnIdentificationControl.TabIndex = 19
        Me.btnIdentificationControl.Text = "Identification GUI"
        '
        'btnEnrollmentControl
        '
        Me.btnEnrollmentControl.Enabled = False
        Me.btnEnrollmentControl.Location = New System.Drawing.Point(12, 150)
        Me.btnEnrollmentControl.Name = "btnEnrollmentControl"
        Me.btnEnrollmentControl.Size = New System.Drawing.Size(115, 23)
        Me.btnEnrollmentControl.TabIndex = 18
        Me.btnEnrollmentControl.Text = "Enrollment GUI"
        '
        'Form_Main
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(257, 177)
        Me.Controls.Add(Me.btnIdentificationControl)
        Me.Controls.Add(Me.btnEnrollmentControl)
        Me.Controls.Add(Me.txtReaderSelected)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEnroll)
        Me.Controls.Add(Me.btnIdentify)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.btnStreaming)
        Me.Controls.Add(Me.btnCapture)
        Me.Controls.Add(Me.btnReaderSelect)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
#If Not WindowsCE Then
        Me.MaximumSize = New System.Drawing.Size(277, 227)
        Me.MinimumSize = New System.Drawing.Size(277, 227)
        Me.ClientSize = New System.Drawing.Size(277, 227)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
#End If
        Me.Name = "Form_Main"
        Me.Text = "U.are.U Sample VB.NET"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnReaderSelect As System.Windows.Forms.Button
    Friend WithEvents btnCapture As System.Windows.Forms.Button
    Friend WithEvents btnStreaming As System.Windows.Forms.Button
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents btnIdentify As System.Windows.Forms.Button
    Friend WithEvents btnEnroll As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReaderSelected As System.Windows.Forms.TextBox
    Public WithEvents btnIdentificationControl As System.Windows.Forms.Button
    Friend WithEvents btnEnrollmentControl As System.Windows.Forms.Button

End Class
