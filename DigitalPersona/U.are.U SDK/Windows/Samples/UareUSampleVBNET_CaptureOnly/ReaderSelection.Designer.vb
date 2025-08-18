<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReaderSelect
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
        Me.lblSelectReader = New System.Windows.Forms.Label
        Me.cboReaders = New System.Windows.Forms.ComboBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnCaps = New System.Windows.Forms.Button
        Me.btnSelect = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblSelectReader
        '
        Me.lblSelectReader.Location = New System.Drawing.Point(12, 9)
        Me.lblSelectReader.Name = "lblSelectReader"
        Me.lblSelectReader.Size = New System.Drawing.Size(296, 13)
        Me.lblSelectReader.Text = "Select Reader:"
        '
        'cboReaders
        '
        Me.cboReaders.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.cboReaders.Location = New System.Drawing.Point(12, 25)
        Me.cboReaders.Name = "cboReaders"
        Me.cboReaders.Size = New System.Drawing.Size(256, 20)
        Me.cboReaders.TabIndex = 8
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(22, 52)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(115, 23)
        Me.btnRefresh.TabIndex = 9
        Me.btnRefresh.Text = "Refresh List"
        '
        'btnCaps
        '
        Me.btnCaps.Enabled = False
        Me.btnCaps.Location = New System.Drawing.Point(143, 52)
        Me.btnCaps.Name = "btnCaps"
        Me.btnCaps.Size = New System.Drawing.Size(115, 23)
        Me.btnCaps.TabIndex = 10
        Me.btnCaps.Text = "Capabilities"
        '
        'btnSelect
        '
        Me.btnSelect.Enabled = False
        Me.btnSelect.Location = New System.Drawing.Point(22, 81)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(115, 23)
        Me.btnSelect.TabIndex = 11
        Me.btnSelect.Text = "Select"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(143, 81)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(115, 23)
        Me.btnBack.TabIndex = 12
        Me.btnBack.Text = "Back"
        '
        'ReaderSelect
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(292, 109)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnCaps)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.cboReaders)
        Me.Controls.Add(Me.lblSelectReader)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
#If Not WindowsCE Then
        Me.MaximumSize = New System.Drawing.Size(312, 159)
        Me.MinimumSize = New System.Drawing.Size(312, 159)
        Me.ClientSize = New System.Drawing.Size(312, 159)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
#End If
        Me.Name = "Select Reader"
        Me.Text = "Select Reader"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSelectReader As System.Windows.Forms.Label
    Friend WithEvents cboReaders As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnCaps As System.Windows.Forms.Button
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
