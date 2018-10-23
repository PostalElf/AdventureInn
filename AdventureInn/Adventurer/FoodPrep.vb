Public Class FoodPrep
    Public Shared AllFoodPreps As Dictionary(Of String, FoodPrep) = AllFoodPrepsPopulate()
    Private Shared Function AllFoodPrepsPopulate() As Dictionary(Of String, FoodPrep)
        Dim total As New Dictionary(Of String, FoodPrep)
        Dim allRawData As Dictionary(Of String, List(Of String)) = IO.ImportSquareBracketList(IO.sbprep)
        For Each key In allRawData.Keys
            Dim rawdata As List(Of String) = allRawData(key)
            total.Add(key, Generate(key, rawdata))
        Next
        Return total
    End Function
    Public Overloads Shared Function Generate(ByVal targetName As String, Optional ByVal rawdata As List(Of String) = Nothing) As FoodPrep
        If rawdata Is Nothing Then
            rawdata = IO.ImportSquareBracketSelect(IO.sbPrep, targetName)
            If rawdata Is Nothing Then Return Nothing
        End If

        Dim p As New FoodPrep
        With p
            ._Name = targetName
            For Each l In rawdata
                .Requirements.Add(l)
                .iRequired.Add(l)
            Next
        End With
        Return p
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
    Public Requirements As New List(Of String)
    Private iRequired As New List(Of String)
    Private iFilled As New List(Of String)
    Private Ingredients As New List(Of FoodIngredient)
    Public ReadOnly Property Completed As Boolean
        Get
            If iRequired.Count = 0 Then Return True Else Return False
        End Get
    End Property

    Public Function Add(ByVal fi As FoodIngredient) As String
        Dim n As String = fi.Name
        If iRequired.Contains(n) = False Then
            n = "<" & n & ">"
            If iRequired.Contains(n) = False Then Return "Ingredient not required."
        End If

        iRequired.Remove(n)
        iFilled.Add(n)
        Ingredients.Add(fi)

        Return Nothing
    End Function
    Public Function Remove(ByVal fi As FoodIngredient) As String
        If Ingredients.Contains(fi) = False Then Return "Ingredient not found in prep."

        Dim n As String = fi.Name
        If iFilled.Contains(n) = False Then
            n = "<" & n & ">"
            If iFilled.Contains(n) = False Then Return "Ingredient not found in prep."
        End If

        iRequired.Add(n)
        iFilled.Remove(n)
        Ingredients.Remove(fi)

        Return Nothing
    End Function
    Public Function Clear() As List(Of FoodIngredient)
        Dim total As New List(Of FoodIngredient)(Ingredients)
        Ingredients.Clear()
        Return total
    End Function
End Class
