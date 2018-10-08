<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlFloor = New System.Windows.Forms.Panel()
        Me.numFloor = New System.Windows.Forms.NumericUpDown()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.numFloor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Floor:"
        '
        'pnlFloor
        '
        Me.pnlFloor.Location = New System.Drawing.Point(14, 45)
        Me.pnlFloor.Name = "pnlFloor"
        Me.pnlFloor.Size = New System.Drawing.Size(204, 204)
        Me.pnlFloor.TabIndex = 2
        '
        'numFloor
        '
        Me.numFloor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numFloor.Location = New System.Drawing.Point(172, 12)
        Me.numFloor.Name = "numFloor"
        Me.numFloor.Size = New System.Drawing.Size(46, 20)
        Me.numFloor.TabIndex = 3
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
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(237, 269)
        Me.Controls.Add(Me.numFloor)
        Me.Controls.Add(Me.pnlFloor)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "Room"
        CType(Me.numFloor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlFloor As System.Windows.Forms.Panel
    Friend WithEvents numFloor As System.Windows.Forms.NumericUpDown
    Friend WithEvents tt As System.Windows.Forms.ToolTip

End Class
