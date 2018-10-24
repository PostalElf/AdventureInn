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

    Const PartyMaxSize As Integer = 4
    Private Party As New List(Of Adventurer)
    Public Function Add(ByVal adventurer As Adventurer) As String
        If Party.Count + 1 > PartyMaxSize Then Return "No space in party."

        Party.Add(adventurer)
        Return Nothing
    End Function

    Private Area As String
    Private Encounters As New Queue(Of Encounter)
End Class
