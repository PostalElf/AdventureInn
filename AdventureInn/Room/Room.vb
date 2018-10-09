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

    Public ReadOnly Property TotalFurnishing As String
        Get
            Dim furnishing As Integer = 0
            For Each ri In RoomItems
                furnishing += ri.Furnishing
            Next

            Select Case Furnishing
                Case Is <= 0 : Return "Unfurnished"
                Case 1 To 4 : Return "Barely Furnished"
                Case Is >= 5 : Return "Well Furnished"
                Case Else : Throw New Exception
            End Select
        End Get
    End Property
    Public ReadOnly Property TotalOpulence As String
        Get
            Dim opulence As Integer = 0
            For Each ri In RoomItems
                opulence += ri.Opulence
            Next

            Select Case Opulence
                Case 0 : Return "Boring"
                Case Is < 0 : Return "Tasteful"
                Case Is > 0 : Return "Opulent"
                Case Else : Throw New Exception
            End Select
        End Get
    End Property
    Public ReadOnly Property TotalRestfulness As String
        Get
            Dim restfulness As Integer = 0
            For Each ri In RoomItems
                restfulness += ri.Restfulness
            Next

            Select Case Restfulness
                Case 0 : Return "Middling"
                Case Is < 0 : Return "Exciting"
                Case Is > 0 : Return "Restful"
                Case Else : Throw New Exception
            End Select
        End Get
    End Property
    Public ReadOnly Property TotalAlignment As String
        Get
            Dim lawfulness As Integer = 0
            For Each ri In RoomItems
                lawfulness += ri.Lawfulness
            Next

            Select Case Lawfulness
                Case 0 : Return "Neutral"
                Case Is < 0 : Return "Chaotic"
                Case Is > 0 : Return "Lawful"
                Case Else : Throw New Exception
            End Select
        End Get
    End Property
    Public ReadOnly Property TotalNiche As String
        Get
            Dim faith, strength, focus, tinkering As Integer
            For Each ri In RoomItems
                faith += ri.Faith
                strength += ri.Strength
                focus += ri.Focus
                tinkering += ri.Tinkering
            Next

            Dim highestNiche As String = ""
            Dim highestValue As Integer = -1
            If Faith > highestValue Then highestNiche = "Faith" : highestValue = Faith
            If Strength > highestValue Then highestNiche = "Strength" : highestValue = Strength
            If Focus > highestValue Then highestNiche = "Focus" : highestValue = Focus
            If Tinkering > highestValue Then highestNiche = "Tinkering" : highestValue = Tinkering

            Return highestNiche
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