Public Class RoomBed
    Inherits Room
    Public Sub New(ByVal _roomSize As RoomSize)
        MyBase.New(_roomSize)
    End Sub

    Public ReadOnly Property TotalPrivacy As Pair(Of String, Integer)
        Get
            Dim bedCount As Integer = GuestCapacity
            If bedCount <= 1 Then Return New Pair(Of String, Integer)("Private", bedCount) Else Return New Pair(Of String, Integer)("Communal", bedCount)
        End Get
    End Property
    Private _Guests As New List(Of Adventurer)
    Public ReadOnly Property Guests As List(Of Adventurer)
        Get
            Return _Guests
        End Get
    End Property
    Public Overridable ReadOnly Property GuestCapacity As Integer
        Get
            Dim bedCount As Integer = 0
            For Each ri In RoomItems
                bedCount += ri.Capacity
            Next
            Return bedCount
        End Get
    End Property
    Overloads Function Add(ByVal guest As Adventurer) As String
        If Guests.Count + 1 > GuestCapacity Then Return "No open beds."

        _Guests.Add(guest)
        Return Nothing
    End Function
    Overloads Function Remove(ByVal guest As Adventurer) As String
        If Guests.Contains(guest) = False Then Return "No such guest."

        _Guests.Remove(guest)
        Return Nothing
    End Function
End Class
