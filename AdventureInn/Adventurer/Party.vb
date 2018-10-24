Public Class Party
    Private Const MaxSize As Integer = 4
    Private Adventurers As New List(Of Adventurer)
    Public Function Add(ByVal adventurer As Adventurer) As String
        If Adventurers.Count + 1 > MaxSize Then Return "Party is full."

        Adventurers.Add(adventurer)
        Return Nothing
    End Function
    Public Function CheckEncounter(ByVal job As Job, ByVal level As Integer) As Boolean
        Dim successes As Integer = 0
        For Each a In Adventurers
            If a.CheckEncounter(job, level) = True Then successes += 1
        Next

        'traps only require one success but only one adventurer can work on it
        'monsters require two successes but all adventurers can work on it
        If job = AdventurerInn.Job.Monster Then
            If successes >= 2 Then Return True
        Else
            If successes >= 1 Then Return True
        End If
        Return False
    End Function
End Class
