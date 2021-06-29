Imports TinyExe
Imports System.Text
Imports System.IO
Imports TkChatBot_Database

Public Class CommandInterpreter
    'Public db As DatabaseEntities = New DatabaseEntities()
    'Public shouldSaveDB As Boolean = False
    Private saveDBTimer As System.Threading.Timer

    Public expressionContextMain As TinyExe.Context
    Public sessionStart As DateTime

    Public Event DbSaveChanges()

    Public Sub New()

        expressionContextMain = New TinyExe.Context()

        Dim db As DatabaseEntities = New DatabaseEntities()

        'Check for initialized database, create a demo command if needed
        If db.Commands.Count() = 0 Then
            Dim aboutCommand As New Command
            aboutCommand.Keyword = "!about"
            aboutCommand.Actions = "This is a Tk-TwitchChatbot"
            aboutCommand.CoolDownMessage = "This command is on cooldown."
            aboutCommand.Enabled = True
            db.Commands.Add(aboutCommand)
            db.SaveChanges()
            'shouldSaveDB = True
        End If
        addBasicCommands()

        'Set up the timer
        saveDBTimer = New Threading.Timer(AddressOf saveDBTimer_Tick, Nothing, 5000, 3000)

    End Sub

    Private Sub saveDBTimer_Tick(ByVal stateInfo As Object)
        'If shouldSaveDB Then
        '    Try
        '        Dim db As DatabaseEntities = New DatabaseEntities()
        '        db.SaveChanges()

        '    Catch ex As System.AccessViolationException
        '        Exit Try
        '    Catch ex As Exception


        '    End Try
        '    shouldSaveDB = False
        'End If

    End Sub


    Public Function doCommand(ByVal Message As ChatSharp.PrivateMessage, Optional ByVal ForceExecution As Boolean = False) As String
        Return _doCommand(Message.Message, ForceExecution, Message.User.Nick, Message.IsChannelMessage)
    End Function
    Private Function _doCommand(ByVal Message As String, Optional ByVal ForceExecution As Boolean = False, Optional ByVal UserName As String = "[SysCallback]", Optional ByVal isChannelMessage As Boolean = True) As String
        'First, get the potential command
        Dim commandEnd As Integer = Message.IndexOf(" ")
        'Test for sanity, exit if it's clearly not a command
        If commandEnd > 40 Then Return ""

        Dim commandSearch As String = Message
        If commandEnd > -1 Then commandSearch = commandSearch.Substring(0, commandEnd).ToLower()
        If commandSearch.Length > 40 Then Return ""

        'Get the command, if it's enabled
        Dim db As DatabaseEntities = New DatabaseEntities()
        Dim commandList As List(Of Command) = db.Commands.ToList()
        Dim cmds = (From a In commandList
                             Where a.Keyword = commandSearch And (a.Enabled = True Or ForceExecution)).ToList()


        Dim cmd As Command = cmds.FirstOrDefault()
        'Check if we got anything
        If cmd Is Nothing Then Return ""

        'Check for permission level
        Dim userInfo As User = (From a In db.Users Where a.UserName = UserName).FirstOrDefault()
        If userInfo Is Nothing Then userInfo = New User()
        If Not userInfo Is Nothing And userInfo.PermissionLevel < cmd.MinPermissionLevel Then
            Return "Sorry " & UserName & ", Your permission level is insufficient to run " & commandSearch
        End If

        'Prepare scope and local variables
        Dim Result As String = ""
        expressionContextMain.PushScope(expressionContextMain.getScope(-1))

        '' ANY EARLY RETURNS PAST THIS POINT NEED TO POP THE SCOPE BEFORE SO DOING

        'Add message-specific variables
        expressionContextMain.CurrentScope.Add("$user", UserName)
        expressionContextMain.CurrentScope.Add("$isChannelMessage", isChannelMessage)
        'Add the $message variable if something other than the command was passed
        If commandEnd > -1 Then
            Dim msg As String = Message.Substring(commandEnd + 1)
            expressionContextMain.CurrentScope.Add("$message", msg)

            'Loop through the message and add variables
            Dim countArg As Integer = 1
            Dim countNum As Integer = 1
            Dim countTarget As Integer = 1

            For Each item In msg.Split(" ")
                'Always add "arg"
                expressionContextMain.CurrentScope.Add("$arg" & countArg, item)

                'Check if it seems numeric

                If Double.TryParse(item, New Double()) Then
                    expressionContextMain.CurrentScope.Add("$num" & countNum, item)
                    countNum += 1
                End If

                'Check if a username was mentioned
                If (From a In db.Users Where a.UserName = item).Count() > 0 Then
                    expressionContextMain.CurrentScope.Add("$target" & countTarget, item)
                    countTarget += 1
                End If

                countArg += 1
            Next

        End If

        'Check for extra precondition
        Dim Precondition As String = cmd.ExtraPrecondition
        If Precondition Is Nothing Then Precondition = ""
        If Precondition <> "" And Not ForceExecution Then
            'Note, anything other than False is failure, and returns it as a chat message
            If Precondition.StartsWith("=") Then
                Dim eval As New TinyExe.Expression(Precondition.Substring(1), expressionContextMain)
                If eval.Errors.Count > 0 Then
                    'An error in the precondition does not automatically fail the command
                    Result += ("Error in expression: " & eval.Errors(0).Message)
                Else
                    Dim resultTemp = eval.Eval()
                    If Not resultTemp Is Nothing Then
                        If TypeOf resultTemp Is Boolean Then
                            If resultTemp <> False Then
                                expressionContextMain.PopScope()
                                Return "Command Precondition failed."
                            End If
                        Else
                            expressionContextMain.PopScope()
                            Return resultTemp
                        End If
                    End If

                End If
            Else
                'A message is an automatic fail, give it back to chat
                expressionContextMain.PopScope()
                Return Precondition
            End If

        End If

        'Prepare to execute actions
        Dim Actions As String = cmd.Actions

        'Check for cooldown
        If _checkCooldown(commandSearch, UserName) And Not ForceExecution Then Actions = cmd.CoolDownMessage

        If Actions Is Nothing Then Actions = ""

        'Do the Actions
        For Each Action In Actions.Replace(Chr(10), "").Split(Chr(13))

            If Action.StartsWith("=") Then
                Dim eval As New TinyExe.Expression(Action.Substring(1), expressionContextMain)
                If eval.Errors.Count > 0 Then
                    Result += ("Error in expression: " & eval.Errors(0).Message)
                Else
                    Dim resultTemp = eval.Eval()
                    If Not resultTemp Is Nothing Then
                        Result += (resultTemp.ToString()) + vbCrLf
                    End If

                End If
            Else
                Result += Action + vbCrLf
            End If

        Next
        'Apply cooldowns if the command wasn't forced, and isn't currently in cooldown
        If Not _checkCooldown(commandSearch, UserName) And Not ForceExecution Then
            If expressionContextMain.CurrentScope.ContainsKey("$nocooldown") Then
                'If it's the global user, still apply to user
                If expressionContextMain.CurrentScope("$nocooldown") = "." Then
                    _resetCooldown(commandSearch, UserName, False)
                Else
                    'Not the global user, so it's probably just the user. 
                    'Don't cooldown anything
                End If
            Else
                'No NoCooldown specified, and we're not forcing execution, cooldown as normal
                _resetCooldown(commandSearch, UserName, True)

            End If
        End If

        expressionContextMain.PopScope()
        Return Result
    End Function

    Public Function _checkCooldown(ByVal Command As String, ByVal UserName As String, Optional ByVal includeGlobal As Boolean = True, Optional ByVal resetCooldown As Boolean = False)
        Dim db As DatabaseEntities = New DatabaseEntities()
        Dim currentCooldowns = (From a As Cooldown In db.Cooldowns.ToList() Join b In db.Commands.ToList() On a.CommandId Equals b.Id
                Where b.Keyword = Command And (a.User = UserName Or (a.User = "." And includeGlobal))
        ).ToList()
        Dim result As Boolean = (From a In currentCooldowns Where a.a.Expiration > Now).Count() > 0
        If resetCooldown Then _resetCooldown(Command, UserName, includeGlobal)


        Return result
    End Function

    Public Sub _resetCooldown(ByVal Command As String, ByVal UserName As String, Optional ByVal includeGlobal As Boolean = True)
        Dim db As DatabaseEntities = New DatabaseEntities()
        Dim currentCooldowns = (From a As Cooldown In db.Cooldowns Join b In db.Commands On a.CommandId Equals b.Id
                Where b.Keyword = Command And (a.User = UserName Or (a.User = "." And includeGlobal))
        )
        Dim commandDef As Command = (From a In db.Commands Where a.Keyword = Command).FirstOrDefault()
        'Check if we're going to reset Global
        If includeGlobal Then
            Dim GlobalCooldown As Cooldown = (From z In currentCooldowns Where z.a.User = "." Select z.a).FirstOrDefault()

            'Create the entry if it doesn't exist
            If GlobalCooldown Is Nothing Then
                GlobalCooldown = New Cooldown()
                GlobalCooldown.CommandId = commandDef.Id
                GlobalCooldown.User = "."
                db.Cooldowns.Add(GlobalCooldown)
            End If
            GlobalCooldown.Expiration = DateAdd(DateInterval.Second, commandDef.GlobalCD, Now)

        End If

        Dim userCooldown As Cooldown = (From z In currentCooldowns Where z.a.User = UserName Select z.a).FirstOrDefault()

        'Create the entry if it doesn't exist
        If userCooldown Is Nothing Then
            userCooldown = New Cooldown()
            userCooldown.CommandId = commandDef.Id
            userCooldown.User = UserName
            db.Cooldowns.Add(userCooldown)
        End If
        userCooldown.Expiration = DateAdd(DateInterval.Second, commandDef.UserCD, Now)
        'Save the updates
        db.SaveChanges()
        'shouldSaveDB = True
    End Sub

    Public Function _getCooldown(ByVal Command As String, ByVal UserName As String, Optional ByVal includeGlobal As Boolean = True)
        Dim db As DatabaseEntities = New DatabaseEntities()
        Dim currentCooldowns = (From a As Cooldown In db.Cooldowns Join b In db.Commands On a.CommandId Equals b.Id
                Where b.Keyword = Command And (a.User = UserName Or (a.User = "." And includeGlobal))
                Select a
                Order By a.Expiration Descending
                Take 1
        ).FirstOrDefault()

        If currentCooldowns Is Nothing Then Return 0
        If currentCooldowns.Expiration < Now Then Return 0

        Return (currentCooldowns.Expiration - Now).TotalSeconds

    End Function

    Private Sub _clearCooldown(ByVal Command As String, ByVal UserName As String, ByVal includeGlobal As Boolean)
        Dim db As DatabaseEntities = New DatabaseEntities()
        Dim currentCooldowns = (From a As Cooldown In db.Cooldowns Join b In db.Commands On a.CommandId Equals b.Id
                Where b.Keyword = Command And (a.User = UserName Or (a.User = "." And includeGlobal))
        )

        'Delete the entry if it exists
        For Each cd In currentCooldowns
            db.Cooldowns.Remove(cd.a)
        Next

        'Save the updates
        db.SaveChanges()
        'shouldSaveDB = True
    End Sub
    Private Sub addBasicCommands()
        'At this point, expressionContextMain should exist
        expressionContextMain.Functions.Add("rnd", New StaticFunction("Rnd", AddressOf _Rnd, 0, 2, "Returns random number between [Begin] and [End]. If no parameters are specified, returns a Double between 0 and 1."))
        expressionContextMain.Functions.Add("cmds", New StaticFunction("CMDS", AddressOf _Cmds, 0, 3, "[User=Everyone(""."")], [Cooldown=true], [Enabled Only=true]. Lists commands available to the current user. Global cooldown denoted by [seconds], user cooldown by {seconds}"))
        expressionContextMain.Functions.Add("docmd", New StaticFunction("DoCMD", AddressOf _DoCMD, 1, 3, "Message, [ForceExecution=true], [AsUser=""[SysCallback]"". Executes a command by name. Text is interpreted as a complete chat message as sent by the user."))
        expressionContextMain.Functions.Add("enablecmd", New StaticFunction("EnableCMD", AddressOf _EnableCMD, 1, 1, "Enables a command by name."))
        expressionContextMain.Functions.Add("disablecmd", New StaticFunction("DisableCMD", AddressOf _DisableCMD, 1, 1, "Disables a command by name."))
        expressionContextMain.Functions.Add("eval", New StaticFunction("eval", AddressOf _Eval, 1, 1, "Evaluate an expression directly."))
        expressionContextMain.Functions.Add("null", New StaticFunction("NULL", AddressOf _Null, 0, 1, "Swallows up any output from the argument."))
        expressionContextMain.Functions.Add("eol", New StaticFunction("EOL", AddressOf _EOL, 0, 0, "Starts a new line in the message."))
        expressionContextMain.Functions.Add("whisper", New StaticFunction("Whisper", AddressOf _Whisper, 1, 1, "Sends the current output to a user directly. Must be the first thing on the line."))
        expressionContextMain.Functions.Add("checkcooldown", New StaticFunction("CheckCoolDown", AddressOf __checkCooldown, 2, 4, "Command, User, [IncludeGlobal=true], [Reset Cooldown=false]. Checks cooldown state of Command."))
        expressionContextMain.Functions.Add("resetcooldown", New StaticFunction("ResetCoolDown", AddressOf __resetCooldown, 2, 3, "Command, User, [IncludeGlobal=true]. Re-applies cooldown to the selected command."))
        expressionContextMain.Functions.Add("clearcooldown", New StaticFunction("ClearCoolDown", AddressOf __clearCooldown, 2, 3, "Command, User, [IncludeGlobal=true]. Clears cooldown to the selected command."))
        expressionContextMain.Functions.Add("getcooldown", New StaticFunction("GetCoolDown", AddressOf __getCooldown, 2, 3, "Command, User, [IncludeGlobal=true]. Gets remaining cooldown (in seconds) for the given user."))
        expressionContextMain.Functions.Add("getuserattribute", New StaticFunction("getUserAttribute", AddressOf __getUserAttribute, 1, 2, "User, [Attribute Name]. If not attribute is specified, returns a space-separated list of set attributes for that user."))
        expressionContextMain.Functions.Add("setuserattribute", New StaticFunction("setUserAttribute", AddressOf __setUserAttribute, 3, 3, "User, Attribute Name, Value."))
        expressionContextMain.Functions.Add("gua", New StaticFunction("gUA", AddressOf __getUserAttribute, 1, 2, "Alias of getUserAttribute"))
        expressionContextMain.Functions.Add("sua", New StaticFunction("sUA", AddressOf __setUserAttribute, 3, 3, "Alias of setUserAttribute"))
        expressionContextMain.Functions.Add("foreach", New StaticFunction("ForEach", AddressOf __foreach, 2, 4, "List, Action, [Separator="" ""], [pushScope=true]. Evaluates Action for each item in List, separated by Separator, with the variable $item given for each item.", False))
        expressionContextMain.Functions.Add("readline", New StaticFunction("ReadLine", AddressOf __readLine, 1, 2, "Txt File, [Line Number]. Reads a line from Txt File. If True is specified for Line Number, chooses random from the file, 1-indexed."))
        expressionContextMain.Functions.Add("writeline", New StaticFunction("WriteLine", AddressOf __writeLine, 3, 3, "Txt File, Line Number, Text to write. Writes/replaces a line to Txt File. If True is specified for Line Number, appends to the end. If False, prepends, if number, replaces the chosen line. 1-indexed."))

    End Sub

    Dim rnd As New Random()

    Private Function _Rnd(ByVal ps As Object())
        Dim num1, num2, mode As Integer

        mode = 0
        'Check for single parameter
        If ps.Count() > 0 Then
            If Integer.TryParse(ps(0), num1) Then
                mode = 1
            Else
                'Throw some kind of error?
            End If
        End If

        'Check for a second parameter
        If ps.Count() > 1 Then
            If Integer.TryParse(ps(1), num2) Then
                If mode = 0 Then
                    'Somehow we got a second parameter but no first parameter.
                    'Assume they wanted it to be the first on accident.
                    num1 = num2
                    mode = 1
                Else
                    mode = 2
                    'correct possible reversal
                    If num1 > num2 Then
                        num1 = num2
                        num2 = Integer.Parse(ps(0))
                    End If
                End If
            Else
                'Throw some kind of error?
            End If
        End If


        If mode = 0 Then Return rnd.NextDouble()
        If mode = 1 Then Return rnd.Next(num1)
        If mode = 2 Then Return rnd.Next(num1, num2)

        Return Nothing
    End Function

    Private Function _Cmds(ByVal ps As Object())
        Dim db As DatabaseEntities = New DatabaseEntities()
        Dim result As StringBuilder = New StringBuilder()

        'Some flags you can set
        Dim Username As String = "", Cooldown As Boolean = True, EnabledOnly As Boolean = True

        If ps.Count() > 0 Then
            'Parameter 1 is the username
            Username = ps(0)
        End If
        If ps.Count() > 1 Then
            'Parameter 2 is the Cooldown
            Boolean.TryParse(ps(1), Cooldown)
        End If
        If ps.Count() > 2 Then
            'Parameter 3 is the Enabled Only
            Boolean.TryParse(ps(2), EnabledOnly)
        End If


        result.Append("Available commands: ")

        'Get commands
        Dim commands = (From a In db.Commands
        Where (a.Enabled = True Or a.Enabled = EnabledOnly)
        ).ToArray()
        'Get cooldowns
        Dim cooldowns = (From a In db.Cooldowns Where a.User = "." Or a.User = Username).ToArray()
        'Get the user queried (if provided)
        Dim usr = (From a In db.Users Where a.UserName.ToLower() = Username.ToLower()).FirstOrDefault()

        For Each cmd As Command In commands
            'Check if the user can execute this command

            Dim PreconditionFailed As Boolean = False, PermissionLevel As Boolean = True, GlobalCooldown As String = "0", UserCooldown As String = "0"
            'Checking Precondition
            If cmd.ExtraPrecondition <> "" Then
                'Note, anything other than False is failure, and returns it as a chat message
                If cmd.ExtraPrecondition.StartsWith("=") Then
                    Dim eval As New TinyExe.Expression(cmd.ExtraPrecondition.Substring(1), expressionContextMain)
                    If eval.Errors.Count > 0 Then
                        'An error in the precondition does not automatically fail the command
                        'Assume we're OK
                    Else
                        Dim resultTemp = eval.Eval()
                        If Not resultTemp Is Nothing Then
                            If TypeOf resultTemp Is Boolean Then
                                If resultTemp <> False Then PreconditionFailed = True
                            Else
                                PreconditionFailed = True
                            End If
                        End If
                    End If
                Else
                    'A message is an automatic fail, give it back to chat
                    PreconditionFailed = True
                End If
            End If

            'Check cooldown
            Dim gCooldown As Cooldown = (From a In cooldowns Where a.CommandId = cmd.Id And a.User = ".").FirstOrDefault()
            Dim uCooldown As Cooldown = (From a In cooldowns Where a.CommandId = cmd.Id And a.User = Username).FirstOrDefault()

            If Not gCooldown Is Nothing Then
                If gCooldown.Expiration > Now Then
                    GlobalCooldown = Math.Round((gCooldown.Expiration - Now).TotalSeconds()).ToString()
                End If
            End If
            If Not uCooldown Is Nothing Then
                If uCooldown.Expiration > Now Then
                    UserCooldown = Math.Round((uCooldown.Expiration - Now).TotalSeconds()).ToString()
                End If
            End If

            'Check permission level
            If Not usr Is Nothing Then
                If cmd.MinPermissionLevel > usr.PermissionLevel Then PermissionLevel = False
            End If

            'Finally, lets see if we can add this command to the list
            If PermissionLevel And Not PreconditionFailed Then
                'Give the keyword
                result.Append(cmd.Keyword)
                'Check if we need to add cooldown info
                If Cooldown Then
                    'If we have a Global cooldown, give that
                    If cmd.GlobalCD > 0 Then
                        result.Append("[")
                        result.Append(GlobalCooldown)
                        result.Append("/")
                        result.Append(cmd.GlobalCD)
                        result.Append("]")
                    End If
                    'If we have a User cooldown, give that
                    If cmd.UserCD > 0 Then
                        result.Append("{")
                        'If we weren't given a user to compare to, we can't give the cooldown for them
                        If usr Is Nothing Then
                            result.Append("--")
                        Else
                            result.Append(UserCooldown)
                        End If
                        result.Append("/")
                        result.Append(cmd.UserCD)
                        result.Append("}")
                    End If
                End If

                'add a space for the next entry
                result.Append(" ")
            End If



        Next

        Return result.ToString()
    End Function

    Private Function _DoCMD(ByVal ps As Object())
        Dim message As String = ps(0)
        Dim forceexecution As Boolean = True
        Dim username As String = "[SysCallback]"
        If ps.Count > 1 Then Boolean.TryParse(ps(1), forceexecution)
        If ps.Count > 2 Then If Not ps(2) Is Nothing Then username = ps(2)


        Return _doCommand(ps(0), forceexecution, username)
    End Function

    Private Function _EnableCMD(ByVal ps As Object())
        Dim db As DatabaseEntities = New DatabaseEntities()
        Dim Command As String = ps(0).ToString()

        Dim commandDef As Command = (From a In db.Commands Where a.Keyword = Command).FirstOrDefault()
        If commandDef Is Nothing Then Return Nothing

        commandDef.Enabled = True
        db.SaveChanges()
        RaiseEvent DbSaveChanges()
        Return Nothing
    End Function
    Private Function _DisableCMD(ByVal ps As Object())
        Dim db As DatabaseEntities = New DatabaseEntities()
        Dim Command As String = ps(0).ToString()

        Dim commandDef As Command = (From a In db.Commands Where a.Keyword = Command).FirstOrDefault()
        If commandDef Is Nothing Then Return Nothing

        commandDef.Enabled = False
        db.SaveChanges()
        RaiseEvent DbSaveChanges()
        Return Nothing
    End Function

    Private Function _Eval(ByVal ps As Object())
        Dim result As Expression = New Expression(ps(0), expressionContextMain)
        If result.Errors.Count > 0 Then
            Return result.Errors(0).Message

        End If
        Return result.Eval()

    End Function

    Private Function _Null(ByVal ps As Object())
        Return Nothing
    End Function

    Private Function _Whisper(ByVal ps As Object())
        Return ps(0).ToString() & Chr(1)
    End Function

    Private Function _EOL(ByVal ps As Object())
        Return Chr(13)
    End Function

    Private Function __checkCooldown(ByVal ps As Object())
        Dim Command As String = ps(0)
        Dim UserName As String = ps(1)
        Dim includeGlobal As Boolean = True
        Dim resetCooldown As Boolean = False

        If ps.Count() > 2 Then includeGlobal = Convert.ToBoolean(ps(2))
        If ps.Count() > 3 Then resetCooldown = Convert.ToBoolean(ps(3))
        Return _checkCooldown(Command, UserName, includeGlobal, resetCooldown)

    End Function

    Private Function __resetCooldown(ByVal ps As Object())
        Dim Command As String = ps(0)
        Dim UserName As String = ps(1)
        Dim includeGlobal As Boolean = True

        If ps.Count() > 2 Then includeGlobal = Convert.ToBoolean(ps(2))
        _resetCooldown(Command, UserName, includeGlobal)
        Return Nothing
    End Function

    Private Function __getCooldown(ByVal ps As Object())
        Dim Command As String = ps(0)
        Dim UserName As String = ps(1)
        Dim includeGlobal As Boolean = True

        If ps.Count() > 2 Then includeGlobal = Convert.ToBoolean(ps(2))

        Return _getCooldown(Command, UserName, includeGlobal)

    End Function
    Private Function __clearCooldown(ByVal ps As Object())
        Dim Command As String = ps(0)
        Dim UserName As String = ps(1)
        Dim includeGlobal As Boolean = True

        If ps.Count() > 2 Then includeGlobal = Convert.ToBoolean(ps(2))

        _clearCooldown(Command, UserName, includeGlobal)
        Return Nothing
    End Function

    Private Function __foreach(ByVal ps As Object())
        'Arguments: List, Action, Separator (default space), PushScope (default True)
        Dim theList As String = ps(0)
        Dim action As String = ps(1)
        Dim separator As String = " "
        Dim pushscope As Boolean = True, result As String = "", lastItem = Nothing

        'Check if we got the separator
        If ps.Length > 2 Then separator = ps(2)

        'Check if we got a flag to push the scope or not
        If ps.Length > 3 Then Boolean.TryParse(ps(2).ToString(), pushscope)


        'Ok, lets prepare the expression context
        If pushscope Then expressionContextMain.PushScope(expressionContextMain.CurrentScope)

        'Clear out the pushed-scope's $arg, $num, and $target variables
        'For Each variable In expressionContextMain.CurrentScope
        '    If variable.Key.StartsWith("$arg") Or variable.Key.StartsWith("$num") Or variable.Key.StartsWith("$target") Then
        '        expressionContextMain.CurrentScope.Remove(variable.Key)
        '    End If
        'Next


        'If we already have an item... Um... Replace it!
        If Not expressionContextMain.CurrentScope.ContainsKey("$item") Then
            expressionContextMain.CurrentScope.Add("$item", "")
        Else
            'save the $item
            lastItem = expressionContextMain.CurrentScope("$item")
        End If


        'Lets loop!
        For Each item As String In theList.Split({separator}, StringSplitOptions.RemoveEmptyEntries)
            'Set the current item
            expressionContextMain.CurrentScope("$item") = item

            'Make the expression
            Dim exp As New Expression(action, expressionContextMain)

            'Check if there's an error
            If exp.Errors.Count > 0 Then
                'Slam up only the first error
                result += exp.Errors(0).Message
            Else
                'Append the result of the evaluation!
                Dim preresult = exp.Eval()
                If Not preresult Is Nothing Then
                    result += preresult.ToString()
                End If

            End If

        Next

        'We're done, lets pop the scope then
        If pushscope Then
            expressionContextMain.PopScope()
        Else
            'if there was no $item before, erase it, else set it
            If lastItem Is Nothing Then
                expressionContextMain.CurrentScope.Remove("$item")
            Else
                expressionContextMain.CurrentScope("$item") = lastItem
            End If
        End If


        Return result
    End Function

    'For file reading, we alias file names. These are stored under their extension like so:
    'Username: ".ext"   Key: "File alias used in commands", Value: "Full Filename Path"
    'For example, a text file for the ReadLine function might look for values like:
    '".txt", "mytext","C:\Users\Me\Documents\My Text.txt"

    Private Function __readLine(ByVal ps As Object())
        Dim requestedFile As String = ps(0)
        'If second parameter is a number, get that line
        'If it's False, read the first line
        'If it's True, read a random line
        'Command will not work with files > 2 Mb for safety reasons
        Dim requestedLine As Integer = 0

        'Get the real file name from the table, if it exists.
        requestedFile = __getUserAttribute({".txt", requestedFile})

        'If the entry doesn't exist, return nothing
        If requestedFile Is Nothing Then Return Nothing

        'Check if the file exists, and is of the right size
        If Dir(requestedFile) = "" Then
            Return Nothing
        End If

        If FileLen(requestedFile) > 2 * 1024 * 1024 Then
            Return "File is too big!"
        End If

        'Okay, we have a file, we know it's not going to kill our memory if we load it, so lets get going!
        'StreamReader to read our file
        Dim ioFile As New StreamReader(requestedFile)
        'Generic list for holding the lines
        Dim lines As New List(Of String)
        'Now we loop through each line of our text file
        'adding each line to our list
        While ioFile.Peek <> -1
            lines.Add(ioFile.ReadLine())
        End While
        ioFile.Close()

        'Now, get our result depending on the input
        If ps.Count() > 1 Then
            If TypeOf ps(1) Is Boolean Then
                If ps(1) Then
                    requestedLine = rnd.Next(1, lines.Count())
                End If
            Else
                'Get a specific line
                If ps(1) > lines.Count Then
                    Return Nothing
                Else
                    Integer.TryParse(ps(1), requestedLine)
                End If
            End If
        End If

        'quick sanity check
        If requestedLine < 1 Or requestedLine > lines.Count Then Return Nothing

        Dim Result = lines(requestedLine - 1)

        'Check for empty string, or possible binary content
        If Result.Length = 0 Or Result.Contains(Chr(0)) Then Return Nothing


        'Check if the line needs to be evaluated
        If Result.StartsWith("=") Then
            Result = _Eval({Result.Substring(1)})
        End If


        Return Result

    End Function

    Private Function __writeLine(ByVal ps As Object())
        Dim requestedFile As String = ps(0)
        'If second parameter is a number, replace that line (1-indexed), 0 will mean the same in this case
        'If it's False, prepend the first line
        'If it's True, append the line
        'Command will not work with files > 2 Mb for safety reasons
        Dim requestedLine As Integer = 0

        'Get the real file name from the table, if it exists.
        requestedFile = __getUserAttribute({".txt", requestedFile})

        'If the entry doesn't exist, return nothing
        If requestedFile Is Nothing Then Return Nothing

        'Check if the file exists, and is of the right size
        If Dir(requestedFile) = "" Then
            'file doesn't exist, touch it
            System.IO.File.Create(requestedFile).Close()
        End If

        If FileLen(requestedFile) > 2 * 1024 * 1024 Then
            Return "File is too big!"
        End If

        'Okay, we have a file, we know it's not going to kill our memory if we load it, so lets get going!
        'StreamReader to read our file
        Dim ioFile As New StreamReader(requestedFile)
        'Generic list for holding the lines
        Dim lines As New List(Of String)
        'Now we loop through each line of our text file
        'adding each line to our list
        While ioFile.Peek <> -1
            lines.Add(ioFile.ReadLine())
        End While
        ioFile.Close()

        'Now, write our result depending on the input
        If ps.Count() > 1 Then
            If TypeOf ps(1) Is Boolean Then
                If ps(1) Then
                    requestedLine = -1
                End If
            Else
                'write a specific line
                If ps(1) > lines.Count Then
                    requestedFile = -1
                Else
                    Integer.TryParse(ps(1), requestedLine)
                End If
            End If
        End If

        'quick sanity check
        Dim Result As String = ""
        If requestedLine < -1 Or requestedLine > lines.Count - 1 Then Return Nothing

        If requestedLine > 0 Then Result = lines(requestedLine - 1)


        'OK great! Lets do our swap/insert
        If requestedLine < 1 Then
            'Special handling
            If requestedLine = 0 Then
                'prepend only
                lines.Insert(0, ps(2))
            Else
                'Append
                lines.Add(ps(2))
            End If

        Else
            lines.Insert(requestedLine - 1, ps(2))
            lines.RemoveAt(requestedLine)
        End If

        'Sweet! Lets save the altered file
        Dim ioWriter As New StreamWriter(requestedFile, False)
        'Write the lines
        For Each line In lines
            ioWriter.WriteLine(line)
        Next
        ioWriter.Close()

        'Give back the old line text
        Return Result

    End Function
    Public Function __getUserAttribute(ByVal ps As Object())
        Dim db As DatabaseEntities = New DatabaseEntities()
        'Expecting UserName, Key. If key not specified, return a list of keys
        Dim UserName As String = ps(0)
        Dim _Key As String = Nothing

        If ps.Count > 1 Then _Key = ps(1)

        Dim result As List(Of UserAttribute) = (From a In db.UserAttributes Where a.UserName = UserName And (a.Key = _Key Or _Key Is Nothing)).ToList()

        If result.Count > 1 Or _Key Is Nothing Then
            Return String.Join(", ", (From a In result Select a.Key))
        Else
            If result.Count = 1 Then Return (result.FirstOrDefault()).Value

        End If
        Return Nothing
    End Function

    Public Function __setUserAttribute(ByVal ps As Object())
        Dim db As DatabaseEntities = New DatabaseEntities()
        'Expecting UserName, Key, value. if value is null, deletes that attribute
        Dim UserName As String = ps(0)
        Dim Key As String = ps(1)
        Dim Attrib As String = Nothing
        If ps.Count > 2 Then Attrib = ps(2)

        'If for some reason we have null for user or key, quit
        If String.IsNullOrWhiteSpace(UserName) Or String.IsNullOrWhiteSpace(Key) Then Return Nothing

        Dim foundattribute As UserAttribute = (From a In db.UserAttributes Where a.UserName = UserName And a.Key = Key).FirstOrDefault()

        'Decision tree time!
        If foundattribute Is Nothing Then

            If Attrib Is Nothing Then
                'Don't do anything. Why would we?
                Return Nothing
            End If
            'Create a new attribute
            foundattribute = New UserAttribute()
            foundattribute.UserName = UserName
            foundattribute.Key = Key
            db.UserAttributes.Add(foundattribute)
        End If
        foundattribute.Value = Attrib

        If Attrib Is Nothing Then db.UserAttributes.Remove(foundattribute)

        db.SaveChanges()
        'shouldSaveDB = True

        Return Nothing
    End Function

    Public Sub UpdateUserData(ByVal OnlineUsers As List(Of String))
        Dim db As DatabaseEntities = New DatabaseEntities()

        'Cache known users
        Dim KnownUsers As List(Of User)

        Try
            KnownUsers = db.Users.ToList()
        Catch ex As Exception
            'Failed to get the users for some reason.
            'We're just going to exit in this case, since we don't want to block with a messagebox, and we don't have a handle to the logger.

            Exit Sub

        End Try



        'Loop through the users given, excluding the bot itself
        For Each userName In (From a In OnlineUsers Where a <> My.Settings.Bot_Name)
            Dim _userName As String = userName
            Dim knownUser As User = (From a In KnownUsers Where a.UserName.ToLowerInvariant() = _userName.ToLowerInvariant()).FirstOrDefault()

            'Check if this user is known
            If knownUser Is Nothing Then
                'Need to create them
                knownUser = New User()
                With knownUser
                    .UserName = _userName
                    .PermissionLevel = 0
                    .FirstSeen = Now

                End With
                'Add them to the DB
                db.Users.Add(knownUser)
            End If

            'Check if this is the first time we've seen them this session
            If knownUser.FirstSeenThisSession < sessionStart Then knownUser.FirstSeenThisSession = Now

            'Update last seen
            knownUser.LastSeen = Now


        Next

        'Save the changes
        db.SaveChanges()
        'shouldSaveDB = True 

    End Sub


End Class
