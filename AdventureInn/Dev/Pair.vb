Public Class Pair(Of T, P)
    Public Key As T
    Public Value As P
    Public Sub New(ByVal _key As T, ByVal _value As P)
        Key = _key
        Value = _value
    End Sub
End Class
