Public Class DialogRoomItem
    Public RoomItem As RoomItem = Nothing
    Public Inventory As List(Of RoomItem)

    Private Sub DialogRoomItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each entry In Inventory
            ListBox1.Items.Add(entry.Name)
        Next
    End Sub
    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.SelectedItem Is Nothing Then Exit Sub
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Listbox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim i As Integer = ListBox1.SelectedIndex
        RoomItem = Inventory(i)
        lblDescription.Text = RoomItem.Description
        lblSize.Text = RoomItem.Width & "x" & RoomItem.Height
    End Sub

    Private Sub buttonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class