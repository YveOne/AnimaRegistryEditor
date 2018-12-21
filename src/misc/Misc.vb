Module Misc

    Public Function CIntSave(val As Object) As Integer
        Try
            Return CInt(val)
        Catch ex As Exception
            MessageBox.Show("Cannot cast """ & CStr(val) & """ to int")
            Return 0
        End Try
    End Function

End Module
