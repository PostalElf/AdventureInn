Public Class Food
    Private _Richness As Integer
    Public ReadOnly Property TotalRichness As Pair(Of String, Integer)
        Get
            Dim total As String = ""
            Select Case _Richness
                Case 0 : total = "Confused"
                Case Is < 0 : total = "Plain"
                Case Is > 0 : total = "Rich"
            End Select
            Return New Pair(Of String, Integer)(total, _Richness)
        End Get
    End Property
    Private _Meatiness As Integer
    Public ReadOnly Property TotalMeatiness As Pair(Of String, Integer)
        Get
            Dim total As String = ""
            Select Case _Meatiness
                Case 0 : total = "Mashed"
                Case Is < 0 : total = "Vegetarian"
                Case Is > 0 : total = "Meat"
            End Select
            Return New Pair(Of String, Integer)(total, _Meatiness)
        End Get
    End Property
    Private _Exoticness As Integer
    Public ReadOnly Property TotalExoticness As Pair(Of String, Integer)
        Get
            Dim total As String = ""
            Select Case _Exoticness
                Case 0 : total = "Ugh"
                Case Is < 0 : total = "Common"
                Case Is > 0 : total = "Exotic"
            End Select
            Return New Pair(Of String, Integer)(total, _Exoticness)
        End Get
    End Property
    Private _Quality As Integer
    Public ReadOnly Property TotalQuality As Pair(Of String, Integer)
        Get
            Dim total As String = ""
            Select Case _Quality
                Case Is <= 0 : total = "Poor"
                Case 1 To 4 : total = "Good"
                Case Is >= 5 : total = "Extraordinary"
            End Select
            Return New Pair(Of String, Integer)(total, _Quality)
        End Get
    End Property
End Class
