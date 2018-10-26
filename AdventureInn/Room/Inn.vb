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
    Private _Gold As Integer
    Public Property Gold As Integer
        Get
            Return _Gold
        End Get
        Set(ByVal value As Integer)
            _Gold = value
            RaiseEvent GoldChange()
        End Set
    End Property
    Public Event GoldChange()

    Public WaitingGuests As New List(Of Adventurer)
    Public ReadOnly Property RoomedGuests As List(Of Adventurer)
        Get
            Dim total As New List(Of Adventurer)
            For Each f In Floors
                For Each r In f.Rooms
                    If r.Guests.Count > 0 Then total.AddRange(r.Guests)
                Next
            Next
            Return total
        End Get
    End Property
    Public ExitingGuests As New Dictionary(Of Adventurer, Pair(Of String, Integer))
    Public ExitingParties As New List(Of Party)

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

    Public Sub EndNight()
        ExitingGuests.Clear()
        For Each Floor In Floors
            For Each Room In Floor.Rooms
                For Each guest In Room.Guests
                    Dim guestSatisfaction As Pair(Of String, Integer) = guest.RoomSatisfaction(Room)
                    ExitingGuests.Add(guest, guestSatisfaction)
                Next
                Room.Guests.Clear()
            Next
        Next

        WaitingGuests.Clear()
        For n = 1 To 10
            Dim g As Adventurer = Adventurer.Generate
            WaitingGuests.Add(g)
        Next
    End Sub
End Class
