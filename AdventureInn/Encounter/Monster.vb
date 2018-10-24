﻿Public Class Monster
    Implements Encounter
    Private Shared AllMonsters As Dictionary(Of String, List(Of Monster)) = AllMonstersPopulate()
    Private Shared Function AllMonstersPopulate() As Dictionary(Of String, List(Of Monster))
        Dim all As New List(Of Monster)
        Dim allRawData As Dictionary(Of String, List(Of String)) = IO.ImportSquareBracketList(IO.sbMonsters)
        For Each key In allRawData.Keys
            Dim rawdata As List(Of String) = allRawData(key)
            all.Add(GenerateFromName(key, rawdata))
        Next

        Dim total As New Dictionary(Of String, List(Of Monster))
        For Each monster In all
            If total.ContainsKey(monster.Area) = False Then total.Add(monster.Area, New List(Of Monster))
            total(monster.Area).Add(monster)
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
    Public Shared Function Generate(ByVal pArea As String) As Monster
        If AllMonsters.Keys.Contains(pArea) = False Then Return Nothing

        Dim monsterName As String = ""
        Dim monsters As List(Of Monster) = AllMonsters(pArea)
        If monsters.Count = 0 Then
            Return Nothing
        ElseIf monsters.Count = 1 Then
            monsterName = monsters(0).Name
        Else
            Dim roll As Integer = Rng.Next(monsters.Count)
            monsterName = monsters(roll).Name
        End If
        Return GenerateFromName(monsterName)
    End Function
    Private Shared Function GenerateFromName(ByVal targetName As String, Optional ByVal rawData As List(Of String) = Nothing) As Monster
        If rawData Is Nothing Then
            rawData = IO.ImportSquareBracketSelect(IO.sbMonsters, targetName)
            If rawData Is Nothing Then Return Nothing
        End If

        Dim m As New Monster
        With m
            ._Name = targetName
            For Each l In rawData
                Dim rawsplit As String() = l.Split(":")
                Dim header As String = rawsplit(0).Trim
                Dim entry As String = rawsplit(1).Trim

                Select Case header
                    Case "Level" : ._Level = Convert.ToInt32(entry)
                    Case "Area" : ._Area = entry
                    Case "Drop1" : .Drop1.Add(CommaStringToPair(entry))
                    Case "Drop2" : .Drop2.Add(CommaStringToPair(entry))
                    Case "Drop3" : .Drop3.Add(CommaStringToPair(entry))
                    Case "Drop4" : .Drop4.Add(CommaStringToPair(entry))
                    Case "Drop5" : .Drop5.Add(CommaStringToPair(entry))
                End Select
            Next
        End With
        Return m
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
    Private _Level As Integer
    Public ReadOnly Property Level As Integer Implements Encounter.Level
        Get
            Return _Level
        End Get
    End Property
    Public ReadOnly Property Job As Job Implements Encounter.Job
        Get
            Return AdventurerInn.Job.Monster
        End Get
    End Property
    Private _Area As String
    Public ReadOnly Property Area As String
        Get
            Return _Area
        End Get
    End Property
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