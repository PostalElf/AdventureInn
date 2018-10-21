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
    Public Sub Add(ByVal floor As Floor)
        Floors.Add(floor)
    End Sub

    Public InventoryRoomItems As New List(Of RoomItem)
    Public InventoryFoodIngredients As New List(Of FoodIngredient)
    Public InventoryFood As New List(Of Food)
    Public Gold As Integer
End Class
