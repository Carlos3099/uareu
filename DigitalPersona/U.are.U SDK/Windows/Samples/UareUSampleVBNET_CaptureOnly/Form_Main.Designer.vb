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
        Me.btnReaderSelect = New System.Windows.Forms.Button()
        Me.btnCapture = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReaderSelected = New System.Windows.Forms.TextBox()
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
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Selected Reader:"
        '
        'txtReaderSelected
        '
        Me.txtReaderSelected.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtReaderSelected.Location = New System.Drawing.Point(15, 27)
        Me.txtReaderSelected.Name = "txtReaderSelected"
        Me.txtReaderSelected.ReadOnly = True
        Me.txtReaderSelected.Size = New System.Drawing.Size(233, 20)
        Me.txtReaderSelected.TabIndex = 0
        '
        'Form_Main
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(261, 89)
        Me.Controls.Add(Me.txtReaderSelected)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCapture)
        Me.Controls.Add(Me.btnReaderSelect)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(277, 127)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(277, 127)
        Me.Name = "Form_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "U.are.U Sample VB.NET"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReaderSelect As System.Windows.Forms.Button
    Friend WithEvents btnCapture As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReaderSelected As System.Windows.Forms.TextBox

End Class
