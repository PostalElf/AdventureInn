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
    Private ReadOnly Property RoomPreferences As String()
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
    Public ReadOnly Property RoomSatisfaction(ByVal room As Room) As Pair(Of String, Integer)
        Get
            Dim stars As Integer = 0
            Dim likedLast As Boolean
            Dim total As String = """"

            Dim pref As String() = RoomPreferences
            With room
                Select Case .TotalFurnishing.Key
                    Case "Unfurnished"
                        likedLast = False
                        stars -= 1
                        total &= "Room is completely unfurnished! "
                    Case "Furnished"
                        likedLast = False
                        total &= "Furnishings are bare but servicable. "
                    Case "Well Furnished"
                        stars += 1
                        likedLast = True
                        total &= "Room is well-furnished. "
                End Select

                If .TotalPrivacy.Key = pref(0) Then
                    stars += 1
                    If likedLast = False Then total &= "That said, "
                    likedLast = True
                    Select Case .TotalPrivacy.Key
                        Case "Private" : total &= "I enjoyed having the place to myself. "
                        Case "Communal" : total &= "I appreciated the company of my room mates. "
                    End Select
                Else
                    likedLast = False
                    Select Case .TotalPrivacy.Key
                        Case "Private" : total &= "Would be better with some bunk beds. "
                        Case "Communal" : total &= "Didn't really care to share the room with others. "
                    End Select
                End If

                If .TotalOpulence.Key = pref(1) Then
                    stars += 1
                    likedLast = True
                    Select Case .TotalOpulence.Key
                        Case "Opulent" : total &= "The decor was beautifully decadent, "
                        Case "Tasteful" : total &= "The decor was tasteful, "
                    End Select
                Else
                    likedLast = False
                    Select Case .TotalOpulence.Key
                        Case "Opulent" : total &= "The decor was gaudy, "
                        Case "Tasteful" : total &= "The decor was bland, "
                        Case "Boring" : total &= "There was no character to the decor, "
                    End Select
                End If

                If .TotalRestfulness.Key = pref(2) Then
                    stars += 1
                    If likedLast = True Then total &= "and " Else total &= "but at least "
                    likedLast = True
                    Select Case .TotalRestfulness.Key
                        Case "Restful" : total &= "I got a good night's sleep. "
                        Case "Exciting" : total &= "I was thorougly entertained. "
                    End Select
                Else
                    If likedLast = False Then total &= "and " Else total &= "but "
                    likedLast = False
                    Select Case .TotalRestfulness.Key
                        Case "Restful" : total &= "it was too quiet. "
                        Case "Exciting" : total &= "it was too noisy. "
                        Case "Middling" : total &= "the beds were hard and uncomfortable. "
                    End Select
                End If

                If .TotalAlignment.Key = pref(3) Then
                    stars += 1
                    likedLast = True
                    Select Case .TotalAlignment.Key
                        Case "Lawful" : total &= "The neatness was a plus point"
                        Case "Chaotic" : total &= "The artful mess was a nice touch"
                        Case "Neutral" : total &= "The view was beautiful"
                    End Select
                Else
                    likedLast = False
                    Select Case .TotalAlignment.Key
                        Case "Lawful" : total &= "The room felt claustrophobic"
                        Case "Chaotic" : total &= "Housekeeping was terrible"
                        Case "Neutral" : total &= "The view was awful"
                    End Select
                End If

                If .TotalNiche.Key = pref(4) Then
                    stars += 1
                    likedLast = True
                    Select Case .TotalNiche.Key
                        Case "Faith" : total &= ", and I appreciated the religious trappings."
                        Case "Strength" : total &= ", and I liked the workout I got."
                        Case "Curiosity" : total &= ", and I had a good time exploring the room's many secrets."
                        Case "Focus" : total &= ", and I managed to get a good amount of work done."
                    End Select
                Else
                    likedLast = False
                    total &= "."
                End If
            End With

            total &= """" & vbCrLf & vbCrLf
            total &= "Rating: "
            If stars < 0 Then stars = 0
            If stars > 5 Then stars = 5
            For n = 1 To stars
                total &= "★"
            Next
            For n = 1 To 5 - stars
                total &= "✰"
            Next
            Return New Pair(Of String, Integer)(total, stars)
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