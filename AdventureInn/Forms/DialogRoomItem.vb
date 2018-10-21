Public Class DialogRoomItem
    Public UseCase As String

    'RoomItem
    Public RoomItem As RoomItem = Nothing
    Public Inventory As List(Of RoomItem)

    'Room
    Public RoomSize As RoomSize
    Private RoomSizes As String() = {"2x2", "4x2", "4x4", "8x4"}
    Private RoomSizeDescriptions As String() = {"Slightly larger than a broom closet.", _
                                              "Snug and cosy, for a gnome.", _
                                              "The copper standard size for an inn room.", _
                                              "Enough room to swing a cat around in."}

    Private Sub DialogRoomItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UseCase = "RoomItem" Then
            For Each entry In Inventory
                ListBox1.Items.Add(entry.Name)
            Next
        ElseIf UseCase = "Room" Then
            For Each rs In [Enum].GetValues(GetType(RoomSize))
                ListBox1.Items.Add(rs.ToString)
            Next
        End If
    End Sub
    Private Sub Listbox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If UseCase = "RoomItem" Then
            Dim i As Integer = ListBox1.SelectedIndex
            RoomItem = Inventory(i)
            lblDescription.Text = RoomItem.AttributesDescription
            lblSize.Text = RoomItem.Width & "x" & RoomItem.Height
        ElseIf UseCase = "Room" Then
            Dim i As Integer = ListBox1.SelectedIndex
            RoomSize = i
            lblSize.Text = RoomSizes(i)
            lblDescription.Text = RoomSizeDescriptions(i)
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        buttonOK_Click(sender, e)
    End Sub
    Private Sub buttonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonOK.Click
        If ListBox1.SelectedItem Is Nothing Then Exit Sub
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class