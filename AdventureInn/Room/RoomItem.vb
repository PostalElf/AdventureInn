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

                Case "Furnishing" : _Furnishing = Convert.ToInt32(entry)
                Case "Opulence" : _Opulence = Convert.ToInt32(entry)
                Case "Tastefulness" : _Opulence = Convert.ToInt32(-entry)
                Case "Restfulness" : _Restfulness = Convert.ToInt32(entry)
                Case "Excitement" : _Restfulness = Convert.ToInt32(-entry)
                Case "Law", "Lawfulness" : _Lawfulness = Convert.ToInt32(entry)
                Case "Chaos" : _Lawfulness = Convert.ToInt32(-entry)
                Case "Faith" : _Faith = Convert.ToInt32(entry)
                Case "Strength" : _Strength = Convert.ToInt32(entry)
                Case "Focus" : _Focus = Convert.ToInt32(entry)
                Case "Curiosity" : _Tinkering = Convert.ToInt32(entry)
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

    Private _Furnishing As Integer
    Public ReadOnly Property Furnishing As Integer
        Get
            Return _Furnishing
        End Get
    End Property
    Private _Opulence As Integer
    Public ReadOnly Property Opulence As Integer
        Get
            Return _Opulence
        End Get
    End Property
    Private _Restfulness As Integer
    Public ReadOnly Property Restfulness As Integer
        Get
            Return _Restfulness
        End Get
    End Property
    Private _Lawfulness As Integer
    Public ReadOnly Property Lawfulness As Integer
        Get
            Return _Lawfulness
        End Get
    End Property
    Private _Faith As Integer
    Public ReadOnly Property Faith As Integer
        Get
            Return _Faith
        End Get
    End Property
    Private _Strength As Integer
    Public ReadOnly Property Strength As Integer
        Get
            Return _Strength
        End Get
    End Property
    Private _Focus As Integer
    Public ReadOnly Property Focus As Integer
        Get
            Return _Focus
        End Get
    End Property
    Private _Tinkering As Integer
    Public ReadOnly Property Curiosity As Integer
        Get
            Return _Tinkering
        End Get
    End Property
End Class
