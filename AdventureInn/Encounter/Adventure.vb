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
    Public Function CheckEncounters(ByVal party As Party) As List(Of String)
        Dim totalLoot As New List(Of String)
        While Encounters.Count > 0
            Dim encounter As Encounter = Encounters.Dequeue
            Dim loot As List(Of String) = encounter.CheckEncounter(party)
            If loot.Count > 0 Then totalLoot.AddRange(loot)
        End While
        Return totalLoot
    End Function
End Class
