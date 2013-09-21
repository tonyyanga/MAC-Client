Public Class Login
    Inherits CGroupControl
    Friend Property user As String
    Friend Property note As String
    Private Declare Function UserLogin Lib "LibInternet.dll" Alias "Login" (CurrentSocket As System.Net.Sockets.Socket, Username As String, Passwd As String) As String

    Friend Property Button1 As System.Windows.Forms.Button
    Friend Property Button2 As System.Windows.Forms.Button
    Friend Property Label1 As System.Windows.Forms.Label
    Friend Property Label2 As System.Windows.Forms.Label
    Friend Property Label3 As System.Windows.Forms.Label
    Friend Property Label4 As System.Windows.Forms.Label
    Friend Property Textbox1 As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox
    Friend Sub Load()
        'GroupControlMain
        Clean_GroupControl()
        GroupControl.Visible = True
        GroupControl.Controls.Add(Button2)
        GroupControl.Controls.Add(Textbox1)
        GroupControl.Controls.Add(Label4)
        GroupControl.Controls.Add(Label3)
        GroupControl.Controls.Add(Label2)
        GroupControl.Controls.Add(Label1)
        GroupControl.Controls.Add(Button1)
        GroupControl.Location = New System.Drawing.Point(282, 153)
        GroupControl.Size = New System.Drawing.Size(436, 234)
        GroupControl.TabIndex = 5
        GroupControl.Text = "登录服务端"
        GroupControl.Tag = "Login"
        'Button1
        Button1.Location = New System.Drawing.Point(188, 160)
        Button1.Size = New System.Drawing.Size(75, 23)
        Button1.TabIndex = 0
        Button1.Text = "登录"
        Button1.UseVisualStyleBackColor = True
        AddHandler Button1.Click, AddressOf Conn_Login_Click
        'Button2
        Button2.Location = New System.Drawing.Point(188, 189)
        Button2.Size = New System.Drawing.Size(75, 23)
        Button2.TabIndex = 6
        Button2.Text = "断开连接"
        Button2.UseVisualStyleBackColor = True
        AddHandler Button2.Click, AddressOf Conn_Cancel_Click
        'Label1
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(127, 46)
        Label1.Size = New System.Drawing.Size(43, 14)
        Label1.TabIndex = 1
        Label1.Text = "连接到" & Form.Server
        'Label2
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(127, 73)
        Label2.Size = New System.Drawing.Size(55, 14)
        Label2.TabIndex = 2
        Label2.Text = "提示信息:" & note
        'Label3
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(127, 96)
        Label3.Size = New System.Drawing.Size(31, 14)
        Label3.TabIndex = 3
        Label3.Text = "用户：" & user
        'Label4
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(127, 120)
        Label4.Size = New System.Drawing.Size(43, 14)
        Label4.TabIndex = 4
        Label4.Text = "密码："
        'TextBox1
        Textbox1.Location = New System.Drawing.Point(176, 119)
        Textbox1.Size = New System.Drawing.Size(100, 22)
        Textbox1.TabIndex = 5
        Textbox1.Text = ""
        Textbox1.UseSystemPasswordChar = True

    End Sub
    Friend Sub Conn_Login_Click()
        Dim logincode As String
        Form.BarStaticItem_Status.Caption = "正连接到" & Form.Server
        logincode = UserLogin(Form.CurrentSocket, user, Trim(Textbox1.Text))
        If logincode = "ERROR" Then
            MsgBox("登录失败" & Chr(10) & "用户名或密码错误", vbExclamation, "MAC Client")
            Form.Server = ""
        ElseIf logincode = "" Then
            MsgBox("登录失败" & Chr(10) & "未知错误", vbExclamation, "MAC Client")
            Form.Server = ""
        Else
            Form.BarStaticItem_Status.Caption = "已连接到" & Form.Server
            Form.LoginCode = logincode
            Form.User = user
            Form.Passwd = Trim(Textbox1.Text)
            Clean_GroupControl()
            Form.connected()
        End If
    End Sub

    Friend Sub Conn_Cancel_Click()
        'Handle Connect.Cancel.Click
        Form.CurrentSocket.Close()
        Form.CurrentSocket = Nothing
        Form.Server = ""
        Clean_GroupControl()
    End Sub

End Class
