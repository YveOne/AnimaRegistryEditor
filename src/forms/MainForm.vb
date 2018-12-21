
Imports System.Runtime.InteropServices
Imports BrightIdeasSoftware

Public Class MainForm

    Private SelectedGamesave As AnimaRegistryEditor.Gamesaves.Gamesave = Nothing
    Private IgnoreControlChange As Boolean = False
    Private MyFileVersion As String = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion
    Private DataFolder As String = "Anima Registry Editor Data"

#Region "Form Events"

    <DllImport("User32.dll")>
    Private Shared Sub SetProcessDPIAware()
    End Sub

    Public Sub New()
        SetProcessDPIAware()
        InitializeComponent()
        Application.EnableVisualStyles()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.icon
        Dim v As String() = MyFileVersion.Split(CChar("."))
        Me.Text &= " (" & Join({v(0), v(1)}, ".") & ")"
        Initialize()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        IgnoreControlChange = True
    End Sub

#End Region

#Region "Controls"

    Private Sub Initialize()

        If (Not IO.Directory.Exists(DataFolder)) Then
            MessageBox.Show("Data folder missing!")
            UIThreadInvoke(Me, Sub() Me.Close())
            Return
        End If

        AnimaRegistryEditor.Initialize(DataFolder)
        IgnoreControlChange = True
        DisableControls()
        InitializeHeadMenuStrip()
        InitializeGamesaveMenuStrip()
        InitializeGeneralTabPage()
        InitializeInventoryTabPage()
        InitializeSkillTreeTabPage()
        InitializeHowToTabPage()
        IgnoreControlChange = False
        UpdateControls()
    End Sub

    Private Sub SetControlsEnabled(v As Boolean)
        SaveButton.Enabled = v
        SaveAsButton.Enabled = v
        DeleteButton.Enabled = v
        GeneralTabPage.Enabled = v
        InventoryTabPage.Enabled = v
        SkillTreeTabPage.Enabled = v
        ReloadGamesaveButton.Enabled = v
    End Sub

    Private Sub EnableControls()
        SetControlsEnabled(True)
    End Sub

    Private Sub DisableControls()
        SetControlsEnabled(False)
    End Sub

    Private Sub UpdateControls()
        UpdateHowToTabPage()
        UpdateSkillTreeTabPage()
        UpdateInventoryTabPage()
        UpdateGeneralTabPage()

        IgnoreControlChange = True
        If SelectedGamesave IsNot Nothing Then
            EnableControls()
        Else
            GamesaveTitleButton.Text = AnimaRegistryEditor.GetString("Select Gamesave")
            DisableControls()
        End If
        UpdateSlotText()
        IgnoreControlChange = False
    End Sub

#End Region

