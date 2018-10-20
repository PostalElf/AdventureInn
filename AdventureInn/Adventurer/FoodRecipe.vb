Public Class FoodRecipe
    Private Name As String
    Private iRequired As New List(Of String)
    Private iFilled As New List(Of String)
    Private Ingredients As New List(Of FoodIngredient)
    Public Function Add(ByVal fi As FoodIngredient) As String
        If iRequired.Contains(fi.IngredientType) = False Then Return "Ingredient type '" & fi.IngredientType & "' not required."

        iRequired.Remove(fi.IngredientType)
        iFilled.Add(fi.IngredientType)
        Ingredients.Add(fi)
        Return Nothing
    End Function
    Public Function Remove(ByVal fi As FoodIngredient) As String
        If Ingredients.Contains(fi) = False Then Return "Ingredient not found in recipe."

        iFilled.Remove(fi.IngredientType)
        iRequired.Add(fi.IngredientType)
        Ingredients.Remove(fi)
        Return Nothing
    End Function
    Public Function Export(ByVal inn As Inn) As Food
        If iRequired.Count > 0 Then Return Nothing

        Dim richness, meatiness, exoticness, quality As Integer
        For Each i In Ingredients
            richness += i.Richness
            meatiness += i.Meatiness
            exoticness += i.Exoticness
            quality += i.Quality

            inn.InventoryFoodIngredients.Remove(i)
        Next
        Return New Food(Name, richness, meatiness, exoticness, quality)
    End Function
End Class
