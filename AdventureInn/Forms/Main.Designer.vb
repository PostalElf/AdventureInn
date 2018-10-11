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
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabFloor = New System.Windows.Forms.TabPage()
        Me.grpRoom = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pnlFloor = New System.Windows.Forms.Panel()
        Me.numFloor = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstRooms = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pnlRoom = New System.Windows.Forms.Panel()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabFloor.SuspendLayout()
        Me.grpRoom.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numFloor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(85, 191)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Floor:"
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(534, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.tabFloor)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 27)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(536, 528)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 5
        Me.TabControl1.TabStop = False
        '
        'tabFloor
        '
        Me.tabFloor.BackColor = System.Drawing.SystemColors.Window
        Me.tabFloor.Controls.Add(Me.grpRoom)
        Me.tabFloor.Controls.Add(Me.GroupBox2)
        Me.tabFloor.Controls.Add(Me.GroupBox1)
        Me.tabFloor.Location = New System.Drawing.Point(4, 4)
        Me.tabFloor.Name = "tabFloor"
        Me.tabFloor.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFloor.Size = New System.Drawing.Size(528, 502)
        Me.tabFloor.TabIndex = 0
        Me.tabFloor.Text = "Floor"
        '
        'grpRoom
        '
        Me.grpRoom.Controls.Add(Me.lblDescription)
        Me.grpRoom.Controls.Add(Me.pnlRoom)
        Me.grpRoom.Location = New System.Drawing.Point(11, 244)
        Me.grpRoom.Name = "grpRoom"
        Me.grpRoom.Size = New System.Drawing.Size(174, 236)
        Me.grpRoom.TabIndex = 11
        Me.grpRoom.TabStop = False
        Me.grpRoom.Text = "Room Plan"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pnlFloor)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.numFloor)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(177, 218)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Floorplan"
        '
        'pnlFloor
        '
        Me.pnlFloor.Location = New System.Drawing.Point(6, 19)
        Me.pnlFloor.Name = "pnlFloor"
        Me.pnlFloor.Size = New System.Drawing.Size(164, 164)
        Me.pnlFloor.TabIndex = 6
        '
        'numFloor
        '
        Me.numFloor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numFloor.Location = New System.Drawing.Point(124, 189)
        Me.numFloor.Name = "numFloor"
        Me.numFloor.Size = New System.Drawing.Size(46, 20)
        Me.numFloor.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstRooms)
        Me.GroupBox1.Location = New System.Drawing.Point(210, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(247, 185)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rooms"
        '
        'lstRooms
        '
        Me.lstRooms.BackColor = System.Drawing.Color.White
        Me.lstRooms.FormattingEnabled = True
        Me.lstRooms.Location = New System.Drawing.Point(6, 19)
        Me.lstRooms.Name = "lstRooms"
        Me.lstRooms.Size = New System.Drawing.Size(235, 160)
        Me.lstRooms.TabIndex = 8
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(528, 502)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'pnlRoom
        '
        Me.pnlRoom.Location = New System.Drawing.Point(5, 19)
        Me.pnlRoom.Name = "pnlRoom"
        Me.pnlRoom.Size = New System.Drawing.Size(164, 84)
        Me.pnlRoom.TabIndex = 12
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(5, 108)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(164, 118)
        Me.lblDescription.TabIndex = 12
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 556)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "Room"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabFloor.ResumeLayout(False)
        Me.grpRoom.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numFloor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabFloor As System.Windows.Forms.TabPage
    Friend WithEvents numFloor As System.Windows.Forms.NumericUpDown
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstRooms As System.Windows.Forms.ListBox
    Friend WithEvents pnlFloor As System.Windows.Forms.Panel
    Friend WithEvents grpRoom As System.Windows.Forms.GroupBox
    Friend WithEvents pnlRoom As System.Windows.Forms.Panel
    Friend WithEvents lblDescription As System.Windows.Forms.Label

End Class
