Public Class Floor
    Inherits xyContainer
    Public Sub New()
        _Width = 10
        _Height = 10
        ReDim Contents(Width, Height)

        RoomColours.Add(Color.Beige)
        RoomColours.Add(Color.BlueViolet)
        RoomColours.Add(Color.DarkRed)
        RoomColours.Add(Color.BlanchedAlmond)
        RoomColours.Add(Color.Tomato)
        RoomColours.Add(Color.SlateBlue)
        RoomColours.Add(Color.Olive)
        RoomColours.Add(Color.White)
    End Sub

    Private RoomColours As New List(Of Color)
    Private RoomCount As Integer = 0
    Overloads Function Add(ByVal item As Room, ByVal x As Integer, ByVal y As Integer) As String
        Dim errorString As String = MyBase.Add(item, x, y)
        If errorString <> "" Then Return errorString

        item.Color = RoomColours(RoomCount)
        RoomCount += 1
        If RoomCount > RoomColours.Count - 1 Then RoomCount = 0
        Return Nothing
    End Function
End Class