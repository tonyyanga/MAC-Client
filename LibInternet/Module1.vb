Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports LibInternet.Crypt
Namespace Internet
    Public Module Module1
        Public Function StartTCPConnection(Domain As String, Port As UInteger) As Socket
            Try
                Dim Socket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Domain = Trim(Domain)
                Dim EndPoint As New DnsEndPoint(Domain, Port)
                Socket.Bind(EndPoint)
                Socket.Connect(EndPoint)
                'Socket.Listen(MaxNumber)
                StartTCPConnection = Socket
            Catch
                StartTCPConnection = Nothing
                Exit Function
            End Try
        End Function

        Public Function TCPSend(Connection As Socket, Contents As String) As Boolean
            'TCP Send
            Dim msg As Byte() = System.Text.Encoding.UTF8.GetBytes(Contents)
            Try
                Connection.Send(msg)
                Connection.Send(System.Text.Encoding.UTF8.GetBytes("###"))
            Catch ex As Exception
                TCPSend = False
            End Try
            TCPSend = True
        End Function

        Public Function TCPListen(Connection As Socket) As String
            'TCP Listen. Ended with ###.
            Dim bytes() As Byte = New [Byte](1024) {}
            Dim data As String = ""
            Dim result As String = ""
            Dim bytesRec As Integer
            While True
                Try
                    bytesRec = Connection.Receive(bytes)
                Catch ex As Exception
                    'If ex.ToString = SocketError.ConnectionReset Or ex = SocketError.HostDown Or ex = SocketError.NetworkDown Then Return "DISCONNECT###"
                    TCPListen = "ERROR"
                End Try
                data = System.Text.Encoding.UTF8.GetString(bytes, 0, bytesRec)
                data = Trim(data)

                If data = "###" Then
                    Exit While
                Else
                    result = result & data
                    data = ""
                End If
                Thread.Yield()
            End While
            TCPListen = result
        End Function

        Public Function Login(CurrentSocket As Socket, Username As String, Passwd As String) As String
            'Login and get login code, encrypted with "AUTH".
            Dim listen As String
            If Not (TCPSend(CurrentSocket, "LOGIN " & Username & "@" & Passwd)) Then Login = False
            listen = TCPListen(CurrentSocket)
            If Left(listen, 9) = "AUTH PASS" Then
                Return Decrypt(Right(listen, Microsoft.VisualBasic.Len(listen) - 9), "AUTH PASS")
            ElseIf listen = "AUTH FAIL" Then
                Login = "FAIL"
            Else
                Login = ""
            End If
        End Function

        Public Function GetStatus(Connection As Socket, LoginCode As String) As Byte
            Dim listen As String
            If Not (TCPSend(Connection, Encrypt("GET STATUS", LoginCode))) Then GetStatus = 0
            listen = TCPListen(Connection)
            Select Case listen
                Case "RUNNING"
                    GetStatus = 1
                Case "SUSPEND"
                    GetStatus = 2
                Case "DISABLED"
                    GetStatus = 3
                Case Else
                    GetStatus = 0
            End Select
        End Function

        Public Function GetStarFeature(Connection As Socket, LoginCode As String) As Byte
            If Not (TCPSend(Connection, Encrypt("GET FEATURE STAR", LoginCode))) Then GetStarFeature = 0
            Return AnalyzeFeatureStatus(TCPListen(Connection))
        End Function

        Public Function GetLevelUp(Connection As Socket, LoginCode As String) As Byte
            If Not (TCPSend(Connection, Encrypt("GET FEATURE LEVELUP", LoginCode))) Then GetLevelUp = 0
            Return AnalyzeFeatureStatus(TCPListen(Connection))
        End Function
        Public Function GetFileEncrypt(Connection As Socket, LoginCode As String) As Byte
            If Not (TCPSend(Connection, Encrypt("GET FEATURE FILEENCRYPT", LoginCode))) Then GetFileEncrypt = 0
            Return AnalyzeFeatureStatus(TCPListen(Connection))
        End Function
        Public Function GetDomainControl(Connection As Socket, LoginCode As String) As Byte
            If Not (TCPSend(Connection, Encrypt("GET FEATUER DOMAINCTRL", LoginCode))) Then GetDomainControl = 0
           Return AnalyzeFeatureStatus(TCPListen(Connection))
        End Function
        Private Function AnalyzeFeatureStatus(value As String) As Byte
            Select Case value
                Case "ENABLED"
                    Return 1
                Case "DISABLED"
                    Return 2
                Case "UNAVAILABLE"
                    Return 3
                Case Else
                    Return 0
            End Select
        End Function
        Private Function AnalyzeServiceCommand(value As String) As Byte
            Select Case value
                Case "SUCCEED"
                    Return 1
                Case "ALREADY"
                    Return 2
                Case "FAIL"
                    Return 3
                Case Else
                    Return 0
            End Select
        End Function
        Public Function StartService(Conn As Socket, Logincode As String) As Byte
            If Not (TCPSend(Conn, Encrypt("START SERVICE", Logincode))) Then Return 0
            Return AnalyzeServiceCommand(TCPListen(Conn))
        End Function
        Public Function PauseService(Conn As Socket, Logincode As String) As Byte
            If Not (TCPSend(Conn, Encrypt("PAUSE SERVICE", Logincode))) Then Return 0
            Return AnalyzeServiceCommand(TCPListen(Conn))
        End Function
        Public Function StopService(Conn As Socket, Logincode As String) As Byte
            If Not (TCPSend(Conn, Encrypt("STOP SERVICE", Logincode))) Then Return 0
            Return AnalyzeServiceCommand(TCPListen(Conn))
        End Function
        Public Function DisableService(Conn As Socket, Logincode As String) As Byte
            If Not (TCPSend(Conn, Encrypt("DISABLE SERVICE", Logincode))) Then Return 0
            Return AnalyzeServiceCommand(TCPListen(Conn))
        End Function
        Public Function CheckComp(Conn As Socket, Logincode As String) As String
            If Not (TCPSend(Conn, Encrypt("CHECK COMPONENTS", Logincode))) Then Return "ERROR"
            Return (TCPListen(Conn))
        End Function
        Public Function ResetDB(Conn As Socket, Logincode As String) As Boolean
            If Not (TCPSend(Conn, Encrypt("CHECK COMPONENTS", Logincode))) Then Return False
            If TCPListen(Conn) Then Return True Else Return False
        End Function
        Public Function GetSysInfo(Conn As Socket, Logincode As String) As String
            If Not (TCPSend(Conn, Encrypt("GET SYSTEMINFO", Logincode))) Then Return "ERROR"
            Return (TCPListen(Conn))
        End Function
        Public Function GetServiceInfo(Conn As Socket, Logincode As String) As String
            If Not (TCPSend(Conn, Encrypt("GET SERVICEINFO", Logincode))) Then Return "ERROR"
            Return (TCPListen(Conn))
        End Function
        Public Function GetAffairsInfo(Conn As Socket, AffairsID As String, Logincode As String) As String
            If Not (TCPSend(Conn, Encrypt("GET AFFAIRINFO " + AffairsID, Logincode))) Then Return "ERROR"
            Return (TCPListen(Conn))
        End Function
        Public Function GetAffairsSuggestion(Conn As Socket, AffairsID As String, Logincode As String) As String
            If Not (TCPSend(Conn, Encrypt("GET AFFAIRSUGGESTION " + affairsid, Logincode))) Then Return "ERROR"
            Return (TCPListen(Conn))
        End Function
        Public Function AffairsResult(Conn As Socket, AffairsID As String, Method As Byte, Logincode As String) As Boolean
            Select Case Method
                Case 1
                    If Not (TCPSend(Conn, Encrypt("AFFAIR " + AffairsID + " ALLOW", Logincode))) Then Return False
                Case 2
                    If Not (TCPSend(Conn, Encrypt("AFFAIR " + AffairsID + " REJECT", Logincode))) Then Return False
                Case 3
                    If Not (TCPSend(Conn, Encrypt("AFFAIR " + AffairsID + " ALLOWASRULE", Logincode))) Then Return False
                Case 4
                    If Not (TCPSend(Conn, Encrypt("AFFAIR " + AffairsID + " REJECTASRULE", Logincode))) Then Return False
                Case Else
                    Return False
            End Select
            Return True
        End Function
        Public Function GetBLPStategies(Conn As Socket, Logincode As String) As String
            If Not (TCPSend(Conn, Encrypt("GET BLPSTATEGIES ", Logincode))) Then Return "ERROR"
            Return (TCPListen(Conn))
        End Function
        Public Function GetLevels(Conn As Socket, Logincode As String) As String
            If Not (TCPSend(Conn, Encrypt("GET LEVELS ", Logincode))) Then Return "ERROR"
            Return (TCPListen(Conn))
        End Function
        'Public Function GetLevelID(Conn As Socket, LevelName As String, Logincode As String) As String
        '    If Not (TCPSend(Conn, Encrypt("GET LEVELS ", Logincode))) Then Return "ERROR"
        '    Return (TCPListen(Conn))
        'End Function
        Public Function GetLevelDetails(Conn As Socket, Logincode As String) As MLS.MLSCollection

        End Function
        Public Function AdoptStrategy(Conn As Socket, Logincode As String, name As String) As Boolean
            Return TCPSend(Conn, Encrypt("SET STRATEGY " + name, Logincode))
        End Function
    End Module
End Namespace