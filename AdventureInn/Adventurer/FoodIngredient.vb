Public Class FoodIngredient
    Public Shared AllFoodIngredients As Dictionary(Of String, FoodIngredient) = AllFoodIngredientsPopulate()
    Private Shared Function AllFoodIngredientsPopulate() As Dictionary(Of String, FoodIngredient)
        Dim total As New Dictionary(Of String, FoodIngredient)
        Dim allRawData As Dictionary(Of String, List(Of String)) = IO.ImportSquareBracketList(IO.sbIngredients)
        For Each key In allRawData.Keys
            Dim rawdata As List(Of String) = allRawData(key)
            total.Add(key, Generate(key, rawdata))
        Next
        Return total
    End Function
    Public Shared Function Generate(ByVal targetName As String, Optional ByVal rawdata As List(Of String) = Nothing)
        If rawdata Is Nothing Then
            rawdata = IO.ImportSquareBracketSelect(IO.sbIngredients, targetName)
            If rawdata Is Nothing Then Return Nothing
        End If

        Dim fi As New FoodIngredient
        With fi
            .Name = targetName
            For Each l In rawdata
                Dim rawsplit As String() = l.Split(":")
                Dim header As String = rawsplit(0).Trim
                Dim entry As String = rawsplit(1).Trim

                Select Case header
                    Case "Type" : .IngredientType = entry
                    Case "Richness" : .Richness = Convert.ToInt32(entry)
                    Case "Plainess" : .Richness = -Convert.ToInt32(entry)
                    Case "Meatiness", "Meat" : .Meatiness = Convert.ToInt32(entry)
                    Case "Vegetarian", "Veg" : .Meatiness = -Convert.ToInt32(entry)
                    Case "Exoticness" : .Exoticness = Convert.ToInt32(entry)
                    Case "Commonness", "Common" : .Exoticness = -Convert.ToInt32(entry)
                    Case "Quality" : .Quality = Convert.ToInt32(entry)
                End Select
            Next
        End With
        Return fi
    End Function
    Public Overrides Function ToString() As String
        Return Name
    End Function

    Public Name As String
    Public IngredientType As String
    Public Richness As Integer
    Public Meatiness As Integer
    Public Exoticness As Integer
    Public Quality As Integer
    Public ReadOnly Property AttributesDescription As String
        Get
            Dim total As String = ""
            total &= "Quality: " & Quality & vbCrLf
            total &= "Richness: " & Richness & vbCrLf
            total &= "Meatiness: " & Meatiness & vbCrLf
            total &= "Exoticness: " & Exoticness
            Return total
        End Get
    End Property
End Class