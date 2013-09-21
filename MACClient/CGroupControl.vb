Public MustInherit Class CGroupControl
    Friend Property GroupControl As DevExpress.XtraEditors.GroupControl
    Friend Property Form As main
    Friend Sub Clean_GroupControl()
        'Clean GroupMain and hide it.
        Dim obj As System.Windows.Forms.Control
        For Each obj In GroupControl.Controls
            GroupControl.Controls.Remove(obj)
            obj = Nothing
        Next
        GroupControl.Visible = False
        GroupControl.Tag = Nothing
    End Sub
End Class
