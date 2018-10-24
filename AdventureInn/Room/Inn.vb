Public Class Inn
    Private Floors As New List(Of Floor)
    Default Public Property Index(ByVal i As Integer) As Floor
        Get
            If i > Floors.Count - 1 Then Return Nothing
            Return Floors(i)
        End Get
        Set(ByVal value As Floor)
            If i > Floors.Count - 1 Then Exit Property
            Floors(i) = value
        End Set
    End Property
    Public ReadOnly Property FloorsMax As Integer
        Get
            Return Floors.Count
        End Get
    End Property

    Public InventoryRoomItems As New List(Of RoomItem)
    Public InventoryFoodIngredients As New List(Of FoodIngredient)
    Public InventoryFoodRecipes As New List(Of FoodRecipe)
    Public InventoryFoodPreps As New List(Of FoodPrep)
    Public InventoryFood As New List(Of Food)
    Public Gold As Integer

    Public WaitingGuests As New List(Of Adventurer)

    Public Sub Add(ByVal floor As Floor)
        Floors.Add(floor)
    End Sub
    Public Sub Add(ByVal ri As RoomItem)
        InventoryRoomItems.Add(ri)
    End Sub
    Public Sub Add(ByVal fi As FoodIngredient)
        InventoryFoodIngredients.Add(fi)
    End Sub
    Public Sub Add(ByVal fr As FoodRecipe)
        InventoryFoodRecipes.Add(fr)
        InventoryFoodRecipes.Sort(New FoodRecipe.SortByName)
    End Sub
    Public Sub Add(ByVal fp As FoodPrep)
        InventoryFoodPreps.Add(fp)
        InventoryFoodPreps.Sort(New FoodPrep.sortbyname)
    End Sub
    Public Sub Add(ByVal f As Food)
        InventoryFood.Add(f)
    End Sub
    Public Sub Add(ByVal adventurer As Adventurer)
        WaitingGuests.Add(adventurer)
    End Sub
End Class
