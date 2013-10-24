Imports System.Windows.Forms
Public Class SbjLevel
    Inherits Grouplevel

    Friend Overrides Sub Del()

    End Sub

    Friend Overrides Function GetID(Name As String) As String

    End Function

    Friend Overrides Sub GetLevelInfo()

    End Sub

    Friend Overrides Sub Load()
        If CStr(GroupControl.Tag) <> "MLSLevel" Then
            init_public()
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
        End If
        GetLevelInfo()
    End Sub

    Friend Overrides Sub loadlevel()

    End Sub

    Friend Overrides Sub Save()

    End Sub
End Class
