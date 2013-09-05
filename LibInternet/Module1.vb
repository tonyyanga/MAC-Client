Imports System.Threading
Imports System.Net
Imports System.Net.Sockets


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
        Dim bytes() As Byte = New [Byte](1024) {}
        Dim data As String = ""
        Dim result As String = ""
        Dim bytesRec As Integer
        While True
            Try
                bytesRec = Connection.Receive(bytes)
            Catch ex As Exception
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
        Dim listen As String
        If Not (TCPSend(CurrentSocket, "LOGIN " & Username & "@" & Passwd)) Then Login = False
        listen = TCPListen(CurrentSocket)
        If Left(listen, 9) = "AUTH PASS" Then
            Login = Right(listen, Microsoft.VisualBasic.Len(listen) - 9)
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
        Dim listen As String
        If Not (TCPSend(Connection, Encrypt("GET FEATURE STAR", LoginCode))) Then GetStarFeature = 0
        listen = TCPListen(Connection)
        Select Case listen
            Case "ENABLED"
                GetStarFeature = 1
            Case "DISABLED"
                GetStarFeature = 2
            Case "UNAVAILABLE"
                GetStarFeature = 3
            Case Else
                GetStarFeature = 0
        End Select
    End Function

    Public Function GetLevelUp(Connection As Socket, LoginCode As String) As Byte
        Dim listen As String
        If Not (TCPSend(Connection, Encrypt("GET FEATURE LEVELUP", LoginCode))) Then getlevelup = 0
        listen = TCPListen(Connection)
        Select Case listen
            Case "ENABLED"
                getlevelup = 1
            Case "DISABLED"
                getlevelup = 2
            Case "UNAVAILABLE"
                getlevelup = 3
            Case Else
                getlevelup = 0
        End Select
    End Function
    Public Function GetFileEncrypt(Connection As Socket, LoginCode As String) As Byte
        Dim listen As String
        If Not (TCPSend(Connection, Encrypt("GET FEATURE FILEENCRYPT", LoginCode))) Then GetFileEncrypt = 0
        listen = TCPListen(Connection)
        Select Case listen
            Case "ENABLED"
                getfileencrypt = 1
            Case "DISABLED"
                getfileencrypt = 2
            Case "UNAVAILABLE"
                getfileencrypt = 3
            Case Else
                getfileencrypt = 0
        End Select
    End Function
    Public Function GetDomainControl(Connection As Socket, LoginCode As String) As Byte
        Dim listen As String
        If Not (TCPSend(Connection, Encrypt("GET FEATUER DOMAINCTRL", LoginCode))) Then GetDomainControl = 0
        listen = TCPListen(Connection)
        Select Case listen
            Case "ENABLED"
                GetDomainControl = 1
            Case "DISABLED"
                GetDomainControl = 2
            Case "UNAVAILABLE"
                GetDomainControl = 3
            Case Else
                GetDomainControl = 0
        End Select
    End Function
End Module
