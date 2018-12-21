Partial Class AnimaRegistryEditor

    Private Sub New()
    End Sub

    Private Shared RegHandler As RegistryHandler = Nothing

    Private Shared RegistryPath As String = "HKEY_CURRENT_USER\Software\Anima Project Studio\GateofMemories"
    Private Shared LevelExpIncreaseStep As Integer = 250
    Private Shared LevelExpIncreaseStart As Integer = 1000
    Public Shared SavegameSlots As Integer = 5
    Public Shared SavegameMaxLength As Integer = 20
    'Private Shared skillSlots As Integer = 23
    'Private Shared gearSlots As Integer = 8

    Public Shared SkillTreeSize As Integer = 88
    Public Shared SkillTreeMaxPointsBearer As Integer = 50
    Public Shared SkillTreeMaxPointsErgo As Integer = 48

    Public Shared InventorySize As Integer = 108

    Public Shared MaxLevel As Integer = 20
    Public Shared MaxXP As Integer = 36538000
    Public Shared MaxCoins As Integer = 36538000
    Public Shared MaxPlayTime As Integer = 36538000

    Public Shared DifficultyNames As String() = {"None", "Easy", "Normal", "Locked"}
    Public Shared ItemTypeNames As New SortedList(Of String, String) From {{"w", "Weapon"}, {"a", "Armor"}, {"k", "Key"}, {"u", "Useable"}}

    Public Shared SlotDateFormatPattern As String = "HH:mm  dd '/'MM'/'yyyy"
    Public Shared SlotTextFormatPattern As String = "Slot{0} - Lv{1}  {2}  {3}"
    Public Shared EmptySlotFormatPattern As String = "Slot{0} - Empty -"
    Public Shared GamesaveChangedIndicator As String = "*"

    Private Shared Strings As New SortedList(Of String, String)
    Private Shared KeyAliases As New SortedList(Of String, String)

    Public Shared Sub Initialize(DataFilePath As String)
        DataFiles.LoadFiles(DataFilePath)
        RegHandler = New RegistryHandler(RegistryPath)
        Gamesaves.LoadSlots()
    End Sub

    Public Shared Function GetString(k As String) As String
        If (Strings.ContainsKey(k)) Then
            Return Strings(k)
        End If
        Return k
    End Function

    Public Shared Function GetKeyAlias(k As String) As String
        Return If(KeyAliases.ContainsKey(k), KeyAliases(k), k)
    End Function

    Public Shared Sub Export()
        Dim dialog As New SaveFileDialog
        dialog.Title = "Backup"
        dialog.Filter = "Registry Data File|*.reg"
        If dialog.ShowDialog() = DialogResult.OK Then
            RegHandler.Export(dialog.FileName)
        End If
    End Sub

    Public Shared Sub ExportKeyAliases()
        Dim dialog As New SaveFileDialog
        dialog.FileName = "keyaliases.txt"
        dialog.Title = "Key Aliases"
        dialog.Filter = "Data File|keyaliases.txt"
        If (dialog.ShowDialog() = DialogResult.OK) Then
            Dim KeySplit As String()
            Dim lines As New List(Of String)
            For Each regkey As String In RegHandler.GetValueNames()
                KeySplit = regkey.Split(CChar("_"))
                If (KeySplit(0).Length > 0) Then
                    lines.Add(KeySplit(0) & "=" & regkey)
                End If
            Next
            lines.Sort()
            System.IO.File.WriteAllLines(dialog.FileName, lines.ToArray())
        End If
    End Sub

End Class
