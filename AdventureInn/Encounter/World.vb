Public Class World
    Public Sub New()
        Dim areas As String() = {"Farmlands", "Forest", "Desert", "Ruins", "Hills", "Mountains"}
        For Each area In areas
            If LocationDescription.Keys.Contains(area) = False Then
                Dim desc As String = ""
                Select Case area
                    Case "Farmlands" : desc = "A calm, quiet place suitable for level 0 adventurers."
                    Case "Forest" : desc = "Full of monsters appropriately scaled for level 1-2 adventurers."
                    Case "Desert" : desc = "Endless sands with endless level 3-4 monsters."
                    Case "Ruins" : desc = "Dark corners filled with challenges for level 5-6 adventurers."
                    Case "Hills" : desc = "Challenging even for a party of level 7-8 adventurers."
                    Case "Mountains" : desc = "Fame and fortune awaits here for level 9 adventurers."
                End Select
                LocationDescription.Add(area, desc)
                LocationDanger.Add(area, 100)
            End If
        Next
    End Sub

    Public LocationDanger As New Dictionary(Of String, Integer)
    Public LocationDescription As New Dictionary(Of String, String)
    Public Function GetRandomLoot(ByVal area As String) As List(Of LootItem)
        Dim monsters As List(Of Monster) = Monster.AllMonsters(area)
        Dim m As Monster = GetRandom(monsters)
        Dim loot As List(Of LootItem) = m.GetLoot
        Return loot
    End Function
End Class
