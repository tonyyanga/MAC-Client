Imports System.Windows.Forms
Imports LibInternet
Public Class ServiceStatus
    Inherits CGroupControl
    Dim Button1 As Button = New Button
    Dim Button2 As Button = New Button
    Dim Button3 As Button = New Button
    Dim Button4 As Button = New Button
    Dim Textbox1 As TextBox = New TextBox
    Dim TextboxInfo As TextBox = New TextBox
    Dim Label1 As Label = New Label
    Dim LabelInfo As Label = New Label
    Friend Sub Load()
        '
        'GroupControlMain
        '
        Clean_GroupControl()
        GroupControl.Visible = True
        Me.GroupControl.Controls.Add(Me.Button4)
        Me.GroupControl.Controls.Add(Me.Button3)
        Me.GroupControl.Controls.Add(Me.Button2)
        Me.GroupControl.Controls.Add(Me.Button1)
        Me.GroupControl.Controls.Add(Me.TextBox1)
        Me.GroupControl.Controls.Add(Me.Label1)
        Me.GroupControl.Controls.Add(Me.TextBoxInfo)
        Me.GroupControl.Controls.Add(Me.LabelInfo)
        Me.GroupControl.Location = New System.Drawing.Point(91, 153)
        Me.GroupControl.Name = "groupcontrol"
        Me.GroupControl.Size = New System.Drawing.Size(741, 234)
        Me.GroupControl.TabIndex = 5
        Me.GroupControl.Text = "服务状态"
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.LabelInfo.Location = New System.Drawing.Point(87, 29)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(67, 14)
        Me.LabelInfo.TabIndex = 0
        Me.LabelInfo.Text = "服务端信息"
        '
        'TextBoxInfo
        '
        Me.TextBoxInfo.Location = New System.Drawing.Point(18, 46)
        Me.TextBoxInfo.Multiline = True
        Me.TextBoxInfo.Name = "TextBoxInfo"
        Me.TextBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxInfo.Size = New System.Drawing.Size(241, 183)
        Me.TextBoxInfo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(399, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "访问控制服务"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(285, 46)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(319, 183)
        Me.TextBox1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(623, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 30)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "检查服务端组件"
        Me.Button1.UseVisualStyleBackColor = True
        AddHandler Button1.Click, AddressOf CheckComponets
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(623, 82)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 30)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "查看服务日志"
        Me.Button2.UseVisualStyleBackColor = True
        AddHandler Button2.Click, AddressOf ShowLog
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(623, 119)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 29)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "数据库重置"
        Me.Button3.UseVisualStyleBackColor = True
        AddHandler Button3.Click, AddressOf ResetDB
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(623, 191)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(101, 29)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "关闭"
        Me.Button4.UseVisualStyleBackColor = True
        AddHandler Button4.Click, AddressOf Clean_GroupControl
    End Sub
    Private Sub CheckComponets()
        MsgBox(Internet.CheckComp(Form.CurrentSocket, Form.LoginCode), vbOKOnly, "MAC Client")
    End Sub
    Private Sub ShowLog()
        Form.RibbonControl.SelectedPage = Form.RibbonPage2
    End Sub
    Private Sub ResetDB()
        If Internet.ResetDB(Form.CurrentSocket, Form.LoginCode) Then
            MsgBox("重置成功", vbOKOnly, "MAC Client")
        Else
            MsgBox("重置出现错误", vbExclamation, "MAC Client")
        End If
    End Sub
End Class
