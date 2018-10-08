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
        _Name = Size.ToString & " Room"
        ReDim Contents(Width, Height)
    End Sub

    Private _Name As String
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
End Class

Public Enum RoomSize
    Tiny
    Small
    Standard
    Large
    Deluxe
End Enum