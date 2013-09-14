Public Class Conn_Edit
    Inherits CGroupControl
    Friend Property Button1 As System.Windows.Forms.Button
    Friend Property Button2 As System.Windows.Forms.Button
    Friend Property Label2 As System.Windows.Forms.Label
    Friend Property Label3 As System.Windows.Forms.Label
    Friend Property Label4 As System.Windows.Forms.Label
    Friend Property Textbox1 As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox
    Friend Property Textbox2 As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox
    Friend Property NewConn As Boolean = True
    Friend Property Origin_Server As String = ""
    Friend Property Origin_User As String = ""
    Friend Sub Load()
        Button1 = New System.Windows.Forms.Button()
        Button2 = New System.Windows.Forms.Button()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        'GroupControlMain
        Clean_GroupControl()
        GroupControl.Visible = True
        GroupControl.Controls.Add(Button2)
        GroupControl.Controls.Add(Textbox1)
        GroupControl.Controls.Add(Textbox2)
        GroupControl.Controls.Add(Label4)
        GroupControl.Controls.Add(Label3)
        GroupControl.Controls.Add(Label2)
        GroupControl.Controls.Add(Button1)
        GroupControl.Controls.Add(Button2)
        GroupControl.Location = New System.Drawing.Point(282, 153)
        GroupControl.Size = New System.Drawing.Size(436, 234)
        GroupControl.TabIndex = 5
        If NewConn Then GroupControl.Text = "新连接" Else GroupControl.Text = "更改连接"
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
        Textbox2.Text = Origin_User
        'TextBox1
        Textbox1.Location = New System.Drawing.Point(176, 95)
        Textbox1.Size = New System.Drawing.Size(100, 22)
        Textbox1.TabIndex = 5
        Textbox1.Name = "Textbox1"
        Textbox1.Text = Origin_Server
        Textbox1.Focus()
    End Sub
    Friend Sub Conn_Edit_Save_Click()
        Dim ip As System.Windows.Forms.TextBox, user As System.Windows.Forms.TextBox
        ip = Nothing
        user = Nothing
        For Each obj As System.Windows.Forms.Control In GroupControl.Controls
            If obj.Name = "Textbox1" Then ip = DirectCast(obj, System.Windows.Forms.TextBox)
            If obj.Name = "Textbox2" Then user = DirectCast(obj, System.Windows.Forms.TextBox)
        Next
        Try
            If NewConn = True Then
                If Not (main_module1.SaveConn(Trim(ip.Text), Trim(user.Text))) Then MsgBox("保存失败", vbOKOnly, "MAC Client")
            Else
                If Not (main_module1.EditConn(Origin_Server, Origin_User, Trim(ip.Text), Trim(user.Text))) Then MsgBox("保存失败", vbOKOnly, "MAC Client")
            End If
        Catch ex As Exception
            MsgBox("保存失败, " & ex.Message, vbOKOnly, "MAC Client")
        End Try
        Clean_GroupControl()
        Form.Ribbon_Connect_Init()
    End Sub

    Friend Sub Conn_Edit_Cancel_Click()
        'Handle EditConnection.Cancel.Click
        Clean_GroupControl()
    End Sub
End Class
