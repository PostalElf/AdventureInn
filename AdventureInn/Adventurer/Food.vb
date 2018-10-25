Public Class Food
    Public Shared Function Generate(ByVal recipe As FoodRecipe) As Food
        Dim f As New Food
        With f
            .Name = recipe.Name
            .Richness = recipe.Richness
            .Meatiness = recipe.Meatiness
            .Exoticness = recipe.Exoticness
            .Quality = recipe.Quality
            .IngredientNames.AddRange(recipe.IngredientNames)
        End With
        Return f
    End Function
    Public Overrides Function ToString() As String
        Return Name
    End Function

    Protected Name As String
    Protected Richness As Integer
    Public ReadOnly Property TotalRichness As Pair(Of String, Integer)
        Get
            Dim total As String = ""
            Select Case Richness
                Case 0 : total = "Confused"
                Case Is < 0 : total = "Plain"
                Case Is > 0 : total = "Rich"
            End Select
            Return New Pair(Of String, Integer)(total, Richness)
        End Get
    End Property
    Protected Meatiness As Integer
    Public ReadOnly Property TotalMeatiness As Pair(Of String, Integer)
        Get
            Dim total As String = ""
            Select Case Meatiness
                Case 0 : total = "Mashed"
                Case Is < 0 : total = "Vegetarian"
                Case Is > 0 : total = "Meat"
            End Select
            Return New Pair(Of String, Integer)(total, Meatiness)
        End Get
    End Property
    Protected Exoticness As Integer
    Public ReadOnly Property TotalExoticness As Pair(Of String, Integer)
        Get
            Dim total As String = ""
            Select Case Exoticness
                Case 0 : total = "Ugh"
                Case Is < 0 : total = "Common"
                Case Is > 0 : total = "Exotic"
            End Select
            Return New Pair(Of String, Integer)(total, Exoticness)
        End Get
    End Property
    Protected Quality As Integer
    Public ReadOnly Property TotalQuality As Pair(Of String, Integer)
        Get
            Dim total As String = ""
            Select Case Quality
                Case Is <= 0 : total = "Poor"
                Case 1 To 4 : total = "Good"
                Case Is >= 5 : total = "Extraordinary"
            End Select
            Return New Pair(Of String, Integer)(total, Quality)
        End Get
    End Property

    Protected IngredientNames As New List(Of String)
    Public ReadOnly Property AttributesDescription As String
        Get
            Dim total As String = ""
            total &= "Quality: " & TotalQuality.Key & vbCrLf
            total &= "Richness: " & TotalRichness.Key & vbCrLf
            total &= "Meatiness: " & TotalMeatiness.Key & vbCrLf
            total &= "Exoticness: " & TotalExoticness.Key
            Return total
        End Get
    End Property
    Public ReadOnly Property FullName As String
        Get
            Return Name & " with " & ListToCommaString(IngredientNames, " && ")
        End Get
    End Property

    Public Class SortByName
        Implements IComparer(Of Food)
        Public Function Compare(ByVal x As Food, ByVal y As Food) As Integer Implements System.Collections.Generic.IComparer(Of Food).Compare
            Return String.Compare(x.Name, y.Name)
        End Function
    End Class
    Public Class SortByRichness
        Implements IComparer(Of Food)
        Public Function Compare(ByVal x As Food, ByVal y As Food) As Integer Implements System.Collections.Generic.IComparer(Of Food).Compare
            If x.Richness < y.Richness Then
                Return 1
            ElseIf x.Richness > y.Richness Then
                Return -1
            Else
                Return 0
            End If
        End Function
    End Class
    Public Class SortByMeatiness
        Implements IComparer(Of Food)
        Public Function Compare(ByVal x As Food, ByVal y As Food) As Integer Implements System.Collections.Generic.IComparer(Of Food).Compare
            If x.Meatiness < y.Meatiness Then
                Return 1
            ElseIf x.Meatiness > y.Meatiness Then
                Return -1
            Else
                Return 0
            End If
        End Function
    End Class
    Public Class SortByExoticness
        Implements IComparer(Of Food)
        Public Function Compare(ByVal x As Food, ByVal y As Food) As Integer Implements System.Collections.Generic.IComparer(Of Food).Compare
            If x.Exoticness < y.Exoticness Then
                Return 1
            ElseIf x.Exoticness > y.Exoticness Then
                Return -1
            Else
                Return 0
            End If
        End Function
    End Class
    Public Class SortByQuality
        Implements IComparer(Of Food)
        Public Function Compare(ByVal x As Food, ByVal y As Food) As Integer Implements System.Collections.Generic.IComparer(Of Food).Compare
            If x.Quality < y.Quality Then
                Return 1
            ElseIf x.Quality > y.Quality Then
                Return -1
            Else
                Return 0
            End If
        End Function
    End Class
End Class
