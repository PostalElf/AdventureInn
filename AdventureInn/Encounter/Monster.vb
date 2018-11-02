Public Class Monster
    Inherits Encounter
    Public Shared AllMonsters As Dictionary(Of String, List(Of Monster)) = AllMonstersPopulate()
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
    Public Overloads Shared Function Generate(ByVal pArea As String) As Monster
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
        m.Generate(targetName, rawData)
        Return m
    End Function
    Private Shared Function CommaStringToPair(ByVal entry As String) As Pair(Of String, Integer)
        Dim rawsplit As String() = entry.Split(",")
        Dim key As String = rawsplit(0).Trim
        Dim value As Integer = Convert.ToInt32(rawsplit(1).Trim)

        Return New Pair(Of String, Integer)(key, value)
    End Function
End Class
