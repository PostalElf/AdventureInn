<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogAdventure
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogAdventure))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpLoot = New System.Windows.Forms.GroupBox()
        Me.lstLoot = New System.Windows.Forms.ListBox()
        Me.lblLootDescription = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.grpLoot.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 11)
        Me.Label1.MinimumSize = New System.Drawing.Size(475, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(475, 150)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This space intentionally left blank."
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(507, 174)
        Me.Panel1.TabIndex = 1
        '
        'grpLoot
        '
        Me.grpLoot.Controls.Add(Me.lblLootDescription)
        Me.grpLoot.Controls.Add(Me.lstLoot)
        Me.grpLoot.Location = New System.Drawing.Point(12, 192)
        Me.grpLoot.Name = "grpLoot"
        Me.grpLoot.Size = New System.Drawing.Size(452, 153)
        Me.grpLoot.TabIndex = 2
        Me.grpLoot.TabStop = False
        Me.grpLoot.Text = "Loot"
        '
        'lstLoot
        '
        Me.lstLoot.FormattingEnabled = True
        Me.lstLoot.Location = New System.Drawing.Point(10, 19)
        Me.lstLoot.Name = "lstLoot"
        Me.lstLoot.Size = New System.Drawing.Size(254, 121)
        Me.lstLoot.TabIndex = 0
        '
        'lblLootDescription
        '
        Me.lblLootDescription.Location = New System.Drawing.Point(270, 19)
        Me.lblLootDescription.Name = "lblLootDescription"
        Me.lblLootDescription.Size = New System.Drawing.Size(176, 121)
        Me.lblLootDescription.TabIndex = 1
        Me.lblLootDescription.Text = "This space intentionally left blank."
        '
        'btnOK
        '
        Me.btnOK.BackgroundImage = CType(resources.GetObject("btnOK.BackgroundImage"), System.Drawing.Image)
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(470, 295)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(50, 50)
        Me.btnOK.TabIndex = 3
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'DialogAdventure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 357)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpLoot)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogAdventure"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Adventure!"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpLoot.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grpLoot As System.Windows.Forms.GroupBox
    Friend WithEvents lblLootDescription As System.Windows.Forms.Label
    Friend WithEvents lstLoot As System.Windows.Forms.ListBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
