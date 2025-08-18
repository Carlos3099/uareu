Imports DPCtlUruNet

'! @cond
    Partial Class EnrollmentControl
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pbFingerprint = New System.Windows.Forms.PictureBox()
        Me.SuspendLayout()
        '
        'txtMessage
        '
        Me.txtMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular)
        Me.txtMessage.Location = New System.Drawing.Point(491, 3)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(276, 173)
        Me.txtMessage.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(499, 207)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 20)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(499, 233)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 20)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'pbFingerprint
        '
        Me.pbFingerprint.Location = New System.Drawing.Point(621, 182)
        Me.pbFingerprint.Name = "pbFingerprint"
        Me.pbFingerprint.Size = New System.Drawing.Size(128, 180)
        Me.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbFingerprint.TabIndex = 0
        Me.pbFingerprint.TabStop = False
        '
        'EnrollmentControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(770, 354)
        Me.Controls.Add(Me.pbFingerprint)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtMessage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
#If Not WindowsCE Then
        Me.MaximumSize = New System.Drawing.Size(790, 404)
        Me.MinimumSize = New System.Drawing.Size(790, 404)
        Me.ClientSize = New System.Drawing.Size(790, 404)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
#End If
        Me.Name = "EnrollmentControl"
        Me.Text = "Enrollment"
        Me.ResumeLayout(False)


    End Sub

#End Region

        Private txtMessage As System.Windows.Forms.TextBox
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
        Private pbFingerprint As System.Windows.Forms.PictureBox
    End Class
'! @endcond
