Public Class Floor
    Inherits xyContainer
    Public Sub New()
        _Width = 10
        _Height = 10
        ReDim Contents(Width, Height)
    End Sub
End Class