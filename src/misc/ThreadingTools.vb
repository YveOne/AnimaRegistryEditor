Module ThreadingTools

    Public Sub UIThread(ctrl As Control, code As Action)
        If (ctrl.InvokeRequired) Then
            ctrl.BeginInvoke(code)
            Return
        End If
        code.Invoke()
    End Sub

    Public Sub UIThreadInvoke(ctrl As Control, code As Action)
        If (ctrl.InvokeRequired) Then
            ctrl.Invoke(code)
            Return
        End If
        code.Invoke()
    End Sub

End Module
