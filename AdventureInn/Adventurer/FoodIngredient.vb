Public Class FoodIngredient
    Public Name As String
    Public IngredientType As String
    Public Richness As Integer
    Public Meatiness As Integer
    Public Exoticness As Integer
    Public Quality As Integer

    Public Shared Function Generate(ByVal targetName As String)
        Dim rawdata As List(Of String) = IO.ImportSquareBracketSelect(IO.sbIngredients, targetName)
        If rawdata Is Nothing Then Return Nothing

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