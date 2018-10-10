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
        If maxWidth < 100 Then maxWidth = 200
        Dim maxHeight As Integer = yMargin * 2 + (pHeight * CurrentRoom.Height) + 110
        Me.Size = New Size(maxWidth, maxheight)
        lblTitle.Width = maxWidth
        lblTitle.Location = New Point(0, 0)
        lblDescription.Width = maxWidth
        lblDescription.Location = New Point(0, yMargin + (pHeight * CurrentRoom.Height) + 10)
    End Sub
    Private Sub RoomRefresh()
        lblTitle.Text = CurrentRoom.Name

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

        With CurrentRoom
            lblDescription.Text = "Reviews:" & vbCrLf
            lblDescription.Text &= "- " & TotalDescribe(.TotalFurnishing) & vbCrLf
            lblDescription.Text &= "- " & TotalDescribe(.TotalOpulence) & vbCrLf
            lblDescription.Text &= "- " & TotalDescribe(.TotalRestfulness) & vbCrLf
            lblDescription.Text &= "- " & TotalDescribe(.TotalNiche) & vbCrLf
            lblDescription.Text &= "- " & TotalDescribe(.TotalAlignment)
        End With
    End Sub
    Private Function TotalDescribe(ByVal desc As Pair(Of String, Integer)) As String
        Return """" & desc.Key & "."""
        'Select Case desc
        '    Case "Unfurnished"
        '    Case "Furnished"
        '    Case "Well Furnished"
        '    Case "Boring"
        '    Case "Opulent"
        '    Case "Tasteful"
        '    Case "Middling"
        '    Case "Restful"
        '    Case "Exciting"
        '    Case "Neutral"
        '    Case "Lawful"
        '    Case "Chaotic"
        '    Case "Bland"
        '    Case "Faith"
        '    Case "Focus"
        '    Case "Strength"
        '    Case "Curiosity"
        '    Case Else : Throw New Exception
        'End Select
    End Function

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
    Private Sub lblTitle_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim newName As String = InputBox("Enter new name:", "Name", CurrentRoom.Name)
            CurrentRoom.Name = newName
            RoomRefresh()
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            ColorDialog1.Color = CurrentRoom.Color
            If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                CurrentRoom.Color = ColorDialog1.Color
            End If
        End If
    End Sub
End Class