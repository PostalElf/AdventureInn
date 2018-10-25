Public Class Party
    Private Const MaxSize As Integer = 4
    Private Adventurers As New List(Of Adventurer)
    Public Function Add(ByVal adventurer As Adventurer) As String
        If Adventurers.Count + 1 > MaxSize Then Return "Party is full."

        Adventurers.Add(adventurer)
        Return Nothing
    End Function
    Public Function CheckEncounter(ByVal job As Job, ByVal level As Integer, ByVal encounter As Encounter) As Pair(Of Adventurer, Boolean)
        If job = AdventurerInn.Job.Monster Then
            Dim successes As Integer = 0
            For Each a In Adventurers
                If a.CheckEncounter(job, level) = True Then successes += 1
            Next
            Dim success As Boolean = False
            If successes >= 2 Then success = True
            Return New Pair(Of Adventurer, Boolean)(GetRandom(Adventurers), success)
        Else
            Dim adventurer As Adventurer = GetBestFit(job, level)
            If adventurer Is Nothing Then adventurer = GetRandom(Adventurers)
            Return New Pair(Of Adventurer, Boolean)(adventurer, adventurer.CheckEncounter(job, level))
        End If
    End Function
    Private Function GetBestFit(ByVal job As Job, ByVal level As Integer) As Adventurer
        Dim bestfit As Adventurer = Nothing
        Dim highestLevel As Integer = -1
        For Each adv In Adventurers
            If adv.job = job Then
                If adv.level > highestLevel Then
                    bestfit = adv
                    highestLevel = adv.level
                End If
            End If
        Next
        Return bestfit
    End Function
End Class
