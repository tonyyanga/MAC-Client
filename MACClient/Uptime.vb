Public MustInherit Class Uptime
    Friend Property Form As main
    Friend Property ListView As System.Windows.Forms.ListView
    Friend Declare Function TCPSend Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket, Contents As String) As Boolean
    Friend Declare Function TCPListen Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket) As String
End Class
