Public Class Adventurer
    Public Shared Function Generate() As Adventurer
        Dim adventurer As New Adventurer
        With adventurer
            ._Race = Rng.Next(0, 4)
            ._Job = Rng.Next(0, 4)
            ._Name = GenerateName(._Race)

            If .Race = AdventurerInn.Race.Dwarf OrElse .Race = AdventurerInn.Race.Human Then ._Alignment += 1 Else ._Alignment -= 1
            If .Job = AdventurerInn.Job.Cleric OrElse .Job = AdventurerInn.Job.Fighter Then ._Alignment += 1 Else ._Alignment -= 1

        End With
        Return adventurer
    End Function
    Public Overrides Function ToString() As String
        Return Name & " the " & _Race.ToString & " " & _Job.ToString
    End Function

    Private _Name As String
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    Public ReadOnly Property Pronoun As String
        Get
            Return "him"
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

    Private _Race As Race
    Public ReadOnly Property Race As Race
        Get
            Return _Race
        End Get
    End Property
    Private _Job As Job
    Public ReadOnly Property Job As Job
        Get
            Return _Job
        End Get
    End Property
    Private _Level As Integer
    Public ReadOnly Property Level As Integer
        Get
            Return _Level
        End Get
    End Property
    Private _Alignment As Integer
    Public ReadOnly Property Alignment As String
        Get
            Select Case _Alignment
                Case Is < 0 : Alignment = "Chaotic"
                Case Is > 0 : Alignment = "Lawful"
                Case 0 : Alignment = "Neutral"
                Case Else : Throw New Exception
            End Select
        End Get
    End Property
    Public Function CheckEncounter(ByVal pJob As Job, ByVal pLevel As Integer) As Boolean
        If pJob = AdventurerInn.Job.Monster OrElse pJob = _Job Then
            Dim levelDifference As Integer = pLevel - _Level
            If levelDifference < 0 Then levelDifference = 0
            Dim difficulty As Integer = 95 - (levelDifference * 10)
            If Rng.Next(1, 101) <= difficulty Then Return True Else Return False
        Else
            Return False
        End If
    End Function

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
    Public ReadOnly Property RoomPreferenceDescription As String
        Get
            Dim total As String = ""
            total &= "- " & _Race.ToString & "s like " & RoomPreferences(0) & " and " & RoomPreferences(1) & " rooms." & vbCrLf
            total &= "- " & _Job.ToString & "s like " & RoomPreferences(2) & " rooms that are full of " & RoomPreferences(4) & "." & vbCrLf
            total &= "- " & RoomPreferences(3) & " characters like " & RoomPreferences(3) & " things."
            Return total
        End Get
    End Property
    Private ReadOnly Property RoomPreferences As String()
        Get
            Dim privacy, opulence, restfulness, align, niche As String

            Select Case _Race
                Case AdventurerInn.Race.Human
                    privacy = "Private"
                    opulence = "Tasteful"
                Case AdventurerInn.Race.Dwarf
                    privacy = "Communal"
                    opulence = "Opulent"
                Case AdventurerInn.Race.Elf
                    privacy = "Private"
                    opulence = "Opulent"
                Case AdventurerInn.Race.Halfling
                    privacy = "Communal"
                    opulence = "Tasteful"
                Case Else : Throw New Exception
            End Select

            Select Case _Job
                Case AdventurerInn.Job.Cleric
                    restfulness = "Restful"
                    niche = "Faith"
                Case AdventurerInn.Job.Fighter
                    restfulness = "Exciting"
                    niche = "Strength"
                Case AdventurerInn.Job.Mage
                    restfulness = "Restful"
                    niche = "Focus"
                Case AdventurerInn.Job.Rogue
                    restfulness = "Exciting"
                    niche = "Curiosity"
                Case Else : Throw New Exception
            End Select

            align = Alignment

            Return {privacy, opulence, restfulness, align, niche}
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
            Select Case _Race
                Case AdventurerInn.Race.Human : richness = "Plain"
                Case AdventurerInn.Race.Dwarf : richness = "Rich"
                Case AdventurerInn.Race.Elf : richness = "Plain"
                Case AdventurerInn.Race.Halfling : richness = "Rich"
                Case Else : Throw New Exception
            End Select
            Select Case _Job
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
            If food Is Nothing Then Return New Pair(Of String, Integer)("""Dining hall was out of food.""" & vbCrLf & vbCrLf & "Rating: " & GetStarRating(0), 0)

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
    Private ReadOnly Property DrinkPreferences As String()
        Get
            Dim alcoholType, fanciness As String
            Select Case _Race
                Case AdventurerInn.Race.Dwarf : alcoholType = "Beer"
                Case AdventurerInn.Race.Elf : alcoholType = "Wine"
                Case AdventurerInn.Race.Halfling : alcoholType = "Beer"
                Case AdventurerInn.Race.Human : alcoholType = "Wine"
                Case Else : Throw New Exception
            End Select
            Select Case _Job
                Case AdventurerInn.Job.Cleric : fanciness = "Simple"
                Case AdventurerInn.Job.Fighter : fanciness = "Simple"
                Case AdventurerInn.Job.Mage : fanciness = "Fancy"
                Case AdventurerInn.Job.Rogue : fanciness = "Fancy"
                Case Else : Throw New Exception
            End Select
            Return {alcoholType, fanciness}
        End Get
    End Property
    Public ReadOnly Property DrinkSatisfaction(ByVal drink As Drink, ByVal food As Food) As Pair(Of String, Integer)
        Get
            If drink Is Nothing Then Return New Pair(Of String, Integer)("""Bar was shamefully unstocked.""" & vbCrLf & vbCrLf & "Rating: " & GetStarRating(0), 0)

            Dim pref As String() = DrinkPreferences
            Dim stars As Integer = 0
            Dim total As String = """"
            Dim likedLast As Boolean = False
            If pref(0) = drink.Fanciness Then
                Select Case drink.Fanciness
                    Case "Fancy" : total &= drink.Name & " was deliciously decadent "
                    Case "Simple" : total &= drink.Name & " was neat and appetising "
                End Select
                stars += 1
                likedLast = True
            Else
                Select Case drink.Fanciness
                    Case "Fancy" : total &= drink.Name & " was unnecessarily complicated "
                    Case "Simple" : total &= drink.Name & " was utterly boring "
                End Select
                likedLast = False
            End If

            If pref(1) = drink.Alcoholism OrElse drink.Alcoholism = "Spirit" Then
                stars += 2
                If likedLast = True Then total &= "as a " Else total &= "for a "
                total &= drink.Alcoholism.ToLower & ". "
                likedLast = True
            Else
                If likedLast = True Then total &= "for a " Else total &= "as a "
                total &= drink.Alcoholism.ToLower & ". "
                likedLast = False
            End If

            Dim foodMatch As Boolean = False
            If food Is Nothing = False Then
                Select Case food.TotalExoticness.Key
                    Case "Exotic" : If drink.Subtype = "Red" OrElse drink.Subtype = "Ale" OrElse drink.Subtype = "Rum" Then foodMatch = True
                    Case "Common" : If drink.Subtype = "White" OrElse drink.Subtype = "Lager" OrElse drink.Subtype = "Whisky" Then foodMatch = True
                End Select
            Else
                If likedLast = False Then total &= "I could also " Else total &= "But I could "
                total &= "have done with some food to go with the drink."
                likedLast = False
            End If
            If foodMatch = True Then
                If likedLast = True Then total &= "It " Else total &= "However, it "
                total &= "paired very well with the food. "
                likedLast = True
                stars += 1
            ElseIf foodMatch = False Then
                If likedLast = True Then total &= "However, it " Else total &= "It "
                total &= "did not go well with the food at all. "
                likedLast = False
            End If

            If Alignment = drink.Alignment Then
                Select Case drink.Alignment
                    Case "Chaotic" : total &= "I also enjoyed the riot of colour in the drink, "
                    Case "Neutral" : total &= "I also enjoyed the water served on the side, "
                    Case "Lawful" : total &= "I also enjoyed the orderly presentation of the drink, "
                End Select
                stars += 1
                likedLast = True
            Else
                Select Case drink.Alignment
                    Case "Chaotic" : total &= "I did not care for the mess, "
                    Case "Neutral" : total &= "I did not care for the blandness, "
                    Case "Lawful" : total &= "I did not care for the lack of colour, "
                End Select
                likedLast = False
            End If

            'TODO: bartender

            total &= """" & vbCrLf & vbCrLf
            total &= "Rating: " & GetStarRating(stars)
            Return New Pair(Of String, Integer)(stars, stars)
        End Get
    End Property
    Private ReadOnly Property EntertainmentPreferences As String()
        Get

        End Get
    End Property
    Public ReadOnly Property EntertainmentSatisfaction(ByVal entertainment As entertainment) As Pair(Of String, Integer)
        Get

        End Get
    End Property
    Private ReadOnly Property ServicePreferences As String()
        Get

        End Get
    End Property
    Public ReadOnly Property ServiceSatisfaction(ByVal service As Service) As Pair(Of String, Integer)
        Get

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
            Return String.Compare(x._Job.ToString, y._Job.ToString)
        End Function
    End Class
    Public Class SortByRace
        Implements IComparer(Of Adventurer)
        Public Function Compare(ByVal x As Adventurer, ByVal y As Adventurer) As Integer Implements System.Collections.Generic.IComparer(Of Adventurer).Compare
            Return String.Compare(x._Race.ToString, y._Race.ToString)
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