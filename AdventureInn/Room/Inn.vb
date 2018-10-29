Public Class Inn
    Public Sub New()
        For n = 1 To RecurringGuestNumber
            RecurringGuests.Add(Adventurer.Generate)
        Next
        Dim allGuests As New List(Of Adventurer)(RecurringGuests)
        For n = 1 To 10
            WaitingGuests.Add(GrabRandom(allGuests))
        Next
    End Sub

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
    Public InventoryFood As New List(Of Food)
    Public InventoryFoodIngredients As New List(Of FoodIngredient)
    Public InventoryFoodRecipes As New List(Of FoodRecipe)
    Public InventoryFoodPreps As New List(Of FoodPrep)
    Public InventoryDrinks As New List(Of Drink)
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
                    If TypeOf r Is RoomBed Then
                        Dim b As RoomBed = CType(r, RoomBed)
                        If b.Guests.Count > 0 Then total.AddRange(b.Guests)
                    End If
                Next
            Next
            Return total
        End Get
    End Property
    Const RecurringGuestNumber As Integer = 20
    Private RecurringGuests As New List(Of Adventurer)

    Public MenuFood As New List(Of Food)
    Public MenuDrink As New List(Of Drink)
    Private Function GetBestFood(ByVal adv As Adventurer) As Food
        If MenuFood.Count = 0 Then Return Nothing
        If MenuFood.Count = 1 Then Return MenuFood(0)

        Dim highestStars As Integer = -1
        Dim bestFood As Food = Nothing
        For Each f In MenuFood
            Dim stars As Integer = adv.FoodSatisfaction(f).Value
            If stars > highestStars Then
                highestStars = -1
                bestFood = f
            End If
        Next
        Return bestFood
    End Function
    Private Function GetBestDrink(ByVal adv As Adventurer, ByVal food As Food, ByVal bar As Room) As Drink
        If MenuDrink.Count = 0 Then Return Nothing
        If MenuDrink.Count = 1 Then Return MenuDrink(1)

        Dim highestStars As Integer = -1
        Dim best As Drink = Nothing
        For Each d In MenuDrink
            Dim stars As Integer = adv.DrinkSatisfaction(d, food, bar).Value
            If stars > highestStars Then
                highestStars = -1
                best = d
            End If
        Next
        Return best
    End Function
    Private Function GetBestEntertainment(ByVal adv As Adventurer) As Entertainment
        Return Nothing
    End Function
    Private Function GetBestService(ByVal adv As Adventurer) As Service
        Return Nothing
    End Function
    Public GuestsRoomSatisfaction As New Dictionary(Of Adventurer, Pair(Of String, Integer))
    Public GuestsFoodSatisfaction As New Dictionary(Of Adventurer, Pair(Of String, Integer))
    Public GuestsDrinkSatisfaction As New Dictionary(Of Adventurer, Pair(Of String, Integer))
    Public GuestsEntertainmentSatisfaction As New Dictionary(Of Adventurer, Pair(Of String, Integer))
    Public GuestsServiceSatisfaction As New Dictionary(Of Adventurer, Pair(Of String, Integer))
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
        InventoryFoodPreps.Sort(New FoodPrep.SortByName)
    End Sub
    Public Sub Add(ByVal f As Food)
        InventoryFood.Add(f)
    End Sub
    Public Sub Add(ByVal adventurer As Adventurer)
        WaitingGuests.Add(adventurer)
    End Sub

    Private ReadOnly Property Bar As Room
        Get
            For Each f In Floors
                For Each r In f.Rooms
                    If TypeOf r Is RoomBar Then Return r
                Next
            Next
            Return Nothing
        End Get
    End Property
    Public Sub EndNight()
        GuestsFoodSatisfaction.Clear()
        GuestsRoomSatisfaction.Clear()
        For Each Floor In Floors
            For Each Room In Floor.Rooms
                If TypeOf Room Is RoomBed Then
                    Dim bedroom As RoomBed = CType(Room, RoomBed)
                    For Each guest In bedroom.Guests
                        Dim food As Food = GetBestFood(guest)
                        Dim drink As Drink = GetBestDrink(guest, food, Bar)

                        GuestsRoomSatisfaction.Add(guest, guest.RoomSatisfaction(bedroom))
                        GuestsFoodSatisfaction.Add(guest, guest.FoodSatisfaction(food))
                        GuestsDrinkSatisfaction.Add(guest, guest.DrinkSatisfaction(drink, food, Bar))
                        GuestsEntertainmentSatisfaction.Add(guest, guest.EntertainmentSatisfaction(GetBestEntertainment(guest)))
                        GuestsServiceSatisfaction.Add(guest, guest.ServiceSatisfaction(GetBestService(guest)))
                    Next
                    bedroom.Guests.Clear()
                End If
            Next
        Next

        MenuFood.Clear()
        MenuDrink.Clear()

        'repopulate guest list
        While RecurringGuests.Count < RecurringGuestNumber
            Dim g As Adventurer = Adventurer.Generate
            RecurringGuests.Add(g)
        End While
        WaitingGuests.Clear()
        Dim allGuests As New List(Of Adventurer)(RecurringGuests)
        For n = 1 To 10
            WaitingGuests.Add(GrabRandom(allGuests))
        Next
    End Sub
End Class
