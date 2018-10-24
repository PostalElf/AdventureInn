Public Interface Encounter
    ReadOnly Property Name As String
    ReadOnly Property Job As Job
    ReadOnly Property Level As Integer
    Function GetLoot() As List(Of String)
End Interface
