
Imports Microsoft.Win32

Class RegistryHandler

    Private WorkingKey As RegistryKey = Nothing

    Public Sub New(RootKey As RegistryKey, WorkingPath As String)
        If (Not SetWorkingKey(RootKey, WorkingPath)) Then
            Throw New Exception("Invalid RootKey")
        End If
    End Sub

    Public Sub New(RootKey As String, WorkingPath As String)
        If (Not SetWorkingKey(RootKey, WorkingPath)) Then
            Throw New Exception("Invalid RootKey")
        End If
    End Sub

    Public Sub New(WorkingPath As String)
        If (Not SetWorkingKey(WorkingPath)) Then
            Throw New Exception("Invalid RootKey")
        End If
    End Sub





    Public Function SetWorkingKey(RootKey As RegistryKey, WorkingPath As String) As Boolean
        Dim NewKey As RegistryKey = RootKey.OpenSubKey(WorkingPath, RegistryKeyPermissionCheck.ReadWriteSubTree)
        If (NewKey IsNot Nothing) Then
            WorkingKey = NewKey
            Return True
        End If
        Return False
    End Function

    Public Function SetWorkingKey(RootKey As String, WorkingPath As String) As Boolean
        If (RootKeys.ContainsKey(RootKey)) Then
            Return SetWorkingKey(RootKeys(RootKey), WorkingPath)
        End If
        Return False
    End Function

    Public Function SetWorkingKey(WorkingPath As String) As Boolean
        Dim WorkingKeyStrings As List(Of String) = WorkingPath.Split(CChar("\")).ToList()
        Dim RootKeyString = WorkingKeyStrings(0)
        WorkingKeyStrings.RemoveAt(0)
        If (RootKeys.ContainsKey(RootKeyString)) Then
            Return SetWorkingKey(RootKeys(RootKeyString), Join(WorkingKeyStrings.ToArray(), "\"))
        End If
        Return False
    End Function

    Public Function GetValueNames() As String()
        Return WorkingKey.GetValueNames
    End Function




    Public Function GetRegVal(k As String) As Object
        Return WorkingKey.GetValue(k, Nothing)
    End Function

    Public Sub SetRegVal(k As String, v As Object, t As RegistryValueKind)
        WorkingKey.SetValue(k, v, t)
    End Sub

    Public Sub DelRegVal(k As String)
        If WorkingKey.GetValueNames().Contains(k) Then
            WorkingKey.DeleteValue(k)
        End If
    End Sub

    Public Shared ReadOnly RootKeys As New SortedList(Of String, RegistryKey) From {
        {"HKLM", Registry.LocalMachine},
        {"HKCU", Registry.CurrentUser},
        {"HKCR", Registry.ClassesRoot},
        {"HKU", Registry.Users},
        {"HKCC", Registry.CurrentConfig},
        {"HKEY_LOCAL_MACHINE", Registry.LocalMachine},
        {"HKEY_CURRENT_USER", Registry.CurrentUser},
        {"HKEY_CLASSES_ROOT", Registry.ClassesRoot},
        {"HKEY_USERS", Registry.Users},
        {"HKEY_CURRENT_CONFIG", Registry.CurrentConfig}
    }

    Public Shared ReadOnly LongRootKeys As New SortedList(Of String, String) From {
        {"HKLM", "HKEY_LOCAL_MACHINE"},
        {"HKCU", "HKEY_CURRENT_USER"},
        {"HKCR", "HKEY_CLASSES_ROOT"},
        {"HKU", "HKEY_USERS"},
        {"HKCC", "HKEY_CURRENT_CONFIG"}
    }

    Public Shared ReadOnly ShortRootKeys As New SortedList(Of String, String) From {
        {"HKEY_LOCAL_MACHINE", "HKLM"},
        {"HKEY_CURRENT_USER", "HKCU"},
        {"HKEY_CLASSES_ROOT", "HKCR"},
        {"HKEY_USERS", "HKU"},
        {"HKEY_CURRENT_CONFIG", "HKCC"}
    }

    Public Sub Export(fPath As String)
        Dim RootStr As String = WorkingKey.ToString()
        Dim RootStrSplit As String() = RootStr.Split(CChar("\"))
        RootStrSplit(0) = ShortRootKeys(RootStrSplit(0))
        RootStr = Join(RootStrSplit, "\")
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.WindowStyle = ProcessWindowStyle.Hidden
        pi.CreateNoWindow = True
        pi.UseShellExecute = False
        pi.Arguments = " /C reg export """ & RootStr & """ """ & fPath & """"
        pi.FileName = "cmd.exe"
        p.StartInfo = pi
        p.Start()
    End Sub

End Class
