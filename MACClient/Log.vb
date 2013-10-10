Public Class Log 
    Sub LoadLog(Contents As String)
        TextBox1.Text = Contents
        Me.Show()
    End Sub
    Private Sub Log_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TextBox1.Width = Me.Width - 40
        TextBox1.Height = Me.Height - 62
    End Sub
End Class