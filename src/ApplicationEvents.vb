Namespace My
    ' Für MyApplication sind folgende Ereignisse verfügbar:
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
    ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst.  Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung mit einem Fehler beendet wird.
    ' UnhandledException: Wird bei einem Ausnahmefehler ausgelöst.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn die Anwendung bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
    Partial Friend Class MyApplication

        Private WithEvents Domaene As AppDomain = AppDomain.CurrentDomain
        Private Function Domaene_AssemblyResolve(ByVal sender As Object, ByVal args As System.ResolveEventArgs) As System.Reflection.Assembly Handles Domaene.AssemblyResolve
            If args.Name.Contains("DropDownControls") Then
                Return System.Reflection.Assembly.Load(My.Resources.DropDownControls)
            ElseIf args.Name.Contains("ObjectListView") Then
                Return System.Reflection.Assembly.Load(My.Resources.ObjectListView)
            ElseIf args.Name.Contains("DotNetZip") Then
                Return System.Reflection.Assembly.Load(My.Resources.DotNetZip)
            Else
                Return Nothing
            End If
        End Function

    End Class
End Namespace
