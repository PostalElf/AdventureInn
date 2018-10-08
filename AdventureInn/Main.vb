﻿Public Class Main
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
        CurrentInn(0).Add(New Room(RoomSize.Medium), 1, 1)

        Dim floor2 As New Floor
        CurrentInn.Add(floor2)

        CurrentInn.Inventory.Add(New RoomItem("Straw Bed"))
        CurrentInn.Inventory.Add(New RoomItem("Study Table"))
        CurrentInn.Inventory.Add(New RoomItem("Study Table"))
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
                        .BackColor = Color.AliceBlue
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
        If CurrentRoom Is Nothing Then Exit Sub

        Dim dr As New DialogRoom
        With dr
            .CurrentInn = CurrentInn
            .CurrentFloor = CurrentFloor
            .CurrentRoom = CurrentRoom
        End With
        dr.ShowDialog()
    End Sub
End Class
