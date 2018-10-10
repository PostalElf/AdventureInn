Public Class Adventurer
    Private Race As Race
    Private Job As Job

    Private Name As String
    Private Shared GeneratedNames As New List(Of String)
    Private Shared Function GenerateName() As String
        Dim syllables As New List(Of String) From {"mon", "fay", "shi", "zag", "arg", "rash", "izen", "don", "ill", _
                                                   "mal", "zak", "abo"}
        Dim suffixes As New List(Of String) From {"son", "li", "ssen", "kor"}
        Dim numSyllables As Integer = Rng.Next(2, 4)

        Dim name As String = ""
        For n = 1 To numSyllables
            Dim p As Integer = Rng.Next(syllables.Count)
            name &= syllables(p)
            syllables.RemoveAt(p)
        Next
        If Rng.Next(1, 3) = 1 Then
            Dim p As Integer = Rng.Next(suffixes.Count)
            name &= suffixes(p)
        End If

        Dim arr() As Char = name.ToCharArray
        arr(0) = Char.ToUpper(arr(0))
        Return arr.ToString
    End Function

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