#Region "MenuStrips"

    Private Sub InitializeHeadMenuStrip()
        GamesaveTitleButton.DropDown.Items.Clear()
        GamesaveButtons.Clear()
        For _slot As Integer = 1 To AnimaRegistryEditor.SavegameSlots
            Dim slot As Integer = _slot
            Dim GamesaveButton As New ToolStripButton
            AddHandler GamesaveButton.Click, Sub() SelectGamesave(slot)
            GamesaveTitleButton.DropDown.Items.Add(GamesaveButton)
            GamesaveButtons.Add(GamesaveButton)
        Next
        HeadMenuButton.Text = AnimaRegistryEditor.GetString("Menu")
        HeadDataButton.Text = AnimaRegistryEditor.GetString("Data")
        BackupButton.Text = AnimaRegistryEditor.GetString("Backup Registry")
        ReloadRegistryButton.Text = AnimaRegistryEditor.GetString("Reload Registry")
        SaveKeyAliasesButton.Text = AnimaRegistryEditor.GetString("Save Key Aliases")
        HeadHelpButton.Text = AnimaRegistryEditor.GetString("Help")
        HeadAboutButton.Text = AnimaRegistryEditor.GetString("About")
        ReloadGamesaveButton.Text = AnimaRegistryEditor.GetString("Reload")
    End Sub

    Private Sub InitializeGamesaveMenuStrip()
        SaveAsButton.DropDown.Items.Clear()
        SaveAsButtons.Clear()
        For _slot As Integer = 1 To AnimaRegistryEditor.SavegameSlots
            Dim slot As Integer = _slot
            Dim SaveAsButton As New ToolStripButton
            AddHandler SaveAsButton.Click, Sub() SaveGamesaveAs(slot)
            Me.SaveAsButton.DropDown.Items.Add(SaveAsButton)
            SaveAsButtons.Add(SaveAsButton)
        Next
        SaveAsButton.Text = AnimaRegistryEditor.GetString("Save as")
        SaveButton.Text = AnimaRegistryEditor.GetString("Save")
        DeleteButton.Text = AnimaRegistryEditor.GetString("Delete")
    End Sub

    Private Sub SelectGamesave(Slot As Integer)
        DisableControls()
        SelectedGamesave = AnimaRegistryEditor.Gamesaves.SelectSlot(Slot)
        UpdateControls()
    End Sub

    Private GamesaveButtons As New List(Of ToolStripButton)
    Private Function GetGamesaveButton(slot As Integer) As ToolStripButton
        Return GamesaveButtons(slot - 1)
    End Function

    Private SaveAsButtons As New List(Of ToolStripButton)
    Private Function GetSaveAsButton(slot As Integer) As ToolStripButton
        Return SaveAsButtons(slot - 1)
    End Function

    Private Sub UpdateSlotText(slot As Integer)
        Dim SlotText = AnimaRegistryEditor.Gamesaves.GetSlotText(slot)
        GetGamesaveButton(slot).Text = SlotText
        GetSaveAsButton(slot).Text = SlotText
        If (AnimaRegistryEditor.Gamesaves.IsSlotSelected(slot)) Then
            GamesaveTitleButton.Text = SlotText
        End If
    End Sub

    Private Sub UpdateSlotText()
        For slot As Integer = 1 To AnimaRegistryEditor.SavegameSlots
            UpdateSlotText(slot)
        Next
    End Sub

    Private Sub SaveGamesaveAs(slot As Integer)
        If (AnimaRegistryEditor.Gamesaves.IsSlotSelected(slot)) Then
            SelectedGamesave.SaveToRegistry(slot)
        Else
            If (AnimaRegistryEditor.Gamesaves.SlotExist(slot)) Then
                If MessageBox.Show("Overwrite Slot?", "", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    SelectedGamesave.SaveToRegistry(slot)
                Else
                    Return
                End If
            Else
                SelectedGamesave.SaveToRegistry(slot)
            End If
        End If
        AnimaRegistryEditor.Gamesaves.LoadSlot(slot)
        SelectGamesave(slot)
    End Sub

    Private Sub BackupButton_Click(sender As Object, e As EventArgs) Handles BackupButton.Click
        AnimaRegistryEditor.Export()
    End Sub

    Private Sub ReloadButton_Click(sender As Object, e As EventArgs) Handles ReloadRegistryButton.Click
        SelectedGamesave = Nothing
        Initialize()
    End Sub

    Private Sub SaveKeyAliasesButton_Click(sender As Object, e As EventArgs) Handles SaveKeyAliasesButton.Click
        AnimaRegistryEditor.ExportKeyAliases()
    End Sub

    Private Sub SaveGamesaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        SelectedGamesave.SaveToRegistry()
        UpdateSlotText(SelectedGamesave.Slot)
    End Sub

    Private Sub DeleteGamesaveButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If (MessageBox.Show("Delete all data of '" & AnimaRegistryEditor.Gamesaves.GetSlotText(SelectedGamesave.Slot) & "' ?", "Warning", MessageBoxButtons.OKCancel)) = DialogResult.OK Then
            AnimaRegistryEditor.Gamesaves.DeleteSlot(SelectedGamesave.Slot)
            SelectedGamesave = Nothing
            UpdateControls()
        End If
    End Sub

    Private Sub ReloadGamesaveButton_Click(sender As Object, e As EventArgs) Handles ReloadGamesaveButton.Click
        Dim slot As Integer = SelectedGamesave.Slot
        AnimaRegistryEditor.Gamesaves.LoadSlot(slot)
        SelectGamesave(slot)
    End Sub

    Private Sub HeadAboutButton_Click(sender As Object, e As EventArgs) Handles HeadAboutButton.Click
        Dim l As New List(Of String)
        l.Add("Made with ♥")
        l.Add("")
        l.Add("Version: " & MyFileVersion)
        l.Add(FileVersionInfo.GetVersionInfo(Application.ExecutablePath).LegalCopyright)
        l.Add("Email: contact@yveone.com")
        l.Add("")
        l.Add("https://yveone.com/AnimaRegistryEditor")
        l.Add("https://github.com/YveOne/AnimaRegistryEditor")
        MessageBox.Show(Join(l.ToArray(), vbCrLf), "", MessageBoxButtons.OK)
    End Sub

#End Region

#Region "General TabPage"

    Private Sub InitializeGeneralTabPage()

        GeneralTabPage.Text = AnimaRegistryEditor.GetString("General")
        DateStringLabel.Text = AnimaRegistryEditor.GetString("Date String") & ":"
        CurrentPlaceLabel.Text = AnimaRegistryEditor.GetString("Current Place") & ":"
        LevelLabel.Text = AnimaRegistryEditor.GetString("Level") & ":"
        ExperienceLabel.Text = AnimaRegistryEditor.GetString("Experience") & ":"
        CoinsLabel.Text = AnimaRegistryEditor.GetString("Coins") & ":"
        DificultyLabel.Text = AnimaRegistryEditor.GetString("Dificulty") & ":"
        PlayTimeLabel.Text = AnimaRegistryEditor.GetString("Play Time") & ":"

        LevelNumeric.Minimum = 1
        LevelNumeric.Maximum = AnimaRegistryEditor.MaxLevel
        ExperienceNumeric.Minimum = 0
        ExperienceNumeric.Maximum = AnimaRegistryEditor.MaxXP
        CoinsNumeric.Minimum = 0
        CoinsNumeric.Maximum = AnimaRegistryEditor.MaxCoins
        PlayTimeNumeric.Minimum = 0
        PlayTimeNumeric.Maximum = AnimaRegistryEditor.MaxPlayTime

        DificultyComboBox.Items.Clear()
        For Each s As String In AnimaRegistryEditor.DifficultyNames
            DificultyComboBox.Items.Add(AnimaRegistryEditor.GetString(s))
        Next

        Dim LocationsDataSource As New ArrayList()
        Dim LocationPlace As AnimaRegistryEditor.Locations.LocationPlace
        Dim LocationGroups As New SortedList(Of String, Integer)
        Dim locationTitle As String
        For i As Integer = 0 To AnimaRegistryEditor.Locations.Places.Count - 1
            LocationPlace = AnimaRegistryEditor.Locations.Places(i)
            locationTitle = LocationPlace.Title
            If (Not LocationGroups.ContainsKey(locationTitle)) Then
                LocationGroups.Add(locationTitle, LocationGroups.Values.Count)
            End If
            locationTitle = CStr(LocationGroups(locationTitle)).PadLeft(3, CChar("0")) & ") " & locationTitle
            LocationsDataSource.Add(New With {
                .Value = LocationPlace.Key,
                .Display = CStr(i).PadLeft(3, CChar("0")) & ") " & LocationPlace.Text,
                .Group = locationTitle
             })
        Next
        CurrentPlaceDropDown.ValueMember = "Value"
        CurrentPlaceDropDown.DisplayMember = "Display"
        CurrentPlaceDropDown.GroupMember = "Group"
        CurrentPlaceDropDown.DataSource = LocationsDataSource

    End Sub

    Private Sub UpdateGeneralTabPage()
        IgnoreControlChange = True
        If SelectedGamesave IsNot Nothing Then
            ExperienceNumeric.Value = SelectedGamesave.XP
            LevelNumeric.Value = SelectedGamesave.Level
            DateStringTextBox.Text = SelectedGamesave.DateString
            CurrentPlaceDropDown.SelectedValue = SelectedGamesave.CurrentPlace
            CoinsNumeric.Value = SelectedGamesave.Coins
            DificultyComboBox.SelectedIndex = SelectedGamesave.Dificulty
            PlayTimeNumeric.Value = SelectedGamesave.CurrentPlayTime
        Else
            ExperienceNumeric.Value = 0
            LevelNumeric.Value = 1
            DateStringTextBox.Text = ""
            CurrentPlaceDropDown.SelectedIndex = -1
            CoinsNumeric.Value = 0
            DificultyComboBox.SelectedIndex = 0
            PlayTimeNumeric.Value = 0
        End If
        IgnoreControlChange = False
    End Sub

    Private Sub CurrentPlaceDropDown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CurrentPlaceDropDown.SelectedIndexChanged
        If (IgnoreControlChange) Then
            Return
        End If
        SelectedGamesave.CurrentPlace = CStr(CurrentPlaceDropDown.SelectedValue)
        UpdateSlotText(SelectedGamesave.Slot)
    End Sub

    Private Sub LevelNumeric_ValueChanged(sender As Object, e As EventArgs) Handles LevelNumeric.ValueChanged, LevelNumeric.KeyUp
        If (IgnoreControlChange) Then
            Return
        End If
        SelectedGamesave.Level = CInt(LevelNumeric.Value)
        UpdateSlotText(SelectedGamesave.Slot)
        IgnoreControlChange = True
        ExperienceNumeric.Value = SelectedGamesave.XP
        IgnoreControlChange = False
    End Sub

    Private Sub ExperienceNumeric_ValueChanged(sender As Object, e As EventArgs) Handles ExperienceNumeric.ValueChanged, ExperienceNumeric.KeyUp
        If (IgnoreControlChange) Then
            Return
        End If
        SelectedGamesave.XP = CInt(ExperienceNumeric.Value)
        UpdateSlotText(SelectedGamesave.Slot)
        IgnoreControlChange = True
        LevelNumeric.Value = SelectedGamesave.Level
        IgnoreControlChange = False
    End Sub

    Private Sub DateStringTextBox_TextChanged(sender As Object, e As EventArgs) Handles DateStringTextBox.TextChanged
        If (IgnoreControlChange) Then
            Return
        End If
        SelectedGamesave.DateString = DateStringTextBox.Text
        UpdateSlotText(SelectedGamesave.Slot)
    End Sub

    Private Sub CoinsNumeric_ValueChanged(sender As Object, e As EventArgs) Handles CoinsNumeric.ValueChanged, CoinsNumeric.KeyUp
        If (IgnoreControlChange) Then
            Return
        End If
        SelectedGamesave.Coins = CInt(CoinsNumeric.Value)
        UpdateSlotText(SelectedGamesave.Slot)
    End Sub

    Private Sub DificultyComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DificultyComboBox.SelectedIndexChanged
        If (IgnoreControlChange) Then
            Return
        End If
        SelectedGamesave.Dificulty = DificultyComboBox.SelectedIndex
        UpdateSlotText(SelectedGamesave.Slot)
    End Sub

    Private Sub PlayTimeNumeric_ValueChanged(sender As Object, e As EventArgs) Handles PlayTimeNumeric.ValueChanged, PlayTimeNumeric.KeyUp
        If (IgnoreControlChange) Then
            Return
        End If
        SelectedGamesave.CurrentPlayTime = CInt(PlayTimeNumeric.Value)
        UpdateSlotText(SelectedGamesave.Slot)
    End Sub

#End Region

#Region "Inventory TabPage"

    Private Sub InitializeInventoryTabPage()
        ItemTypeColumn.GroupKeyGetter = New GroupKeyGetterDelegate(AddressOf InventoryListView_TypeGroupGetter)
        InventoryListView.RowFormatter = New RowFormatterDelegate(AddressOf InventoryListView_FormatRow)
        InventoryItems.Clear()
        For ItemID As Integer = 0 To AnimaRegistryEditor.InventorySize - 1
            InventoryItems.Add(New InventoryItem(
                ItemID,
                AnimaRegistryEditor.Inventory.Items(ItemID).Name,
                AnimaRegistryEditor.Inventory.Items(ItemID).TypeName,
                0
            ))
        Next
        InventoryItemCountNumeric.Minimum = 0
        InventoryItemCountNumeric.Maximum = 0
        InventoryTabPage.Text = AnimaRegistryEditor.GetString("Inventory")
        ItemIdColumn.Text = AnimaRegistryEditor.GetString("ID")
        ItemNameColumn.Text = AnimaRegistryEditor.GetString("Name")
        ItemTypeColumn.Text = AnimaRegistryEditor.GetString("Type")
        ItemCountColumn.Text = AnimaRegistryEditor.GetString("Count")
        InventoryItemCountLabel.Text = AnimaRegistryEditor.GetString("Count") & ":"
        ItemNameLabel.Text = AnimaRegistryEditor.GetString("Item Name")
        ItemDescriptionLabel.Text = AnimaRegistryEditor.GetString("Item Description")
        ItemEffectsLabel.Text = AnimaRegistryEditor.GetString("Item Effects")
    End Sub

    Private Sub UpdateInventoryTabPage()
        IgnoreControlChange = True
        If SelectedGamesave IsNot Nothing Then
            For ItemID As Integer = 0 To InventoryListView.Items.Count - 1
                InventoryItems(ItemID).SetCount(SelectedGamesave.GetItemCount(ItemID))
            Next
        Else
            For Each II As InventoryItem In InventoryItems
                II.SetCount(0)
            Next
        End If
        InventoryListView.SetObjects(InventoryItems)
        InventoryItemCountNumeric.Enabled = False
        IgnoreControlChange = False
    End Sub

    Private Class InventoryItem
        Private _ItemId As Integer
        Private _Name As String
        Private _Type As String
        Private _ItemCount As Integer
        Public Sub New(ItemID As Integer, Name As String, Type As String, ItemCount As Integer)
            Me._ItemId = ItemID
            Me._Name = Name
            Me._Type = Type
            Me._ItemCount = ItemCount
        End Sub
        Public ReadOnly Property ID As Integer
            Get
                Return _ItemId
            End Get
        End Property
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property
        Public ReadOnly Property Type As String
            Get
                Return _Type
            End Get
        End Property
        Public Property Count As Integer
            Get
                Return _ItemCount
            End Get
            Set(value As Integer)
                _ItemCount = value
                MainForm.SelectedGamesave.SetItemCount(_ItemId, _ItemCount)
                MainForm.UpdateSlotText(MainForm.SelectedGamesave.Slot)
            End Set
        End Property
        Public Sub SetCount(value As Integer)
            _ItemCount = Math.Max(0, Math.Min(value, AnimaRegistryEditor.Inventory.Items(_ItemId).MaxCount))
        End Sub
    End Class

    Private InventoryItems As New List(Of InventoryItem)
    Private SelectedInventoryItem As InventoryItem = Nothing
    Private SelectedInventoryRow As OLVListItem = Nothing

    Private Function InventoryListView_TypeGroupGetter(row As Object) As String
        Return CType(row, InventoryItem).Type
    End Function

    Private Sub InventoryListView_FormatRow(olvi As OLVListItem)
        Dim Item As InventoryItem = CType(olvi.RowObject, InventoryItem)
        If olvi.Equals(SelectedInventoryRow) Then
            olvi.BackColor = Color.FromName("Highlight")
            olvi.ForeColor = Color.White
        Else
            If (Item.Count = 0) Then
                olvi.ForeColor = Color.DarkGray
            End If
        End If
    End Sub

    Private Sub InventoryListView_SelectionChanged() Handles InventoryListView.SelectionChanged
        If (IgnoreControlChange) Then
            Return
        End If
        If (InventoryListView.SelectedIndex < 0) Then
            Return
        End If
        Dim LastSelectedRow As OLVListItem = SelectedInventoryRow
        SelectedInventoryRow = CType(InventoryListView.Items(InventoryListView.SelectedIndex), OLVListItem)
        SelectedInventoryItem = InventoryItems(InventoryListView.SelectedIndex)
        InventoryItemCountNumeric.Enabled = True
        If LastSelectedRow IsNot Nothing Then
            InventoryListView.RefreshItem(LastSelectedRow)
        End If
        Dim AnimaItem As AnimaRegistryEditor.Inventory.Item = AnimaRegistryEditor.Inventory.Items(SelectedInventoryItem.ID)
        IgnoreControlChange = True
        InventoryItemCountNumeric.Maximum = AnimaItem.MaxCount
        InventoryItemCountNumeric.Value = SelectedInventoryItem.Count
        IgnoreControlChange = False
        ItemNameLabel.Text = AnimaItem.Name
        ItemDescriptionLabel.Text = AnimaItem.Description
        ItemEffectsLabel.Text = ""
        Select Case AnimaItem.TypeChar
            Case CChar("w")
                ItemEffectsLabel.Text = Join({
                    AnimaRegistryEditor.Inventory.GetEffectName("patk") & ": " & AnimaItem.StatEffects("patk"),
                    AnimaRegistryEditor.Inventory.GetEffectName("matk") & ": " & AnimaItem.StatEffects("matk"),
                    AnimaRegistryEditor.Inventory.GetEffectName("crit") & ": " & AnimaItem.StatEffects("crit"),
                    AnimaRegistryEditor.Inventory.GetEffectName("cdmg") & ": " & AnimaItem.StatEffects("cdmg"),
                    "",
                    AnimaRegistryEditor.GetString("Special") & ": " & AnimaRegistryEditor.Inventory.GetEffectName(AnimaItem.SpecialEffect)
                }, vbCrLf)
            Case CChar("a")
                ItemEffectsLabel.Text = Join({
                    AnimaRegistryEditor.Inventory.GetEffectName("pdef") & ": " & AnimaItem.StatEffects("pdef"),
                    AnimaRegistryEditor.Inventory.GetEffectName("mdef") & ": " & AnimaItem.StatEffects("mdef"),
                    "",
                    AnimaRegistryEditor.GetString("Special") & ": " & AnimaRegistryEditor.Inventory.GetEffectName(AnimaItem.SpecialEffect)
                }, vbCrLf)
        End Select
    End Sub

    Private Sub InventoryItemCountNumeric_ValueChanged(sender As Object, e As EventArgs) Handles InventoryItemCountNumeric.ValueChanged, InventoryItemCountNumeric.KeyUp
        If (IgnoreControlChange) Then
            Return
        End If
        SelectedInventoryItem.Count = CInt(InventoryItemCountNumeric.Value)
        InventoryListView.RefreshItem(SelectedInventoryRow)
    End Sub

#End Region

#Region "SkillTree TabPage"

    Private Sub InitializeSkillTreeTabPage()
        SkillTreeTabPage.Text = AnimaRegistryEditor.GetString("Skill Tree")
        SkillTreePointsLabel1.Text = AnimaRegistryEditor.GetString("Skill Points") & ":"
        SkillTreePointsLabel2.Text = AnimaRegistryEditor.GetString("Skill Points") & ":"
        SkillTreeUsedLabel1.Text = AnimaRegistryEditor.GetString("Used") & ":"
        SkillTreeUsedLabel2.Text = AnimaRegistryEditor.GetString("Used") & ":"
        SkillTreeClearBearerButton.Text = AnimaRegistryEditor.GetString("Clear")
        SkillTreeClearErgoButton.Text = AnimaRegistryEditor.GetString("Clear")
    End Sub

    Private Sub UpdateSkillTreeTabPage()
        IgnoreControlChange = True
        If SelectedGamesave IsNot Nothing Then

            SkillTreeBearerPointsNumeric.Minimum = 0
            SkillTreeBearerPointsNumeric.Maximum = 999
            SkillTreeErgoPointsNumeric.Minimum = 0
            SkillTreeErgoPointsNumeric.Maximum = 999

            Dim spUsedBearer As Integer = SelectedGamesave.BearerUsedSkillPoints
            Dim spUnusedBearer As Integer = SelectedGamesave.BearerSP
            SkillTreeUsedBearerLabel.Text = spUsedBearer & " / " & AnimaRegistryEditor.SkillTreeMaxPointsBearer
            SkillTreeBearerPointsNumeric.Value = spUnusedBearer
            SkillTreeBearerPointsNumeric.Maximum = Math.Max(0, AnimaRegistryEditor.SkillTreeMaxPointsBearer - spUsedBearer)

            Dim spUsedErgo As Integer = SelectedGamesave.ErgoUsedSkillPoints
            Dim spUnusedErgo As Integer = SelectedGamesave.ErgoSP
            SkillTreeUsedErgoLabel.Text = spUsedErgo & " / " & AnimaRegistryEditor.SkillTreeMaxPointsErgo
            SkillTreeErgoPointsNumeric.Value = spUnusedErgo
            SkillTreeErgoPointsNumeric.Maximum = Math.Max(0, AnimaRegistryEditor.SkillTreeMaxPointsErgo - spUsedErgo)

        Else
            SkillTreeBearerPointsNumeric.Minimum = 0
            SkillTreeBearerPointsNumeric.Value = 0
            SkillTreeBearerPointsNumeric.Maximum = 0
            SkillTreeErgoPointsNumeric.Minimum = 0
            SkillTreeErgoPointsNumeric.Value = 0
            SkillTreeErgoPointsNumeric.Maximum = 0
        End If
        IgnoreControlChange = False
    End Sub

    Private Sub SkillTreeBearerPointsNumeric_ValueChanged(sender As Object, e As EventArgs) Handles SkillTreeBearerPointsNumeric.ValueChanged, SkillTreeBearerPointsNumeric.KeyUp
        If (IgnoreControlChange) Then
            Return
        End If
        SelectedGamesave.BearerSP = CInt(SkillTreeBearerPointsNumeric.Value)
        UpdateSlotText(SelectedGamesave.Slot)
    End Sub

    Private Sub SkillTreeErgoPointsNumeric_ValueChanged(sender As Object, e As EventArgs) Handles SkillTreeErgoPointsNumeric.ValueChanged, SkillTreeErgoPointsNumeric.KeyUp
        If (IgnoreControlChange) Then
            Return
        End If
        SelectedGamesave.ErgoSP = CInt(SkillTreeErgoPointsNumeric.Value)
        UpdateSlotText(SelectedGamesave.Slot)
    End Sub

    Private Sub SkillTreeClearBearerButton_Click(sender As Object, e As EventArgs) Handles SkillTreeClearBearerButton.Click
        SelectedGamesave.BearerSP = Math.Min(SelectedGamesave.BearerSP + SelectedGamesave.BearerUsedSkillPoints, AnimaRegistryEditor.SkillTreeMaxPointsBearer)
        SelectedGamesave.ClearBearerSkillPoints()
        UpdateSlotText(SelectedGamesave.Slot)
        UpdateSkillTreeTabPage()
    End Sub

    Private Sub SkillTreeClearErgoButton_Click(sender As Object, e As EventArgs) Handles SkillTreeClearErgoButton.Click
        SelectedGamesave.ErgoSP = Math.Min(SelectedGamesave.ErgoSP + SelectedGamesave.ErgoUsedSkillPoints, AnimaRegistryEditor.SkillTreeMaxPointsErgo)
        SelectedGamesave.ClearErgoSkillPoints()
        UpdateSlotText(SelectedGamesave.Slot)
        UpdateSkillTreeTabPage()
    End Sub

#End Region

#Region "HowToTabPage"

    Private Sub InitializeHowToTabPage()
        HowToTabPage.Text = AnimaRegistryEditor.GetString("How To")
        If IO.File.Exists(DataFolder & "/howto.txt") Then
            HowToLabel.Text = IO.File.ReadAllText(DataFolder & "/howto.txt")
        Else
            HowToLabel.Text = "howto file missing"
        End If
    End Sub

    Private Sub UpdateHowToTabPage()
        If SelectedGamesave IsNot Nothing Then
            If GamesaveTabControl.SelectedIndex = 0 Then
                GamesaveTabControl.SelectedTab = GeneralTabPage
            End If
        Else
            GamesaveTabControl.SelectedTab = HowToTabPage
        End If
    End Sub

#End Region

End Class
