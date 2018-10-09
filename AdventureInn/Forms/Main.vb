Public Class Main
    Dim CurrentInn As New Inn
    Dim CurrentFloor As Floor
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
    End Sub
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        numFloor.Minimum = 0
        numFloor.Maximum = CurrentInn.FloorsMax - 1
        numFloor.Value = 0
        CurrentFloor = CurrentInn(0)
        FloorBuild()
        FloorRefresh()
    End Sub

    Private Panels(,) As Panel
    Private Sub numFloor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numFloor.ValueChanged
        CurrentFloor = CurrentInn(numFloor.Value)
        FloorRefresh()
    End Sub
    Private Sub FloorBuild()
        Const xMargin As Integer = 2
        Const yMargin As Integer = 2
        Const pHeight As Integer = 20
        Const pWidth As Integer = 20

        With CurrentFloor
            ReDim Panels(.Width, .Height)
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
                    AddHandler panel.MouseDown, AddressOf PanelClick
                    pnlFloor.Controls.Add(panel)
                    Panels(x, y) = panel
                Next
            Next
        End With
    End Sub
    Private Sub FloorRefresh()
        tt.RemoveAll()
        For x = 1 To CurrentFloor.Width
            For y = 1 To CurrentFloor.Height
                Dim room As Room = CurrentFloor(x, y)
                With Panels(x, y)
                    If room Is Nothing Then
                        .BackColor = Color.Gray
                    Else
                        .BackColor = room.Color
                        tt.SetToolTip(Panels(x, y), room.Name)
                    End If
                End With
            Next
        Next
    End Sub

    Private Sub PanelClick(ByVal sender As Panel, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim tagSplit As String() = sender.Tag.ToString.Split(",")
        Dim x As Integer = tagSplit(0)
        Dim y As Integer = tagSplit(1)
        Dim CurrentRoom As Room = CurrentFloor(x, y)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            'right-click to modify
            If CurrentRoom Is Nothing Then
                'empty, right-click to add
                Dim dri As New DialogRoomItem
                dri.UseCase = "Room"
                If dri.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim roomSize As RoomSize = dri.RoomSize
                    dri.Close()
                    Dim errorString As String = CurrentFloor.Add(New Room(roomSize), x, y)
                    If errorString <> "" Then MsgBox(errorString, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error") : Exit Sub
                    FloorRefresh()
                End If
            Else
                'occupied, right-click to remove
                If MsgBox("Are you sure you want to destroy " & CurrentRoom.Name & " and everything inside it?" & vbCrLf & vbCrLf & _
                          "This cannot be undone.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Destroy Room") = MsgBoxResult.Yes Then
                    CurrentFloor.Remove(CurrentRoom)
                    FloorRefresh()
                End If
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            'left click to enter room
            If CurrentRoom Is Nothing Then Exit Sub
            Dim dr As New DialogRoom
            With dr
                .CurrentInn = CurrentInn
                .CurrentFloor = CurrentFloor
                .CurrentRoom = CurrentRoom
            End With
            dr.ShowDialog()
            FloorRefresh()
        ElseIf e.Button = Windows.Forms.MouseButtons.Middle Then
            'middle click for dev tools
            If CurrentRoom Is Nothing Then Exit Sub
            Dim adjlist As List(Of Room) = CurrentFloor.GetAdjacentRooms(CurrentRoom)
        End If
    End Sub
End Class
