Public Class Floor
    Inherits xyContainer
    Public Sub New()
        _Width = 8
        _Height = 8
        ReDim Contents(Width, Height)

        RoomColours.Add(Color.Beige)
        RoomColours.Add(Color.BlueViolet)
        RoomColours.Add(Color.DarkRed)
        RoomColours.Add(Color.AliceBlue)
        RoomColours.Add(Color.Tomato)
        RoomColours.Add(Color.SlateBlue)
        RoomColours.Add(Color.Olive)
        RoomColours.Add(Color.White)
    End Sub

    Private RoomColours As New List(Of Color)
    Private RoomCount As Integer = 0
    Private _Rooms As New List(Of Room)
    Public ReadOnly Property Rooms As List(Of Room)
        Get
            Return _Rooms
        End Get
    End Property
    Overloads Function Add(ByVal item As Room, ByVal x As Integer, ByVal y As Integer) As String
        Dim errorString As String = MyBase.Add(item, x, y)
        If errorString <> "" Then Return errorString

        item.Color = RoomColours(RoomCount)
        RoomCount += 1
        If RoomCount > RoomColours.Count - 1 Then RoomCount = 0

        _Rooms.Add(item)
        Return Nothing
    End Function
    Overloads Function Remove(ByVal item As Room) As String
        Dim errorString As String = MyBase.Remove(item)
        If errorString <> "" Then Return errorString

        _Rooms.Remove(item)
        Return Nothing
    End Function

    Public Function GetAdjacentRooms(ByVal room As Room) As List(Of Room)
        Dim RoomList As New List(Of Room)
        With room
            For x = .InitialX To .InitialX + .Width
                PopulateRoomList(RoomList, x, .InitialY - 1)
                PopulateRoomList(RoomList, x, .InitialY + .Height + 1)
            Next
            For y = .InitialY To .InitialY + .Height
                PopulateRoomList(RoomList, .InitialX - 1, y)
                PopulateRoomList(RoomList, .InitialX + .Width + 1, y)
            Next
        End With
        Return RoomList
    End Function
    Private Sub PopulateRoomList(ByRef roomList As List(Of Room), ByVal x As Integer, ByVal y As Integer)
        If x < 1 Then Exit Sub
        If y < 1 Then Exit Sub
        If x > Width Then Exit Sub
        If y > Height Then Exit Sub

        Dim room As Room = Contents(x, y)
        If room Is Nothing Then Exit Sub
        If roomList.Contains(room) = False Then roomList.Add(room)
    End Sub
End Class