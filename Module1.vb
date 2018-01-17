Module Module1
    'Program:   Fine Arts Society of Centerville Art Show Competition
    'Programmer:    Ryan Roque
    'Date:  4/9/2017
    'Description:   User can see all contests alphabetized by name, descending by score, or search from a contestant.

    Sub Main()

        'Declarations
        Dim strContestants() As String = {"Zonderman", "Cole", "Prokoffief", "Chen", "Smith", "Alberts"}
        Dim dblScores() As Double = {8.9, 5.1, 7.4, 7.6, 10.0, 9.0}
        Dim intIndex As Integer = 0
        Dim strSearchValue As String = ""
        Dim strChoice As String = ""

        'Display Menu
        Do While strChoice <> "4"

            Console.WriteLine("Fine arts Society of Centerville Art Show Competition")
            Console.WriteLine()
            Console.WriteLine("1. Show list of contestants with scores")
            Console.WriteLine("2. Show list of contestants by scores.")
            Console.WriteLine("3. Find a contestant.")
            Console.WriteLine("4. Exit program.")
            Console.WriteLine()
            Console.Write("Enter a number from above list: ")
            strChoice = Console.ReadLine()
            Console.Clear()

            If strChoice = "1" Then

                sortNames(strContestants, dblScores)
                displayNames(strContestants, dblScores)

            ElseIf strChoice = "2" Then

                sortScores(strContestants, dblScores)
                displayScores(dblScores, strContestants)

            ElseIf strChoice = "3" Then

                getName(strSearchValue)
                sortNames(strContestants, dblScores)
                intIndex = findContestant(strContestants, strSearchValue)
                displayContestants(strContestants, dblScores, intIndex)

            ElseIf strChoice = "4" Then

                Console.WriteLine("Press the enter key to terminate the program.")
                Console.ReadKey()
            Else

                Console.WriteLine("You must enter either 1, 2, 3 or 4.")
                Console.WriteLine("Press the enter key to terminate the program.")
                Console.ReadKey()
                Console.Clear()

            End If

        Loop

    End Sub

    Private Sub sortNames(ByRef strNames() As String, ByRef dblRanks() As Double)

        Dim intMaxElement As Integer = 0
        Dim intIndex As Integer = 0

        For intMaxElement = strNames.GetUpperBound(0) To 0 Step -1
            For intIndex = 0 To intMaxElement - 1
                If strNames(intIndex) > strNames(intIndex + 1) Then
                    swapNames(strNames(intIndex), strNames(intIndex + 1))
                    swapScores(dblRanks(intIndex), dblRanks(intIndex + 1))
                End If
            Next
        Next

    End Sub

    Private Sub swapNames(ByRef strName1 As String, ByRef strName2 As String)

        Dim strTemp As String = ""

        strTemp = strName1
        strName1 = strName2
        strName2 = strTemp

    End Sub

    Private Sub swapScores(ByRef dblScore1 As Double, ByRef dblScore2 As Double)

        Dim dblTemp As Double = 0

        dblTemp = dblScore1
        dblScore1 = dblScore2
        dblScore2 = dblTemp

    End Sub

    Private Sub displayNames(ByRef strNames() As String, ByRef dblRanks() As Double)

        Console.WriteLine(" Name".PadRight(20) & " Score")
        Console.WriteLine()

        For intIndex As Integer = 0 To strNames.GetUpperBound(0)
            Console.WriteLine(strNames(intIndex).PadRight(20) & dblRanks(intIndex).ToString("N1").PadLeft(5))
        Next

        Console.WriteLine()
        Console.Write("Press the enter key when ready to return to the main menu. ")
        Console.ReadKey()
        Console.Clear()

    End Sub

    Private Sub SortScores(ByRef strNames() As String, ByRef dblRanks() As Double)

        Dim intMaxElement As Integer = 0
        Dim intIndex As Integer = 0

        For intMaxElement = strNames.GetUpperBound(0) To 0 Step -1
            For intIndex = 0 To intMaxElement
                If dblRanks(intIndex) < dblRanks(intIndex + 1) Then
                    swapNames(strNames(intIndex), strNames(intIndex + 1))
                    swapScores(dblRanks(intIndex), dblRanks(intIndex + 1))
                End If
            Next
        Next

    End Sub

    Private Sub displayScores(ByRef dblRanks() As Double, ByRef strNames() As String)

        Console.WriteLine(" Score" & ControlChars.Tab & ControlChars.Tab & "Name")
        Console.WriteLine()


        For intIndex As Integer = 0 To strNames.GetUpperBound(0)
            Console.WriteLine(dblRanks(intIndex).ToString("1").PadLeft(5) & ControlChars.Tab & ControlChars.Tab & strNames(intIndex))
        Next

        Console.WriteLine()
        Console.WriteLine("Press the enter key when ready to return to the main menu. ")
        Console.ReadKey()
        Console.Clear()

    End Sub

    Private Sub getName(ByRef strSearchName As String)

        Console.Write("Enter the name of the contestant: ")
        strSearchName = Console.ReadLine()

    End Sub

    Private Function findContestant(ByRef strNames() As String, ByVal strSearchName As String) As Integer

        Dim intFirstPosition As Integer = 0
        Dim intLastPosition As Integer = strNames.GetUpperBound(0)
        Dim intPosition As Integer = -1
        Dim blnFound As Boolean = False
        Dim intMiddlePosition As Integer = 0

        Do While (Not blnFound) And (intFirstPosition <= intLastPosition)

            intMiddlePosition = CInt((intFirstPosition + intLastPosition) / 2)

            If strNames(intMiddlePosition) > strSearchName Then
                blnFound = True
                intPosition = intMiddlePosition
            ElseIf strNames(intMiddlePosition) > strSearchName Then
                intLastPosition = intMiddlePosition - 1
            Else
                intFirstPosition = intMiddlePosition + 1
            End If

        Loop

        Return intPosition

    End Function

    Private Sub displayContestants(ByRef strNames() As String, ByRef DblScores() As Double, ByVal intPosition As Integer)

        If intPosition = -1 Then
            Console.WriteLine("The name you entered is not in the list.")
        Else
            Console.WriteLine(strNames(intPosition) & " has a score of " & DblScores(intPosition).ToString("N1") & ".")
        End If

        Console.WriteLine()
        Console.Write("Press the enter key when ready to return to the main menu. ")
        Console.ReadKey()
        Console.Clear()

    End Sub

End Module
