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

    Private Opulence As Integer
    Private Restfulness As Integer
End Class
