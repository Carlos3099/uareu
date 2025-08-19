<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stream
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
        Me.pbFingerprint = New System.Windows.Forms.PictureBox
        Me.btnBack = New System.Windows.Forms.Button
        Me.lblPlaceFinger = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'pbFingerprint
        '
        Me.pbFingerprint.Location = New System.Drawing.Point(3, 1)
        Me.pbFingerprint.Name = "pbFingerprint"
        Me.pbFingerprint.Size = New System.Drawing.Size(256, 360)
        Me.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(197, 375)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(56, 23)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "Back"
        '
        'lblPlaceFinger
        '
        Me.lblPlaceFinger.Location = New System.Drawing.Point(2, 380)
        Me.lblPlaceFinger.Name = "lblPlaceFinger"
        Me.lblPlaceFinger.Size = New System.Drawing.Size(187, 19)
        Me.lblPlaceFinger.Text = "Place a finger on the reader"
        '
        'Stream
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(256, 360)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lblPlaceFinger)
        Me.Controls.Add(Me.pbFingerprint)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
#If Not WindowsCE Then
        Me.MaximumSize = New System.Drawing.Size(275, 440)
        Me.MinimumSize = New System.Drawing.Size(275, 440)
        Me.ClientSize = New System.Drawing.Size(275, 440)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
#End If
        Me.Name = "Stream"
        Me.Text = "Stream"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbFingerprint As System.Windows.Forms.PictureBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents lblPlaceFinger As System.Windows.Forms.Label
End Class
