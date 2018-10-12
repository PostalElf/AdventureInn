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
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabFloor = New System.Windows.Forms.TabPage()
        Me.grpRoom = New System.Windows.Forms.GroupBox()
        Me.lblReview = New System.Windows.Forms.Label()
        Me.lstGuests = New System.Windows.Forms.ListBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.pnlRoom = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pnlFloor = New System.Windows.Forms.Panel()
        Me.numFloor = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstRooms = New System.Windows.Forms.ListBox()
        Me.tabInventory = New System.Windows.Forms.TabPage()
        Me.lstInventory = New System.Windows.Forms.ListBox()
        Me.grpInventory = New System.Windows.Forms.GroupBox()
        Me.grpWorkbench = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbWorkbench = New System.Windows.Forms.ComboBox()
        Me.lblWorkbenchDescription = New System.Windows.Forms.Label()
        Me.btnBuild = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabFloor.SuspendLayout()
        Me.grpRoom.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numFloor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tabInventory.SuspendLayout()
        Me.grpInventory.SuspendLayout()
        Me.grpWorkbench.SuspendLayout()
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
        'tabControl1
        '
        Me.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabControl1.Controls.Add(Me.tabFloor)
        Me.tabControl1.Controls.Add(Me.tabInventory)
        Me.tabControl1.Location = New System.Drawing.Point(0, 27)
        Me.tabControl1.Multiline = True
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(536, 528)
        Me.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabControl1.TabIndex = 5
        Me.tabControl1.TabStop = False
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
        Me.grpRoom.Controls.Add(Me.lblReview)
        Me.grpRoom.Controls.Add(Me.lstGuests)
        Me.grpRoom.Controls.Add(Me.lblDescription)
        Me.grpRoom.Controls.Add(Me.pnlRoom)
        Me.grpRoom.Location = New System.Drawing.Point(11, 229)
        Me.grpRoom.Name = "grpRoom"
        Me.grpRoom.Size = New System.Drawing.Size(361, 267)
        Me.grpRoom.TabIndex = 11
        Me.grpRoom.TabStop = False
        Me.grpRoom.Text = "Room Plan"
        '
        'lblReview
        '
        Me.lblReview.Location = New System.Drawing.Point(172, 115)
        Me.lblReview.Name = "lblReview"
        Me.lblReview.Size = New System.Drawing.Size(183, 149)
        Me.lblReview.TabIndex = 14
        '
        'lstGuests
        '
        Me.lstGuests.FormattingEnabled = True
        Me.lstGuests.Location = New System.Drawing.Point(175, 20)
        Me.lstGuests.Name = "lstGuests"
        Me.lstGuests.Size = New System.Drawing.Size(180, 82)
        Me.lstGuests.TabIndex = 13
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(2, 115)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(167, 149)
        Me.lblDescription.TabIndex = 12
        '
        'pnlRoom
        '
        Me.pnlRoom.Location = New System.Drawing.Point(5, 19)
        Me.pnlRoom.Name = "pnlRoom"
        Me.pnlRoom.Size = New System.Drawing.Size(164, 84)
        Me.pnlRoom.TabIndex = 12
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
        'tabInventory
        '
        Me.tabInventory.BackColor = System.Drawing.SystemColors.Window
        Me.tabInventory.Controls.Add(Me.grpWorkbench)
        Me.tabInventory.Controls.Add(Me.grpInventory)
        Me.tabInventory.Location = New System.Drawing.Point(4, 4)
        Me.tabInventory.Name = "tabInventory"
        Me.tabInventory.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInventory.Size = New System.Drawing.Size(528, 502)
        Me.tabInventory.TabIndex = 1
        Me.tabInventory.Text = "Inventory"
        '
        'lstInventory
        '
        Me.lstInventory.FormattingEnabled = True
        Me.lstInventory.Location = New System.Drawing.Point(6, 19)
        Me.lstInventory.Name = "lstInventory"
        Me.lstInventory.Size = New System.Drawing.Size(210, 160)
        Me.lstInventory.TabIndex = 0
        '
        'grpInventory
        '
        Me.grpInventory.Controls.Add(Me.lstInventory)
        Me.grpInventory.Location = New System.Drawing.Point(8, 6)
        Me.grpInventory.Name = "grpInventory"
        Me.grpInventory.Size = New System.Drawing.Size(223, 190)
        Me.grpInventory.TabIndex = 1
        Me.grpInventory.TabStop = False
        Me.grpInventory.Text = "Inventory"
        '
        'grpWorkbench
        '
        Me.grpWorkbench.Controls.Add(Me.btnBuild)
        Me.grpWorkbench.Controls.Add(Me.lblWorkbenchDescription)
        Me.grpWorkbench.Controls.Add(Me.cmbWorkbench)
        Me.grpWorkbench.Controls.Add(Me.Label2)
        Me.grpWorkbench.Location = New System.Drawing.Point(254, 6)
        Me.grpWorkbench.Name = "grpWorkbench"
        Me.grpWorkbench.Size = New System.Drawing.Size(231, 190)
        Me.grpWorkbench.TabIndex = 2
        Me.grpWorkbench.TabStop = False
        Me.grpWorkbench.Text = "Workbench"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Item:"
        '
        'cmbWorkbench
        '
        Me.cmbWorkbench.BackColor = System.Drawing.Color.White
        Me.cmbWorkbench.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWorkbench.FormattingEnabled = True
        Me.cmbWorkbench.Location = New System.Drawing.Point(38, 23)
        Me.cmbWorkbench.Name = "cmbWorkbench"
        Me.cmbWorkbench.Size = New System.Drawing.Size(133, 21)
        Me.cmbWorkbench.TabIndex = 1
        '
        'lblWorkbenchDescription
        '
        Me.lblWorkbenchDescription.Location = New System.Drawing.Point(7, 52)
        Me.lblWorkbenchDescription.Name = "lblWorkbenchDescription"
        Me.lblWorkbenchDescription.Size = New System.Drawing.Size(217, 128)
        Me.lblWorkbenchDescription.TabIndex = 13
        '
        'btnBuild
        '
        Me.btnBuild.Location = New System.Drawing.Point(174, 22)
        Me.btnBuild.Name = "btnBuild"
        Me.btnBuild.Size = New System.Drawing.Size(47, 23)
        Me.btnBuild.TabIndex = 3
        Me.btnBuild.Text = "Build"
        Me.btnBuild.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 556)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "Room"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        Me.tabFloor.ResumeLayout(False)
        Me.grpRoom.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numFloor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.tabInventory.ResumeLayout(False)
        Me.grpInventory.ResumeLayout(False)
        Me.grpWorkbench.ResumeLayout(False)
        Me.grpWorkbench.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabFloor As System.Windows.Forms.TabPage
    Friend WithEvents numFloor As System.Windows.Forms.NumericUpDown
    Friend WithEvents tabInventory As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstRooms As System.Windows.Forms.ListBox
    Friend WithEvents pnlFloor As System.Windows.Forms.Panel
    Friend WithEvents grpRoom As System.Windows.Forms.GroupBox
    Friend WithEvents pnlRoom As System.Windows.Forms.Panel
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lstGuests As System.Windows.Forms.ListBox
    Friend WithEvents lblReview As System.Windows.Forms.Label
    Friend WithEvents grpInventory As System.Windows.Forms.GroupBox
    Friend WithEvents lstInventory As System.Windows.Forms.ListBox
    Friend WithEvents grpWorkbench As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuild As System.Windows.Forms.Button
    Friend WithEvents lblWorkbenchDescription As System.Windows.Forms.Label
    Friend WithEvents cmbWorkbench As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
