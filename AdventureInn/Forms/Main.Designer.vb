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
        Me.tbc = New System.Windows.Forms.TabControl()
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
        Me.grpGold = New System.Windows.Forms.GroupBox()
        Me.lblGold = New System.Windows.Forms.Label()
        Me.grpWorkbench = New System.Windows.Forms.GroupBox()
        Me.btnBuild = New System.Windows.Forms.Button()
        Me.cmbWorkbench = New System.Windows.Forms.ComboBox()
        Me.lblWorkbenchDescription = New System.Windows.Forms.Label()
        Me.grpInventory = New System.Windows.Forms.GroupBox()
        Me.lblInventoryDescription = New System.Windows.Forms.Label()
        Me.btnInventorySort = New System.Windows.Forms.Button()
        Me.lstInventory = New System.Windows.Forms.ListBox()
        Me.tabFood = New System.Windows.Forms.TabPage()
        Me.grpKitchen = New System.Windows.Forms.GroupBox()
        Me.lblKitchen = New System.Windows.Forms.Label()
        Me.btnCook = New System.Windows.Forms.Button()
        Me.cmbKitchen = New System.Windows.Forms.ComboBox()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.cmbIngredient1 = New System.Windows.Forms.ComboBox()
        Me.lblIngredient1 = New System.Windows.Forms.Label()
        Me.lblIngredient2 = New System.Windows.Forms.Label()
        Me.cmbIngredient2 = New System.Windows.Forms.ComboBox()
        Me.lblIngredient3 = New System.Windows.Forms.Label()
        Me.cmbIngredient3 = New System.Windows.Forms.ComboBox()
        Me.lblIngredient4 = New System.Windows.Forms.Label()
        Me.cmbIngredient4 = New System.Windows.Forms.ComboBox()
        Me.lblIngredient5 = New System.Windows.Forms.Label()
        Me.cmbIngredient5 = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1.SuspendLayout()
        Me.tbc.SuspendLayout()
        Me.tabFloor.SuspendLayout()
        Me.grpRoom.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numFloor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tabInventory.SuspendLayout()
        Me.grpGold.SuspendLayout()
        Me.grpWorkbench.SuspendLayout()
        Me.grpInventory.SuspendLayout()
        Me.tabFood.SuspendLayout()
        Me.grpKitchen.SuspendLayout()
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
        'tbc
        '
        Me.tbc.Controls.Add(Me.tabFloor)
        Me.tbc.Controls.Add(Me.tabInventory)
        Me.tbc.Controls.Add(Me.tabFood)
        Me.tbc.Location = New System.Drawing.Point(0, 29)
        Me.tbc.Multiline = True
        Me.tbc.Name = "tbc"
        Me.tbc.SelectedIndex = 0
        Me.tbc.Size = New System.Drawing.Size(536, 544)
        Me.tbc.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tbc.TabIndex = 5
        Me.tbc.TabStop = False
        '
        'tabFloor
        '
        Me.tabFloor.BackColor = System.Drawing.SystemColors.Window
        Me.tabFloor.Controls.Add(Me.grpRoom)
        Me.tabFloor.Controls.Add(Me.GroupBox2)
        Me.tabFloor.Controls.Add(Me.GroupBox1)
        Me.tabFloor.Location = New System.Drawing.Point(4, 22)
        Me.tabFloor.Name = "tabFloor"
        Me.tabFloor.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFloor.Size = New System.Drawing.Size(528, 518)
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
        Me.tabInventory.Controls.Add(Me.grpGold)
        Me.tabInventory.Controls.Add(Me.grpWorkbench)
        Me.tabInventory.Controls.Add(Me.grpInventory)
        Me.tabInventory.Location = New System.Drawing.Point(4, 22)
        Me.tabInventory.Name = "tabInventory"
        Me.tabInventory.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInventory.Size = New System.Drawing.Size(528, 518)
        Me.tabInventory.TabIndex = 1
        Me.tabInventory.Text = "Inventory"
        '
        'grpGold
        '
        Me.grpGold.Controls.Add(Me.lblGold)
        Me.grpGold.Location = New System.Drawing.Point(400, 6)
        Me.grpGold.Name = "grpGold"
        Me.grpGold.Size = New System.Drawing.Size(118, 71)
        Me.grpGold.TabIndex = 3
        Me.grpGold.TabStop = False
        Me.grpGold.Text = "Gold"
        '
        'lblGold
        '
        Me.lblGold.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblGold.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGold.Location = New System.Drawing.Point(8, 23)
        Me.lblGold.Name = "lblGold"
        Me.lblGold.Size = New System.Drawing.Size(99, 33)
        Me.lblGold.TabIndex = 4
        Me.lblGold.Text = "0"
        Me.lblGold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpWorkbench
        '
        Me.grpWorkbench.Controls.Add(Me.btnBuild)
        Me.grpWorkbench.Controls.Add(Me.cmbWorkbench)
        Me.grpWorkbench.Controls.Add(Me.lblWorkbenchDescription)
        Me.grpWorkbench.Location = New System.Drawing.Point(247, 120)
        Me.grpWorkbench.Name = "grpWorkbench"
        Me.grpWorkbench.Size = New System.Drawing.Size(224, 207)
        Me.grpWorkbench.TabIndex = 2
        Me.grpWorkbench.TabStop = False
        Me.grpWorkbench.Text = "Workbench"
        '
        'btnBuild
        '
        Me.btnBuild.Location = New System.Drawing.Point(166, 17)
        Me.btnBuild.Name = "btnBuild"
        Me.btnBuild.Size = New System.Drawing.Size(47, 23)
        Me.btnBuild.TabIndex = 3
        Me.btnBuild.Text = "Build"
        Me.btnBuild.UseVisualStyleBackColor = True
        '
        'cmbWorkbench
        '
        Me.cmbWorkbench.BackColor = System.Drawing.Color.White
        Me.cmbWorkbench.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWorkbench.FormattingEnabled = True
        Me.cmbWorkbench.Location = New System.Drawing.Point(6, 19)
        Me.cmbWorkbench.Name = "cmbWorkbench"
        Me.cmbWorkbench.Size = New System.Drawing.Size(154, 21)
        Me.cmbWorkbench.TabIndex = 1
        '
        'lblWorkbenchDescription
        '
        Me.lblWorkbenchDescription.Location = New System.Drawing.Point(6, 47)
        Me.lblWorkbenchDescription.Name = "lblWorkbenchDescription"
        Me.lblWorkbenchDescription.Size = New System.Drawing.Size(210, 149)
        Me.lblWorkbenchDescription.TabIndex = 13
        '
        'grpInventory
        '
        Me.grpInventory.Controls.Add(Me.lblInventoryDescription)
        Me.grpInventory.Controls.Add(Me.btnInventorySort)
        Me.grpInventory.Controls.Add(Me.lstInventory)
        Me.grpInventory.Location = New System.Drawing.Point(8, 6)
        Me.grpInventory.Name = "grpInventory"
        Me.grpInventory.Size = New System.Drawing.Size(223, 321)
        Me.grpInventory.TabIndex = 1
        Me.grpInventory.TabStop = False
        Me.grpInventory.Text = "Inventory"
        '
        'lblInventoryDescription
        '
        Me.lblInventoryDescription.Location = New System.Drawing.Point(6, 161)
        Me.lblInventoryDescription.Name = "lblInventoryDescription"
        Me.lblInventoryDescription.Size = New System.Drawing.Size(210, 149)
        Me.lblInventoryDescription.TabIndex = 13
        '
        'btnInventorySort
        '
        Me.btnInventorySort.Location = New System.Drawing.Point(162, 131)
        Me.btnInventorySort.Name = "btnInventorySort"
        Me.btnInventorySort.Size = New System.Drawing.Size(54, 23)
        Me.btnInventorySort.TabIndex = 3
        Me.btnInventorySort.Text = "Sort"
        Me.btnInventorySort.UseVisualStyleBackColor = True
        '
        'lstInventory
        '
        Me.lstInventory.FormattingEnabled = True
        Me.lstInventory.Location = New System.Drawing.Point(6, 19)
        Me.lstInventory.Name = "lstInventory"
        Me.lstInventory.Size = New System.Drawing.Size(210, 108)
        Me.lstInventory.TabIndex = 0
        '
        'tabFood
        '
        Me.tabFood.Controls.Add(Me.grpKitchen)
        Me.tabFood.Controls.Add(Me.grpMenu)
        Me.tabFood.Location = New System.Drawing.Point(4, 22)
        Me.tabFood.Name = "tabFood"
        Me.tabFood.Size = New System.Drawing.Size(528, 518)
        Me.tabFood.TabIndex = 2
        Me.tabFood.Text = "Food"
        Me.tabFood.UseVisualStyleBackColor = True
        '
        'grpKitchen
        '
        Me.grpKitchen.Controls.Add(Me.lblIngredient5)
        Me.grpKitchen.Controls.Add(Me.cmbIngredient5)
        Me.grpKitchen.Controls.Add(Me.lblIngredient4)
        Me.grpKitchen.Controls.Add(Me.cmbIngredient4)
        Me.grpKitchen.Controls.Add(Me.lblIngredient3)
        Me.grpKitchen.Controls.Add(Me.cmbIngredient3)
        Me.grpKitchen.Controls.Add(Me.lblIngredient2)
        Me.grpKitchen.Controls.Add(Me.cmbIngredient2)
        Me.grpKitchen.Controls.Add(Me.lblIngredient1)
        Me.grpKitchen.Controls.Add(Me.cmbIngredient1)
        Me.grpKitchen.Controls.Add(Me.lblKitchen)
        Me.grpKitchen.Controls.Add(Me.btnCook)
        Me.grpKitchen.Controls.Add(Me.cmbKitchen)
        Me.grpKitchen.Location = New System.Drawing.Point(8, 292)
        Me.grpKitchen.Name = "grpKitchen"
        Me.grpKitchen.Size = New System.Drawing.Size(510, 210)
        Me.grpKitchen.TabIndex = 1
        Me.grpKitchen.TabStop = False
        Me.grpKitchen.Text = "Kitchen"
        '
        'lblKitchen
        '
        Me.lblKitchen.Location = New System.Drawing.Point(11, 51)
        Me.lblKitchen.Name = "lblKitchen"
        Me.lblKitchen.Size = New System.Drawing.Size(210, 149)
        Me.lblKitchen.TabIndex = 14
        '
        'btnCook
        '
        Me.btnCook.Location = New System.Drawing.Point(447, 168)
        Me.btnCook.Name = "btnCook"
        Me.btnCook.Size = New System.Drawing.Size(47, 23)
        Me.btnCook.TabIndex = 4
        Me.btnCook.Text = "Cook"
        Me.btnCook.UseVisualStyleBackColor = True
        '
        'cmbKitchen
        '
        Me.cmbKitchen.BackColor = System.Drawing.Color.White
        Me.cmbKitchen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKitchen.FormattingEnabled = True
        Me.cmbKitchen.Location = New System.Drawing.Point(6, 19)
        Me.cmbKitchen.Name = "cmbKitchen"
        Me.cmbKitchen.Size = New System.Drawing.Size(215, 21)
        Me.cmbKitchen.TabIndex = 2
        '
        'grpMenu
        '
        Me.grpMenu.Location = New System.Drawing.Point(8, 3)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(510, 283)
        Me.grpMenu.TabIndex = 0
        Me.grpMenu.TabStop = False
        Me.grpMenu.Text = "Today's Menu"
        '
        'cmbIngredient1
        '
        Me.cmbIngredient1.BackColor = System.Drawing.Color.White
        Me.cmbIngredient1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIngredient1.FormattingEnabled = True
        Me.cmbIngredient1.Location = New System.Drawing.Point(335, 21)
        Me.cmbIngredient1.Name = "cmbIngredient1"
        Me.cmbIngredient1.Size = New System.Drawing.Size(159, 21)
        Me.cmbIngredient1.TabIndex = 15
        '
        'lblIngredient1
        '
        Me.lblIngredient1.Location = New System.Drawing.Point(234, 24)
        Me.lblIngredient1.Name = "lblIngredient1"
        Me.lblIngredient1.Size = New System.Drawing.Size(95, 16)
        Me.lblIngredient1.TabIndex = 16
        Me.lblIngredient1.Text = "Ingredient:"
        Me.lblIngredient1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblIngredient2
        '
        Me.lblIngredient2.Location = New System.Drawing.Point(234, 54)
        Me.lblIngredient2.Name = "lblIngredient2"
        Me.lblIngredient2.Size = New System.Drawing.Size(95, 16)
        Me.lblIngredient2.TabIndex = 18
        Me.lblIngredient2.Text = "Ingredient:"
        Me.lblIngredient2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbIngredient2
        '
        Me.cmbIngredient2.BackColor = System.Drawing.Color.White
        Me.cmbIngredient2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIngredient2.FormattingEnabled = True
        Me.cmbIngredient2.Location = New System.Drawing.Point(335, 51)
        Me.cmbIngredient2.Name = "cmbIngredient2"
        Me.cmbIngredient2.Size = New System.Drawing.Size(159, 21)
        Me.cmbIngredient2.TabIndex = 17
        '
        'lblIngredient3
        '
        Me.lblIngredient3.Location = New System.Drawing.Point(234, 81)
        Me.lblIngredient3.Name = "lblIngredient3"
        Me.lblIngredient3.Size = New System.Drawing.Size(95, 16)
        Me.lblIngredient3.TabIndex = 20
        Me.lblIngredient3.Text = "Ingredient:"
        Me.lblIngredient3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbIngredient3
        '
        Me.cmbIngredient3.BackColor = System.Drawing.Color.White
        Me.cmbIngredient3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIngredient3.FormattingEnabled = True
        Me.cmbIngredient3.Location = New System.Drawing.Point(335, 78)
        Me.cmbIngredient3.Name = "cmbIngredient3"
        Me.cmbIngredient3.Size = New System.Drawing.Size(159, 21)
        Me.cmbIngredient3.TabIndex = 19
        '
        'lblIngredient4
        '
        Me.lblIngredient4.Location = New System.Drawing.Point(234, 108)
        Me.lblIngredient4.Name = "lblIngredient4"
        Me.lblIngredient4.Size = New System.Drawing.Size(95, 16)
        Me.lblIngredient4.TabIndex = 22
        Me.lblIngredient4.Text = "Ingredient:"
        Me.lblIngredient4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbIngredient4
        '
        Me.cmbIngredient4.BackColor = System.Drawing.Color.White
        Me.cmbIngredient4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIngredient4.FormattingEnabled = True
        Me.cmbIngredient4.Location = New System.Drawing.Point(335, 105)
        Me.cmbIngredient4.Name = "cmbIngredient4"
        Me.cmbIngredient4.Size = New System.Drawing.Size(159, 21)
        Me.cmbIngredient4.TabIndex = 21
        '
        'lblIngredient5
        '
        Me.lblIngredient5.Location = New System.Drawing.Point(234, 135)
        Me.lblIngredient5.Name = "lblIngredient5"
        Me.lblIngredient5.Size = New System.Drawing.Size(95, 16)
        Me.lblIngredient5.TabIndex = 24
        Me.lblIngredient5.Text = "Ingredient:"
        Me.lblIngredient5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbIngredient5
        '
        Me.cmbIngredient5.BackColor = System.Drawing.Color.White
        Me.cmbIngredient5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIngredient5.FormattingEnabled = True
        Me.cmbIngredient5.Location = New System.Drawing.Point(335, 132)
        Me.cmbIngredient5.Name = "cmbIngredient5"
        Me.cmbIngredient5.Size = New System.Drawing.Size(159, 21)
        Me.cmbIngredient5.TabIndex = 23
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 580)
        Me.Controls.Add(Me.tbc)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "Room"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tbc.ResumeLayout(False)
        Me.tabFloor.ResumeLayout(False)
        Me.grpRoom.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numFloor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.tabInventory.ResumeLayout(False)
        Me.grpGold.ResumeLayout(False)
        Me.grpWorkbench.ResumeLayout(False)
        Me.grpInventory.ResumeLayout(False)
        Me.tabFood.ResumeLayout(False)
        Me.grpKitchen.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbc As System.Windows.Forms.TabControl
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
    Friend WithEvents cmbWorkbench As System.Windows.Forms.ComboBox
    Friend WithEvents btnInventorySort As System.Windows.Forms.Button
    Friend WithEvents grpGold As System.Windows.Forms.GroupBox
    Friend WithEvents lblGold As System.Windows.Forms.Label
    Friend WithEvents lblInventoryDescription As System.Windows.Forms.Label
    Friend WithEvents lblWorkbenchDescription As System.Windows.Forms.Label
    Friend WithEvents tabFood As System.Windows.Forms.TabPage
    Friend WithEvents grpMenu As System.Windows.Forms.GroupBox
    Friend WithEvents grpKitchen As System.Windows.Forms.GroupBox
    Friend WithEvents btnCook As System.Windows.Forms.Button
    Friend WithEvents cmbKitchen As System.Windows.Forms.ComboBox
    Friend WithEvents lblKitchen As System.Windows.Forms.Label
    Friend WithEvents lblIngredient5 As System.Windows.Forms.Label
    Friend WithEvents cmbIngredient5 As System.Windows.Forms.ComboBox
    Friend WithEvents lblIngredient4 As System.Windows.Forms.Label
    Friend WithEvents cmbIngredient4 As System.Windows.Forms.ComboBox
    Friend WithEvents lblIngredient3 As System.Windows.Forms.Label
    Friend WithEvents cmbIngredient3 As System.Windows.Forms.ComboBox
    Friend WithEvents lblIngredient2 As System.Windows.Forms.Label
    Friend WithEvents cmbIngredient2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblIngredient1 As System.Windows.Forms.Label
    Friend WithEvents cmbIngredient1 As System.Windows.Forms.ComboBox

End Class
