Public Class RoomItem
    Implements xy
    Public Sub New(ByVal targetname As String)
        Dim rawdata As List(Of String) = IO.ImportSquareBracketSelect(IO.sbRooms, targetname)
        For Each line In rawdata
            Dim linesplit As String() = line.Split(":")
            Dim header As String = linesplit(0).Trim
            Dim entry As String = linesplit(1).Trim

            _Name = targetname
            Select Case header
                Case "Width" : _Width = Convert.ToInt32(entry)
                Case "Height" : _Height = Convert.ToInt32(entry)
                Case "Description" : _Description = entry

                Case "Furnishing" : Furnishing = Convert.ToInt32(entry)
                Case "Opulence" : Opulence = Convert.ToInt32(entry)
                Case "Tastefulness" : Opulence = Convert.ToInt32(-entry)
                Case "Restfulness" : Restfulness = Convert.ToInt32(entry)
                Case "Excitement" : Restfulness = Convert.ToInt32(-entry)
                Case "Law", "Lawfulness" : Lawfulness = Convert.ToInt32(entry)
                Case "Chaos" : Lawfulness = Convert.ToInt32(-entry)
                Case "Faith" : Faith = Convert.ToInt32(entry)
                Case "Strength" : Strength = Convert.ToInt32(entry)
                Case "Focus" : Focus = Convert.ToInt32(entry)
                Case "Tinkering" : Tinkering = Convert.ToInt32(entry)
            End Select
        Next
    End Sub
    Public Overrides Function ToString() As String
        Return Name
    End Function

    Private _Name As String
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    Private _Description As String
    Public ReadOnly Property Description As String
        Get
            Return _Description
        End Get
    End Property
    Private _Width As Integer
    Public ReadOnly Property Width As Integer Implements xy.Width
        Get
            Return _Width
        End Get
    End Property
    Private _Height As Integer
    Public ReadOnly Property Height As Integer Implements xy.Height
        Get
            Return _Height
        End Get
    End Property
    Private Property InitialX As Integer Implements xy.InitialX
    Private Property InitialY As Integer Implements xy.InitialY

    Private Furnishing As Integer
    Private Opulence As Integer
    Private Restfulness As Integer
    Private Lawfulness As Integer
    Private Faith As Integer
    Private Strength As Integer
    Private Focus As Integer
    Private Tinkering As Integer
    Public ReadOnly Property TotalFurnishing As String
        Get
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
