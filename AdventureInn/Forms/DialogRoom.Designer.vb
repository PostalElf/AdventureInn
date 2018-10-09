<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogRoom
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
        Me.components = New System.ComponentModel.Container()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(282, 23)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "lblTitle"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tt
        '
        Me.tt.AutomaticDelay = 10
        Me.tt.AutoPopDelay = 10000
        Me.tt.InitialDelay = 1
        Me.tt.IsBalloon = True
        Me.tt.ReshowDelay = 2
        Me.tt.UseAnimation = False
        Me.tt.UseFading = False
        '
        'ColorDialog1
        '
        Me.ColorDialog1.FullOpen = True
        '
        'lblDescription
        '
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(0, 162)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(282, 100)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Label1"
        '
        'DialogRoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "DialogRoom"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Room View"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents lblDescription As System.Windows.Forms.Label
End Class
