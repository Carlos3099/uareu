<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Enrollment
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
        Me.btnBack = New System.Windows.Forms.Button
        Me.txtEnroll = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(276, 229)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 4
        Me.btnBack.Text = "Back"
        '
        'txtEnroll
        '
        Me.txtEnroll.Location = New System.Drawing.Point(12, 10)
        Me.txtEnroll.Multiline = True
        Me.txtEnroll.Name = "txtEnroll"
        Me.txtEnroll.Size = New System.Drawing.Size(339, 213)
        Me.txtEnroll.TabIndex = 3
        '
        'Enrollment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(354, 262)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.txtEnroll)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
#If Not WindowsCE Then
        Me.MaximumSize = New System.Drawing.Size(374, 312)
        Me.MinimumSize = New System.Drawing.Size(374, 312)
        Me.ClientSize = New System.Drawing.Size(374, 312)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
#End If
        Me.Name = "Enrollment"
        Me.Text = "Enrollment"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents txtEnroll As System.Windows.Forms.TextBox
End Class
