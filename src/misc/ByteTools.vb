Module ByteTools

    Public Function BytesToString(b As Byte()) As String
        b = If(b Is Nothing, {}, b)
        Return System.Text.Encoding.UTF8.GetString(b)
    End Function

    Public Function StringToBytes(ByVal str As String) As Byte()
        str = If(str Is Nothing, "", str)
        Return System.Text.Encoding.UTF8.GetBytes(str)
    End Function

    Public Function DropLastByte(b As Byte()) As Byte()
        b = If(b Is Nothing, {}, b)
        Dim byts As List(Of Byte) = b.ToList()
        If (byts.Count > 0 AndAlso byts(byts.Count - 1) = 0) Then
            byts.RemoveAt(byts.Count - 1)
        End If
        Return byts.ToArray()
    End Function

    Public Function AddLastByte(b As Byte()) As Byte()
        b = If(b Is Nothing, {}, b)
        Dim byts As List(Of Byte) = b.ToList()
        If (byts.Count = 0 OrElse byts(byts.Count - 1) <> 0) Then
            byts.Add(0)
        End If
        Return byts.ToArray()
    End Function

End Module
