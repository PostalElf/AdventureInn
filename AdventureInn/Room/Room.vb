Public Class Room
    Inherits xyContainer
    Private Size As RoomSize
    Public Sub New(ByVal _size As RoomSize)
        Size = _size
        Select Case Size
            Case RoomSize.Tiny
                _Width = 2
                _Height = 2
            Case RoomSize.Small
                _Width = 4
                _Height = 2
            Case RoomSize.Standard
                _Width = 4
                _Height = 4
            Case RoomSize.Large
                _Width = 8
                _Height = 4
            Case RoomSize.Deluxe
                _Width = 8
                _Height = 8
        End Select
        Name = Size.ToString & " Room"
        ReDim Contents(Width, Height)
    End Sub

    Public Name As String
    Public Color As Color

    Private RoomItems As New List(Of RoomItem)
    Overloads Function Add(ByVal item As RoomItem, ByVal x As Integer, ByVal y As Integer) As String
        Dim errorString As String = MyBase.Add(item, x, y)
        If errorString <> "" Then Return errorString

        RoomItems.Add(item)
        Return Nothing
    End Function
    Overloads Function Remove(ByVal item As RoomItem) As String
        Dim errorstring As String = MyBase.Remove(item)
        If errorstring <> "" Then Return errorstring

        RoomItems.Remove(item)
        Return Nothing
    End Function

    Public ReadOnly Property TotalPrivacy As Pair(Of String, Integer)
        Get
            Dim bedCount As Integer = 0
            For Each ri In RoomItems
                If ri.FurnitureType = "Bed" Then bedCount += 1
            Next

            If bedCount <= 1 Then Return New Pair(Of String, Integer)("Private", bedCount) Else Return New Pair(Of String, Integer)("Communal", bedCount)
        End Get
    End Property
    Public ReadOnly Property TotalFurnishing As Pair(Of String, Integer)
        Get
            Dim furnishing As Integer = 0
            For Each ri In RoomItems
                furnishing += ri.Furnishing
            Next

            Select Case furnishing
                Case Is <= 0 : Return New Pair(Of String, Integer)("Unfurnished", furnishing)
                Case 1 To 4 : Return New Pair(Of String, Integer)("Furnished", furnishing)
                Case Is >= 5 : Return New Pair(Of String, Integer)("Well Furnished", furnishing)
                Case Else : Throw New Exception
            End Select
        End Get
    End Property
    Public ReadOnly Property TotalOpulence As Pair(Of String, Integer)
        Get
            Dim opulence As Integer = 0
            For Each ri In RoomItems
                opulence += ri.Opulence
            Next

            Select Case opulence
                Case 0 : Return New Pair(Of String, Integer)("Boring", opulence)
                Case Is < 0 : Return New Pair(Of String, Integer)("Tasteful", opulence)
                Case Is > 0 : Return New Pair(Of String, Integer)("Opulent", opulence)
                Case Else : Throw New Exception
            End Select
        End Get
    End Property
    Public ReadOnly Property TotalRestfulness As Pair(Of String, Integer)
        Get
            Dim restfulness As Integer = 0
            For Each ri In RoomItems
                restfulness += ri.Restfulness
            Next

            Select Case restfulness
                Case 0 : Return New Pair(Of String, Integer)("Middling", restfulness)
                Case Is < 0 : Return New Pair(Of String, Integer)("Exciting", restfulness)
                Case Is > 0 : Return New Pair(Of String, Integer)("Restful", restfulness)
                Case Else : Throw New Exception
            End Select
        End Get
    End Property
    Public ReadOnly Property TotalAlignment As Pair(Of String, Integer)
        Get
            Dim lawfulness As Integer = 0
            For Each ri In RoomItems
                lawfulness += ri.Lawfulness
            Next

            Select Case lawfulness
                Case 0 : Return New Pair(Of String, Integer)("Neutral", lawfulness)
                Case Is < 0 : Return New Pair(Of String, Integer)("Chaotic", lawfulness)
                Case Is > 0 : Return New Pair(Of String, Integer)("Lawful", lawfulness)
                Case Else : Throw New Exception
            End Select
        End Get
    End Property
    Public ReadOnly Property TotalNiche As Pair(Of String, Integer)
        Get
            Dim faith, strength, focus, Curiosity As Integer
            For Each ri In RoomItems
                faith += ri.Faith
                strength += ri.Strength
                focus += ri.Focus
                Curiosity += ri.Curiosity
            Next

            Dim highestNiche As String = ""
            Dim highestValue As Integer = -1
            If faith > highestValue Then highestNiche = "Faith" : highestValue = faith
            If strength > highestValue Then highestNiche = "Strength" : highestValue = strength
            If focus > highestValue Then highestNiche = "Focus" : highestValue = focus
            If Curiosity > highestValue Then highestNiche = "Curiosity" : highestValue = Curiosity

            If highestValue <= 0 Then Return New Pair(Of String, Integer)("Bland", 0) Else Return New Pair(Of String, Integer)(highestNiche, highestValue)
        End Get
    End Property
End Class

Public Enum RoomSize
    Tiny
    Small
    Standard
    Large
    Deluxe
End Enum