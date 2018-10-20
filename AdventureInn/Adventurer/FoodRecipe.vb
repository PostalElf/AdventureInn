Public Class FoodRecipe
    Private Name As String
    Private iRequired As New List(Of String)
    Private iFilled As New List(Of String)
    Private Ingredients As New List(Of FoodIngredient)

    Public Shared Function Generate(ByVal targetName As String) As FoodRecipe
        Dim rawData As List(Of String) = IO.ImportSquareBracketSelect(IO.sbRecipes, targetName)
        If rawData Is Nothing Then Return Nothing

        Dim fr As New FoodRecipe
        For Each l In rawData
            Dim rawsplit As String() = l.Split(":")
            Dim header As String = rawsplit(0).Trim
            Dim entry As String = rawsplit(1).Trim

            With fr
                Select Case header
                    Case "Name" : .Name = entry
                    Case "Ingredient" : .iRequired.Add(entry)
                End Select
            End With
        Next
        Return fr
    End Function
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
