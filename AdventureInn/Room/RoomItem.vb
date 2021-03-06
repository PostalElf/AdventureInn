﻿Public Class RoomItem
    Implements xy, IComparable
    Public Shared AllRoomItems As Dictionary(Of String, RoomItem) = AllRoomItemsPopulate()
    Private Shared Function AllRoomItemsPopulate() As Dictionary(Of String, RoomItem)
        Dim total As New Dictionary(Of String, RoomItem)
        Dim allRawData As Dictionary(Of String, List(Of String)) = IO.ImportSquareBracketList(IO.sbRooms)
        For Each key In allRawData.Keys
            Dim rawdata As List(Of String) = allRawData(key)
            total.Add(key, Generate(key, rawdata))
        Next
        Return total
    End Function
    Public Shared Function Generate(ByVal targetName As String, Optional ByVal rawdata As List(Of String) = Nothing) As RoomItem
        If rawdata Is Nothing Then
            rawdata = IO.ImportSquareBracketSelect(IO.sbRooms, targetName)
            If rawdata Is Nothing Then Return Nothing
        End If

        Dim ri As New RoomItem
        For Each line In rawdata
            Dim linesplit As String() = line.Split(":")
            Dim header As String = linesplit(0).Trim
            Dim entry As String = linesplit(1).Trim

            With ri
                ._Name = targetName
                Select Case header
                    Case "Width" : ._Width = Convert.ToInt32(entry)
                    Case "Height" : ._Height = Convert.ToInt32(entry)
                    Case "Cost" : ._Cost = Convert.ToInt32(entry)
                    Case "Description" : ._Description = entry

                    Case "Capacity" : ._Capacity = Convert.ToInt32(entry)
                    Case "Furnishing" : ._Furnishing = Convert.ToInt32(entry)
                    Case "Opulence" : ._Opulence = Convert.ToInt32(entry)
                    Case "Tastefulness" : ._Opulence = Convert.ToInt32(-entry)
                    Case "Restfulness" : ._Restfulness = Convert.ToInt32(entry)
                    Case "Excitement" : ._Restfulness = Convert.ToInt32(-entry)
                    Case "Law", "Lawfulness" : ._Lawfulness = Convert.ToInt32(entry)
                    Case "Chaos" : ._Lawfulness = Convert.ToInt32(-entry)
                    Case "Faith" : ._Faith = Convert.ToInt32(entry)
                    Case "Strength" : ._Strength = Convert.ToInt32(entry)
                    Case "Focus" : ._Focus = Convert.ToInt32(entry)
                    Case "Curiosity" : ._Curiosity = Convert.ToInt32(entry)
                End Select
            End With
        Next
        Return ri
    End Function
    Public Overrides Function ToString() As String
        Return Name
    End Function

    Private _Name As String
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    Private _Description As String
    Public ReadOnly Property Description As String
        Get
            Return _Description
        End Get
    End Property
    Private _Cost As Integer
    Public ReadOnly Property Cost As Integer
        Get
            Return _Cost
        End Get
    End Property
    Private _Width As Integer
    Public ReadOnly Property Width As Integer Implements xy.Width
        Get
            Return _Width
        End Get
    End Property
    Private _Height As Integer
    Public ReadOnly Property Height As Integer Implements xy.Height
        Get
            Return _Height
        End Get
    End Property
    Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
        Dim ri As RoomItem = CType(obj, RoomItem)
        Return String.Compare(Me.Name, ri.Name)
    End Function
    Private Property InitialX As Integer Implements xy.InitialX
    Private Property InitialY As Integer Implements xy.InitialY

    Private _Capacity As Integer
    Public ReadOnly Property Capacity As Integer
        Get
            Return _Capacity
        End Get
    End Property
    Private _Furnishing As Integer
    Public ReadOnly Property Furnishing As Integer
        Get
            Return _Furnishing
        End Get
    End Property
    Private _Opulence As Integer
    Public ReadOnly Property Opulence As Integer
        Get
            Return _Opulence
        End Get
    End Property
    Private _Restfulness As Integer
    Public ReadOnly Property Restfulness As Integer
        Get
            Return _Restfulness
        End Get
    End Property
    Private _Lawfulness As Integer
    Public ReadOnly Property Lawfulness As Integer
        Get
            Return _Lawfulness
        End Get
    End Property
    Private _Faith As Integer
    Public ReadOnly Property Faith As Integer
        Get
            Return _Faith
        End Get
    End Property
    Private _Strength As Integer
    Public ReadOnly Property Strength As Integer
        Get
            Return _Strength
        End Get
    End Property
    Private _Focus As Integer
    Public ReadOnly Property Focus As Integer
        Get
            Return _Focus
        End Get
    End Property
    Private _Curiosity As Integer
    Public ReadOnly Property Curiosity As Integer
        Get
            Return _Curiosity
        End Get
    End Property

    Public ReadOnly Property AttributesDescription As String
        Get
            Dim total As String = ""
            total &= "Capacity: " & Capacity & vbCrLf
            ParseDescription(total, "Furnishing", Furnishing)
            ParseDescription(total, "Opulence", Opulence)
            ParseDescription(total, "Restfulness", Restfulness)
            ParseDescription(total, "Lawfulness", Lawfulness)
            ParseDescription(total, "Faith", Faith)
            ParseDescription(total, "Strength", Strength)
            ParseDescription(total, "Focus", Focus)
            ParseDescription(total, "Curiosity", Curiosity)
            Return total
        End Get
    End Property
    Private Sub ParseDescription(ByRef total As String, ByVal prefix As String, ByVal value As Integer)
        If value = 0 Then Exit Sub

        Dim truePrefix As String = prefix
        Dim invertValue As Integer = 1
        Select Case prefix
            Case "Opulence" : If value < 0 Then truePrefix = "Tastefulness" : invertValue = -1
            Case "Restfulness" : If value < 0 Then truePrefix = "Excitement" : invertValue = -1
            Case "Lawfulness" : If value < 0 Then truePrefix = "Chaos" : invertValue = -1
        End Select

        total &= truePrefix & ": "
        value *= invertValue
        If value > 0 Then total &= "+"
        total &= value & vbCrLf
    End Sub
End Class
