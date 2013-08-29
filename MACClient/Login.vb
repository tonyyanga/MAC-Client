Public Class Login
    Inherits CGroupControl
    Friend Property user As String
    Friend Property password As System.Windows.Forms.TextBox
    Public Declare Function UserLogin Lib "LibInternet.dll" Alias "Login" (CurrentSocket As System.Net.Sockets.Socket, Username As String, Passwd As String) As String
    Friend Sub Conn_Login_Click()
        Dim logincode As String
        Form.BarStaticItem_Status.Caption = "正连接到" & Form.Server
        logincode = UserLogin(Form.CurrentSocket, user, Trim(password.Text))
        If logincode = "ERROR" Then
            MsgBox("登录失败" & Chr(10) & "用户名或密码错误", vbExclamation, "MAC Client")
            Form.Server = ""
        ElseIf logincode = "" Then
            MsgBox("登录失败" & Chr(10) & "未知错误", vbExclamation, "MAC Client")
            Form.Server = ""
        Else
            Form.LoginCode = logincode
            Form.User = user
            Form.Passwd = Trim(password.Text)
            Clean_GroupControl(GroupControl)
            Form.connected()
        End If
	Form.CurrentSocket.Disconnect()
    End Sub

    Friend Sub Conn_Cancel_Click()
        'Handle Connect.Cancel.Click
        Form.CurrentSocket.Close()
        Form.CurrentSocket = Nothing
        Form.Server = ""
        Clean_GroupControl(GroupControl)
    End Sub

End Class
