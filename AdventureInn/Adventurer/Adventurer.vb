Public Class Adventurer
    Public Shared Function Generate() As Adventurer
        Dim adventurer As New Adventurer
        With adventurer
            .Race = Rng.Next(0, 4)
            .Job = Rng.Next(0, 4)
            ._Name = GenerateName(.Race)
        End With
        Return adventurer
    End Function
    Public Overrides Function ToString() As String
        Return Name & " the " & Race.ToString & " " & Job.ToString
    End Function

    Private _Name As String
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    Private Shared GeneratedNames As New List(Of String)
    Private Shared Function GenerateName(ByVal race As Race) As String
        Dim sourceList As List(Of String) = Nothing
        Select Case race
            Case AdventurerInn.Race.Human : sourceList = IO.ImportTextList(IO.txHumanNames)
            Case AdventurerInn.Race.Dwarf : sourceList = IO.ImportTextList(IO.txDwarfNames)
            Case AdventurerInn.Race.Elf : sourceList = IO.ImportTextList(IO.txElfNames)
            Case AdventurerInn.Race.Halfling : sourceList = IO.ImportTextList(IO.txHalflingNames)
            Case Else : Throw New Exception
        End Select

        Dim name As String = ""
        While name = ""
            name = GetRandom(sourceList)
            If GeneratedNames.Contains(name) Then name = ""
        End While
        GeneratedNames.Add(name)
        Return name
    End Function

    Private Race As Race
    Private Job As Job
    Private ReadOnly Property PreferencesRoom As String()
        Get
            Dim privacy, opulence, restfulness, alignment, niche As String
            Dim alignValue As Integer = 0

            Select Case Race
                Case AdventurerInn.Race.Human
                    privacy = "Private"
                    opulence = "Tasteful"
                    alignValue += 1
                Case AdventurerInn.Race.Dwarf
                    privacy = "Communal"
                    opulence = "Opulent"
                    alignValue += 1
                Case AdventurerInn.Race.Elf
                    privacy = "Private"
                    opulence = "Opulent"
                    alignValue -= 1
                Case AdventurerInn.Race.Halfling
                    privacy = "Communal"
                    opulence = "Opulent"
                    alignValue -= 1
                Case Else : Throw New Exception
            End Select

            Select Case Job
                Case AdventurerInn.Job.Cleric
                    restfulness = "Restful"
                    niche = "Faith"
                    alignValue += 1
                Case AdventurerInn.Job.Fighter
                    restfulness = "Exciting"
                    niche = "Strength"
                    alignValue += 1
                Case AdventurerInn.Job.Mage
                    restfulness = "Restful"
                    niche = "Focus"
                    alignValue -= 1
                Case AdventurerInn.Job.Rogue
                    restfulness = "Exciting"
                    niche = "Curiosity"
                    alignValue -= 1
                Case Else : Throw New Exception
            End Select

            Select Case alignValue
                Case Is < 0 : alignment = "Chaotic"
                Case Is > 0 : alignment = "Lawful"
                Case 0 : alignment = "Neutral"
                Case Else : Throw New Exception
            End Select

            Return {privacy, opulence, restfulness, alignment, niche}
        End Get
    End Property
End Class

Public Enum Race
    Human
    Dwarf
    Elf
    Halfling
End Enum

Public Enum Job
    Cleric
    Fighter
    Mage
    Rogue
End Enum