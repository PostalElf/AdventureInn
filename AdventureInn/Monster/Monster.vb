Public Class Monster
    Public Shared AllMonsters As Dictionary(Of String, Monster) = AllMonstersPopulate
    Private Shared Function AllMonstersPopulate() As Dictionary(Of String, Monster)
        Dim total As New Dictionary(Of String, Monster)
        Dim allRawData As Dictionary(Of String, List(Of String)) = IO.ImportSquareBracketList(IO.sbMonsters)
        For Each key In allRawData.Keys
            Dim rawdata As List(Of String) = allRawData(key)
            total.Add(key, Generate(key, rawdata))
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
    Public Shared Function Generate(ByVal targetName As String, Optional ByVal rawData As List(Of String) = Nothing) As Monster
        If rawData Is Nothing Then
            rawData = IO.ImportSquareBracketSelect(IO.sbMonsters, targetName)
            If rawdata Is Nothing Then Return Nothing
        End If

        Dim m As New Monster
        With m
            ._Name = targetName
            For Each l In rawdata
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
    Public ReadOnly Property Name As String
        Get
            Return _Name
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
    Private Drops(4) As List(Of Pair(Of String, Integer))
    Private Drop1 As New List(Of Pair(Of String, Integer))
    Private Drop2 As New List(Of Pair(Of String, Integer))
    Private Drop3 As New List(Of Pair(Of String, Integer))
    Private Drop4 As New List(Of Pair(Of String, Integer))
    Private Drop5 As New List(Of Pair(Of String, Integer))

    Public Function RollLoot() As List(Of String)
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
