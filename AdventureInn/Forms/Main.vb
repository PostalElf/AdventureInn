Public Class Main
    Private WithEvents CurrentInn As New Inn
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetupInn()
    End Sub
    Private Sub SetupInn()
        With CurrentInn
            Dim floor1 As New Floor
            floor1.Add(New Room(RoomSize.Large), 1, 1)
            .Add(floor1)
            Dim floor2 As New Floor
            .Add(floor2)

            For n = 1 To 10
                .Add(Adventurer.Generate)
            Next

            .Add(RoomItem.Generate("Straw Bed"))
            .Add(RoomItem.Generate("Study Table"))
            .Add(RoomItem.Generate("Study Table"))
            .Add(RoomItem.Generate("Four-Poster Bed"))
            .Gold = 20000

            .Add(FoodRecipe.Generate("Omelette"))
            .Add(FoodPrep.Generate("Cow Cheese"))
            .Add(FoodPrep.Generate("Beef Sausages"))
            .Add(FoodIngredient.Generate("Beef Flank"))
            .Add(FoodIngredient.Generate("Dragon Egg"))
            .Add(FoodIngredient.Generate("Manticore Egg"))
            .Add(FoodIngredient.Generate("Gorgon Milk"))
            .Add(FoodIngredient.Generate("Gorgon Butter"))
            .Add(FoodIngredient.Generate("Cow Milk"))
            .Add(FoodIngredient.Generate("Cow Milk"))
            .Add(FoodIngredient.Generate("Beef Offals"))
            .Add(FoodIngredient.Generate("Muskgrass"))
        End With
    End Sub
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        numFloor.Minimum = 0
        numFloor.Maximum = CurrentInn.FloorsMax - 1
        numFloor.Value = 0
        CurrentFloor = CurrentInn(0)
        FloorBuild()
        FloorRefresh()
        GuestsRefresh()
        WorkbenchBuild()
        WorkbenchRefresh()
        KitchenBuild()
        KitchenRefresh()
    End Sub
    Private Sub RefreshGold() Handles CurrentInn.GoldChange
        lblGold.Text = CurrentInn.Gold.ToString("N0")
    End Sub
    Private Sub btnEndNight_Click(ByVal sender As Button, ByVal e As System.EventArgs) Handles btnEndNight.Click
        CurrentInn.EndNight()
        FloorRefresh()
        GuestsRefresh()
        KitchenRefresh()
    End Sub

