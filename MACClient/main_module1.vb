Imports System
Imports System.IO
Imports System.Collections
Imports System.Text
Imports Microsoft.VisualBasic
Module main_module1
    Public Function LoadProfile(path As String) As ArrayList
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
    Public Function WriteProfile(path As String, contents As String) As Boolean
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
    
End Module
