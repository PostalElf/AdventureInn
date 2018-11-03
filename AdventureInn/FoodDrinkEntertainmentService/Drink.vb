Public Class Drink
    Public Shared AllDrinks As SortedDictionary(Of String, Drink) = PopulateAllDrinks()
    Private Shared Function PopulateAllDrinks() As SortedDictionary(Of String, Drink)
        Dim total As New SortedDictionary(Of String, Drink)
        Dim allRawData As Dictionary(Of String, List(Of String)) = IO.ImportSquareBracketList(IO.sbDrinks)
        For Each key In allRawData.Keys
            Dim rawdata As List(Of String) = allRawData(key)
            total.Add(key, Generate(key, rawdata))
        Next
        Return total
    End Function
    Public Shared Function Generate(ByVal targetName As String, Optional ByVal rawdata As List(Of String) = Nothing) As Drink
        If rawdata Is Nothing Then
            rawdata = IO.ImportSquareBracketSelect(IO.sbDrinks, targetName)
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
    Public Overrides Function ToString() As String
        Return Name
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

    Public ReadOnly Property AttributesDescription As String
        Get
            Return Fanciness & " " & Alcoholism & ", " & Subtype
        End Get
    End Property

    Public Class SortByName
        Implements IComparer(Of Drink)
        Public Function Compare(ByVal x As Drink, ByVal y As Drink) As Integer Implements System.Collections.Generic.IComparer(Of Drink).Compare
            Return String.Compare(x.Name, y.Name)
        End Function
    End Class
    Public Class SortByFanciness
        Implements IComparer(Of Drink)
        Public Function Compare(ByVal x As Drink, ByVal y As Drink) As Integer Implements System.Collections.Generic.IComparer(Of Drink).Compare
            Return String.Compare(x.Fanciness, y.Fanciness)
        End Function
    End Class
    Public Class SortByAlcoholism
        Implements IComparer(Of Drink)
        Public Function Compare(ByVal x As Drink, ByVal y As Drink) As Integer Implements System.Collections.Generic.IComparer(Of Drink).Compare
            Return String.Compare(x.Alcoholism, y.Alcoholism)
        End Function
    End Class
    Public Class SortBySubtype
        Implements IComparer(Of Drink)
        Public Function Compare(ByVal x As Drink, ByVal y As Drink) As Integer Implements System.Collections.Generic.IComparer(Of Drink).Compare
            Return String.Compare(x.Subtype, y.Subtype)
        End Function
    End Class
End Class
