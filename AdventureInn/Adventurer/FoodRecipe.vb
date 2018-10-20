Public Class FoodRecipe
    Private Name As String
    Private iRequired As New List(Of String)
    Private iFilled As New List(Of String)
    Private Ingredients As New List(Of FoodIngredient)
    Public Sub Add(ByVal fi As FoodIngredient)
        If iRequired.Contains(fi.IngredientType) = False Then Exit Sub

        iRequired.Remove(fi.IngredientType)
        iFilled.Add(fi.IngredientType)
        Ingredients.add(fi)
    End Sub
    Public Sub Remove(ByVal fi As FoodIngredient)
        If Ingredients.Contains(fi) = False Then Exit Sub

        iFilled.Remove(fi.IngredientType)
        iRequired.Add(fi.IngredientType)
        Ingredients.Remove(fi)
    End Sub
    Public Function Export() As Food
        If iRequired.Count > 0 Then Return Nothing

        Dim richness, meatiness, exoticness, quality As Integer
        For Each i In Ingredients
            richness += i.Richness
            meatiness += i.Meatiness
            exoticness += i.Exoticness
            quality += i.Quality
        Next
        Return New Food(Name, richness, meatiness, exoticness, quality)
    End Function
End Class
