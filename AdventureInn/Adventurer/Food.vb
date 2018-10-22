Public Class Food
    Protected Name As String
    Public Overrides Function ToString() As String
        Return Name
    End Function

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
            Return Name & " with " & ListToCommaString(IngredientNames, "&&")
        End Get
    End Property

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
End Class
