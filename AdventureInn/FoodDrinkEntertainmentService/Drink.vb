Public Class Drink
    Public Shared Function Generate(ByVal targetName As String, Optional ByVal rawdata As List(Of String) = Nothing) As Drink
        If rawdata Is Nothing Then
            rawdata = IO.ImportSquareBracketSelect(IO.sbdrinks, targetName)
            If rawdata Is Nothing Then Return Nothing
        End If

        Dim d As New Drink
        With d
            ._Name = targetName
            ._Fanciness = rawdata(0)
            ._Alcoholism = rawdata(1)
            ._Subtype = rawdata(2)
        End With
        Return d
    End Function

    Private _Name As String
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    Private _Fanciness As String
    Public ReadOnly Property Fanciness As String
        Get
            Return _Fanciness
        End Get
    End Property
    Private _Alcoholism As String
    Public ReadOnly Property Alcoholism As String
        Get
            Return _Alcoholism
        End Get
    End Property
    Private _Subtype As String
    Public ReadOnly Property Subtype As String
        Get
            Return _Subtype
        End Get
    End Property
End Class
