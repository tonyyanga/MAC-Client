Imports System.Windows.Forms
Public Class SbjLevel
    Inherits CGroupControl
    Friend Panel1 As System.Windows.Forms.Panel = New Panel
    Friend ListView5 As System.Windows.Forms.ListView = New ListView
    Friend TextBox4 As System.Windows.Forms.TextBox = New TextBox
    Friend Label4 As System.Windows.Forms.Label = New Label
    Friend TextBox3 As System.Windows.Forms.TextBox = New TextBox
    Friend Label3 As System.Windows.Forms.Label = New Label
    Friend TextBox2 As System.Windows.Forms.TextBox = New TextBox
    Friend Label2 As System.Windows.Forms.Label = New Label
    Friend TextBox1 As System.Windows.Forms.TextBox = New TextBox
    Friend Label1 As System.Windows.Forms.Label = New Label
    Friend Button2 As System.Windows.Forms.Button = New Button
    Friend Button1 As System.Windows.Forms.Button = New Button
    Friend Label5 As System.Windows.Forms.Label = New Label
    Friend Button3 As System.Windows.Forms.Button = New Button
    Friend ColumnHeader20 As System.Windows.Forms.ColumnHeader = New Windows.Forms.ColumnHeader
    Friend ColumnHeader21 As System.Windows.Forms.ColumnHeader = New Windows.Forms.ColumnHeader
    Friend ColumnHeader22 As System.Windows.Forms.ColumnHeader = New Windows.Forms.ColumnHeader
    Friend Property ID As String
    Private Property MLSObject As MLS.MLSCollection = New MLS.MLSCollection
    Friend Misson As Byte '1 = new;2=edit level;
    Friend Sub Load()
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "文件名"
        Me.ColumnHeader20.Width = 73
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "所在目录"
        Me.ColumnHeader21.Width = 120
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "所属安全等级"
        Me.ColumnHeader22.Width = 87
        If CStr(GroupControl.Tag) <> "MLSLevel" Then
            If Misson = 2 Then
                Me.TextBox1.Size = New System.Drawing.Size(208, 189)
                Me.GroupControl.Text = "设置程序组"
                Me.Label4.Text = "组描述"
                Me.Label3.Text = "组名称"
                Me.Label2.Text = "组ID"
                Me.Label1.Text = "组信息"
                Me.Button3.Text = "删除组"
            Else
                Me.TextBox1.Size = New System.Drawing.Size(208, 110)
                Me.GroupControl.Text = "新建安全等级/组"
                Me.Label4.Text = "等级描述"
                Me.Label3.Text = "等级名称"
                Me.Label2.Text = "等级ID"
                Me.Label1.Text = "等级信息"
                Me.Button3.Text = "删除等级"
            End If
            Me.TextBox1.Location = New System.Drawing.Point(7, 40)
            Me.TextBox1.Multiline = True
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.ReadOnly = True
            Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBox1.TabIndex = 1
            'Groupcontrol
            '
            Clean_GroupControl()
            Me.GroupControl.Controls.Add(Me.Panel1)
            Me.GroupControl.Controls.Add(Me.TextBox1)
            Me.GroupControl.Controls.Add(Me.Label1)
            Me.GroupControl.Location = New System.Drawing.Point(91, 153)
            Me.GroupControl.Name = "groupcontrol"
            Me.GroupControl.Size = New System.Drawing.Size(741, 234)
            Me.GroupControl.TabIndex = 5

            GroupControl.Tag = "MLSLevel"
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.Button3)
            Me.Panel1.Controls.Add(Me.Button2)
            Me.Panel1.Controls.Add(Me.Button1)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.ListView5)
            Me.Panel1.Controls.Add(Me.TextBox4)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.TextBox3)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.TextBox2)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Location = New System.Drawing.Point(241, 40)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(475, 189)
            Me.Panel1.TabIndex = 4
            '
            'ListView5
            '
            Me.ListView5.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22})
            Me.ListView5.LabelEdit = True
            Me.ListView5.Location = New System.Drawing.Point(192, 27)
            Me.ListView5.MultiSelect = False
            Me.ListView5.Name = "ListView5"
            Me.ListView5.Size = New System.Drawing.Size(278, 112)
            Me.ListView5.TabIndex = 8
            Me.ListView5.UseCompatibleStateImageBehavior = False
            Me.ListView5.View = System.Windows.Forms.View.Details

            '
            'TextBox4
            '
            Me.TextBox4.Location = New System.Drawing.Point(17, 89)
            Me.TextBox4.Multiline = True
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Size = New System.Drawing.Size(158, 95)
            Me.TextBox4.TabIndex = 7
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(63, 72)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(55, 14)
            Me.Label4.TabIndex = 6

            '
            'TextBox3
            '
            Me.TextBox3.Location = New System.Drawing.Point(75, 40)
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Size = New System.Drawing.Size(100, 22)
            Me.TextBox3.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(14, 43)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(55, 14)
            Me.Label3.TabIndex = 4

            '
            'TextBox2
            '
            Me.TextBox2.Location = New System.Drawing.Point(75, 12)
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(100, 22)
            Me.TextBox2.TabIndex = 3
            TextBox2.ReadOnly = True
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(14, 15)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(55, 14)
            Me.Label2.TabIndex = 2


            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(81, 22)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(55, 14)
            Me.Label1.TabIndex = 0

            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(303, 10)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(55, 14)
            Me.Label5.TabIndex = 9
            Me.Label5.Text = "组成员"
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(274, 150)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(96, 23)
            Me.Button1.TabIndex = 10
            Me.Button1.Text = "保存"
            Me.Button1.UseVisualStyleBackColor = True
            AddHandler Button1.Click, AddressOf Save
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(192, 150)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(75, 23)
            Me.Button2.TabIndex = 11
            Me.Button2.Text = "放弃更改"
            Me.Button2.UseVisualStyleBackColor = True
            AddHandler Button2.Click, AddressOf Clean_GroupControl
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(376, 150)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(94, 23)
            Me.Button3.TabIndex = 12

            Me.Button3.UseVisualStyleBackColor = True
            AddHandler Button3.Click, AddressOf Del
        End If
        GetLevelInfo()
    End Sub
    Friend Function GetID(Name As String) As String
        
    End Function
    Private Sub GetLevelInfo()
        
    End Sub
    Private Sub loadlevel()
       
    End Sub

    Private Sub Save()

    End Sub
    Private Sub Del()

    End Sub
End Class
