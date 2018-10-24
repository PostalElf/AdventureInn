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
    Private Function GetStarRating(ByRef stars As Integer) As String
        Dim total As String = ""
        If stars < 0 Then stars = 0
        If stars > 5 Then stars = 5
        For n = 1 To stars
            total &= "★"
        Next
        For n = 1 To 5 - stars
            total &= "✰"
        Next
        Return total
    End Function
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
    Public ReadOnly Property RoomPreferenceDescription As String
        Get
            Dim total As String = ""
            total &= Race.ToString & "s like " & RoomPreferences(0) & " and " & RoomPreferences(1) & " rooms." & vbCrLf
            total &= Job.ToString & "s like " & RoomPreferences(2) & " rooms with " & RoomPreferences(4) & "." & vbCrLf
            total &= RoomPreferences(3) & " characters like " & RoomPreferences(3) & " things."
            Return total
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
            total &= "Rating: " & GetStarRating(stars)
            Return New Pair(Of String, Integer)(total, stars)
        End Get
    End Property
    Private ReadOnly Property FoodPreferences As String()
        Get
            Dim richness, meatiness, exoticness As String
            Select Case Race
                Case AdventurerInn.Race.Human : richness = "Plain"
                Case AdventurerInn.Race.Dwarf : richness = "Rich"
                Case AdventurerInn.Race.Elf : richness = "Plain"
                Case AdventurerInn.Race.Halfling : richness = "Rich"
                Case Else : Throw New Exception
            End Select
            Select Case Job
                Case AdventurerInn.Job.Cleric
                    meatiness = "Vegetarian"
                    exoticness = "Common"
                Case AdventurerInn.Job.Fighter
                    meatiness = "Meat"
                    exoticness = "Exotic"
                Case AdventurerInn.Job.Mage
                    meatiness = "Meat"
                    exoticness = "Common"
                Case AdventurerInn.Job.Rogue
                    meatiness = "Vegetarian"
                    exoticness = "Exotic"
                Case Else : Throw New Exception
            End Select
            Return {richness, meatiness, exoticness}
        End Get
    End Property
    Public ReadOnly Property FoodSatisfaction(ByVal food As Food) As Pair(Of String, Integer)
        Get
            Dim stars As Integer = 0
            Dim likedLast As Boolean
            Dim total As String = """"

            Dim pref As String() = FoodPreferences
            Select Case food.TotalQuality.Key
                Case "Poor"
                    likedLast = False
                    stars -= 1
                    total &= "Dish was poorly presented. "
                Case "Good"
                    likedLast = False
                    total &= "Ate at the dining hall. "
                Case "Extraordinary"
                    likedLast = True
                    stars += 1
                    total &= "Dish was delightfully plated. "
            End Select

            Dim prefix As String = ""
            If food.TotalRichness.Key = pref(0) Then
                Select Case food.TotalRichness.Key
                    Case "Rich" : total &= "The flavours were " & prefix & "surprisingly rich and complex, "
                    Case "Plain" : total &= "Its subtle, subdued flavours " & prefix & "reminded me of home, "
                End Select
                stars += 1
                likedLast = True
            Else
                Select Case food.TotalRichness.Key
                    Case "Rich" : total &= "It was " & prefix & "cloying and overwhelmingly rich, "
                    Case "Plain" : total &= "It was " & prefix & "bland and flavourless, "
                End Select
                likedLast = False
            End If

            Dim cont As String = ""
            If food.TotalMeatiness.Key = pref(1) Then
                If likedLast = True Then total &= "and " Else total &= "but "
                total &= "I particularly enjoyed the "
                Select Case food.TotalMeatiness.Key
                    Case "Vegetarian" : cont = "vegetables"
                    Case "Meat" : cont = "meat"
                End Select
                stars += 1
                likedLast = True
            Else
                If likedLast = False Then total &= "and " Else total &= "but "
                likedLast = False
                total &= "I would have liked less "
                Select Case food.TotalMeatiness.Key
                    Case "Vegetarian" : cont = "vegetables in my food"
                    Case "Meat" : cont = "meat in the dish"
                End Select
            End If

            If food.TotalExoticness.Key = pref(2) Then
                Select Case food.TotalExoticness.Key
                    Case "Exotic"
                        If likedLast = True Then
                            total &= "unpredictable textures of the exotic " & cont & "."
                        Else
                            total &= cont & ". The strangeness was however quite refreshing."
                        End If
                    Case "Common"
                        If likedLast = True Then
                            total &= "fresh taste of common " & cont & "."
                        Else
                            total &= cont & ". I must admit though that the straightforward freshness was rather pleasant."
                        End If
                End Select
                stars += 1
                likedLast = True
            Else
                Select Case food.TotalExoticness.Key
                    Case "Exotic"
                        If likedLast = True Then
                            total &= cont & ", though they were a little foreign."
                        Else
                            total &= "weird " & cont & "."
                        End If
                    Case "Common"
                        If likedLast = True Then
                            total &= cont & ". Would have liked it more if it were less run-of-the-mill though."
                        Else
                            total &= "ordinary " & cont & "."
                        End If
                End Select
                likedLast = False
            End If

            total &= """" & vbCrLf & vbCrLf
            total &= "Rating: " & GetStarRating(stars)
            Return New Pair(Of String, Integer)(total, stars)
        End Get
    End Property

    Public Class SortByName
        Implements IComparer(Of Adventurer)
        Public Function Compare(ByVal x As Adventurer, ByVal y As Adventurer) As Integer Implements System.Collections.Generic.IComparer(Of Adventurer).Compare
            Return String.Compare(x.Name, y.Name)
        End Function
    End Class
    Public Class SortByJob
        Implements IComparer(Of Adventurer)
        Public Function Compare(ByVal x As Adventurer, ByVal y As Adventurer) As Integer Implements System.Collections.Generic.IComparer(Of Adventurer).Compare
            Return String.Compare(x.Job.ToString, y.Job.ToString)
        End Function
    End Class
    Public Class SortByRace
        Implements IComparer(Of Adventurer)
        Public Function Compare(ByVal x As Adventurer, ByVal y As Adventurer) As Integer Implements System.Collections.Generic.IComparer(Of Adventurer).Compare
            Return String.Compare(x.Race.ToString, y.Race.ToString)
        End Function
    End Class
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
    Monster
End Enum