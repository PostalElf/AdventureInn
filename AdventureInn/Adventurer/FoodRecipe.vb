Public Class FoodRecipe
    Inherits Food
    Public Requirements As New List(Of String)
    Private iRequired As New List(Of String)
    Private iFilled As New List(Of String)
    Private Ingredients As New List(Of FoodIngredient)

    Public Overloads Shared Function Generate(ByVal targetName As String) As FoodRecipe
        Dim rawData As List(Of String) = IO.ImportSquareBracketSelect(IO.sbRecipes, targetName)
        If rawData Is Nothing Then Return Nothing

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
    Public Function Add(ByVal fi As FoodIngredient) As String
        If iRequired.Contains(fi.IngredientType) = False Then Return "Ingredient type '" & fi.IngredientType & "' not required."

        iRequired.Remove(fi.IngredientType)
        iFilled.Add(fi.IngredientType)
        Ingredients.Add(fi)

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

        Richness -= fi.Richness
        Meatiness -= fi.Meatiness
        Exoticness -= fi.Exoticness
        Quality -= fi.Quality

        Return Nothing
    End Function
    Public Function Clone() As FoodRecipe
        Dim fr As New FoodRecipe
        With fr
            .Name = Name
            If Requirements.Count > 0 Then .Requirements.AddRange(Requirements)
            If iRequired.Count > 0 Then .iRequired.AddRange(iRequired)
            If iFilled.Count > 0 Then .iFilled.AddRange(iFilled)
            If Ingredients.Count > 0 Then .Ingredients.AddRange(Ingredients)
        End With
        Return fr
    End Function
End Class
