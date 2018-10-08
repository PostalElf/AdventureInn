Public Class DialogRoom
    Public CurrentInn As Inn
    Public CurrentFloor As Floor
    Public CurrentRoom As Room
    Dim panels(,) As Panel

    Private Sub FormShow(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        RoomBuild()
        RoomRefresh()
    End Sub
    Private Sub RoomBuild()
        Const xMargin As Integer = 10
        Const yMargin As Integer = 30
        Const pHeight As Integer = 20
        Const pWidth As Integer = 20

        ReDim panels(CurrentRoom.Width, CurrentRoom.Height)
        lblTitle.Text = CurrentRoom.Name
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
                AddHandler panel.MouseDown, AddressOf PanelClick
                Controls.Add(panel)
                panels(x, y) = panel
            Next
        Next

        Dim maxWidth As Integer = xMargin * 2 + (pWidth * CurrentRoom.Width) + 10
        Dim maxHeight As Integer = yMargin * 2 + (pHeight * CurrentRoom.Height) + 10
        Me.Size = New Size(maxWidth, maxheight)
        lblTitle.Width = maxWidth
    End Sub
    Private Sub RoomRefresh()
        For x = 1 To CurrentRoom.Width
            For y = 1 To CurrentRoom.Height
                Dim roomItem As RoomItem = CurrentRoom(x, y)
                With panels(x, y)
                    If roomItem Is Nothing Then
                        .BackColor = Color.Gray
                    Else
                        .BackColor = Color.AliceBlue
                        tt.SetToolTip(panels(x, y), roomItem.Name)
                    End If
                End With
            Next
        Next
    End Sub

    Private Sub PanelClick(ByVal sender As Panel, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim tagSplit As String() = sender.Tag.ToString.Split(",")
        Dim x As Integer = tagSplit(0)
        Dim y As Integer = tagSplit(1)
        RoomItemClick(x, y, e)
    End Sub
    Private Sub RoomItemClick(ByVal x As Integer, ByVal y As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim roomItem As RoomItem = CurrentRoom(x, y)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            'right-click to manipulate
            If roomItem Is Nothing = False Then
                'item present; prompt to remove item
                If MsgBox("Remove " & roomItem.Name & "?", MsgBoxStyle.YesNo, "Remove Item?") = MsgBoxResult.Yes Then
                    CurrentRoom.Remove(roomItem)
                    CurrentInn.Inventory.Add(roomItem)
                    RoomRefresh()
                End If
            Else
                'no item; prompt to add item
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
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            'left-click for info
            If roomItem Is Nothing Then Exit Sub
            MsgBox(roomItem.Name & vbCrLf & "Size: " & roomItem.Width & "x" & roomItem.Height & vbCrLf & vbCrLf & roomItem.Description, MsgBoxStyle.OkOnly, "Room Item")
        End If
    End Sub
End Class