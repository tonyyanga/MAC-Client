Public Class Affairs
    Inherits Uptime
    Friend Property ListView As System.Windows.Forms.ListView
    Friend Sub GetAffairs()
        Dim listen As String = ""
        If Not (TCPSend(Form.CurrentSocket3, "GET AFFAIRS")) Then Exit Sub
        While True
            While listen = ""
                listen = TCPListen(Form.CurrentSocket3)
            End While
            Convert(listen)
            Threading.Thread.Sleep(10000)
        End While
    End Sub
    Private Sub Convert(ByRef contents As String)

    End Sub

End Class
