Imports DPCtlUruNet

'! @cond
    Partial Class IdentificationControl
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(328, 111)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 20)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        '
        'txtMessage
        '
        Me.txtMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular)
        Me.txtMessage.Location = New System.Drawing.Point(406, 3)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(208, 128)
        Me.txtMessage.TabIndex = 2
        '
        'IdentificationControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(617, 135)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtMessage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
#If Not WindowsCE Then
        Me.MaximumSize = New System.Drawing.Size(637, 185)
        Me.MinimumSize = New System.Drawing.Size(637, 185)
        Me.ClientSize = New System.Drawing.Size(637, 185)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
#End If
        Me.Name = "IdentificationControl"
        Me.Text = "Identification"
        Me.ResumeLayout(False)


    End Sub

#End Region

    Private WithEvents btnClose As System.Windows.Forms.Button
        Private txtMessage As System.Windows.Forms.TextBox
    End Class
'! @endcond
