Namespace MLS
    Public Class Level
        Public Property ID As String = ""
        Public Property Name As String = ""
        Public Property GroupBelongTo As String = ""
        Public Property GroupOrder As Byte = 0
        Public Property Description As String = ""
        Public Property Info As String = ""
        Public Function GetGroupBelongTo(Groups As Collection) As LevelGroup
            Dim findlevel As LevelGroup
            For Each findlevel In Groups
                If findlevel.ID = GroupBelongTo Then
                    Return findlevel
                End If
            Next
            Return Nothing
        End Function
    End Class
    Public Class LevelGroup
        Public ID As String = ""
        Public Property Name As String = ""
        Public Property Order As Byte = 0
        Public Property Description As String
        Public Property Info As String = ""
    End Class
    Public Class MLSCollection
        Public Property Levels As Collection
        Public Property Groups As Collection
        Public Function GetLevel(index As Integer) As Level
            If index >= 0 And index <= Levels.Count Then
                Return Levels(index)
            Else
                Return Nothing
            End If
        End Function
        Public Function GetGroup(index As Integer) As LevelGroup
            If index >= 0 And index <= Groups.Count Then
                Return Groups(index)
            Else
                Return Nothing
            End If
        End Function
        Public Function GetGroup(ID As String) As LevelGroup
            Dim findlevel As LevelGroup
            For Each findlevel In Groups
                If findlevel.ID = ID Then
                    Return findlevel
                End If
            Next
            Return Nothing
        End Function
        Public Function GetLevel(ID As String) As Level
            Dim findlevel As Level
            For Each findlevel In Levels
                If findlevel.ID = ID Then
                    Return findlevel
                End If
            Next
            Return Nothing
        End Function
    End Class
End Namespace
