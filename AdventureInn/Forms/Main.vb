Public Class Main
    Private CurrentInn As New Inn
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
                .WaitingGuests.Add(Adventurer.Generate)
            Next

            .InventoryRoomItems.Add(RoomItem.Generate("Straw Bed"))
            .InventoryRoomItems.Add(RoomItem.Generate("Study Table"))
            .InventoryRoomItems.Add(RoomItem.Generate("Study Table"))
            .InventoryRoomItems.Add(RoomItem.Generate("Four-Poster Bed"))
            .Gold = 20000

            .InventoryFoodIngredients.Add(FoodIngredient.Generate("Dragon's Egg"))
            .InventoryFoodIngredients.Add(FoodIngredient.Generate("Manticore's Egg"))
            .InventoryFoodIngredients.Add(FoodIngredient.Generate("Gorgon's Milk"))
            .InventoryFoodIngredients.Add(FoodIngredient.Generate("Gorgon's Butter"))
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

        lstRooms.Items.Clear()
        For Each rm In CurrentFloor.Rooms
            lstRooms.Items.Add(rm)
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
        ElseIf e.Button = Windows.Forms.MouseButtons.Middle Then
            DevToolsFloor(CurrentRoom)           'middle click for dev tools
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
    Private Sub DevToolsFloor(ByVal room As Room)
        If Room Is Nothing Then Exit Sub
        Dim adjlist As List(Of Room) = CurrentFloor.GetAdjacentRooms(room)
    End Sub
    Private Sub lstRooms_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstRooms.DoubleClick
        If lstRooms.SelectedIndex = -1 Then Exit Sub
        EnterRoom(lstRooms.SelectedItem)
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
        lblReview.Text = ""
        lblDescription.Text = ""
        With CurrentRoom
            lblDescription.Text &= "Privacy: " & .TotalPrivacy.Key & vbCrLf
            lblDescription.Text &= "Furnishing: " & .TotalFurnishing.Key & vbCrLf
            lblDescription.Text &= "Aesthetics: " & .TotalOpulence.Key & vbCrLf
            lblDescription.Text &= "Quietness: " & .TotalRestfulness.Key & vbCrLf
            lblDescription.Text &= "Niche: " & .TotalNiche.Key & vbCrLf
            lblDescription.Text &= "Alignment: " & .TotalAlignment.Key & vbCrLf
            If .GuestCapacity <= 0 Then
                lblDescription.Text &= vbCrLf & "WARNING! A room must have at least one bed to receive guests. You want guests. Fix this."
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
    End Sub
    Private Sub lstGuests_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGuestsRoomed.SelectedIndexChanged
        Dim g As Adventurer = lstGuestsRoomed.SelectedItem
        If g Is Nothing Then Exit Sub

        lblReview.Text = g.RoomSatisfaction(CurrentRoom).Key
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
            DescribeItem(roomItem, lblDescription)              'left-click for info
        ElseIf e.Button = Windows.Forms.MouseButtons.Middle Then
            DevToolsRoom()                                      'middle-click for dev tools
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
    Private Sub DevToolsRoom()
        CurrentRoom.Add(Adventurer.Generate)
        RoomBuild()
        RoomRefresh()
    End Sub
    Private Sub lblDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDescription.Click
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
        lblReview.Text = ""
    End Sub

    Private AllRoomItems As New Dictionary(Of String, RoomItem)
    Private Sub WorkbenchBuild()
        Dim rawData As List(Of String) = IO.ImportSquareBracketHeaders(IO.sbRooms)
        For Each l In rawData
            AllRoomItems.Add(l, RoomItem.Generate(l))
            cmbWorkbench.Items.Add(l)
        Next
    End Sub
    Private Sub WorkbenchRefresh()
        lstInventory.Items.Clear()
        For Each i In CurrentInn.InventoryRoomItems
            lstInventory.Items.Add(i)
        Next
        lblGold.Text = CurrentInn.Gold.ToString("N")
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
        Dim roomItem As RoomItem = AllRoomItems(cmbWorkbench.SelectedItem.ToString)
        DescribeItem(roomItem, lblWorkbenchDescription)
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

    Private AllKitchenRecipes As New Dictionary(Of String, FoodRecipe)
    Private ActiveRecipe As FoodRecipe = Nothing
    Private KitchenLbls(4) As Label
    Private KitchenTxts(4) As Label
    Private Sub KitchenBuild()
        'populate AllKitchenRecipes
        Dim rawData As List(Of String) = IO.ImportSquareBracketHeaders(IO.sbRecipes)
        For Each l In rawData
            AllKitchenRecipes.Add(l, FoodRecipe.Generate(l))
            cmbKitchen.Items.Add(l)
        Next

        'setup KitchenLbls and KitchenTxts
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
            AddHandler KitchenTxts(n).Click, AddressOf txtIngredient_Click
        Next

        RecipeReset()
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
    Private Sub cmbKitchen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKitchen.SelectedIndexChanged
        If cmbKitchen.SelectedIndex = -1 Then
            ActiveRecipe = Nothing
            KitchenRefresh()
            RecipeReset()
        Else
            Dim fr As FoodRecipe = AllKitchenRecipes(cmbKitchen.SelectedItem.ToString)
            ActiveRecipe = fr.Clone
            RecipeShow()
        End If
    End Sub
    Private Sub RecipeShow()
        If ActiveRecipe Is Nothing Then Exit Sub

        RecipeReset()
        For n = 0 To ActiveRecipe.Requirements.Count - 1
            KitchenLbls(n).Visible = True
            KitchenLbls(n).Text = ActiveRecipe.Requirements(n) & ":"
            KitchenTxts(n).Visible = True
            KitchenTxts(n).Enabled = True
            KitchenTxts(n).Tag = ActiveRecipe.Requirements(n)
        Next
        btnCook.Visible = True
        btnCook.Enabled = False
        btnCookReset.Visible = True

        RecipeUpdate()
    End Sub
    Private Sub RecipeUpdate()
        If ActiveRecipe Is Nothing Then Exit Sub

        With ActiveRecipe
            lblKitchen.Text = .AttributesDescription
            btnCook.Enabled = .Completed
        End With
    End Sub
    Private Sub RecipeReset()
        For n = 0 To 4
            KitchenLbls(n).Visible = False
            KitchenTxts(n).Text = ""
            KitchenTxts(n).Visible = False
            KitchenTxts(n).Tag = Nothing
        Next
        btnCook.Visible = False
        btnCookReset.Visible = False
    End Sub
    Private Sub txtIngredient_Click(ByVal sender As Label, ByVal e As System.EventArgs)
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
    Private Sub btnCookReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCookReset.Click
        For Each fi In ActiveRecipe.Clear
            CurrentInn.InventoryFoodIngredients.Add(fi)
        Next

        For n = 0 To 4
            KitchenTxts(n).Tag = Nothing
            KitchenTxts(n).Text = Nothing
            KitchenTxts(n).Enabled = True
        Next

        KitchenRefresh()
    End Sub
    Private Sub btnCook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCook.Click
        Dim f As Food = Food.Generate(ActiveRecipe)
        CurrentInn.InventoryFood.Add(f)

        cmbKitchen.SelectedIndex = -1
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
End Class
