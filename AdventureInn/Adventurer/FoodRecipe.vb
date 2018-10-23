Public Class FoodRecipe
    Inherits Food
    Public Shared AllFoodRecipes As Dictionary(Of String, FoodRecipe) = AllFoodRecipesPopulate
    Private Shared Function AllFoodRecipesPopulate() As Dictionary(Of String, FoodRecipe)
        Dim total As New Dictionary(Of String, FoodRecipe)
        Dim allRawData As Dictionary(Of String, List(Of String)) = IO.ImportSquareBracketList(IO.sbRecipes)
        For Each key In allRawData.Keys
            Dim rawdata As List(Of String) = allRawData(key)
            total.Add(key, Generate(key, rawdata))
        Next
        Return total
    End Function
    Public Overloads Shared Function Generate(ByVal targetName As String, Optional ByVal rawdata As List(Of String) = Nothing) As FoodRecipe
        If rawdata Is Nothing Then
            rawdata = IO.ImportSquareBracketSelect(IO.sbRecipes, targetName)
            If rawData Is Nothing Then Return Nothing
        End If

        Dim fr As New FoodRecipe
        With fr
            .Name = targetName
            For Each l In rawData
                .Requirements.Add(l)
                .iRequired.Add(l)
            Next
        End With
        Return fr
    End Function

    Public Requirements As New List(Of String)
    Protected iRequired As New List(Of String)
    Protected iFilled As New List(Of String)
    Protected Ingredients As New List(Of FoodIngredient)
    Public ReadOnly Property Completed As Boolean
        Get
            If iRequired.Count = 0 Then Return True Else Return False
        End Get
    End Property

    Public Function Add(ByVal fi As FoodIngredient) As String
        If iRequired.Contains(fi.IngredientType) = False Then Return "Ingredient type '" & fi.IngredientType & "' not required."

        iRequired.Remove(fi.IngredientType)
        iFilled.Add(fi.IngredientType)
        Ingredients.Add(fi)
        IngredientNames.Add(fi.Name)

        Richness += fi.Richness
        Meatiness += fi.Meatiness
        Exoticness += fi.Exoticness
        Quality += fi.Quality

        Return Nothing
    End Function
    Public Function Remove(ByVal fi As FoodIngredient) As String
        If Ingredients.Contains(fi) = False Then Return "Ingredient not found in recipe."

        iFilled.Remove(fi.IngredientType)
        iRequired.Add(fi.IngredientType)
        Ingredients.Remove(fi)
        IngredientNames.Remove(fi.Name)

        Richness -= fi.Richness
        Meatiness -= fi.Meatiness
        Exoticness -= fi.Exoticness
        Quality -= fi.Quality

        Return Nothing
    End Function
    Public Function Clear() As List(Of FoodIngredient)
        Dim total As New List(Of FoodIngredient)(Ingredients)
        Ingredients.Clear()
        Return total
    End Function
End Class
