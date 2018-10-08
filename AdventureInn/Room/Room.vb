Public Class Room
    Inherits xyContainer
    Private Size As RoomSize
    Public Sub New(ByVal _size As RoomSize)
        Size = _size
        Select Case Size
            Case RoomSize.Tiny
                _Width = 2
                _Height = 2
            Case RoomSize.Small
                _Width = 4
                _Height = 2
            Case RoomSize.Standard
                _Width = 4
                _Height = 4
            Case RoomSize.Large
                _Width = 8
                _Height = 4
            Case RoomSize.Deluxe
                _Width = 8
                _Height = 8
        End Select
        Name = Size.ToString & " Room"
        ReDim Contents(Width, Height)
    End Sub

    Public Name As String
    Public Color As Color

    Private RoomItems As New List(Of RoomItem)
    Overloads Function Add(ByVal item As RoomItem, ByVal x As Integer, ByVal y As Integer) As String
        Dim errorString As String = MyBase.Add(item, x, y)
        If errorString <> "" Then Return errorString

        RoomItems.Add(item)
        Return Nothing
    End Function
    Overloads Function Remove(ByVal item As RoomItem) As String
        Dim errorstring As String = MyBase.Remove(item)
        If errorstring <> "" Then Return errorstring

        RoomItems.Remove(item)
        Return Nothing
    End Function
End Class

Public Enum RoomSize
    Tiny
    Small
    Standard
    Large
    Deluxe
End Enum