#Region "Floor Management"
    Private CurrentFloor As Floor
    Private FloorPanels(,) As Panel
    Private Sub FloorBuild()
        Const xMargin As Integer = 2
        Const yMargin As Integer = 2
        Const pHeight As Integer = 20
        Const pWidth As Integer = 20

        With CurrentFloor
            ReDim FloorPanels(.Width, .Height)
            For x = 1 To .Width
                For y = 1 To .Height
                    Dim panel As New Panel
                    With panel
                        .Width = pWidth
                        .Height = pHeight
                        .Parent = pnlFloor
                        .Location = New Point(xMargin + (pWidth * (x - 1)), yMargin + (pHeight * (y - 1)))
                        .BorderStyle = BorderStyle.FixedSingle
                        .BackColor = Color.Gray
                        .Tag = x & "," & y
                    End With
                    AddHandler panel.MouseDown, AddressOf FloorPanelClick
                    pnlFloor.Controls.Add(panel)
                    FloorPanels(x, y) = panel
                Next
            Next
        End With
    End Sub
    Private Sub FloorRefresh()
        tt.RemoveAll()
        For x = 1 To CurrentFloor.Width
            For y = 1 To CurrentFloor.Height
                Dim room As Room = CurrentFloor(x, y)
                With FloorPanels(x, y)
                    If room Is Nothing Then
                        .BackColor = Color.Gray
                    Else
                        .BackColor = room.Color
                        tt.SetToolTip(FloorPanels(x, y), room.Name)
                    End If
                End With
            Next
        Next
    End Sub
    Private Sub numFloor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numFloor.ValueChanged
        CurrentFloor = CurrentInn(numFloor.Value)
        FloorRefresh()
    End Sub
    Private Sub FloorPanelClick(ByVal sender As Panel, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim tagSplit As String() = sender.Tag.ToString.Split(",")
        Dim x As Integer = tagSplit(0)
        Dim y As Integer = tagSplit(1)
        Dim CurrentRoom As Room = CurrentFloor(x, y)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            'right-click to modify
            If CurrentRoom Is Nothing Then
                AddRoom(x, y)               'empty, right-click to add
            Else
                RemoveRoom(CurrentRoom)     'occupied, right-click to remove
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            EnterRoom(CurrentRoom)          'left click to enter room
        End If
    End Sub
    Private Sub AddRoom(ByVal x As Integer, ByVal y As Integer)
        Dim dri As New DialogRoomItem
        dri.UseCase = "Room"
        If dri.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim roomSize As RoomSize = dri.RoomSize
            dri.Close()
            Dim errorString As String = CurrentFloor.Add(New Room(roomSize), x, y)
            If errorString <> "" Then MsgBox(errorString, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error") : Exit Sub
            FloorRefresh()
        End If
    End Sub
    Private Sub RemoveRoom(ByVal room As Room)
        If room Is Nothing Then Exit Sub
        If MsgBox("Are you sure you want to destroy " & room.Name & " and everything inside it?" & vbCrLf & vbCrLf & _
                          "This cannot be undone.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Destroy Room") = MsgBoxResult.Yes Then
            CurrentFloor.Remove(room)
            FloorRefresh()
        End If
    End Sub
    Private Sub EnterRoom(ByVal room As Room)
        If room Is Nothing Then Exit Sub
        CurrentRoom = room
        RoomBuild()
        RoomRefresh()
    End Sub

    Private CurrentRoom As Room
    Private RoomPanels(,) As Panel
    Private Sub RoomBuild()
        Const xMargin As Integer = 2
        Const yMargin As Integer = 2
        Const pHeight As Integer = 15
        Const pWidth As Integer = 15

        ReDim RoomPanels(CurrentRoom.Width, CurrentRoom.Height)
        pnlRoom.Controls.Clear()
        For x = 1 To CurrentRoom.Width
            For y = 1 To CurrentRoom.Height
                Dim panel As New Panel
                With panel
                    .Width = pWidth
                    .Height = pHeight
                    .Location = New Point(xMargin + (pWidth * (x - 1)), yMargin + (pHeight * (y - 1)))
                    .BorderStyle = BorderStyle.FixedSingle
                    .BackColor = Color.Gray
                    .Tag = x & "," & y
                End With
                AddHandler panel.MouseDown, AddressOf RoomPanelClick
                pnlRoom.Controls.Add(panel)
                RoomPanels(x, y) = panel
            Next
        Next
    End Sub
    Private Sub RoomRefresh()
        grpRoom.Text = CurrentRoom.Name

        For x = 1 To CurrentRoom.Width
            For y = 1 To CurrentRoom.Height
                Dim roomItem As RoomItem = CurrentRoom(x, y)
                With RoomPanels(x, y)
                    If roomItem Is Nothing Then
                        .BackColor = Color.Gray
                    Else
                        .BackColor = Color.AliceBlue
                        tt.SetToolTip(RoomPanels(x, y), roomItem.Name)
                    End If
                End With
            Next
        Next
        RoomLabelRefresh()
        GuestsRefresh()
    End Sub
    Private Sub RoomLabelRefresh()
        lblGuestRoomedDescription.Text = ""
        With CurrentRoom
            lblGuestRoomedDescription.Text &= "Privacy: " & .TotalPrivacy.Key & vbCrLf
            lblGuestRoomedDescription.Text &= "Furnishing: " & .TotalFurnishing.Key & vbCrLf
            lblGuestRoomedDescription.Text &= "Aesthetics: " & .TotalOpulence.Key & vbCrLf
            lblGuestRoomedDescription.Text &= "Quietness: " & .TotalRestfulness.Key & vbCrLf
            lblGuestRoomedDescription.Text &= "Niche: " & .TotalNiche.Key & vbCrLf
            lblGuestRoomedDescription.Text &= "Alignment: " & .TotalAlignment.Key & vbCrLf
            If .GuestCapacity <= 0 Then
                lblGuestRoomedDescription.Text &= vbCrLf & "WARNING! A room must have at least one bed to receive guests. You want guests. Fix this."
            End If
        End With
    End Sub
    Private Sub GuestsRefresh()
        lstGuestsRoomed.Items.Clear()
        If CurrentRoom Is Nothing = False Then
            For Each g In CurrentRoom.Guests
                lstGuestsRoomed.Items.Add(g)
            Next
        End If

        lstGuestsWaiting.Items.Clear()
        For Each g In CurrentInn.WaitingGuests
            lstGuestsWaiting.Items.Add(g)
        Next

        lstAdventurers.Items.Clear()
        For Each g In CurrentInn.ExitingGuests.Keys
            lstAdventurers.Items.Add(g)
        Next
    End Sub
    Private Sub RoomPanelClick(ByVal sender As Panel, ByVal e As MouseEventArgs)
        Dim tagSplit As String() = sender.Tag.ToString.Split(",")
        Dim x As Integer = tagSplit(0)
        Dim y As Integer = tagSplit(1)
        Dim roomItem As RoomItem = CurrentRoom(x, y)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            'right-click to manipulate
            If roomItem Is Nothing = False Then
                RemoveItem(roomItem)                            'item present; prompt to remove item
            Else
                AddItem(x, y)                                   'no item; prompt to add item
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            DescribeItem(roomItem, lblGuestRoomedDescription)              'left-click for info
        End If
    End Sub
    Private Sub AddItem(ByVal x As Integer, ByVal y As Integer)
        Dim dri As New DialogRoomItem
        dri.UseCase = "RoomItem"
        dri.Inventory = CurrentInn.InventoryRoomItems
        If dri.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim newItem As RoomItem = dri.RoomItem
            dri.Close()
            If newItem Is Nothing Then Exit Sub
            If CurrentRoom.Add(newItem, x, y) = "" Then
                CurrentInn.InventoryRoomItems.Remove(newItem)
                RoomRefresh()
            End If
        End If
    End Sub
    Private Sub RemoveItem(ByVal roomitem As RoomItem)
        If MsgBox("Remove " & roomitem.Name & "?", MsgBoxStyle.YesNo, "Remove Item?") = MsgBoxResult.Yes Then
            CurrentRoom.Remove(roomitem)
            CurrentInn.InventoryRoomItems.Add(roomitem)
            RoomRefresh()
        End If
    End Sub
    Private Sub DescribeItem(ByVal roomItem As RoomItem, ByVal control As Label)
        If roomItem Is Nothing Then Exit Sub

        control.Text = roomItem.Name & vbCrLf
        control.Text &= "Size: " & roomItem.Width & "x" & roomItem.Height & vbCrLf
        control.Text &= roomItem.AttributesDescription & vbCrLf
        control.Text &= roomItem.Description
    End Sub

    Private Sub lstGuestsWaiting_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGuestsWaiting.SelectedIndexChanged
        Dim guest As Adventurer = lstGuestsWaiting.SelectedItem

        If guest Is Nothing Then
            lblGuestWaitingDescription.Text = ""
        Else
            lblGuestWaitingDescription.Text = guest.roompreferencedescription
        End If
    End Sub
    Private Sub lblDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGuestRoomedDescription.Click
        RoomLabelRefresh()
    End Sub
    Private Sub btnWaitingToRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaitingToRoom.Click
        If CurrentRoom Is Nothing Then Exit Sub
        If lstGuestsWaiting.SelectedIndex = -1 Then Exit Sub

        Dim guest As Adventurer = lstGuestsWaiting.SelectedItem
        Dim errorstring As String = CurrentRoom.Add(guest)
        If errorstring <> "" Then MsgBox(errorstring, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error") : Exit Sub
        lstGuestsRoomed.Items.Add(guest)
        CurrentInn.WaitingGuests.Remove(guest)
        lstGuestsWaiting.Items.Remove(guest)
    End Sub
    Private Sub btnRoomToWaiting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoomToWaiting.Click
        If CurrentRoom Is Nothing Then Exit Sub
        If lstGuestsRoomed.SelectedIndex = -1 Then Exit Sub

        Dim guest As Adventurer = lstGuestsRoomed.SelectedItem
        Dim errorstring As String = CurrentRoom.Remove(guest)
        If errorstring <> "" Then MsgBox(errorstring, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error") : Exit Sub
        lstGuestsRoomed.Items.Remove(guest)
        CurrentInn.WaitingGuests.Add(guest)
        lstGuestsWaiting.Items.Add(guest)
    End Sub

    Private Sub lstGuests_Click(ByVal sender As ListBox, ByVal e As MouseEventArgs) Handles lstGuestsWaiting.MouseDown, lstGuestsRoomed.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim choices As New List(Of String) From {"Sort by Race", "Sort by Job", "Sort by Name"}
            Dim dp As New DialogPicker
            dp.MainList = choices
            If dp.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim choice As String = dp.Result
                dp.Close()

                Dim sortList As List(Of Adventurer)
                If sender.Equals(lstGuestsWaiting) Then
                    sortList = CurrentInn.WaitingGuests
                ElseIf sender.Equals(lstGuestsRoomed) Then
                    If CurrentRoom Is Nothing Then Exit Sub
                    sortList = CurrentRoom.Guests
                Else
                    Throw New Exception
                End If

                Select Case choice
                    Case "Sort by Race" : sortList.Sort(New Adventurer.SortByRace)
                    Case "Sort by Job" : sortList.Sort(New Adventurer.SortByJob)
                    Case "Sort by Name" : sortList.Sort(New Adventurer.SortByName)
                End Select
                GuestsRefresh()
            End If
        End If
    End Sub
#End Region

#Region "Inventory"
    Private Sub WorkbenchBuild()
        For Each riName In RoomItem.AllRoomItems.Keys
            Dim ri As RoomItem = RoomItem.AllRoomItems(riName)
            cmbWorkbench.Items.Add(ri)
        Next
    End Sub
    Private Sub WorkbenchRefresh()
        lstInventory.Items.Clear()
        For Each i In CurrentInn.InventoryRoomItems
            lstInventory.Items.Add(i)
        Next
    End Sub
    Private Sub lstInventory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstInventory.SelectedIndexChanged
        If lstInventory.SelectedItem Is Nothing Then Exit Sub
        DescribeItem(lstInventory.SelectedItem, lblInventoryDescription)
    End Sub
    Private Sub btnInventorySort_Click(ByVal sender As Button, ByVal e As System.EventArgs) Handles btnInventorySort.Click
        CurrentInn.InventoryRoomItems.Sort()
        WorkbenchRefresh()
    End Sub
    Private Sub cmbWorkbench_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWorkbench.SelectedIndexChanged
        Dim ri As RoomItem = RoomItem.AllRoomItems(cmbWorkbench.SelectedItem.ToString)
        DescribeItem(ri, lblWorkbenchDescription)
    End Sub
    Private Sub btnBuild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuild.Click
        If cmbWorkbench.SelectedItem Is Nothing Then Exit Sub
        Dim errorString As String = BuildItem(cmbWorkbench.Text)
        If errorString <> "" Then MsgBox(errorString)
    End Sub
    Private Function BuildItem(ByVal itemName As String) As String
        Dim item As RoomItem = RoomItem.Generate(itemName)
        If CurrentInn.Gold < item.Cost Then Return "Insufficient gold."

        CurrentInn.Gold -= item.Cost
        CurrentInn.InventoryRoomItems.Add(item)
        WorkbenchRefresh()
        Return Nothing
    End Function
#End Region

#Region "Kitchen"
    Private ActiveRecipe As FoodRecipe = Nothing
    Private KitchenLbls(4) As Label
    Private KitchenTxts(4) As Label
    Private Sub KitchenBuild()
        For Each r In CurrentInn.InventoryFoodRecipes
            cmbKitchen.Items.Add(r.ToString)
        Next
        KitchenLbls(0) = lblIngredient1
        KitchenLbls(1) = lblIngredient2
        KitchenLbls(2) = lblIngredient3
        KitchenLbls(3) = lblIngredient4
        KitchenLbls(4) = lblIngredient5
        KitchenTxts(0) = txtIngredient1
        KitchenTxts(1) = txtIngredient2
        KitchenTxts(2) = txtIngredient3
        KitchenTxts(3) = txtIngredient4
        KitchenTxts(4) = txtIngredient5
        For n = 0 To 4
            KitchenTxts(n).Visible = False
            KitchenLbls(n).Visible = False
            AddHandler KitchenTxts(n).Click, AddressOf txtKitchenIngredient_Click
        Next
        cmbKitchen.SelectedIndex = -1

        For Each p In CurrentInn.InventoryFoodPreps
            cmbCountertop.Items.Add(p.Name)
        Next
        CountertopLbls(0) = lblCountertopIngredient1
        CountertopLbls(1) = lblCountertopIngredient2
        CountertopLbls(2) = lblCountertopIngredient3
        CountertopTxts(0) = txtCountertopIngredient1
        CountertopTxts(1) = txtCountertopIngredient2
        CountertopTxts(2) = txtCountertopIngredient3
        For n = 0 To 2
            CountertopLbls(n).Visible = False
            CountertopTxts(n).Visible = False
            AddHandler CountertopTxts(n).Click, AddressOf txtCountertopIngredient_Click
        Next
        cmbCountertop.SelectedIndex = -1
    End Sub
    Private Sub KitchenRefresh()
        lstFoodIngredients.Items.Clear()
        For Each fi In CurrentInn.InventoryFoodIngredients
            lstFoodIngredients.Items.Add(fi)
        Next
        lstFood.Items.Clear()
        For Each f In CurrentInn.InventoryFood
            lstFood.Items.Add(f)
        Next
        lblKitchen.Text = ""
    End Sub
    Private Sub RecipeReset()
        lblKitchen.Text = Nothing
        btnKitchenCook.Enabled = False
        btnKitchenCook.Visible = False
        btnKitchenReset.Visible = False
        For n = 0 To 4
            KitchenLbls(n).Visible = False
            KitchenLbls(n).Text = "Ingredient:"
            KitchenTxts(n).Visible = False
            KitchenTxts(n).Text = Nothing
            KitchenTxts(n).Tag = Nothing
        Next

        'clear former activerecipe
        If ActiveRecipe Is Nothing = False Then
            For Each fi In ActiveRecipe.Clear
                CurrentInn.InventoryFoodIngredients.Add(fi)
            Next
            KitchenRefresh()
        End If
    End Sub
    Private Sub RecipeUpdate()
        lblKitchen.Text = ActiveRecipe.AttributesDescription
        btnKitchenCook.Enabled = ActiveRecipe.Completed
    End Sub
    Private Sub cmbKitchen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKitchen.SelectedIndexChanged
        RecipeReset()

        If cmbKitchen.SelectedIndex = -1 Then
            If ActiveRecipe Is Nothing = False Then CurrentInn.InventoryFoodIngredients.AddRange(ActiveRecipe.Clear)
            ActiveRecipe = Nothing
            Exit Sub
        End If

        ActiveRecipe = FoodRecipe.Generate(cmbKitchen.SelectedItem.ToString)
        btnKitchenCook.Visible = True
        btnKitchenReset.Visible = True
        For n = 0 To ActiveRecipe.Requirements.Count - 1
            KitchenLbls(n).Visible = True
            KitchenLbls(n).Text = ActiveRecipe.Requirements(n) & ":"
            KitchenTxts(n).Visible = True
            KitchenTxts(n).Text = Nothing
            KitchenTxts(n).Tag = ActiveRecipe.Requirements(n)
        Next
        RecipeUpdate()
    End Sub
    Private Sub btnKitchenReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKitchenReset.Click
        cmbKitchen.SelectedIndex = -1
    End Sub
    Private Sub btnKitchenCook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKitchenCook.Click
        CurrentInn.Add(Food.Generate(ActiveRecipe))
        ActiveRecipe = Nothing
        cmbKitchen.SelectedIndex = -1
        KitchenRefresh()
    End Sub
    Private Sub txtKitchenIngredient_Click(ByVal sender As Label, ByVal e As System.EventArgs)
        Dim ingredientType As String = sender.Tag
        Dim ingredients As New List(Of FoodIngredient)
        For Each i In CurrentInn.InventoryFoodIngredients
            If i.IngredientType = ingredientType Then ingredients.Add(i)
        Next

        If ingredients.Count = 0 Then
            MsgBox("You have no valid ingredients!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "No valid ingredients")
            Exit Sub
        End If

        Dim fi As FoodIngredient
        If ingredients.Count = 1 Then
            fi = ingredients(0)
        Else
            Dim dp As New DialogPicker
            dp.MainList = ingredients
            If dp.ShowDialog = Windows.Forms.DialogResult.OK Then fi = dp.Result Else Exit Sub
        End If
        lstFoodIngredients.Items.Remove(fi)

        CurrentInn.InventoryFoodIngredients.Remove(fi)
        ActiveRecipe.Add(fi)
        sender.Text = fi.Name
        sender.Enabled = False
        RecipeUpdate()
    End Sub

    Private ActivePrep As FoodPrep = Nothing
    Private CountertopLbls(2) As Label
    Private CountertopTxts(2) As Label
    Private Sub CountertopReset()
        For n = 0 To 2
            CountertopLbls(n).Visible = False
            CountertopLbls(n).Text = "Ingredient:"
            CountertopTxts(n).Visible = False
            CountertopTxts(n).Text = Nothing
            CountertopTxts(n).Tag = Nothing
        Next
        btnCountertopReset.Visible = False
        btnCountertopPrep.Visible = False

        If ActivePrep Is Nothing = False Then
            For Each fi In ActivePrep.Clear
                CurrentInn.InventoryFoodIngredients.Add(fi)
            Next
            KitchenRefresh()
        End If
    End Sub
    Private Sub CountertopUpdate()
        btnCountertopPrep.Enabled = ActivePrep.Completed
    End Sub
    Private Sub cmbCountertop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCountertop.SelectedIndexChanged
        CountertopReset()

        If cmbCountertop.SelectedIndex = -1 Then
            If ActivePrep Is Nothing = False Then CurrentInn.InventoryFoodIngredients.AddRange(ActivePrep.Clear)
            ActivePrep = Nothing
            Exit Sub
        End If

        ActivePrep = FoodPrep.Generate(cmbCountertop.SelectedItem.ToString)
        btnCountertopReset.Visible = True
        btnCountertopPrep.Visible = True
        For n = 0 To ActivePrep.Requirements.Count - 1
            CountertopLbls(n).Visible = True
            CountertopLbls(n).Text = ActivePrep.Requirements(n) & ":"
            CountertopTxts(n).Visible = True
            CountertopTxts(n).Tag = ActivePrep.Requirements(n)
        Next
        CountertopUpdate()
    End Sub
    Private Sub btnCountertopReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountertopReset.Click
        cmbCountertop.SelectedIndex = -1
    End Sub
    Private Sub btnCountertopPrep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountertopPrep.Click
        CurrentInn.Add(FoodIngredient.Generate(ActivePrep.Name))
        ActivePrep = Nothing
        cmbCountertop.SelectedIndex = -1
        KitchenRefresh()
    End Sub
    Private Sub txtCountertopIngredient_Click(ByVal sender As Label, ByVal e As System.EventArgs)
        Dim ingredientType As String = sender.Tag
        Dim ingredients As New List(Of FoodIngredient)
        If ingredientType.StartsWith("<") AndAlso ingredientType.EndsWith(">") Then
            'select by ingredient type
            ingredientType = ingredientType.Replace("<", "")
            ingredientType = ingredientType.Replace(">", "")
            For Each i In CurrentInn.InventoryFoodIngredients
                If i.IngredientType = ingredientType Then ingredients.Add(i)
            Next
        Else
            'select by specific ingredient
            For Each i In CurrentInn.InventoryFoodIngredients
                If i.Name = ingredientType Then ingredients.Add(i) : Exit For
            Next
        End If

        If ingredients.Count = 0 Then
            MsgBox("You have no valid ingredients!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "No valid ingredients")
            Exit Sub
        End If

        Dim fi As FoodIngredient
        If ingredients.Count = 1 Then
            fi = ingredients(0)
        Else
            Dim dp As New DialogPicker
            dp.MainList = ingredients
            If dp.ShowDialog = Windows.Forms.DialogResult.OK Then fi = dp.Result Else Exit Sub
        End If
        lstFoodIngredients.Items.Remove(fi)

        CurrentInn.InventoryFoodIngredients.Remove(fi)
        ActivePrep.Add(fi)
        sender.Text = fi.Name
        sender.Enabled = False
        CountertopUpdate()
    End Sub

    Private MenuLbls(4) As Label
    Private MenuItems(4) As Food
    Private MenuIndex As Integer = 0
    Private Sub btnFoodToMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFoodToMenu.Click
        If MenuIndex = 4 Then Exit Sub
        Dim f As Food = lstFood.SelectedItem
        If f Is Nothing Then Exit Sub

        lstFood.Items.Remove(f)
        AddMenuItem(f)
    End Sub
    Private Sub btnMenuToFood_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenuToFood.Click
        For n = 0 To 4
            If MenuItems(n) Is Nothing = False Then
                grpMenu.Controls.Remove(MenuLbls(n))
                MenuLbls(n) = Nothing
                CurrentInn.InventoryFood.Add(MenuItems(n))
                lstFood.Items.Add(MenuItems(n))
                MenuItems(n) = Nothing
            Else
                Exit For
            End If
        Next
        MenuIndex = 0
    End Sub
    Private Sub AddMenuItem(ByVal f As Food)
        Const lblWidth As Integer = 230
        Const lblHeight As Integer = 33
        Const lblStartX As Integer = 8
        Const lblStartY As Integer = 26

        Dim lbl As New Label
        With lbl
            .AutoSize = False
            .Size = New Size(lblWidth, lblHeight)
            .Location = New Point(lblStartX, lblStartY + (lblHeight * MenuIndex))
            .Text = f.FullName
        End With
        MenuLbls(MenuIndex) = lbl
        MenuItems(MenuIndex) = f
        grpMenu.Controls.Add(lbl)

        MenuIndex += 1
    End Sub

    Private Sub lstFood_Click(ByVal sender As ListBox, ByVal e As MouseEventArgs) Handles lstFood.MouseDown, lstFoodIngredients.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim choices As New List(Of String) From {"Sort by Name", "Sort by Quality", "Sort by Meat/Veg", "Sort by Exotic/Common", "Sort by Rich/Plain"}
            If sender.Equals(lstFoodIngredients) Then choices.Add("Sort by Type")

            Dim dp As New DialogPicker
            dp.MainList = choices
            If dp.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim choice As String = dp.Result
                dp.Close()

                If sender.Equals(lstFood) Then
                    Dim comparer = Nothing
                    Select Case choice
                        Case "Sort by Name" : comparer = New Food.SortByName
                        Case "Sort by Quality" : comparer = New Food.SortByQuality
                        Case "Sort by Meat/Veg" : comparer = New Food.SortByMeatiness
                        Case "Sort by Exotic/Common" : comparer = New Food.SortByExoticness
                        Case "Sort by Rich/Plain" : comparer = New Food.SortByRichness
                    End Select
                    CurrentInn.InventoryFood.Sort(comparer)
                ElseIf sender.Equals(lstFoodIngredients) Then
                    Dim comparer = Nothing
                    Select Case choice
                        Case "Sort by Name" : comparer = New FoodIngredient.SortByName
                        Case "Sort by Quality" : comparer = New FoodIngredient.SortByQuality
                        Case "Sort by Meat/Veg" : comparer = New FoodIngredient.SortByMeatiness
                        Case "Sort by Exotic/Common" : comparer = New FoodIngredient.SortByExoticness
                        Case "Sort by Rich/Plain" : comparer = New FoodIngredient.SortByRichness
                        Case "Sort by Type" : comparer = New FoodIngredient.SortByType
                    End Select
                    CurrentInn.InventoryFoodIngredients.Sort(comparer)
                Else
                    Throw New Exception
                End If
                KitchenRefresh()
            End If
        End If
    End Sub
#End Region

#Region "Party"
    Private Sub lstAdventurers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAdventurers.SelectedIndexChanged
        Dim a As Adventurer = lstAdventurers.SelectedItem
        If a Is Nothing Then lblWhelp.Text = "" : Exit Sub

        Dim review As String = CurrentInn.ExitingGuests(a).Key
        lblWhelp.Text = review
    End Sub
    Private Sub btnAdventurerToParty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdventurerToParty.Click
        Dim a As Adventurer = lstAdventurers.SelectedItem
        If a Is Nothing Then Exit Sub
        If lstParty.Items.Count + 1 > Party.MaxSize Then Exit Sub

        lstAdventurers.Items.Remove(a)
        lstParty.Items.Add(a)
    End Sub
    Private Sub btnPartyToAdventurer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPartyToAdventurer.Click
        Dim a As Adventurer = lstParty.SelectedItem
        If a Is Nothing Then Exit Sub

        lstParty.Items.Remove(a)
        lstAdventurers.Items.Add(a)
    End Sub
    Private Sub btnFormParty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormParty.Click
        If lstParty.Items.Count = 0 Then Exit Sub

        Dim party As New Party
        For Each a As Adventurer In lstParty.Items
            party.Add(a)
            lstParty.Items.Remove(a)
        Next
        party.Name = InputBox("What is the party's name?", "Name Party")
        CurrentInn.ExitingParties.Add(party)
    End Sub
#End Region
End Class
