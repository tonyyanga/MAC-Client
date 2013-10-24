Imports System.IO
Imports System.Collections
Imports System.Threading
Imports LibInternet.Internet

Public Class main
    'Private Declare Function StartTCPConnection Lib "LibInternet.dll" (Domain As String, Port As UInteger, Optional MaxNumber As Integer = 1) As System.Net.Sockets.Socket
    'Private Declare Function TCPSend Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket, Contents As String) As Boolean
    'Private Declare Function TCPListen Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket) As String
    'Private Declare Function GetStatus Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket, LoginCode As String) As Byte
    'Private Declare Function GetStarFeature Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket, LoginCode As String) As Byte
    'Private Declare Function GetLevelUp Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket, LoginCode As String) As Byte
    'Private Declare Function GetDomainControl Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket, LoginCode As String) As Byte
    'Private Declare Function GetFileEncrypt Lib "LibInternet.dll" (Connection As System.Net.Sockets.Socket, LoginCode As String) As Byte
    Friend Property CurrentSocket As System.Net.Sockets.Socket
    Friend Property CurrentSocket2 As System.Net.Sockets.Socket
    Friend Property CurrentSocket3 As System.Net.Sockets.Socket
    Friend Property LoginCode As String = ""
    Friend Property User As String = ""
    Friend Property Passwd As String = ""
    Friend Property Server As String = ""
    Private Property GetAffairs As Thread
    Private Property GetSysStatus As Thread

    Friend Sub Ribbon_Connect_Init()
        'Initialize Ribbon.Connect
        BarList_Connect.Strings.Clear()
        BarList_Conn_ManageProfiles.Strings.Clear()
        LoadConn(BarList_Connect, BarList_Conn_ManageProfiles)
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
        Static count As Integer
        count += 1
        If count = 100 Then
            count = 0
        End If

        'Sync Time
        BarStaticItem_Time.Caption = CStr(Today) & " " & CStr(TimeOfDay)
    End Sub

    Private Sub BarList_Connect_ListItemClick(sender As Object, e As DevExpress.XtraBars.ListItemClickEventArgs) Handles BarList_Connect.ListItemClick
        'Deal with BarList_Connect
        Dim selected As String
        With BarList_Connect
            selected = .Strings(.ItemIndex).ToString
            If selected = "新连接" Then
                Call Conn_Edit_Show()
            Else
                Connect(Microsoft.VisualBasic.Left(selected, InStr(selected, "@") - 1), Microsoft.VisualBasic.Right(selected, InStr(selected, "@") - 1))
            End If
        End With
    End Sub

    Private Sub Conn_Edit_Show()
        Dim CEdit As Conn_Edit = New Conn_Edit
        'Class CEdit
        CEdit.GroupControl = GroupControlMain
        CEdit.Form = Me
        CEdit.Load()
    End Sub

    Private Sub Login_Show(Optional Note As String = "")
        Dim CLogin As Login = New Login
        'CLogin
        CLogin.Form = Me
        CLogin.GroupControl = GroupControlMain
        CLogin.user = User
        CLogin.note = Note
        CLogin.Load()
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
            socket.Listen(1)
            If TCPSend(CurrentSocket, "Get Auth Note") Then
                Login_Show(TCPListen(CurrentSocket))
            Else
                Login_Show()
            End If
            BarStaticItem_Status.Caption = "已连接到" & ConnectIP
            Server = ConnectIP
        End If
    End Sub

    Friend Sub Connected()
        Dim obj As System.Windows.Forms.Control
        Dim value As String(), str As String
        For Each obj In Me.Controls
            obj.Enabled = True
        Next
        'Form
        BarList_Connect.Enabled = False
        BarStaticItem_Status.Caption = "获取远程服务状态"
        value = Split(GetBLPStategies(CurrentSocket, LoginCode), "|", , CompareMethod.Text)
        For Each str In value
            BarList_BLP_Strategies.Strings.Add(str)
        Next
        value = Split(Getlevels(CurrentSocket, LoginCode), "|", , CompareMethod.Text)
        For Each str In value
            BarList_BLP_EditLevel.Strings.Add(str)
        Next
        Select Case GetStatus(CurrentSocket, LoginCode)
            Case 0
                MsgBox("获取远程服务状态失败！" & Chr(10) & "连接将中断！", vbExclamation, "MAC Client")
                TCPSend(CurrentSocket, "DISCONNECT")
                CurrentSocket = Nothing
                Init()
            Case 1
                BarButton_Service_Start.Enabled = False
                BarStaticItem_Status.Caption = "已连接到" & Server & "  服务正在运行"
            Case 2
                BarButton_Service_Pause.Enabled = False
                BarStaticItem_Status.Caption = "已连接到" & Server & "  服务暂停"
            Case 3
                BarButton_Service_Disable.Enabled = False
                BarButton_Service_Pause.Enabled = False
                BarStaticItem_Status.Caption = "已连接到" & Server & "  服务停止"
        End Select
        Select Case GetStarFeature(CurrentSocket, LoginCode)
            Case 0
                MsgBox("获取*特性状态失败！", vbExclamation, "MAC Client")
                BarButton_BLP_ObjPromotion.Enabled = False
            Case 1
                BarButton_BLP_ObjPromotion.Caption = "禁用*特性"
            Case 2
                BarButton_BLP_ObjPromotion.Caption = "启用*特性"
            Case 3
                BarButton_BLP_ObjPromotion.Enabled = False
        End Select
        Select Case GetLevelUp(CurrentSocket, LoginCode)
            Case 0
                MsgBox("获取程序等级提升状态失败！", vbExclamation, "MAC Client")
                BarButton_BLP_SbjPromotion.Enabled = False
            Case 1
                BarButton_BLP_SbjPromotion.Caption = "禁用程序等级提升"
            Case 2
                BarButton_BLP_SbjPromotion.Caption = "启用程序等级提升"
            Case 3
                BarButton_BLP_SbjPromotion.Enabled = False
        End Select
        Select Case GetFileEncrypt(CurrentSocket, LoginCode)
            Case 0
                MsgBox("获取文件加密状态失败！", vbExclamation, "MAC Client")
                BarButton_Encrypt_Enable.Enabled = False
            Case 1
                BarButton_Encrypt_Enable.Caption = "禁用文件加密"
            Case 2
                BarButton_Encrypt_Enable.Caption = "启用文件加密"
            Case 3
                BarButton_Encrypt_Enable.Enabled = False
        End Select
        Select Case GetLevelUp(CurrentSocket, LoginCode)
            Case 0
                MsgBox("获取计算机组策略状态失败！", vbExclamation, "MAC Client")
                BarButton_Domain_Enable.Enabled = False
            Case 1
                BarButton_Domain_Enable.Caption = "禁用计算机组"
            Case 2
                BarButton_Domain_Enable.Caption = "启用计算机组"
            Case 3
                BarButton_Domain_Enable.Enabled = False
        End Select
        GroupControlMain.Visible = False

        'Affairs
        Dim CAffairs As GetAffairs = New GetAffairs
        GetAffairs = New Thread(AddressOf CAffairs.GetAffairs)
        CAffairs.Form = Me
        CAffairs.ListView = ListView4
        GetAffairs.Start()
        CurrentSocket2 = StartTCPConnection(Server, 8010)
        'Status
        Dim CStatus As GetSysStatus = New GetSysStatus
        GetSysStatus = New Thread(AddressOf CStatus.GetStatus)
        CStatus.Form = Me
        CStatus.ListView_IO = ListView1
        CStatus.ListView_Process = ListView2
        CStatus.ListView_Services = ListView3
        GetSysStatus.Start()
        CurrentSocket3 = StartTCPConnection(Server, 8010)
    End Sub


    Private Sub BarButton_Disconnect_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_Disconnect.ItemClick
        Disconnect()
    End Sub
    Friend Sub Disconnect()
        'Close all sockets and reset all properties
        CurrentSocket.Close()
        CurrentSocket2.Close()
        CurrentSocket3.Close()
        Server = ""
        User = ""
        Passwd = ""
        LoginCode = ""
        'Clean the working area and init the ribbon
        GroupControlMain.Visible = False
        Ribbon_Connect_Init()
    End Sub

    Private Sub BarButton_Conn_SaveConn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_Conn_SaveConn.ItemClick
        If Server <> "" And User <> "" Then
            If SaveConn(Server, User) Then MsgBox("已报存", vbExclamation, "MAC Client")
        Else
            MsgBox("未连接或登录", vbExclamation, "MAC Client")
        End If
    End Sub

    Private Sub BarList_Conn_ManageProfiles_ListItemClick(sender As Object, e As DevExpress.XtraBars.ListItemClickEventArgs) Handles BarList_Conn_ManageProfiles.ListItemClick
        Dim CEdit As Conn_Edit = New Conn_Edit
        Dim selected As String = BarList_Conn_ManageProfiles.Strings(BarList_Conn_ManageProfiles.ItemIndex).ToString
        CEdit.NewConn = False
        CEdit.Origin_Server = Microsoft.VisualBasic.Left(selected, InStr(selected, "@") - 1)
        CEdit.Origin_User = Microsoft.VisualBasic.Right(selected, InStr(selected, "@") - 1)
        CEdit.Form = Me
        CEdit.GroupControl = GroupControlMain
        CEdit.Load()
    End Sub

    Private Sub BarButton_Service_Start_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_Service_Start.ItemClick
        Dim value As Byte
        value = StartService(CurrentSocket, LoginCode)
        BarStaticItem_Status.Caption = "已连接到" & Server & "  正在设置服务状态"
        If value = 1 Or value = 2 Then
            BarButton_Service_Start.Enabled = False
            BarButton_Service_Stop.Enabled = True
            BarButton_Service_Pause.Enabled = True
            BarStaticItem_Status.Caption = "已连接到" & Server & "  服务正在运行"
        Else
            Select Case value
                Case 0
                    MsgBox("Unknown Error", vbExclamation, "MAC Client")
                Case 3
                    MsgBox("服务无法启动！", vbExclamation, "MAC Client")
            End Select
        End If
    End Sub

    Private Sub BarButton_Service_Pause_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_Service_Pause.ItemClick
        Dim value As Byte
        value = PauseService(CurrentSocket, LoginCode)
        If value = 1 Or value = 2 Then
            BarButton_Service_Start.Enabled = True
            BarButton_Service_Stop.Enabled = True
            BarButton_Service_Pause.Enabled = False
            BarStaticItem_Status.Caption = "已连接到" & Server & "  服务暂停"
        Else
            Select Case value
                Case 0
                    MsgBox("Unknown Error", vbExclamation, "MAC Client")
                Case 3
                    MsgBox("服务无法暂停！", vbExclamation, "MAC Client")
            End Select
        End If
    End Sub

    Private Sub BarButton_Service_Stop_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_Service_Stop.ItemClick
        Dim value As Byte
        value = StopService(CurrentSocket, LoginCode)
        If value = 1 Or value = 2 Then
            BarButton_Service_Start.Enabled = False
            BarButton_Service_Stop.Enabled = True
            BarButton_Service_Pause.Enabled = True
            BarStaticItem_Status.Caption = "已连接到" & Server & "  服务停止"
        Else
            Select Case value
                Case 0
                    MsgBox("Unknown Error", vbExclamation, "MAC Client")
                Case 3
                    MsgBox("服务无法停止！", vbExclamation, "MAC Client")
            End Select
        End If
    End Sub

    Private Sub BarButton_Service_Disable_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_Service_Disable.ItemClick
        Dim value As Byte
        value = DisableService(CurrentSocket, LoginCode)
        If value = 1 Or value = 2 Then
            BarButton_Service_Start.Enabled = False
            BarButton_Service_Stop.Enabled = True
            BarButton_Service_Pause.Enabled = True
            BarStaticItem_Status.Caption = "已连接到" & Server & "  服务已禁用"
        Else
            Select Case value
                Case 0
                    MsgBox("Unknown Error", vbExclamation, "MAC Client")
                Case 3
                    MsgBox("服务无法禁用！", vbExclamation, "MAC Client")
            End Select
        End If
    End Sub

    Private Sub BarButton_Service_Status_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_Service_Status.ItemClick
        Dim CStatus As ServiceStatus = New ServiceStatus
        CStatus.Form = Me
        CStatus.GroupControl = GroupControlMain
        CStatus.Load()
    End Sub
    Private Sub ListView4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView4.SelectedIndexChanged
        Static CAffairs As Affairs
        If CAffairs Is Nothing Then
            CAffairs = New Affairs
        End If
        CAffairs.Load()
    End Sub

    Private Sub BarButton_Affairs_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_Affairs.ItemClick
        ListView4.Items.Item(0).Selected = True
        ListView4.Select()
    End Sub

    Private Sub BarList_BLP_EditLevel_ListItemClick(sender As Object, e As DevExpress.XtraBars.ListItemClickEventArgs) Handles BarList_BLP_EditLevel.ListItemClick
        Dim CMLSLevel As MLSLevel = New MLSLevel
        Dim Levelid As String
        Levelid = CMLSLevel.GetID(BarList_BLP_EditLevel.Strings(BarList_BLP_EditLevel.ItemIndex).ToString)
        If Levelid <> "" Then
            CMLSLevel.Form = Me
            CMLSLevel.GroupControl = GroupControlMain
            CMLSLevel.ID = Levelid
            CMLSLevel.Load()
        End If
    End Sub

    Private Sub BarButton_BLP_NewLevel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_BLP_NewLevel.ItemClick
        Dim CMLSLevel As MLSLevel = New MLSLevel
        CMLSLevel.Form = Me
        CMLSLevel.GroupControl = GroupControlMain
        CMLSLevel.ID = ""
        CMLSLevel.Load()
    End Sub

    Private Sub BarList_BLP_Strategies_ListItemClick(sender As Object, e As DevExpress.XtraBars.ListItemClickEventArgs) Handles BarList_BLP_Strategies.ListItemClick
        If Not (AdoptStrategy(CurrentSocket, LoginCode, e.Item.Caption)) Then MsgBox("更换规则失败。", vbOKOnly, "MAC Client")
    End Sub

    Private Sub BarList_SbjRequest_ListItemClick(sender As Object, e As DevExpress.XtraBars.ListItemClickEventArgs) Handles BarList_SbjRequest.ListItemClick
        ListView4.Items.Item(CInt(e.Item.Tag)).Selected = True
        ListView4.Select()
    End Sub

    Private Sub BarButton_SbjReqHistory_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_SbjReqHistory.ItemClick
        Dim Clog As Log = New Log
        Clog.LoadLog(LibInternet.Internet.GetAffairLog(CurrentSocket, LoginCode))
    End Sub

    Private Sub BarButton_Sbj_Add_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButton_Sbj_Add.ItemClick
        Dim CSbjLevel As SbjLevel = New SbjLevel
        CSbjLevel.Misson = 1
        CSbjLevel.Form = Me
        CSbjLevel.GroupControl = GroupControlMain
        CSbjLevel.Load()
    End Sub
End Class