<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Verification
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
        Me.txtVerify = New System.Windows.Forms.TextBox
        Me.btnBack = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtVerify
        '
        Me.txtVerify.Location = New System.Drawing.Point(12, 12)
        Me.txtVerify.Multiline = True
        Me.txtVerify.Name = "txtVerify"
        Me.txtVerify.Size = New System.Drawing.Size(339, 213)
        Me.txtVerify.TabIndex = 0
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(276, 231)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 2
        Me.btnBack.Text = "Back"
        '
        'Verification
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(354, 262)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.txtVerify)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
#If Not WindowsCE Then
        Me.MaximumSize = New System.Drawing.Size(374, 312)
        Me.MinimumSize = New System.Drawing.Size(374, 312)
        Me.ClientSize = New System.Drawing.Size(374, 312)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
#End If
        Me.Name = "Verification"
        Me.Text = "Verification"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtVerify As System.Windows.Forms.TextBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
