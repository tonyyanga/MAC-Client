Imports System.Windows.Forms
Public MustInherit Class Grouplevel
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
    
    Friend Property ID As String
    Friend Misson As Byte '1 = new;2=edit;
    Friend MustOverride Sub Load()

    Friend MustOverride Function GetID(Name As String) As String

    Friend MustOverride Sub GetLevelInfo()

    Friend MustOverride Sub loadlevel()

    Friend MustOverride Sub Save()

    Friend MustOverride Sub Del()
    Friend Sub init_public()
        '
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
        Me.GroupControl.Location = New System.Drawing.Point(12, 153)
        Me.GroupControl.Name = "groupcontrol"
        Me.GroupControl.Size = New System.Drawing.Size(976, 234)
        Me.GroupControl.TabIndex = 5
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
        Me.Panel1.Location = New System.Drawing.Point(241, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(727, 204)
        Me.Panel1.TabIndex = 4
        '
        'ListView5
        '
        Me.ListView5.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader20, Me.ColumnHeader21})
        Me.ListView5.LabelEdit = True
        Me.ListView5.Location = New System.Drawing.Point(192, 27)
        Me.ListView5.MultiSelect = False
        Me.ListView5.Name = "ListView5"
        Me.ListView5.Size = New System.Drawing.Size(403, 166)
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
        Me.Label4.Location = New System.Drawing.Point(373, 72)
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
        Me.Button1.Location = New System.Drawing.Point(601, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 24)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "添加文件"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(601, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 27)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "添加文件夹"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(601, 95)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(121, 29)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "全部删除"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(601, 65)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(121, 29)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "删除文件"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(601, 130)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(121, 39)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "保存更改"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(601, 175)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(121, 24)
        Me.Button6.TabIndex = 15
        Me.Button6.Text = "放弃更改"
        Me.Button6.UseVisualStyleBackColor = True

    End Sub

End Class
