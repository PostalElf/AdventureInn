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
        Me.lblFloor = New System.Windows.Forms.Label()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbc = New System.Windows.Forms.TabControl()
        Me.tabFloor = New System.Windows.Forms.TabPage()
        Me.grpGuestsWaiting = New System.Windows.Forms.GroupBox()
        Me.btnGuestSortRace = New System.Windows.Forms.Button()
        Me.btnGuestSortJob = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuestSortName = New System.Windows.Forms.Button()
        Me.lstGuestsWaiting = New System.Windows.Forms.ListBox()
        Me.btnWaitingToRoom = New System.Windows.Forms.Button()
        Me.grpRoom = New System.Windows.Forms.GroupBox()
        Me.lblGuests = New System.Windows.Forms.Label()
        Me.btnRoomToWaiting = New System.Windows.Forms.Button()
        Me.lstGuestsRoomed = New System.Windows.Forms.ListBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.pnlRoom = New System.Windows.Forms.Panel()
        Me.grpFloorplan = New System.Windows.Forms.GroupBox()
        Me.pnlFloor = New System.Windows.Forms.Panel()
        Me.numFloor = New System.Windows.Forms.NumericUpDown()
        Me.tabFood = New System.Windows.Forms.TabPage()
        Me.grpFood = New System.Windows.Forms.GroupBox()
        Me.btnMenuToFood = New System.Windows.Forms.Button()
        Me.btnFoodToMenu = New System.Windows.Forms.Button()
        Me.lstFood = New System.Windows.Forms.ListBox()
        Me.lstFoodIngredients = New System.Windows.Forms.ListBox()
        Me.grpKitchen = New System.Windows.Forms.GroupBox()
        Me.pnlIngredients = New System.Windows.Forms.Panel()
        Me.txtIngredient5 = New System.Windows.Forms.Label()
        Me.txtIngredient4 = New System.Windows.Forms.Label()
        Me.txtIngredient3 = New System.Windows.Forms.Label()
        Me.txtIngredient2 = New System.Windows.Forms.Label()
        Me.txtIngredient1 = New System.Windows.Forms.Label()
        Me.lblIngredient5 = New System.Windows.Forms.Label()
        Me.lblIngredient4 = New System.Windows.Forms.Label()
        Me.lblIngredient3 = New System.Windows.Forms.Label()
        Me.lblIngredient2 = New System.Windows.Forms.Label()
        Me.lblIngredient1 = New System.Windows.Forms.Label()
        Me.btnCookReset = New System.Windows.Forms.Button()
        Me.lblKitchen = New System.Windows.Forms.Label()
        Me.btnCook = New System.Windows.Forms.Button()
        Me.cmbKitchen = New System.Windows.Forms.ComboBox()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
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
        Me.tabGuests = New System.Windows.Forms.TabPage()
        Me.MenuStrip1.SuspendLayout()
        Me.tbc.SuspendLayout()
        Me.tabFloor.SuspendLayout()
        Me.grpGuestsWaiting.SuspendLayout()
        Me.grpRoom.SuspendLayout()
        Me.grpFloorplan.SuspendLayout()
        CType(Me.numFloor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabFood.SuspendLayout()
        Me.grpFood.SuspendLayout()
        Me.grpKitchen.SuspendLayout()
        Me.pnlIngredients.SuspendLayout()
        Me.tabInventory.SuspendLayout()
        Me.grpGold.SuspendLayout()
        Me.grpWorkbench.SuspendLayout()
        Me.grpInventory.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFloor
        '
        Me.lblFloor.AutoSize = True
        Me.lblFloor.Location = New System.Drawing.Point(85, 191)
        Me.lblFloor.Name = "lblFloor"
        Me.lblFloor.Size = New System.Drawing.Size(33, 13)
        Me.lblFloor.TabIndex = 1
        Me.lblFloor.Text = "Floor:"
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
        Me.tbc.Controls.Add(Me.tabFood)
        Me.tbc.Controls.Add(Me.tabInventory)
        Me.tbc.Controls.Add(Me.tabGuests)
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
        Me.tabFloor.Controls.Add(Me.grpGuestsWaiting)
        Me.tabFloor.Controls.Add(Me.grpRoom)
        Me.tabFloor.Controls.Add(Me.grpFloorplan)
        Me.tabFloor.Location = New System.Drawing.Point(4, 22)
        Me.tabFloor.Name = "tabFloor"
        Me.tabFloor.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFloor.Size = New System.Drawing.Size(528, 518)
        Me.tabFloor.TabIndex = 0
        Me.tabFloor.Text = "Floor"
        '
        'grpGuestsWaiting
        '
        Me.grpGuestsWaiting.Controls.Add(Me.btnGuestSortRace)
        Me.grpGuestsWaiting.Controls.Add(Me.btnGuestSortJob)
        Me.grpGuestsWaiting.Controls.Add(Me.Label1)
        Me.grpGuestsWaiting.Controls.Add(Me.btnGuestSortName)
        Me.grpGuestsWaiting.Controls.Add(Me.lstGuestsWaiting)
        Me.grpGuestsWaiting.Controls.Add(Me.btnWaitingToRoom)
        Me.grpGuestsWaiting.Location = New System.Drawing.Point(8, 230)
        Me.grpGuestsWaiting.Name = "grpGuestsWaiting"
        Me.grpGuestsWaiting.Size = New System.Drawing.Size(260, 268)
        Me.grpGuestsWaiting.TabIndex = 18
        Me.grpGuestsWaiting.TabStop = False
        Me.grpGuestsWaiting.Text = "Guests Waiting"
        '
        'btnGuestSortRace
        '
        Me.btnGuestSortRace.Location = New System.Drawing.Point(183, 134)
        Me.btnGuestSortRace.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.btnGuestSortRace.Name = "btnGuestSortRace"
        Me.btnGuestSortRace.Size = New System.Drawing.Size(70, 23)
        Me.btnGuestSortRace.TabIndex = 21
        Me.btnGuestSortRace.Text = "Race"
        Me.btnGuestSortRace.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuestSortRace.UseVisualStyleBackColor = True
        '
        'btnGuestSortJob
        '
        Me.btnGuestSortJob.Location = New System.Drawing.Point(183, 108)
        Me.btnGuestSortJob.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.btnGuestSortJob.Name = "btnGuestSortJob"
        Me.btnGuestSortJob.Size = New System.Drawing.Size(70, 23)
        Me.btnGuestSortJob.TabIndex = 20
        Me.btnGuestSortJob.Text = "Job"
        Me.btnGuestSortJob.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuestSortJob.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Sort by..."
        '
        'btnGuestSortName
        '
        Me.btnGuestSortName.Location = New System.Drawing.Point(183, 82)
        Me.btnGuestSortName.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.btnGuestSortName.Name = "btnGuestSortName"
        Me.btnGuestSortName.Size = New System.Drawing.Size(70, 23)
        Me.btnGuestSortName.TabIndex = 17
        Me.btnGuestSortName.Text = "Name"
        Me.btnGuestSortName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuestSortName.UseVisualStyleBackColor = True
        '
        'lstGuestsWaiting
        '
        Me.lstGuestsWaiting.FormattingEnabled = True
        Me.lstGuestsWaiting.Location = New System.Drawing.Point(6, 19)
        Me.lstGuestsWaiting.Name = "lstGuestsWaiting"
        Me.lstGuestsWaiting.Size = New System.Drawing.Size(172, 238)
        Me.lstGuestsWaiting.TabIndex = 15
        '
        'btnWaitingToRoom
        '
        Me.btnWaitingToRoom.Location = New System.Drawing.Point(183, 19)
        Me.btnWaitingToRoom.Margin = New System.Windows.Forms.Padding(0)
        Me.btnWaitingToRoom.Name = "btnWaitingToRoom"
        Me.btnWaitingToRoom.Size = New System.Drawing.Size(70, 23)
        Me.btnWaitingToRoom.TabIndex = 16
        Me.btnWaitingToRoom.Text = "Room"
        Me.btnWaitingToRoom.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWaitingToRoom.UseVisualStyleBackColor = True
        '
        'grpRoom
        '
        Me.grpRoom.Controls.Add(Me.lblGuests)
        Me.grpRoom.Controls.Add(Me.btnRoomToWaiting)
        Me.grpRoom.Controls.Add(Me.lstGuestsRoomed)
        Me.grpRoom.Controls.Add(Me.lblDescription)
        Me.grpRoom.Controls.Add(Me.pnlRoom)
        Me.grpRoom.Location = New System.Drawing.Point(191, 6)
        Me.grpRoom.Name = "grpRoom"
        Me.grpRoom.Size = New System.Drawing.Size(315, 218)
        Me.grpRoom.TabIndex = 11
        Me.grpRoom.TabStop = False
        Me.grpRoom.Text = "Room Plan"
        '
        'lblGuests
        '
        Me.lblGuests.AutoSize = True
        Me.lblGuests.Location = New System.Drawing.Point(6, 88)
        Me.lblGuests.Name = "lblGuests"
        Me.lblGuests.Size = New System.Drawing.Size(43, 13)
        Me.lblGuests.TabIndex = 18
        Me.lblGuests.Text = "Guests:"
        '
        'btnRoomToWaiting
        '
        Me.btnRoomToWaiting.Location = New System.Drawing.Point(112, 189)
        Me.btnRoomToWaiting.Name = "btnRoomToWaiting"
        Me.btnRoomToWaiting.Size = New System.Drawing.Size(64, 23)
        Me.btnRoomToWaiting.TabIndex = 17
        Me.btnRoomToWaiting.Text = "Unroom"
        Me.btnRoomToWaiting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRoomToWaiting.UseVisualStyleBackColor = True
        '
        'lstGuestsRoomed
        '
        Me.lstGuestsRoomed.FormattingEnabled = True
        Me.lstGuestsRoomed.Location = New System.Drawing.Point(4, 104)
        Me.lstGuestsRoomed.Name = "lstGuestsRoomed"
        Me.lstGuestsRoomed.Size = New System.Drawing.Size(172, 82)
        Me.lstGuestsRoomed.TabIndex = 18
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(184, 16)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(123, 193)
        Me.lblDescription.TabIndex = 12
        '
        'pnlRoom
        '
        Me.pnlRoom.Location = New System.Drawing.Point(5, 19)
        Me.pnlRoom.Name = "pnlRoom"
        Me.pnlRoom.Size = New System.Drawing.Size(124, 64)
        Me.pnlRoom.TabIndex = 12
        '
        'grpFloorplan
        '
        Me.grpFloorplan.Controls.Add(Me.pnlFloor)
        Me.grpFloorplan.Controls.Add(Me.lblFloor)
        Me.grpFloorplan.Controls.Add(Me.numFloor)
        Me.grpFloorplan.Location = New System.Drawing.Point(8, 6)
        Me.grpFloorplan.Name = "grpFloorplan"
        Me.grpFloorplan.Size = New System.Drawing.Size(177, 218)
        Me.grpFloorplan.TabIndex = 10
        Me.grpFloorplan.TabStop = False
        Me.grpFloorplan.Text = "Floorplan"
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
        'tabFood
        '
        Me.tabFood.Controls.Add(Me.grpFood)
        Me.tabFood.Controls.Add(Me.grpKitchen)
        Me.tabFood.Controls.Add(Me.grpMenu)
        Me.tabFood.Location = New System.Drawing.Point(4, 22)
        Me.tabFood.Name = "tabFood"
        Me.tabFood.Size = New System.Drawing.Size(528, 518)
        Me.tabFood.TabIndex = 2
        Me.tabFood.Text = "Food"
        Me.tabFood.UseVisualStyleBackColor = True
        '
        'grpFood
        '
        Me.grpFood.Controls.Add(Me.btnMenuToFood)
        Me.grpFood.Controls.Add(Me.btnFoodToMenu)
        Me.grpFood.Controls.Add(Me.lstFood)
        Me.grpFood.Controls.Add(Me.lstFoodIngredients)
        Me.grpFood.Location = New System.Drawing.Point(265, 14)
        Me.grpFood.Name = "grpFood"
        Me.grpFood.Size = New System.Drawing.Size(253, 272)
        Me.grpFood.TabIndex = 2
        Me.grpFood.TabStop = False
        Me.grpFood.Text = "Inventory"
        '
        'btnMenuToFood
        '
        Me.btnMenuToFood.Location = New System.Drawing.Point(9, 206)
        Me.btnMenuToFood.Name = "btnMenuToFood"
        Me.btnMenuToFood.Size = New System.Drawing.Size(26, 23)
        Me.btnMenuToFood.TabIndex = 19
        Me.btnMenuToFood.Text = "->"
        Me.btnMenuToFood.UseVisualStyleBackColor = True
        '
        'btnFoodToMenu
        '
        Me.btnFoodToMenu.Location = New System.Drawing.Point(9, 177)
        Me.btnFoodToMenu.Name = "btnFoodToMenu"
        Me.btnFoodToMenu.Size = New System.Drawing.Size(26, 23)
        Me.btnFoodToMenu.TabIndex = 18
        Me.btnFoodToMenu.Text = "<-"
        Me.btnFoodToMenu.UseVisualStyleBackColor = True
        '
        'lstFood
        '
        Me.lstFood.FormattingEnabled = True
        Me.lstFood.Location = New System.Drawing.Point(43, 145)
        Me.lstFood.Name = "lstFood"
        Me.lstFood.Size = New System.Drawing.Size(204, 121)
        Me.lstFood.TabIndex = 2
        '
        'lstFoodIngredients
        '
        Me.lstFoodIngredients.FormattingEnabled = True
        Me.lstFoodIngredients.Location = New System.Drawing.Point(6, 19)
        Me.lstFoodIngredients.Name = "lstFoodIngredients"
        Me.lstFoodIngredients.Size = New System.Drawing.Size(241, 121)
        Me.lstFoodIngredients.TabIndex = 1
        '
        'grpKitchen
        '
        Me.grpKitchen.Controls.Add(Me.pnlIngredients)
        Me.grpKitchen.Controls.Add(Me.btnCookReset)
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
        'pnlIngredients
        '
        Me.pnlIngredients.Controls.Add(Me.txtIngredient5)
        Me.pnlIngredients.Controls.Add(Me.txtIngredient4)
        Me.pnlIngredients.Controls.Add(Me.txtIngredient3)
        Me.pnlIngredients.Controls.Add(Me.txtIngredient2)
        Me.pnlIngredients.Controls.Add(Me.txtIngredient1)
        Me.pnlIngredients.Controls.Add(Me.lblIngredient5)
        Me.pnlIngredients.Controls.Add(Me.lblIngredient4)
        Me.pnlIngredients.Controls.Add(Me.lblIngredient3)
        Me.pnlIngredients.Controls.Add(Me.lblIngredient2)
        Me.pnlIngredients.Controls.Add(Me.lblIngredient1)
        Me.pnlIngredients.Location = New System.Drawing.Point(235, 16)
        Me.pnlIngredients.Name = "pnlIngredients"
        Me.pnlIngredients.Size = New System.Drawing.Size(266, 139)
        Me.pnlIngredients.TabIndex = 26
        '
        'txtIngredient5
        '
        Me.txtIngredient5.BackColor = System.Drawing.Color.Silver
        Me.txtIngredient5.Location = New System.Drawing.Point(113, 113)
        Me.txtIngredient5.Name = "txtIngredient5"
        Me.txtIngredient5.Size = New System.Drawing.Size(146, 16)
        Me.txtIngredient5.TabIndex = 30
        Me.txtIngredient5.Text = "-"
        '
        'txtIngredient4
        '
        Me.txtIngredient4.BackColor = System.Drawing.Color.Silver
        Me.txtIngredient4.Location = New System.Drawing.Point(113, 87)
        Me.txtIngredient4.Name = "txtIngredient4"
        Me.txtIngredient4.Size = New System.Drawing.Size(146, 16)
        Me.txtIngredient4.TabIndex = 29
        Me.txtIngredient4.Text = "-"
        '
        'txtIngredient3
        '
        Me.txtIngredient3.BackColor = System.Drawing.Color.Silver
        Me.txtIngredient3.Location = New System.Drawing.Point(113, 61)
        Me.txtIngredient3.Name = "txtIngredient3"
        Me.txtIngredient3.Size = New System.Drawing.Size(146, 16)
        Me.txtIngredient3.TabIndex = 28
        Me.txtIngredient3.Text = "-"
        '
        'txtIngredient2
        '
        Me.txtIngredient2.BackColor = System.Drawing.Color.Silver
        Me.txtIngredient2.Location = New System.Drawing.Point(113, 35)
        Me.txtIngredient2.Name = "txtIngredient2"
        Me.txtIngredient2.Size = New System.Drawing.Size(146, 16)
        Me.txtIngredient2.TabIndex = 27
        Me.txtIngredient2.Text = "-"
        '
        'txtIngredient1
        '
        Me.txtIngredient1.BackColor = System.Drawing.Color.Silver
        Me.txtIngredient1.Location = New System.Drawing.Point(113, 9)
        Me.txtIngredient1.Name = "txtIngredient1"
        Me.txtIngredient1.Size = New System.Drawing.Size(146, 16)
        Me.txtIngredient1.TabIndex = 26
        Me.txtIngredient1.Text = "-"
        '
        'lblIngredient5
        '
        Me.lblIngredient5.Location = New System.Drawing.Point(19, 113)
        Me.lblIngredient5.Name = "lblIngredient5"
        Me.lblIngredient5.Size = New System.Drawing.Size(88, 16)
        Me.lblIngredient5.TabIndex = 25
        Me.lblIngredient5.Text = "Ingredient:"
        Me.lblIngredient5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblIngredient4
        '
        Me.lblIngredient4.Location = New System.Drawing.Point(19, 87)
        Me.lblIngredient4.Name = "lblIngredient4"
        Me.lblIngredient4.Size = New System.Drawing.Size(88, 16)
        Me.lblIngredient4.TabIndex = 23
        Me.lblIngredient4.Text = "Ingredient:"
        Me.lblIngredient4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblIngredient3
        '
        Me.lblIngredient3.Location = New System.Drawing.Point(19, 61)
        Me.lblIngredient3.Name = "lblIngredient3"
        Me.lblIngredient3.Size = New System.Drawing.Size(88, 16)
        Me.lblIngredient3.TabIndex = 21
        Me.lblIngredient3.Text = "Ingredient:"
        Me.lblIngredient3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblIngredient2
        '
        Me.lblIngredient2.Location = New System.Drawing.Point(19, 35)
        Me.lblIngredient2.Name = "lblIngredient2"
        Me.lblIngredient2.Size = New System.Drawing.Size(88, 16)
        Me.lblIngredient2.TabIndex = 19
        Me.lblIngredient2.Text = "Ingredient:"
        Me.lblIngredient2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblIngredient1
        '
        Me.lblIngredient1.Location = New System.Drawing.Point(19, 9)
        Me.lblIngredient1.Name = "lblIngredient1"
        Me.lblIngredient1.Size = New System.Drawing.Size(88, 16)
        Me.lblIngredient1.TabIndex = 17
        Me.lblIngredient1.Text = "Ingredient:"
        Me.lblIngredient1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnCookReset
        '
        Me.btnCookReset.Location = New System.Drawing.Point(394, 173)
        Me.btnCookReset.Name = "btnCookReset"
        Me.btnCookReset.Size = New System.Drawing.Size(47, 23)
        Me.btnCookReset.TabIndex = 15
        Me.btnCookReset.Text = "Reset"
        Me.btnCookReset.UseVisualStyleBackColor = True
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
        Me.btnCook.Location = New System.Drawing.Point(447, 173)
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
        Me.grpMenu.Location = New System.Drawing.Point(8, 14)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(247, 272)
        Me.grpMenu.TabIndex = 0
        Me.grpMenu.TabStop = False
        Me.grpMenu.Text = "Today's Menu"
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
        'tabGuests
        '
        Me.tabGuests.Location = New System.Drawing.Point(4, 22)
        Me.tabGuests.Name = "tabGuests"
        Me.tabGuests.Size = New System.Drawing.Size(528, 518)
        Me.tabGuests.TabIndex = 3
        Me.tabGuests.Text = "Guests"
        Me.tabGuests.UseVisualStyleBackColor = True
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
        Me.grpGuestsWaiting.ResumeLayout(False)
        Me.grpGuestsWaiting.PerformLayout()
        Me.grpRoom.ResumeLayout(False)
        Me.grpRoom.PerformLayout()
        Me.grpFloorplan.ResumeLayout(False)
        Me.grpFloorplan.PerformLayout()
        CType(Me.numFloor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabFood.ResumeLayout(False)
        Me.grpFood.ResumeLayout(False)
        Me.grpKitchen.ResumeLayout(False)
        Me.pnlIngredients.ResumeLayout(False)
        Me.tabInventory.ResumeLayout(False)
        Me.grpGold.ResumeLayout(False)
        Me.grpWorkbench.ResumeLayout(False)
        Me.grpInventory.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFloor As System.Windows.Forms.Label
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbc As System.Windows.Forms.TabControl
    Friend WithEvents tabFloor As System.Windows.Forms.TabPage
    Friend WithEvents numFloor As System.Windows.Forms.NumericUpDown
    Friend WithEvents tabInventory As System.Windows.Forms.TabPage
    Friend WithEvents grpFloorplan As System.Windows.Forms.GroupBox
    Friend WithEvents pnlFloor As System.Windows.Forms.Panel
    Friend WithEvents grpRoom As System.Windows.Forms.GroupBox
    Friend WithEvents pnlRoom As System.Windows.Forms.Panel
    Friend WithEvents lblDescription As System.Windows.Forms.Label
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
    Friend WithEvents btnCookReset As System.Windows.Forms.Button
    Friend WithEvents lblIngredient1 As System.Windows.Forms.Label
    Friend WithEvents lblIngredient5 As System.Windows.Forms.Label
    Friend WithEvents lblIngredient4 As System.Windows.Forms.Label
    Friend WithEvents lblIngredient3 As System.Windows.Forms.Label
    Friend WithEvents lblIngredient2 As System.Windows.Forms.Label
    Friend WithEvents pnlIngredients As System.Windows.Forms.Panel
    Friend WithEvents grpFood As System.Windows.Forms.GroupBox
    Friend WithEvents lstFood As System.Windows.Forms.ListBox
    Friend WithEvents lstFoodIngredients As System.Windows.Forms.ListBox
    Friend WithEvents txtIngredient5 As System.Windows.Forms.Label
    Friend WithEvents txtIngredient4 As System.Windows.Forms.Label
    Friend WithEvents txtIngredient3 As System.Windows.Forms.Label
    Friend WithEvents txtIngredient2 As System.Windows.Forms.Label
    Friend WithEvents txtIngredient1 As System.Windows.Forms.Label
    Friend WithEvents tabGuests As System.Windows.Forms.TabPage
    Friend WithEvents btnRoomToWaiting As System.Windows.Forms.Button
    Friend WithEvents btnWaitingToRoom As System.Windows.Forms.Button
    Friend WithEvents lstGuestsWaiting As System.Windows.Forms.ListBox
    Friend WithEvents btnMenuToFood As System.Windows.Forms.Button
    Friend WithEvents btnFoodToMenu As System.Windows.Forms.Button
    Friend WithEvents lstGuestsRoomed As System.Windows.Forms.ListBox
    Friend WithEvents lblGuests As System.Windows.Forms.Label
    Friend WithEvents grpGuestsWaiting As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuestSortRace As System.Windows.Forms.Button
    Friend WithEvents btnGuestSortJob As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGuestSortName As System.Windows.Forms.Button

End Class
