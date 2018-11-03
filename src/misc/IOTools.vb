Module IOTools

    Public Function ReadFileLines(fPath As String) As List(Of String)
        Dim l As New List(Of String)
        For Each s As String In System.IO.File.ReadAllLines(fPath)
            s = s.Trim()
            If s.StartsWith("//") Then
                s = ""
            End If
            If (s.Length > 0) Then
                l.Add(s)
            End If
        Next
        Return l
    End Function

End Module
