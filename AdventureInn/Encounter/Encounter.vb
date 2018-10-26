Public MustInherit Class Encounter
    Protected Sub New()
        Drops(0) = Drop1
        Drops(1) = Drop2
        Drops(2) = Drop3
        Drops(3) = Drop4
        Drops(4) = Drop5
    End Sub
    Protected Sub Generate(ByVal targetName As String, ByVal rawdata As List(Of String))
        For Each l In rawdata
            Dim rawsplit As String() = l.Split(":")
            Dim header As String = rawsplit(0).Trim
            Dim entry As String = rawsplit(1).Trim

            _Name = targetName
            Select Case header
                Case "Area" : _Area = entry
                Case "Level" : _Level = Convert.ToInt32(entry)
                Case "Job" : _Job = StringToEnum(Of Job)(entry)
                Case "Drop1" : Drop1.Add(CommaStringToPair(entry))
                Case "Drop2" : Drop2.Add(CommaStringToPair(entry))
                Case "Drop3" : Drop3.Add(CommaStringToPair(entry))
                Case "Drop4" : Drop4.Add(CommaStringToPair(entry))
                Case "Drop5" : Drop5.Add(CommaStringToPair(entry))
                Case "Success" : _SuccessString = entry
                Case "Failure" : _FailureString = entry
            End Select
        Next
    End Sub
    Private Shared Function CommaStringToPair(ByVal entry As String) As Pair(Of String, Integer)
        Dim rawsplit As String() = entry.Split(",")
        Dim key As String = rawsplit(0).Trim
        Dim value As Integer = Convert.ToInt32(rawsplit(1).Trim)

        Return New Pair(Of String, Integer)(key, value)
    End Function

    Private _Name As String
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    Private _Job As Job
    Public ReadOnly Property Job As Job
        Get
            Return _Job
        End Get
    End Property
    Private _Level As Integer
    Public ReadOnly Property Level As Integer
        Get
            Return _Level
        End Get
    End Property
    Private _Area As String
    Public ReadOnly Property Area As String
        Get
            Return _Area
        End Get
    End Property
    Private _SuccessString As String
    Private ReadOnly Property SuccessString As String
        Get
            If TypeOf Me Is Monster Then
                Dim adjectives As New List(Of String) From {"eviscerates", "destroys", "wipes out", "utterly devastates"}
                Return "The party " & GetRandom(adjectives) & " the " & Name & " and gets <loot>."
            Else
                Return _SuccessString
            End If
        End Get
    End Property
    Private _FailureString As String
    Private ReadOnly Property FailureString As String
        Get
            If TypeOf Me Is Monster Then
                Return "The party is shamefully forced to flee from the " & Name & "."
            Else
                Return _FailureString
            End If
        End Get
    End Property

    Private Drops(4) As List(Of Pair(Of String, Integer))
    Private Drop1 As New List(Of Pair(Of String, Integer))
    Private Drop2 As New List(Of Pair(Of String, Integer))
    Private Drop3 As New List(Of Pair(Of String, Integer))
    Private Drop4 As New List(Of Pair(Of String, Integer))
    Private Drop5 As New List(Of Pair(Of String, Integer))
    Public Function CheckEncounter(ByVal party As Party) As Pair(Of String, List(Of String))
        Dim loot As New List(Of String)
        Dim report As String
        Dim encounterResult As Pair(Of Adventurer, Boolean) = party.CheckEncounter(Job, Level, Me)
        If encounterResult.Value = True Then
            For n = 0 To 4
                If Drops(n).Count = 0 Then Exit For

                Dim roll As Integer = Rng.Next(1, 101)
                Dim currentCount As Integer = 0
                For Each entry In Drops(n)
                    currentCount += entry.Value
                    If roll <= currentCount Then loot.Add(entry.Key) : Exit For
                Next
            Next
            report = SuccessString
        Else
            report = FailureString
        End If
        report = ParseReport(encounterResult.Key, loot, report)
        Return New Pair(Of String, List(Of String))(report, loot)
    End Function
    Private Function ParseReport(ByVal adv As Adventurer, ByVal loot As List(Of String), ByVal str As String) As String
        Dim total As String = str
        total = total.Replace("<adventurer>", adv.ToString)
        total = total.Replace("<pronoun>", adv.pronoun)
        If loot.Count > 0 Then
            total = total.Replace("<loot>", ListToCommaString(loot, " && "))
        Else
            total = total.Replace("<loot>", "nothing")
        End If
        Return total
    End Function
End Class
