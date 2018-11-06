Public Class Trap
    Inherits Encounter
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
    Public Overloads Shared Function Generate(ByVal pArea As String) As Trap
        If AllTraps.Keys.Contains(pArea) = False Then Return Nothing

        Dim trapName As String = ""
        Dim traps As List(Of Trap) = AllTraps(pArea)
        If traps.Count = 0 Then
            Return Nothing
        ElseIf traps.Count = 1 Then
            trapName = traps(0).Name
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
        trap.Generate(targetName, rawdata)
        Return trap
    End Function

    Public Overrides Function GetLoot() As List(Of LootItem)
        Dim m As Monster = Monster.Generate(Area)
        Return m.GetLoot
    End Function
End Class
