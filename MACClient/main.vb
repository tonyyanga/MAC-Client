Imports System.IO
Imports System.Collections

Public Class main
    Public Declare Function StartTCPConnection Lib "LibInternet.dll" (Domain As String, Port As UInteger, Optional MaxNumber As Integer = 1) As System.Net.Sockets.Socket
    Public Declare Function TCPSend Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket, Contents As String) As Boolean
    Public Declare Function TCPListen Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket) As String
    Public CurrentSocket As System.Net.Sockets.Socket

    Private Sub Ribbon_Connect_Init()
        'Initialize Ribbon.Connect
        BarList_Connect.Strings.Clear()
        BarList_Conn_ManageProfiles.Strings.Clear()
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\MAC Client\Connections.txt") Then
            Dim line As String, ConnectIP As String, ConnectUser As String
            Dim connlist As ArrayList
            connlist = main_module1.LoadProfile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\MAC Client\Connections.txt")
            For Each line In connlist
                line = Trim(line)
                ConnectIP = Microsoft.VisualBasic.Left(line, InStr(line, " ") - 1)
                ConnectUser = Microsoft.VisualBasic.Right(line, Len(line) - Microsoft.VisualBasic.InStr(line, " "))
                BarList_Connect.Strings.Add(ConnectUser & "@" & ConnectIP)
                BarList_Conn_ManageProfiles.Strings.Add(ConnectUser & "@" & ConnectIP)
            Next
        End If
        BarList_Connect.Strings.Add("新连接")
        BarList_Conn_ManageProfiles.Strings.Add("管理面板")
    End Sub
    Private Sub Init()
        'Initialize Ribbon
        Call Ribbon_Connect_Init()
        BarStaticItem_Status.Caption = "未连接"

        'Hide Group controls
        GroupControl1.Visible = False
        GroupControl2.Visible = False
        GroupControlMain.Visible = False
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Initialization
        Call Init()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Sync Time
        BarStaticItem_Time.Caption = CStr(Today) & " " & CStr(TimeOfDay)
    End Sub

    Private Sub BarList_Connect_ListItemClick(sender As Object, e As DevExpress.XtraBars.ListItemClickEventArgs) Handles BarList_Connect.ListItemClick
        'Deal with BarList_Connect
        With BarList_Connect
            If .Strings(.ItemIndex).ToString = "新连接" Then
                Call Conn_Edit_Show()
            Else
                Dim ConnectIP As String, ConnectUser As String
                ConnectIP = Microsoft.VisualBasic.Left(.Strings(.ItemIndex).ToString, InStr(.Strings(.ItemIndex).ToString, "@") - 1)
                ConnectUser = Microsoft.VisualBasic.Right(.Strings(.ItemIndex).ToString, InStr(.Strings(.ItemIndex).ToString, "@") - 1)
                Connect(ConnectIP, ConnectUser)
            End If
        End With
    End Sub

    Private Sub Conn_Edit_Show()
        Dim Button1 As System.Windows.Forms.Button
        Button1 = New System.Windows.Forms.Button()
        Dim Button2 As System.Windows.Forms.Button
        Button2 = New System.Windows.Forms.Button()
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Dim Textbox1 As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox
        Dim Textbox2 As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox
        'GroupControlMain
        GroupControlMain.Visible = True
        GroupControlMain.Controls.Add(Button2)
        GroupControlMain.Controls.Add(Textbox1)
        GroupControlMain.Controls.Add(Textbox2)
        GroupControlMain.Controls.Add(Label4)
        GroupControlMain.Controls.Add(Label3)
        GroupControlMain.Controls.Add(Label2)
        GroupControlMain.Controls.Add(Button1)
        GroupControlMain.Controls.Add(Button2)
        GroupControlMain.Location = New System.Drawing.Point(282, 153)
        GroupControlMain.Size = New System.Drawing.Size(436, 234)
        GroupControlMain.TabIndex = 5
        GroupControlMain.Text = "新连接"
        'Button1
        Button1.Location = New System.Drawing.Point(188, 160)
        Button1.Size = New System.Drawing.Size(75, 23)
        Button1.TabIndex = 7
        Button1.Text = "保存连接"
        Button1.UseVisualStyleBackColor = True
        AddHandler Button1.Click, AddressOf Conn_Edit_Save_Click
        'Button2
        Button2.Location = New System.Drawing.Point(188, 189)
        Button2.Size = New System.Drawing.Size(75, 23)
        Button2.TabIndex = 8
        Button2.Text = "放弃"
        Button2.UseVisualStyleBackColor = True
        AddHandler Button2.Click, AddressOf Conn_Edit_Cancel_Click
        'Label2
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(127, 73)
        Label2.Size = New System.Drawing.Size(55, 14)
        Label2.TabIndex = 2
        Label2.Text = "默认客户端端口=8010"
        'Label3
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(127, 96)
        Label3.Size = New System.Drawing.Size(31, 14)
        Label3.TabIndex = 3
        Label3.Text = "域名："
        'Label4
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(127, 120)
        Label4.Size = New System.Drawing.Size(43, 14)
        Label4.TabIndex = 4
        Label4.Text = "用户："
        'TextBox2
        Textbox2.Location = New System.Drawing.Point(176, 119)
        Textbox2.Size = New System.Drawing.Size(100, 22)
        Textbox2.TabIndex = 6
        Textbox2.Name = "Textbox2"
        Textbox2.Text = ""
        'TextBox1
        Textbox1.Location = New System.Drawing.Point(176, 95)
        Textbox1.Size = New System.Drawing.Size(100, 22)
        Textbox1.TabIndex = 5
        Textbox1.Name = "Textbox1"
        Textbox1.Text = ""
        Textbox1.Focus()
    End Sub

    Private Sub Login_Show(Server As String, Optional User As String = "", Optional Note As String = "无", Optional Password As String = "")
        Dim Button1 As System.Windows.Forms.Button
        Button1 = New System.Windows.Forms.Button()
        Dim Button2 As System.Windows.Forms.Button
        Button2 = New System.Windows.Forms.Button()
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Dim Textbox1 As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox
        'GroupControlMain
        GroupControlMain.Visible = True
        GroupControlMain.Controls.Add(Button2)
        GroupControlMain.Controls.Add(Textbox1)
        GroupControlMain.Controls.Add(Label4)
        GroupControlMain.Controls.Add(Label3)
        GroupControlMain.Controls.Add(Label2)
        GroupControlMain.Controls.Add(Label1)
        GroupControlMain.Controls.Add(Button1)
        GroupControlMain.Location = New System.Drawing.Point(282, 153)
        GroupControlMain.Size = New System.Drawing.Size(436, 234)
        GroupControlMain.TabIndex = 5
        GroupControlMain.Text = "登录服务端"
        'Button1
        Button1.Location = New System.Drawing.Point(188, 160)
        Button1.Size = New System.Drawing.Size(75, 23)
        Button1.TabIndex = 0
        Button1.Text = "登录"
        Button1.UseVisualStyleBackColor = True
        AddHandler Button1.Click, AddressOf Conn_Connect_Click
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
        Label1.Text = "连接到" & Server
        'Label2
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(127, 73)
        Label2.Size = New System.Drawing.Size(55, 14)
        Label2.TabIndex = 2
        Label2.Text = "提示信息:" & Note
        'Label3
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(127, 96)
        Label3.Size = New System.Drawing.Size(31, 14)
        Label3.TabIndex = 3
        Label3.Text = "用户：" & User
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
        Textbox1.Text = Password
        Textbox1.UseSystemPasswordChar = True
    End Sub
    Private Sub Connect(ConnectIP As String, User As String)
        'Start Socket ,get auth note and show login form
        Dim socket As System.Net.Sockets.Socket
        BarStaticItem_Status.Caption = "连接中"
        socket = StartTCPConnection(ConnectIP, 8010)
        If IsNothing(socket) Then
            MsgBox("连接失败!" & Chr(10) & ConnectIP & ":8010", vbOKOnly, "MAC Client")
        Else
            CurrentSocket = socket
            If TCPSend(CurrentSocket, "Get Auth Note") Then
                Login_Show(ConnectIP, User, TCPListen(CurrentSocket))
            Else
                Login_Show(ConnectIP, User)
            End If
            BarStaticItem_Status.Caption = "已连接到" & ConnectIP
        End If
    End Sub

    Private Sub Conn_Connect_Click()

    End Sub

    Private Sub Conn_Cancel_Click()
        'Handle Connect.Cancel.Click
        CurrentSocket.Close()
        CurrentSocket = Nothing
        Call Clean_GroupMain()
    End Sub

    Private Sub Conn_Edit_Save_Click()
        Dim ip As System.Windows.Forms.TextBox, user As System.Windows.Forms.TextBox
        ip = Nothing
        user = Nothing
        For Each obj As System.Windows.Forms.Control In GroupControlMain.Controls
            If obj.Name = "Textbox1" Then ip = DirectCast(obj, System.Windows.Forms.TextBox)
            If obj.Name = "Textbox2" Then user = DirectCast(obj, System.Windows.Forms.TextBox)
        Next
        Try
            If Not (Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\MAC Client")) Then Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\MAC Client")
            If Not (main_module1.WriteProfile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\MAC Client\Connections.txt",
                                   Trim(ip.Text) & " " & Trim(user.Text))) Then MsgBox("保存失败", vbOKOnly, "MAC Client")

        Catch ex As Exception
            MsgBox("保存失败, " & ex.Message, vbOKOnly, "MAC Client")
        End Try
        Call Clean_GroupMain()
        Call Ribbon_Connect_Init()
    End Sub

    Private Sub Conn_Edit_Cancel_Click()
        'Handle EditConnection.Cancel.Click
        Call Clean_GroupMain()
    End Sub
    Private Sub Clean_GroupMain()
        'Clean GroupMain and hide it.
        Dim obj As System.Windows.Forms.Control
        For Each obj In GroupControlMain.Controls
            GroupControlMain.Controls.Remove(obj)
            obj = Nothing
        Next
        GroupControlMain.Visible = False
    End Sub
End Class