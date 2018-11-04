Public Class FoodIngredient
    Implements LootItem
    Public Shared AllFoodIngredients As SortedDictionary(Of String, FoodIngredient) = AllFoodIngredientsPopulate()
    Private Shared Function AllFoodIngredientsPopulate() As SortedDictionary(Of String, FoodIngredient)
        Dim total As New SortedDictionary(Of String, FoodIngredient)
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

    Public Property Name As String Implements LootItem.Name
    Public IngredientType As String
    Public Richness As Integer
    Public Meatiness As Integer
    Public Exoticness As Integer
    Public Quality As Integer
    Public ReadOnly Property AttributesDescription As String Implements LootItem.AttributesDescription
        Get
            Dim total As String = ""
            total &= "Quality: " & Quality & vbCrLf
            total &= "Richness: " & Richness & vbCrLf
            total &= "Meatiness: " & Meatiness & vbCrLf
            total &= "Exoticness: " & Exoticness
            Return total
        End Get
    End Property

    Public Class SortByName
        Implements IComparer(Of FoodIngredient)
        Public Function Compare(ByVal x As FoodIngredient, ByVal y As FoodIngredient) As Integer Implements System.Collections.Generic.IComparer(Of FoodIngredient).Compare
            Return String.Compare(x.Name, y.Name)
        End Function
    End Class
    Public Class SortByType
        Implements IComparer(Of FoodIngredient)
        Public Function Compare(ByVal x As FoodIngredient, ByVal y As FoodIngredient) As Integer Implements System.Collections.Generic.IComparer(Of FoodIngredient).Compare
            Return String.Compare(x.IngredientType, y.IngredientType)
        End Function
    End Class
    Public Class SortByRichness
        Implements IComparer(Of FoodIngredient)
        Public Function Compare(ByVal x As FoodIngredient, ByVal y As FoodIngredient) As Integer Implements System.Collections.Generic.IComparer(Of FoodIngredient).Compare
            If x.Richness < y.Richness Then
                Return 1
            ElseIf x.Richness > y.Richness Then
                Return -1
            Else
                Return 0
            End If
        End Function
    End Class
    Public Class SortByMeatiness
        Implements IComparer(Of FoodIngredient)
        Public Function Compare(ByVal x As FoodIngredient, ByVal y As FoodIngredient) As Integer Implements System.Collections.Generic.IComparer(Of FoodIngredient).Compare
            If x.Meatiness < y.Meatiness Then
                Return 1
            ElseIf x.Meatiness > y.Meatiness Then
                Return -1
            Else
                Return 0
            End If
        End Function
    End Class
    Public Class SortByExoticness
        Implements IComparer(Of FoodIngredient)
        Public Function Compare(ByVal x As FoodIngredient, ByVal y As FoodIngredient) As Integer Implements System.Collections.Generic.IComparer(Of FoodIngredient).Compare
            If x.Exoticness < y.Exoticness Then
                Return 1
            ElseIf x.Exoticness > y.Exoticness Then
                Return -1
            Else
                Return 0
            End If
        End Function
    End Class
    Public Class SortByQuality
        Implements IComparer(Of FoodIngredient)
        Public Function Compare(ByVal x As FoodIngredient, ByVal y As FoodIngredient) As Integer Implements System.Collections.Generic.IComparer(Of FoodIngredient).Compare
            If x.Quality < y.Quality Then
                Return 1
            ElseIf x.Quality > y.Quality Then
                Return -1
            Else
                Return 0
            End If
        End Function
    End Class
End Class