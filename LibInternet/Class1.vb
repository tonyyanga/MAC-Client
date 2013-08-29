Imports System.Threading
Imports System.Net
Imports System.Net.Sockets

Public Class Class1
    Public Function StartTCPConnection(Domain As String, Port As UInteger, Optional MaxNumber As Integer = 1) As Socket
        Try
            Dim Socket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Domain = Trim(Domain)
            Dim EndPoint As New DnsEndPoint(Domain, Port)
            Socket.Bind(EndPoint)
            Socket.Listen(MaxNumber)
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
        Catch ex As Exception
            TCPSend = False
            Exit Function
        End Try
        TCPSend = True
    End Function

    Public Function TCPListen(Connection As Socket) As String
        Dim bytes() As Byte = New [Byte](1024) {}
        Dim data As String = ""
        Dim result As String = ""
        Dim bytesRec As Integer
        While True
            bytesRec = Connection.Receive(bytes)
            data = System.Text.Encoding.UTF8.GetString(bytes, 0, bytesRec)
            data = Trim(data)
            If data = "###" Then
                Exit While
            Else
                result = result & data
                data = ""
            End If
        End While
        TCPListen = result
    End Function

End Class
