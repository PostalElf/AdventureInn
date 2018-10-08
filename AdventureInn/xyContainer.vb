Public MustInherit Class xyContainer
    Implements xy
    Protected _Width As Integer
    Public ReadOnly Property Width As Integer Implements xy.Width
        Get
            Return _Width
        End Get
    End Property
    Protected _Height As Integer
    Public ReadOnly Property Height As Integer Implements xy.Height
        Get
            Return _Height
        End Get
    End Property

    Protected Contents(,) As xy
    Default Public Property Index(ByVal x As Integer, ByVal y As Integer) As xy
        Get
            Return Contents(x, y)
        End Get
        Set(ByVal value As xy)
            Contents(x, y) = value
        End Set
    End Property
    Public Function Add(ByVal item As xy, ByVal x As Integer, ByVal y As Integer) As String
        If item.Width > x + Width - 1 Then Return "Item too wide."
        If item.Height > y + Height - 1 Then Return "Item too tall."

        For px = x To x + item.Width - 1
            For py = y To y + item.Height - 1
                If Contents(px, py) Is Nothing = False Then Return "Tile " & px & "," & py & " is occupied."
            Next
        Next

        For px = x To x + item.Width - 1
            For py = y To y + item.Height - 1
                Contents(px, py) = item
            Next
        Next
        Return Nothing
    End Function
    Public Function Remove(ByVal item As xy, ByVal x As Integer, ByVal y As Integer) As String
        For px = x To x + item.Width - 1
            For py = y To y + item.Height - 1
                If Contents(px, py) Is Nothing Then Return "Tile " & px & "," & py & " is empty."
            Next
        Next

        For px = x To x + item.Width - 1
            For py = y To y + item.Height - 1
                Contents(px, py) = Nothing
            Next
        Next
        Return Nothing
    End Function
End Class
