Imports System.Windows.Forms
Public Class MLSLevel
    Inherits Grouplevel
    Private Property MLSObject As MLS.MLSCollection = New MLS.MLSCollection
    Friend GroupBox1 As GroupBox
    Friend RadioButton1 As RadioButton
    Friend RadioButton2 As RadioButton
    Friend Overrides Sub Load()
        If CStr(GroupControl.Tag) <> "MLSLevel" Then
            If Misson >= 2 Then
                Me.TextBox1.Size = New System.Drawing.Size(208, 189)
                If Misson = 2 Then
                    Me.GroupControl.Text = "设置安全等级"
                    Me.Label4.Text = "等级描述"
                    Me.Label3.Text = "等级名称"
                    Me.Label2.Text = "等级ID"
                    Me.Label1.Text = "等级信息"
                    Me.Button3.Text = "删除等级"
                ElseIf Misson = 3 Then
                    Me.GroupControl.Text = "设置安全等级"
                    Me.Label4.Text = "组别描述"
                    Me.Label3.Text = "组别名称"
                    Me.Label2.Text = "组别ID"
                    Me.Label1.Text = "组别信息"
                    Me.Button3.Text = "删除组别"
                End If
            ElseIf Misson = 1 Then
                Me.TextBox1.Size = New System.Drawing.Size(208, 110)
                RadioButton1 = New RadioButton
                RadioButton2 = New RadioButton
                GroupBox1 = New GroupBox
                'GroupBox1
                '
                Me.GroupBox1.Controls.Add(Me.RadioButton2)
                Me.GroupBox1.Controls.Add(Me.RadioButton1)
                Me.GroupBox1.Location = New System.Drawing.Point(10, 156)
                Me.GroupBox1.Name = "GroupBox1"
                Me.GroupBox1.Size = New System.Drawing.Size(200, 74)
                Me.GroupBox1.TabIndex = 5
                Me.GroupBox1.TabStop = False
                Me.GroupBox1.Text = "新建"
                '
                'RadioButton1
                '
                Me.RadioButton1.AutoSize = True
                Me.RadioButton1.Location = New System.Drawing.Point(23, 21)
                Me.RadioButton1.Name = "RadioButton1"
                Me.RadioButton1.Size = New System.Drawing.Size(109, 18)
                Me.RadioButton1.TabIndex = 0
                Me.RadioButton1.Text = "新建安全等级组"
                Me.RadioButton1.UseVisualStyleBackColor = True
                AddHandler RadioButton1.CheckedChanged, AddressOf Switch
                '
                'RadioButton2
                '
                Me.RadioButton2.AutoSize = True
                Me.RadioButton2.Checked = True
                Me.RadioButton2.Location = New System.Drawing.Point(23, 45)
                Me.RadioButton2.Name = "RadioButton2"
                Me.RadioButton2.Size = New System.Drawing.Size(97, 18)
                Me.RadioButton2.TabIndex = 1
                Me.RadioButton2.TabStop = True
                Me.RadioButton2.Text = "新建安全等级"
                Me.RadioButton2.UseVisualStyleBackColor = True
                AddHandler RadioButton2.CheckedChanged, AddressOf Switch
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
            Me.ListView5.AllowDrop = True
            Me.ListView5.Location = New System.Drawing.Point(192, 27)
            Me.ListView5.MultiSelect = False
            Me.ListView5.Name = "ListView5"
            Me.ListView5.Size = New System.Drawing.Size(278, 112)
            Me.ListView5.TabIndex = 8
            Me.ListView5.UseCompatibleStateImageBehavior = False
            Me.ListView5.View = System.Windows.Forms.View.SmallIcon
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
            Me.Label5.Text = "安全等级"
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
    Friend Overrides Function GetID(Name As String) As String
        If MLSObject Is Nothing Then MLSObject = Internet.GetLevelDetails(Form.CurrentSocket, Form.LoginCode)
        For Each level As MLS.Level In MLSObject.Levels
            If level.Name = Name Then Return level.ID
        Next
        Return ""
    End Function
    Private Sub Switch()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        If RadioButton1.Checked Then
            loadgroup()
            ListView5.Items.Add("New group")
        Else
            loadlevel()
            ListView5.Items.Add("New level")
        End If
    End Sub
    Private Overrides Sub GetLevelInfo()
        If MLSObject Is Nothing Then MLSObject = Internet.GetLevelDetails(Form.CurrentSocket, Form.LoginCode)
        If Misson = 2 Then
            Dim ThisLevel As MLS.Level = New MLS.Level
            ThisLevel = MLSObject.GetLevel(ID)
            If ThisLevel Is Nothing Then
                MsgBox("此等级不存在！", vbExclamation, "MAC Client")
                Clean_GroupControl()
                Exit Sub
            End If
            TextBox4.Text = ThisLevel.Description
            TextBox2.Text = ThisLevel.ID
            TextBox3.Text = ThisLevel.Name
            TextBox1.Text = ThisLevel.Info
            loadgroup()
        ElseIf Misson = 3 Then
            Dim ThisGroup As MLS.LevelGroup = New MLS.LevelGroup
            ThisGroup = MLSObject.GetGroup(ID)
            If ThisGroup Is Nothing Then
                MsgBox("此组别不存在！", vbExclamation, "MAC Client")
                Clean_GroupControl()
                Exit Sub
            End If
            TextBox4.Text = ThisGroup.Description
            TextBox2.Text = ThisGroup.ID
            TextBox3.Text = ThisGroup.Name
            TextBox1.Text = ThisGroup.Info
            loadlevel()
        ElseIf Misson = 0 Then
            loadlevel()
            ListView5.Items.Add("New level")
        End If

    End Sub
    Private Sub loadgroup()
        Dim i As Integer, item As ListViewItem, subitem As ListViewItem.ListViewSubItem
        Dim thisgroup As MLS.LevelGroup
        With ListView5
            .Items.Clear()
            For i = 0 To MLSObject.Groups.Count - 1
                item = New ListViewItem
                subitem = New ListViewItem.ListViewSubItem
                thisgroup = MLSObject.GetGroup(i)
                subitem.Text = thisgroup.Name
                item.SubItems.Add(subitem)
                item.Text = thisgroup.ID
                .Items.Add(item)
            Next
        End With
    End Sub
    Private Overrides Sub loadlevel()
        Dim thislevel As MLS.Level = New MLS.Level, thisgroup As MLS.LevelGroup
        Dim i As Integer
        Dim group As ListViewGroupCollection
        With ListView5
            .Items.Clear()
            group = ListView5.Groups
            For i = 0 To MLSObject.Groups.Count - 1
                Dim item As ListViewGroup = New ListViewGroup
                thisgroup = MLSObject.GetGroup(i)
                item.Header = thisgroup.Name
                group.Add(item)
            Next
            For i = 0 To MLSObject.Levels.Count - 1
                '    Dim item As ListViewItem, subitem As ListViewItem.ListViewSubItem
                '    item = New ListViewItem
                '    'subitem = New ListViewItem.ListViewSubItem
                '    'thislevel = MLSObject.GetLevel(i)
                '    'subitem.Text = thislevel.Name
                '    'item.SubItems.Add(subitem)
                '    'item.Text = thislevel.ID
                '    item.Tag = MLSObject.GetLevel(i)
                '    For Each obj As ListViewGroup In group
                '        If obj.Header = thislevel.GroupBelongTo Then
                '            item.Group = obj
                '            obj.Items.Add(item)
                '        End If
                '    Next

                'Next
                'For Each obj As ListViewGroup In group
                '    i = 0
                '    While True

                '    End While

                '#################################################
                'Order required
                '#################################################
            Next

        End With
    End Sub

    Private Overrides Sub Save()

    End Sub
    Private Overrides Sub Del()

    End Sub
End Class
