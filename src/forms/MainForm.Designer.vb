<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.HeadMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.HeadMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadRegistryButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.HeadDataButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveKeyAliasesButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.HeadHelpButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.HeadAboutButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.GamesaveMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.DeleteButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.GamesaveTitleButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadGamesaveButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemIdColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.InventoryTabPage = New System.Windows.Forms.TabPage()
        Me.ItemEffectsLabel = New System.Windows.Forms.Label()
        Me.ItemDescriptionLabel = New System.Windows.Forms.Label()
        Me.ItemNameLabel = New System.Windows.Forms.Label()
        Me.InventoryItemCountLabel = New System.Windows.Forms.Label()
        Me.InventoryItemCountNumeric = New System.Windows.Forms.NumericUpDown()
        Me.InventoryListView = New BrightIdeasSoftware.ObjectListView()
        Me.ItemNameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ItemTypeColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ItemCountColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.GeneralTabPage = New System.Windows.Forms.TabPage()
        Me.PlayTimeNumeric = New System.Windows.Forms.NumericUpDown()
        Me.PlayTimeLabel = New System.Windows.Forms.Label()
        Me.DificultyLabel = New System.Windows.Forms.Label()
        Me.DificultyComboBox = New System.Windows.Forms.ComboBox()
        Me.CoinsNumeric = New System.Windows.Forms.NumericUpDown()
        Me.CoinsLabel = New System.Windows.Forms.Label()
        Me.DateStringTextBox = New System.Windows.Forms.TextBox()
        Me.DateStringLabel = New System.Windows.Forms.Label()
        Me.ExperienceNumeric = New System.Windows.Forms.NumericUpDown()
        Me.LevelNumeric = New System.Windows.Forms.NumericUpDown()
        Me.CurrentPlaceLabel = New System.Windows.Forms.Label()
        Me.CurrentPlaceDropDown = New GroupedComboBox()
        Me.LevelLabel = New System.Windows.Forms.Label()
        Me.ExperienceLabel = New System.Windows.Forms.Label()
        Me.GamesaveTabControl = New System.Windows.Forms.TabControl()
        Me.HowToTabPage = New System.Windows.Forms.TabPage()
        Me.HowToLabel = New System.Windows.Forms.Label()
        Me.SkillTreeTabPage = New System.Windows.Forms.TabPage()
        Me.SkillTreeErgoGroupBox = New System.Windows.Forms.GroupBox()
        Me.SkillTreeClearErgoButton = New System.Windows.Forms.Button()
        Me.SkillTreeUsedErgoLabel = New System.Windows.Forms.Label()
        Me.SkillTreeUsedLabel2 = New System.Windows.Forms.Label()
        Me.SkillTreeErgoPointsNumeric = New System.Windows.Forms.NumericUpDown()
        Me.SkillTreePointsLabel2 = New System.Windows.Forms.Label()
        Me.SkillTreeBearerGroupBox = New System.Windows.Forms.GroupBox()
        Me.SkillTreeClearBearerButton = New System.Windows.Forms.Button()
        Me.SkillTreeUsedBearerLabel = New System.Windows.Forms.Label()
        Me.SkillTreeUsedLabel1 = New System.Windows.Forms.Label()
        Me.SkillTreeBearerPointsNumeric = New System.Windows.Forms.NumericUpDown()
        Me.SkillTreePointsLabel1 = New System.Windows.Forms.Label()
        Me.HeadMenuStrip.SuspendLayout()
        Me.GamesaveMenuStrip.SuspendLayout()
        Me.InventoryTabPage.SuspendLayout()
        CType(Me.InventoryItemCountNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GeneralTabPage.SuspendLayout()
        CType(Me.PlayTimeNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CoinsNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExperienceNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LevelNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GamesaveTabControl.SuspendLayout()
        Me.HowToTabPage.SuspendLayout()
        Me.SkillTreeTabPage.SuspendLayout()
        Me.SkillTreeErgoGroupBox.SuspendLayout()
        CType(Me.SkillTreeErgoPointsNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SkillTreeBearerGroupBox.SuspendLayout()
        CType(Me.SkillTreeBearerPointsNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HeadMenuStrip
        '
        Me.HeadMenuStrip.BackColor = System.Drawing.Color.White
        Me.HeadMenuStrip.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeadMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.HeadMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HeadMenuButton, Me.HeadDataButton, Me.HeadHelpButton})
        Me.HeadMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.HeadMenuStrip.Name = "HeadMenuStrip"
        Me.HeadMenuStrip.Padding = New System.Windows.Forms.Padding(7, 1, 0, 1)
        Me.HeadMenuStrip.Size = New System.Drawing.Size(717, 26)
        Me.HeadMenuStrip.TabIndex = 3
        Me.HeadMenuStrip.Text = "MenuStrip1"
        '
        'HeadMenuButton
        '
        Me.HeadMenuButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupButton, Me.ReloadRegistryButton})
        Me.HeadMenuButton.Name = "HeadMenuButton"
        Me.HeadMenuButton.Size = New System.Drawing.Size(58, 24)
        Me.HeadMenuButton.Text = "Menu"
        '
        'BackupButton
        '
        Me.BackupButton.Name = "BackupButton"
        Me.BackupButton.Size = New System.Drawing.Size(189, 26)
        Me.BackupButton.Text = "Backup Registry"
        '
        'ReloadRegistryButton
        '
        Me.ReloadRegistryButton.Name = "ReloadRegistryButton"
        Me.ReloadRegistryButton.Size = New System.Drawing.Size(189, 26)
        Me.ReloadRegistryButton.Text = "Reload Registry"
        '
        'HeadDataButton
        '
        Me.HeadDataButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveKeyAliasesButton})
        Me.HeadDataButton.Name = "HeadDataButton"
        Me.HeadDataButton.Size = New System.Drawing.Size(53, 24)
        Me.HeadDataButton.Text = "Data"
        '
        'SaveKeyAliasesButton
        '
        Me.SaveKeyAliasesButton.Name = "SaveKeyAliasesButton"
        Me.SaveKeyAliasesButton.Size = New System.Drawing.Size(193, 26)
        Me.SaveKeyAliasesButton.Text = "Save Key Aliases"
        '
        'HeadHelpButton
        '
        Me.HeadHelpButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HeadAboutButton})
        Me.HeadHelpButton.Name = "HeadHelpButton"
        Me.HeadHelpButton.Size = New System.Drawing.Size(53, 24)
        Me.HeadHelpButton.Text = "Help"
        '
        'HeadAboutButton
        '
        Me.HeadAboutButton.Name = "HeadAboutButton"
        Me.HeadAboutButton.Size = New System.Drawing.Size(125, 26)
        Me.HeadAboutButton.Text = "About"
        '
        'GamesaveMenuStrip
        '
        Me.GamesaveMenuStrip.BackColor = System.Drawing.Color.Transparent
        Me.GamesaveMenuStrip.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GamesaveMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.GamesaveMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteButton, Me.GamesaveTitleButton, Me.ReloadGamesaveButton, Me.SaveAsButton, Me.SaveButton})
        Me.GamesaveMenuStrip.Location = New System.Drawing.Point(0, 26)
        Me.GamesaveMenuStrip.Name = "GamesaveMenuStrip"
        Me.GamesaveMenuStrip.Padding = New System.Windows.Forms.Padding(7, 1, 0, 1)
        Me.GamesaveMenuStrip.Size = New System.Drawing.Size(717, 26)
        Me.GamesaveMenuStrip.TabIndex = 0
        Me.GamesaveMenuStrip.Text = "MenuStrip2"
        '
        'DeleteButton
        '
        Me.DeleteButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(65, 24)
        Me.DeleteButton.Text = "Delete"
        '
        'GamesaveTitleButton
        '
        Me.GamesaveTitleButton.Name = "GamesaveTitleButton"
        Me.GamesaveTitleButton.Size = New System.Drawing.Size(133, 24)
        Me.GamesaveTitleButton.Text = "Select Gamesave"
        '
        'ReloadGamesaveButton
        '
        Me.ReloadGamesaveButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ReloadGamesaveButton.Name = "ReloadGamesaveButton"
        Me.ReloadGamesaveButton.Size = New System.Drawing.Size(68, 24)
        Me.ReloadGamesaveButton.Text = "Reload"
        '
        'SaveAsButton
        '
        Me.SaveAsButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SaveAsButton.Name = "SaveAsButton"
        Me.SaveAsButton.Size = New System.Drawing.Size(70, 24)
        Me.SaveAsButton.Text = "Save as"
        '
        'SaveButton
        '
        Me.SaveButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(52, 24)
        Me.SaveButton.Text = "Save"
        '
        'ItemIdColumn
        '
        Me.ItemIdColumn.AspectName = "ID"
        Me.ItemIdColumn.DisplayIndex = 1
        Me.ItemIdColumn.Groupable = False
        Me.ItemIdColumn.IsVisible = False
        Me.ItemIdColumn.Sortable = False
        Me.ItemIdColumn.Tag = ""
        Me.ItemIdColumn.Text = "ID"
        Me.ItemIdColumn.Width = 52
        '
        'InventoryTabPage
        '
        Me.InventoryTabPage.Controls.Add(Me.ItemEffectsLabel)
        Me.InventoryTabPage.Controls.Add(Me.ItemDescriptionLabel)
        Me.InventoryTabPage.Controls.Add(Me.ItemNameLabel)
        Me.InventoryTabPage.Controls.Add(Me.InventoryItemCountLabel)
        Me.InventoryTabPage.Controls.Add(Me.InventoryItemCountNumeric)
        Me.InventoryTabPage.Controls.Add(Me.InventoryListView)
        Me.InventoryTabPage.Location = New System.Drawing.Point(4, 32)
        Me.InventoryTabPage.Name = "InventoryTabPage"
        Me.InventoryTabPage.Size = New System.Drawing.Size(709, 427)
        Me.InventoryTabPage.TabIndex = 2
        Me.InventoryTabPage.Text = "Inventory"
        Me.InventoryTabPage.UseVisualStyleBackColor = True
        '
        'ItemEffectsLabel
        '
        Me.ItemEffectsLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemEffectsLabel.Location = New System.Drawing.Point(474, 292)
        Me.ItemEffectsLabel.Name = "ItemEffectsLabel"
        Me.ItemEffectsLabel.Size = New System.Drawing.Size(227, 126)
        Me.ItemEffectsLabel.TabIndex = 19
        Me.ItemEffectsLabel.Text = "Item Effects"
        Me.ItemEffectsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ItemDescriptionLabel
        '
        Me.ItemDescriptionLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemDescriptionLabel.Location = New System.Drawing.Point(8, 279)
        Me.ItemDescriptionLabel.Name = "ItemDescriptionLabel"
        Me.ItemDescriptionLabel.Size = New System.Drawing.Size(460, 139)
        Me.ItemDescriptionLabel.TabIndex = 18
        Me.ItemDescriptionLabel.Text = "Item Description"
        Me.ItemDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ItemNameLabel
        '
        Me.ItemNameLabel.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemNameLabel.Location = New System.Drawing.Point(8, 249)
        Me.ItemNameLabel.Name = "ItemNameLabel"
        Me.ItemNameLabel.Size = New System.Drawing.Size(460, 30)
        Me.ItemNameLabel.TabIndex = 17
        Me.ItemNameLabel.Text = "Item Name"
        Me.ItemNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InventoryItemCountLabel
        '
        Me.InventoryItemCountLabel.AutoSize = True
        Me.InventoryItemCountLabel.Location = New System.Drawing.Point(558, 249)
        Me.InventoryItemCountLabel.Name = "InventoryItemCountLabel"
        Me.InventoryItemCountLabel.Size = New System.Drawing.Size(61, 23)
        Me.InventoryItemCountLabel.TabIndex = 16
        Me.InventoryItemCountLabel.Text = "Count:"
        '
        'InventoryItemCountNumeric
        '
        Me.InventoryItemCountNumeric.Location = New System.Drawing.Point(625, 247)
        Me.InventoryItemCountNumeric.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.InventoryItemCountNumeric.Name = "InventoryItemCountNumeric"
        Me.InventoryItemCountNumeric.Size = New System.Drawing.Size(81, 30)
        Me.InventoryItemCountNumeric.TabIndex = 12
        Me.InventoryItemCountNumeric.TabStop = False
        Me.InventoryItemCountNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'InventoryListView
        '
        Me.InventoryListView.AllColumns.Add(Me.ItemNameColumn)
        Me.InventoryListView.AllColumns.Add(Me.ItemIdColumn)
        Me.InventoryListView.AllColumns.Add(Me.ItemTypeColumn)
        Me.InventoryListView.AllColumns.Add(Me.ItemCountColumn)
        Me.InventoryListView.CellEditUseWholeCell = False
        Me.InventoryListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ItemNameColumn, Me.ItemTypeColumn, Me.ItemCountColumn})
        Me.InventoryListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.InventoryListView.FullRowSelect = True
        Me.InventoryListView.GridLines = True
        Me.InventoryListView.Location = New System.Drawing.Point(3, 3)
        Me.InventoryListView.MultiSelect = False
        Me.InventoryListView.Name = "InventoryListView"
        Me.InventoryListView.Size = New System.Drawing.Size(703, 237)
        Me.InventoryListView.TabIndex = 2
        Me.InventoryListView.TabStop = False
        Me.InventoryListView.UseCompatibleStateImageBehavior = False
        Me.InventoryListView.View = System.Windows.Forms.View.Details
        '
        'ItemNameColumn
        '
        Me.ItemNameColumn.AspectName = "Name"
        Me.ItemNameColumn.Text = "Name"
        Me.ItemNameColumn.UseInitialLetterForGroup = True
        Me.ItemNameColumn.Width = 349
        '
        'ItemTypeColumn
        '
        Me.ItemTypeColumn.AspectName = "Type"
        Me.ItemTypeColumn.Text = "Type"
        Me.ItemTypeColumn.Width = 101
        '
        'ItemCountColumn
        '
        Me.ItemCountColumn.AspectName = "Count"
        Me.ItemCountColumn.Groupable = False
        Me.ItemCountColumn.Sortable = False
        Me.ItemCountColumn.Text = "Count"
        Me.ItemCountColumn.Width = 76
        '
        'GeneralTabPage
        '
        Me.GeneralTabPage.BackColor = System.Drawing.Color.White
        Me.GeneralTabPage.Controls.Add(Me.PlayTimeNumeric)
        Me.GeneralTabPage.Controls.Add(Me.PlayTimeLabel)
        Me.GeneralTabPage.Controls.Add(Me.DificultyLabel)
        Me.GeneralTabPage.Controls.Add(Me.DificultyComboBox)
        Me.GeneralTabPage.Controls.Add(Me.CoinsNumeric)
        Me.GeneralTabPage.Controls.Add(Me.CoinsLabel)
        Me.GeneralTabPage.Controls.Add(Me.DateStringTextBox)
        Me.GeneralTabPage.Controls.Add(Me.DateStringLabel)
        Me.GeneralTabPage.Controls.Add(Me.ExperienceNumeric)
        Me.GeneralTabPage.Controls.Add(Me.LevelNumeric)
        Me.GeneralTabPage.Controls.Add(Me.CurrentPlaceLabel)
        Me.GeneralTabPage.Controls.Add(Me.CurrentPlaceDropDown)
        Me.GeneralTabPage.Controls.Add(Me.LevelLabel)
        Me.GeneralTabPage.Controls.Add(Me.ExperienceLabel)
        Me.GeneralTabPage.Location = New System.Drawing.Point(4, 32)
        Me.GeneralTabPage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralTabPage.Name = "GeneralTabPage"
        Me.GeneralTabPage.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralTabPage.Size = New System.Drawing.Size(709, 427)
        Me.GeneralTabPage.TabIndex = 1
        Me.GeneralTabPage.Text = "General"
        '
        'PlayTimeNumeric
        '
        Me.PlayTimeNumeric.Location = New System.Drawing.Point(280, 208)
        Me.PlayTimeNumeric.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PlayTimeNumeric.Name = "PlayTimeNumeric"
        Me.PlayTimeNumeric.Size = New System.Drawing.Size(136, 30)
        Me.PlayTimeNumeric.TabIndex = 20
        Me.PlayTimeNumeric.TabStop = False
        Me.PlayTimeNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PlayTimeLabel
        '
        Me.PlayTimeLabel.AutoSize = True
        Me.PlayTimeLabel.Location = New System.Drawing.Point(280, 181)
        Me.PlayTimeLabel.Name = "PlayTimeLabel"
        Me.PlayTimeLabel.Size = New System.Drawing.Size(87, 23)
        Me.PlayTimeLabel.TabIndex = 19
        Me.PlayTimeLabel.Text = "Play Time:"
        '
        'DificultyLabel
        '
        Me.DificultyLabel.AutoSize = True
        Me.DificultyLabel.Location = New System.Drawing.Point(478, 93)
        Me.DificultyLabel.Name = "DificultyLabel"
        Me.DificultyLabel.Size = New System.Drawing.Size(75, 23)
        Me.DificultyLabel.TabIndex = 18
        Me.DificultyLabel.Text = "Dificulty:"
        '
        'DificultyComboBox
        '
        Me.DificultyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DificultyComboBox.FormattingEnabled = True
        Me.DificultyComboBox.Location = New System.Drawing.Point(478, 120)
        Me.DificultyComboBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DificultyComboBox.Name = "DificultyComboBox"
        Me.DificultyComboBox.Size = New System.Drawing.Size(136, 31)
        Me.DificultyComboBox.TabIndex = 17
        Me.DificultyComboBox.TabStop = False
        '
        'CoinsNumeric
        '
        Me.CoinsNumeric.Location = New System.Drawing.Point(280, 303)
        Me.CoinsNumeric.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CoinsNumeric.Name = "CoinsNumeric"
        Me.CoinsNumeric.Size = New System.Drawing.Size(136, 30)
        Me.CoinsNumeric.TabIndex = 16
        Me.CoinsNumeric.TabStop = False
        Me.CoinsNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CoinsLabel
        '
        Me.CoinsLabel.AutoSize = True
        Me.CoinsLabel.Location = New System.Drawing.Point(280, 276)
        Me.CoinsLabel.Name = "CoinsLabel"
        Me.CoinsLabel.Size = New System.Drawing.Size(56, 23)
        Me.CoinsLabel.TabIndex = 15
        Me.CoinsLabel.Text = "Coins:"
        '
        'DateStringTextBox
        '
        Me.DateStringTextBox.Location = New System.Drawing.Point(82, 208)
        Me.DateStringTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateStringTextBox.Name = "DateStringTextBox"
        Me.DateStringTextBox.Size = New System.Drawing.Size(192, 30)
        Me.DateStringTextBox.TabIndex = 14
        Me.DateStringTextBox.TabStop = False
        '
        'DateStringLabel
        '
        Me.DateStringLabel.AutoSize = True
        Me.DateStringLabel.Location = New System.Drawing.Point(82, 181)
        Me.DateStringLabel.Name = "DateStringLabel"
        Me.DateStringLabel.Size = New System.Drawing.Size(99, 23)
        Me.DateStringLabel.TabIndex = 13
        Me.DateStringLabel.Text = "Date String:"
        '
        'ExperienceNumeric
        '
        Me.ExperienceNumeric.Location = New System.Drawing.Point(169, 303)
        Me.ExperienceNumeric.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ExperienceNumeric.Name = "ExperienceNumeric"
        Me.ExperienceNumeric.Size = New System.Drawing.Size(105, 30)
        Me.ExperienceNumeric.TabIndex = 12
        Me.ExperienceNumeric.TabStop = False
        Me.ExperienceNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LevelNumeric
        '
        Me.LevelNumeric.Location = New System.Drawing.Point(82, 303)
        Me.LevelNumeric.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LevelNumeric.Name = "LevelNumeric"
        Me.LevelNumeric.Size = New System.Drawing.Size(81, 30)
        Me.LevelNumeric.TabIndex = 11
        Me.LevelNumeric.TabStop = False
        Me.LevelNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CurrentPlaceLabel
        '
        Me.CurrentPlaceLabel.Location = New System.Drawing.Point(82, 92)
        Me.CurrentPlaceLabel.Name = "CurrentPlaceLabel"
        Me.CurrentPlaceLabel.Size = New System.Drawing.Size(171, 24)
        Me.CurrentPlaceLabel.TabIndex = 10
        Me.CurrentPlaceLabel.Text = "Current Place:"
        '
        'CurrentPlaceDropDown
        '
        Me.CurrentPlaceDropDown.DataSource = Nothing
        Me.CurrentPlaceDropDown.DropDownHeight = 500
        Me.CurrentPlaceDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CurrentPlaceDropDown.FormattingEnabled = True
        Me.CurrentPlaceDropDown.IntegralHeight = False
        Me.CurrentPlaceDropDown.Location = New System.Drawing.Point(82, 120)
        Me.CurrentPlaceDropDown.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CurrentPlaceDropDown.Name = "CurrentPlaceDropDown"
        Me.CurrentPlaceDropDown.Size = New System.Drawing.Size(390, 31)
        Me.CurrentPlaceDropDown.TabIndex = 9
        Me.CurrentPlaceDropDown.TabStop = False
        '
        'LevelLabel
        '
        Me.LevelLabel.AutoSize = True
        Me.LevelLabel.Location = New System.Drawing.Point(82, 276)
        Me.LevelLabel.Name = "LevelLabel"
        Me.LevelLabel.Size = New System.Drawing.Size(52, 23)
        Me.LevelLabel.TabIndex = 2
        Me.LevelLabel.Text = "Level:"
        '
        'ExperienceLabel
        '
        Me.ExperienceLabel.AutoSize = True
        Me.ExperienceLabel.Location = New System.Drawing.Point(169, 276)
        Me.ExperienceLabel.Name = "ExperienceLabel"
        Me.ExperienceLabel.Size = New System.Drawing.Size(96, 23)
        Me.ExperienceLabel.TabIndex = 1
        Me.ExperienceLabel.Text = "Experience:"
        '
        'GamesaveTabControl
        '
        Me.GamesaveTabControl.Controls.Add(Me.HowToTabPage)
        Me.GamesaveTabControl.Controls.Add(Me.GeneralTabPage)
        Me.GamesaveTabControl.Controls.Add(Me.InventoryTabPage)
        Me.GamesaveTabControl.Controls.Add(Me.SkillTreeTabPage)
        Me.GamesaveTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GamesaveTabControl.Location = New System.Drawing.Point(0, 52)
        Me.GamesaveTabControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GamesaveTabControl.Name = "GamesaveTabControl"
        Me.GamesaveTabControl.SelectedIndex = 0
        Me.GamesaveTabControl.Size = New System.Drawing.Size(717, 463)
        Me.GamesaveTabControl.TabIndex = 1
        Me.GamesaveTabControl.TabStop = False
        '
        'HowToTabPage
        '
        Me.HowToTabPage.Controls.Add(Me.HowToLabel)
        Me.HowToTabPage.Location = New System.Drawing.Point(4, 32)
        Me.HowToTabPage.Name = "HowToTabPage"
        Me.HowToTabPage.Size = New System.Drawing.Size(709, 427)
        Me.HowToTabPage.TabIndex = 4
        Me.HowToTabPage.Text = "How To"
        Me.HowToTabPage.UseVisualStyleBackColor = True
        '
        'HowToLabel
        '
        Me.HowToLabel.Location = New System.Drawing.Point(8, 19)
        Me.HowToLabel.Name = "HowToLabel"
        Me.HowToLabel.Size = New System.Drawing.Size(693, 403)
        Me.HowToLabel.TabIndex = 0
        Me.HowToLabel.Text = "HowToLabel"
        '
        'SkillTreeTabPage
        '
        Me.SkillTreeTabPage.Controls.Add(Me.SkillTreeErgoGroupBox)
        Me.SkillTreeTabPage.Controls.Add(Me.SkillTreeBearerGroupBox)
        Me.SkillTreeTabPage.Location = New System.Drawing.Point(4, 32)
        Me.SkillTreeTabPage.Name = "SkillTreeTabPage"
        Me.SkillTreeTabPage.Size = New System.Drawing.Size(709, 427)
        Me.SkillTreeTabPage.TabIndex = 3
        Me.SkillTreeTabPage.Text = "Skill Tree"
        Me.SkillTreeTabPage.UseVisualStyleBackColor = True
        '
        'SkillTreeErgoGroupBox
        '
        Me.SkillTreeErgoGroupBox.Controls.Add(Me.SkillTreeClearErgoButton)
        Me.SkillTreeErgoGroupBox.Controls.Add(Me.SkillTreeUsedErgoLabel)
        Me.SkillTreeErgoGroupBox.Controls.Add(Me.SkillTreeUsedLabel2)
        Me.SkillTreeErgoGroupBox.Controls.Add(Me.SkillTreeErgoPointsNumeric)
        Me.SkillTreeErgoGroupBox.Controls.Add(Me.SkillTreePointsLabel2)
        Me.SkillTreeErgoGroupBox.Location = New System.Drawing.Point(332, 161)
        Me.SkillTreeErgoGroupBox.Name = "SkillTreeErgoGroupBox"
        Me.SkillTreeErgoGroupBox.Size = New System.Drawing.Size(254, 116)
        Me.SkillTreeErgoGroupBox.TabIndex = 1
        Me.SkillTreeErgoGroupBox.TabStop = False
        Me.SkillTreeErgoGroupBox.Text = "Ergo"
        '
        'SkillTreeClearErgoButton
        '
        Me.SkillTreeClearErgoButton.Location = New System.Drawing.Point(167, 67)
        Me.SkillTreeClearErgoButton.Name = "SkillTreeClearErgoButton"
        Me.SkillTreeClearErgoButton.Size = New System.Drawing.Size(81, 33)
        Me.SkillTreeClearErgoButton.TabIndex = 16
        Me.SkillTreeClearErgoButton.Text = "Clear"
        Me.SkillTreeClearErgoButton.UseVisualStyleBackColor = True
        '
        'SkillTreeUsedErgoLabel
        '
        Me.SkillTreeUsedErgoLabel.AutoSize = True
        Me.SkillTreeUsedErgoLabel.Location = New System.Drawing.Point(64, 72)
        Me.SkillTreeUsedErgoLabel.Name = "SkillTreeUsedErgoLabel"
        Me.SkillTreeUsedErgoLabel.Size = New System.Drawing.Size(19, 23)
        Me.SkillTreeUsedErgoLabel.TabIndex = 16
        Me.SkillTreeUsedErgoLabel.Text = "0"
        '
        'SkillTreeUsedLabel2
        '
        Me.SkillTreeUsedLabel2.AutoSize = True
        Me.SkillTreeUsedLabel2.Location = New System.Drawing.Point(6, 72)
        Me.SkillTreeUsedLabel2.Name = "SkillTreeUsedLabel2"
        Me.SkillTreeUsedLabel2.Size = New System.Drawing.Size(52, 23)
        Me.SkillTreeUsedLabel2.TabIndex = 15
        Me.SkillTreeUsedLabel2.Text = "Used:"
        '
        'SkillTreeErgoPointsNumeric
        '
        Me.SkillTreeErgoPointsNumeric.Location = New System.Drawing.Point(167, 30)
        Me.SkillTreeErgoPointsNumeric.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SkillTreeErgoPointsNumeric.Name = "SkillTreeErgoPointsNumeric"
        Me.SkillTreeErgoPointsNumeric.Size = New System.Drawing.Size(81, 30)
        Me.SkillTreeErgoPointsNumeric.TabIndex = 15
        Me.SkillTreeErgoPointsNumeric.TabStop = False
        Me.SkillTreeErgoPointsNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SkillTreePointsLabel2
        '
        Me.SkillTreePointsLabel2.AutoSize = True
        Me.SkillTreePointsLabel2.Location = New System.Drawing.Point(6, 32)
        Me.SkillTreePointsLabel2.Name = "SkillTreePointsLabel2"
        Me.SkillTreePointsLabel2.Size = New System.Drawing.Size(94, 23)
        Me.SkillTreePointsLabel2.TabIndex = 14
        Me.SkillTreePointsLabel2.Text = "Skill Points:"
        '
        'SkillTreeBearerGroupBox
        '
        Me.SkillTreeBearerGroupBox.Controls.Add(Me.SkillTreeClearBearerButton)
        Me.SkillTreeBearerGroupBox.Controls.Add(Me.SkillTreeUsedBearerLabel)
        Me.SkillTreeBearerGroupBox.Controls.Add(Me.SkillTreeUsedLabel1)
        Me.SkillTreeBearerGroupBox.Controls.Add(Me.SkillTreeBearerPointsNumeric)
        Me.SkillTreeBearerGroupBox.Controls.Add(Me.SkillTreePointsLabel1)
        Me.SkillTreeBearerGroupBox.Location = New System.Drawing.Point(74, 161)
        Me.SkillTreeBearerGroupBox.Name = "SkillTreeBearerGroupBox"
        Me.SkillTreeBearerGroupBox.Size = New System.Drawing.Size(252, 116)
        Me.SkillTreeBearerGroupBox.TabIndex = 0
        Me.SkillTreeBearerGroupBox.TabStop = False
        Me.SkillTreeBearerGroupBox.Text = "Bearer"
        '
        'SkillTreeClearBearerButton
        '
        Me.SkillTreeClearBearerButton.Location = New System.Drawing.Point(153, 67)
        Me.SkillTreeClearBearerButton.Name = "SkillTreeClearBearerButton"
        Me.SkillTreeClearBearerButton.Size = New System.Drawing.Size(93, 33)
        Me.SkillTreeClearBearerButton.TabIndex = 2
        Me.SkillTreeClearBearerButton.Text = "Clear"
        Me.SkillTreeClearBearerButton.UseVisualStyleBackColor = True
        '
        'SkillTreeUsedBearerLabel
        '
        Me.SkillTreeUsedBearerLabel.AutoSize = True
        Me.SkillTreeUsedBearerLabel.Location = New System.Drawing.Point(64, 72)
        Me.SkillTreeUsedBearerLabel.Name = "SkillTreeUsedBearerLabel"
        Me.SkillTreeUsedBearerLabel.Size = New System.Drawing.Size(19, 23)
        Me.SkillTreeUsedBearerLabel.TabIndex = 15
        Me.SkillTreeUsedBearerLabel.Text = "0"
        '
        'SkillTreeUsedLabel1
        '
        Me.SkillTreeUsedLabel1.AutoSize = True
        Me.SkillTreeUsedLabel1.Location = New System.Drawing.Point(6, 72)
        Me.SkillTreeUsedLabel1.Name = "SkillTreeUsedLabel1"
        Me.SkillTreeUsedLabel1.Size = New System.Drawing.Size(52, 23)
        Me.SkillTreeUsedLabel1.TabIndex = 14
        Me.SkillTreeUsedLabel1.Text = "Used:"
        '
        'SkillTreeBearerPointsNumeric
        '
        Me.SkillTreeBearerPointsNumeric.Location = New System.Drawing.Point(153, 30)
        Me.SkillTreeBearerPointsNumeric.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SkillTreeBearerPointsNumeric.Name = "SkillTreeBearerPointsNumeric"
        Me.SkillTreeBearerPointsNumeric.Size = New System.Drawing.Size(93, 30)
        Me.SkillTreeBearerPointsNumeric.TabIndex = 13
        Me.SkillTreeBearerPointsNumeric.TabStop = False
        Me.SkillTreeBearerPointsNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SkillTreePointsLabel1
        '
        Me.SkillTreePointsLabel1.AutoSize = True
        Me.SkillTreePointsLabel1.Location = New System.Drawing.Point(6, 32)
        Me.SkillTreePointsLabel1.Name = "SkillTreePointsLabel1"
        Me.SkillTreePointsLabel1.Size = New System.Drawing.Size(94, 23)
        Me.SkillTreePointsLabel1.TabIndex = 12
        Me.SkillTreePointsLabel1.Text = "Skill Points:"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(717, 515)
        Me.Controls.Add(Me.GamesaveTabControl)
        Me.Controls.Add(Me.GamesaveMenuStrip)
        Me.Controls.Add(Me.HeadMenuStrip)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.HeadMenuStrip
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Anima - Gate of Memories - Registry Editor"
        Me.HeadMenuStrip.ResumeLayout(False)
        Me.HeadMenuStrip.PerformLayout()
        Me.GamesaveMenuStrip.ResumeLayout(False)
        Me.GamesaveMenuStrip.PerformLayout()
        Me.InventoryTabPage.ResumeLayout(False)
        Me.InventoryTabPage.PerformLayout()
        CType(Me.InventoryItemCountNumeric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GeneralTabPage.ResumeLayout(False)
        Me.GeneralTabPage.PerformLayout()
        CType(Me.PlayTimeNumeric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CoinsNumeric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExperienceNumeric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LevelNumeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GamesaveTabControl.ResumeLayout(False)
        Me.HowToTabPage.ResumeLayout(False)
        Me.SkillTreeTabPage.ResumeLayout(False)
        Me.SkillTreeErgoGroupBox.ResumeLayout(False)
        Me.SkillTreeErgoGroupBox.PerformLayout()
        CType(Me.SkillTreeErgoPointsNumeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SkillTreeBearerGroupBox.ResumeLayout(False)
        Me.SkillTreeBearerGroupBox.PerformLayout()
        CType(Me.SkillTreeBearerPointsNumeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HeadMenuStrip As MenuStrip
    Friend WithEvents HeadMenuButton As ToolStripMenuItem
    Friend WithEvents BackupButton As ToolStripMenuItem
    Friend WithEvents ReloadRegistryButton As ToolStripMenuItem
    Friend WithEvents GamesaveMenuStrip As MenuStrip
    Friend WithEvents DeleteButton As ToolStripMenuItem
    Friend WithEvents GamesaveTitleButton As ToolStripMenuItem
    Friend WithEvents SaveButton As ToolStripMenuItem
    Friend WithEvents SaveAsButton As ToolStripMenuItem
    Friend WithEvents HeadDataButton As ToolStripMenuItem
    Friend WithEvents SaveKeyAliasesButton As ToolStripMenuItem
    Friend WithEvents HeadHelpButton As ToolStripMenuItem
    Friend WithEvents HeadAboutButton As ToolStripMenuItem
    Friend WithEvents ItemIdColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents InventoryTabPage As TabPage
    Friend WithEvents ItemEffectsLabel As Label
    Friend WithEvents ItemDescriptionLabel As Label
    Friend WithEvents ItemNameLabel As Label
    Friend WithEvents InventoryItemCountLabel As Label
    Friend WithEvents InventoryItemCountNumeric As NumericUpDown
    Friend WithEvents InventoryListView As BrightIdeasSoftware.ObjectListView
    Friend WithEvents ItemNameColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ItemTypeColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ItemCountColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents GeneralTabPage As TabPage
    Friend WithEvents PlayTimeNumeric As NumericUpDown
    Friend WithEvents PlayTimeLabel As Label
    Friend WithEvents DificultyLabel As Label
    Friend WithEvents DificultyComboBox As ComboBox
    Friend WithEvents CoinsNumeric As NumericUpDown
    Friend WithEvents CoinsLabel As Label
    Friend WithEvents DateStringTextBox As TextBox
    Friend WithEvents DateStringLabel As Label
    Friend WithEvents ExperienceNumeric As NumericUpDown
    Friend WithEvents LevelNumeric As NumericUpDown
    Friend WithEvents CurrentPlaceLabel As Label
    Friend WithEvents CurrentPlaceDropDown As GroupedComboBox
    Friend WithEvents LevelLabel As Label
    Friend WithEvents ExperienceLabel As Label
    Friend WithEvents GamesaveTabControl As TabControl
    Friend WithEvents SkillTreeTabPage As TabPage
    Friend WithEvents SkillTreeErgoGroupBox As GroupBox
    Friend WithEvents SkillTreeErgoPointsNumeric As NumericUpDown
    Friend WithEvents SkillTreePointsLabel2 As Label
    Friend WithEvents SkillTreeBearerGroupBox As GroupBox
    Friend WithEvents SkillTreeBearerPointsNumeric As NumericUpDown
    Friend WithEvents SkillTreePointsLabel1 As Label
    Friend WithEvents ReloadGamesaveButton As ToolStripMenuItem
    Friend WithEvents SkillTreeUsedLabel2 As Label
    Friend WithEvents SkillTreeUsedLabel1 As Label
    Friend WithEvents SkillTreeUsedErgoLabel As Label
    Friend WithEvents SkillTreeUsedBearerLabel As Label
    Friend WithEvents SkillTreeClearErgoButton As Button
    Friend WithEvents SkillTreeClearBearerButton As Button
    Friend WithEvents HowToTabPage As TabPage
    Friend WithEvents HowToLabel As Label
End Class
