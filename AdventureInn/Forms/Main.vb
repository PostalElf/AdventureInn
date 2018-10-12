Public Class Main
    Private CurrentInn As New Inn
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetupInn()
    End Sub
    Private Sub SetupInn()
        Dim floor1 As New Floor
        CurrentInn.Add(floor1)
        CurrentInn(0).Add(New Room(RoomSize.Large), 1, 1)

        Dim floor2 As New Floor
        CurrentInn.Add(floor2)

        CurrentInn.Inventory.Add(New RoomItem("Straw Bed"))
        CurrentInn.Inventory.Add(New RoomItem("Study Table"))
        CurrentInn.Inventory.Add(New RoomItem("Study Table"))
        CurrentInn.Inventory.Add(New RoomItem("Four-Poster Bed"))
        CurrentInn.Gold = 20000
    End Sub
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        numFloor.Minimum = 0
        numFloor.Maximum = CurrentInn.FloorsMax - 1
        numFloor.Value = 0
        CurrentFloor = CurrentInn(0)
        FloorBuild()
        FloorRefresh()
        WorkbenchBuild()
        WorkbenchRefresh()
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
        Const pHeight As Integer = 20
        Const pWidth As Integer = 20

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

            lstGuests.Items.Clear()
            For Each g In CurrentRoom.Guests
                lstGuests.Items.Add(g)
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
    Private Sub lstGuests_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGuests.SelectedIndexChanged
        Dim g As Adventurer = lstGuests.SelectedItem
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
        dri.Inventory = CurrentInn.Inventory
        If dri.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim newItem As RoomItem = dri.RoomItem
            dri.Close()
            If newItem Is Nothing Then Exit Sub
            If CurrentRoom.Add(newItem, x, y) = "" Then
                CurrentInn.Inventory.Remove(newItem)
                RoomRefresh()
            End If
        End If
    End Sub
    Private Sub RemoveItem(ByVal roomitem As RoomItem)
        If MsgBox("Remove " & roomitem.Name & "?", MsgBoxStyle.YesNo, "Remove Item?") = MsgBoxResult.Yes Then
            CurrentRoom.Remove(roomitem)
            CurrentInn.Inventory.Add(roomitem)
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

    Private AllRoomItems As New Dictionary(Of String, RoomItem)
    Private Sub WorkbenchBuild()
        Dim rawData As List(Of String) = IO.ImportSquareBracketHeaders(IO.sbRooms)
        For Each l In rawData
            AllRoomItems.Add(l, New RoomItem(l))
            cmbWorkbench.Items.Add(l)
        Next
    End Sub
    Private Sub WorkbenchRefresh()
        lstInventory.Items.Clear()
        For Each i In CurrentInn.Inventory
            lstInventory.Items.Add(i)
        Next
        lblGold.Text = CurrentInn.Gold.ToString("N")
    End Sub
    Private Sub lstInventory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstInventory.SelectedIndexChanged
        If lstInventory.SelectedItem Is Nothing Then Exit Sub
        DescribeItem(lstInventory.SelectedItem, lblInventoryDescription)
    End Sub
    Private Sub cmbWorkbench_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWorkbench.SelectedIndexChanged
        Dim roomItem As RoomItem = AllRoomItems(cmbWorkbench.SelectedItem.ToString)
        lblWorkbenchDescription.Text = roomItem.AttributesDescription
        lblWorkbenchDescription.Text &= vbCrLf & roomItem.Description
    End Sub
    Private Sub btnBuild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuild.Click
        If cmbWorkbench.SelectedItem Is Nothing Then Exit Sub
        Dim errorString As String = BuildItem(cmbWorkbench.Text)
        If errorString <> "" Then MsgBox(errorString)
    End Sub
    Private Function BuildItem(ByVal itemName As String) As String
        Dim item As New RoomItem(itemName)
        If CurrentInn.Gold < item.Cost Then Return "Insufficient gold."

        CurrentInn.Gold -= item.Cost
        CurrentInn.Inventory.Add(item)
        WorkbenchRefresh()
        Return Nothing
    End Function
End Class
