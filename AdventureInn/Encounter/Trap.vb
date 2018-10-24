Public Class Trap
    Implements Encounter
    Private Shared AllTraps As Dictionary(Of String, List(Of Trap)) = AllTrapsPopulate()
    Private Shared Function AllTrapsPopulate() As Dictionary(Of String, List(Of Trap))
        Dim all As New List(Of Trap)
        Dim allRawData As Dictionary(Of String, List(Of String)) = IO.ImportSquareBracketList(IO.sbTraps)
        For Each key In allRawData.Keys
            Dim rawdata As List(Of String) = allRawData(key)
            all.Add(GenerateFromName(key, rawdata))
        Next

        Dim total As New Dictionary(Of String, List(Of Trap))
        For Each Trap In all
            If total.ContainsKey(Trap.Area) = False Then total.Add(Trap.Area, New List(Of Trap))
            total(Trap.Area).Add(Trap)
        Next
        Return total
    End Function
    Public Sub New()
        Drops(0) = Drop1
        Drops(1) = Drop2
        Drops(2) = Drop3
        Drops(3) = Drop4
        Drops(4) = Drop5
    End Sub
    Public Shared Function Generate(ByVal pArea As String) As Trap
        If AllTraps.Keys.Contains(pArea) = False Then Return Nothing

        Dim trapName As String = ""
        Dim traps As List(Of Trap) = AllTraps(pArea)
        If traps.Count = 0 Then
            Return Nothing
        ElseIf traps.Count = 1 Then
            trapName = ""
        Else
            Dim roll As Integer = Rng.Next(traps.Count)
            trapName = traps(roll).Name
        End If
        Return GenerateFromName(trapName)
    End Function
    Private Shared Function GenerateFromName(ByVal targetName As String, Optional ByVal rawdata As List(Of String) = Nothing) As Trap
        If rawdata Is Nothing Then
            rawdata = IO.ImportSquareBracketSelect(IO.sbTraps, targetName)
            If rawdata Is Nothing Then Return Nothing
        End If

        Dim trap As New Trap
        With trap
            For Each l In rawdata
                Dim rawsplit As String() = l.Split(":")
                Dim header As String = rawsplit(0).Trim
                Dim entry As String = rawsplit(1).Trim

                ._Name = targetName
                Select Case header
                    Case "Area" : .Area = entry
                    Case "Level" : ._Level = Convert.ToInt32(entry)
                    Case "Job" : ._Job = StringToEnum(Of Job)(entry)
                    Case "Drop1" : .Drop1.Add(CommaStringToPair(entry))
                    Case "Drop2" : .Drop2.Add(CommaStringToPair(entry))
                    Case "Drop3" : .Drop3.Add(CommaStringToPair(entry))
                    Case "Drop4" : .Drop4.Add(CommaStringToPair(entry))
                    Case "Drop5" : .Drop5.Add(CommaStringToPair(entry))
                End Select
            Next
        End With
        Return trap
    End Function
    Private Shared Function CommaStringToPair(ByVal entry As String) As Pair(Of String, Integer)
        Dim rawsplit As String() = entry.Split(",")
        Dim key As String = rawsplit(0).Trim
        Dim value As Integer = Convert.ToInt32(rawsplit(1).Trim)

        Return New Pair(Of String, Integer)(key, value)
    End Function

    Private _Name As String
    Public ReadOnly Property Name As String Implements Encounter.Name
        Get
            Return _Name
        End Get
    End Property
    Private _Job As Job
    Public ReadOnly Property Job As Job Implements Encounter.Job
        Get
            Return _Job
        End Get
    End Property
    Private _Level As Integer
    Public ReadOnly Property Level As Integer Implements Encounter.Level
        Get
            Return _Level
        End Get
    End Property
    Private Area As String

    Private Drops(4) As List(Of Pair(Of String, Integer))
    Private Drop1 As New List(Of Pair(Of String, Integer))
    Private Drop2 As New List(Of Pair(Of String, Integer))
    Private Drop3 As New List(Of Pair(Of String, Integer))
    Private Drop4 As New List(Of Pair(Of String, Integer))
    Private Drop5 As New List(Of Pair(Of String, Integer))
    Public Function GetLoot() As List(Of String) Implements Encounter.GetLoot
        Dim total As New List(Of String)
        For n = 0 To 4
            If Drops(n).Count = 0 Then Exit For

            Dim roll As Integer = Rng.Next(1, 101)
            Dim currentCount As Integer = 0
            For Each entry In Drops(n)
                currentCount += entry.Value
                If roll <= currentCount Then total.Add(entry.Key) : Exit For
            Next
        Next
        Return total
    End Function
End Class
