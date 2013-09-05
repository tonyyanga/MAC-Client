Public Class GetSysStatus
    Inherits Uptime
    Friend Sub GetStatus()
        Dim listen As String = ""
        If Not (TCPSend(Form.CurrentSocket2, "GET SYSSTATUS")) Then Exit Sub
        While True
            While listen = ""
                listen = TCPListen(Form.CurrentSocket2)
            End While
            Convert(listen)
            Threading.Thread.Sleep(10000)
        End While
    End Sub
    Private Sub Convert(ByRef contents As String)

    End Sub
End Class
