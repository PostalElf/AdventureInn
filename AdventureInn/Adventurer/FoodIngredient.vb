Public Class FoodIngredient
    Public Name As String
    Public IngredientType As String
    Public Richness As Integer
    Public Meatiness As Integer
    Public Exoticness As Integer
    Public Quality As Integer

    Public Sub New(ByVal target As String)
        Dim rawdata As List(Of String) = IO.ImportSquareBracketSelect(IO.sbIngredients, target)
        If rawdata Is Nothing Then Exit Sub

        Name = target
        For Each l In rawdata
            Dim rawsplit As String() = l.Split(":")
            Dim header As String = rawsplit(0)
            Dim entry As String = rawsplit(1)

            Select Case header
                Case "Type" : IngredientType = entry
                Case "Richness" : Richness = Convert.ToInt32(entry)
                Case "Plainess" : Richness = -Convert.ToInt32(entry)
                Case "Meatiness", "Meat" : Meatiness = Convert.ToInt32(entry)
                Case "Vegetarian", "Veg" : Meatiness = -Convert.ToInt32(entry)
                Case "Exoticness" : Exoticness = Convert.ToInt32(entry)
                Case "Commonness", "Common" : Exoticness = -Convert.ToInt32(entry)
                Case "Quality" : Quality = Convert.ToInt32(entry)
            End Select
        Next
    End Sub
End Class