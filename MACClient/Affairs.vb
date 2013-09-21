Imports LibInternet
Public Class Affairs
    Inherits CGroupControl
    Dim Button1 As Button = New Button
    Dim Button2 As Button = New Button
    Dim Button3 As Button = New Button
    Dim Button4 As Button = New Button
    Dim Textbox1 As TextBox = New TextBox
    Dim TextboxInfo As TextBox = New TextBox
    Dim Label1 As Label = New Label
    Dim Label2 As Label = New Label
    Dim AID As String = ""

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
        Me.GroupControl.Controls.Add(Me.Textbox1)
        Me.GroupControl.Controls.Add(Me.Label1)
        Me.GroupControl.Controls.Add(Me.TextboxInfo)
        Me.GroupControl.Controls.Add(Me.Label2)
        Me.GroupControl.Location = New System.Drawing.Point(91, 153)
        Me.GroupControl.Name = "groupcontrol"
        Me.GroupControl.Size = New System.Drawing.Size(741, 234)
        Me.GroupControl.TabIndex = 5
        Me.GroupControl.Text = "事务信息"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(162, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "此事务信息"
        '
        'TextBoxInfo
        '
        Me.TextboxInfo.Location = New System.Drawing.Point(18, 46)
        Me.TextboxInfo.Multiline = True
        Me.TextboxInfo.Name = "TextBoxInfo"
        Me.TextboxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextboxInfo.Size = New System.Drawing.Size(370, 183)
        Me.TextboxInfo.TabIndex = 1
        TextboxInfo.ReadOnly = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(474, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "自动分析结果"
        '
        'TextBox1
        '
        Me.Textbox1.Location = New System.Drawing.Point(394, 46)
        Me.Textbox1.Multiline = True
        Me.Textbox1.Name = "TextBox1"
        Me.Textbox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Textbox1.Size = New System.Drawing.Size(210, 183)
        Me.Textbox1.TabIndex = 3
        Textbox1.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(623, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 30)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "允许请求"
        Me.Button1.UseVisualStyleBackColor = True
        AddHandler Button1.Click, AddressOf Allow
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(623, 82)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 30)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "拒绝请求"
        Me.Button2.UseVisualStyleBackColor = True
        AddHandler Button2.Click, AddressOf Reject
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(623, 119)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 29)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "允许并作为策略"
        Me.Button3.UseVisualStyleBackColor = True
        AddHandler Button3.Click, AddressOf AllowAsRule
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(623, 191)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(101, 29)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "拒绝并作为策略"
        Me.Button4.UseVisualStyleBackColor = True
        AddHandler Button4.Click, AddressOf RejectAsRule
    End Sub
    Private Sub Allow()

    End Sub
    Private Sub Reject()

    End Sub
    Private Sub AllowAsRule()

    End Sub
    Private Sub RejectAsRule()

    End Sub
    Friend Sub Selected(ByRef ID As String)

    End Sub


End Class
