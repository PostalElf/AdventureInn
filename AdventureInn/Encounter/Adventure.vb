Public Class Adventure
    Public Shared Function Generate(ByVal pArea As String) As Adventure
        Dim a As New Adventure
        a.Area = pArea
        With a.Encounters

            If Rng.Next(1, 3) = 1 Then
                .Enqueue(Monster.Generate(pArea))
            Else
                .Enqueue(Trap.Generate(pArea))
            End If

            .Enqueue(Trap.Generate(pArea))
            .Enqueue(Monster.Generate(pArea))
            .Enqueue(Monster.Generate(pArea))
            .Enqueue(Monster.Generate(pArea))
        End With
        Return a
    End Function

    Private Area As String
    Private Encounters As New Queue(Of Encounter)
    Public Function CheckEncounters(ByVal party As Party) As Pair(Of List(Of String), List(Of LootItem))
        Dim totalReports As New List(Of String)
        Dim totalLoot As New List(Of LootItem)
        While Encounters.Count > 0
            Dim encounter As Encounter = Encounters.Dequeue
            Dim encounterResult As Pair(Of String, List(Of String)) = encounter.CheckEncounter(party)
            Dim report As String = encounterResult.Key
            If report <> "" Then totalReports.Add(report)
            Dim loot As List(Of String) = encounterResult.Value
            For Each l In loot
                Dim lootItem = FoodIngredient.Generate(l)
                If lootItem Is Nothing Then Continue For

                totalLoot.Add(lootItem)
            Next
        End While
        Return New Pair(Of List(Of String), List(Of LootItem))(totalReports, totalLoot)
    End Function
End Class
