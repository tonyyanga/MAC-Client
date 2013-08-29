Public Class Conn_Edit
    Inherits CGroupControl
    Friend Sub Conn_Edit_Save_Click()
        Dim ip As System.Windows.Forms.TextBox, user As System.Windows.Forms.TextBox
        ip = Nothing
        user = Nothing
        For Each obj As System.Windows.Forms.Control In GroupControl.Controls
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
        Clean_GroupControl(GroupControl)
        Form.Ribbon_Connect_Init()
    End Sub

    Friend Sub Conn_Edit_Cancel_Click()
        'Handle EditConnection.Cancel.Click
        Clean_GroupControl(GroupControl)
    End Sub
End Class
