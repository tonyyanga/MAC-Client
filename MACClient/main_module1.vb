Imports System
Imports System.IO
Imports System.Collections
Imports System.Text
Imports Microsoft.VisualBasic
Module main_module1
    Private Function LoadProfile(path As String) As ArrayList
        Dim connlist As New ArrayList
        Dim reader As New StreamReader(path)
        Dim line As String = ""
        Do
            line = reader.ReadLine()
            If Not (line = Nothing) Then
                connlist.Add(line)
            End If
        Loop Until reader.EndOfStream
        reader.Close()
        LoadProfile = connlist

    End Function
    Private Function WriteProfile(path As String, contents As String) As Boolean
        Dim writer As StreamWriter = New StreamWriter(path)
        'Try
        writer.Write(contents)
        'Catch ex As Exception
        'WriteProfile = False
        'Exit Function
        'End Try
        WriteProfile = True
        writer.Close()
    End Function
    Public Sub LoadConn(ByRef Barlist1 As DevExpress.XtraBars.BarListItem, Optional ByRef Barlist2 As DevExpress.XtraBars.BarListItem = Nothing)
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\MAC Client\Connections.txt") Then
            Dim line As String, ConnectIP As String, ConnectUser As String
            Dim connlist As ArrayList
            connlist = main_module1.LoadProfile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\MAC Client\Connections.txt")
            For Each line In connlist
                line = Trim(line)
                ConnectIP = Microsoft.VisualBasic.Left(line, InStr(line, " ") - 1)
                ConnectUser = Microsoft.VisualBasic.Right(line, Len(line) - Microsoft.VisualBasic.InStr(line, " "))
                Barlist1.Strings.Add(ConnectUser & "@" & ConnectIP)
                If Barlist2 IsNot Nothing Then Barlist2.Strings.Add(ConnectUser & "@" & ConnectIP)
            Next
        End If
    End Sub
    Public Function SaveConn(Server As String, user As String) As Boolean
        If Not (File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\MAC Client\Connections.txt")) Then
            If File.Create(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\MAC Client\Connections.txt") Is Nothing Then
                MsgBox("创建文件失败", vbExclamation, "MAC Client")
                Return False
            End If
        End If
        Server = Trim(Server)
        user = Trim(user)
        If Not (WriteProfile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\MAC Client\Connections.txt", Server & " " & user)) Then
            MsgBox("保存失败", vbExclamation, "MAC Client")
            Return False
        End If
        Return True
    End Function
End Module
