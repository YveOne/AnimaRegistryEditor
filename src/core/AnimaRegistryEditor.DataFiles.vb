
Partial Class AnimaRegistryEditor

    Private Class DataFiles

        Private Delegate Sub DataFileDelegate(fPath As String)
        Private Class DataFile
            Public FilePath As String
            Public FileDelegate As DataFileDelegate
            Public Sub New(FilePath As String, FileDelegate As DataFileDelegate)
                Me.FilePath = FilePath
                Me.FileDelegate = FileDelegate
            End Sub
        End Class
        Private Shared ReadOnly DataFilesDelegates As New List(Of DataFile) From {
            New DataFile("constants.txt", AddressOf LoadConstantsFile),
            New DataFile("strings.txt", AddressOf LoadStringsFile),
            New DataFile("keyaliases.txt", AddressOf LoadKeyAliasesFile),
            New DataFile("skilltreenodenames.txt", AddressOf LoadSkillTreeNodeNamesFile),
            New DataFile("skilltreeNodelevels.txt", AddressOf LoadSkillTreeNodeLevelsFile),
            New DataFile("itemnames.txt", AddressOf LoadItemNamesFile),
            New DataFile("itemtypes.txt", AddressOf LoadItemTypesFile),
            New DataFile("itemeffects.txt", AddressOf LoadItemEffectsFile),
            New DataFile("locationplaces.txt", AddressOf LoadLocationPlacesFile),
            New DataFile("effectnames.txt", AddressOf LoadEffectNamesFile)
        }
        'New DataFile("data/skilltreeNodeskills.txt", AddressOf LoadSkillTreeNodeSkillsFile),
        'New DataFile("data/skillnames.txt", AddressOf LoadSkillNamesFile),

        Public Shared Sub LoadFiles(DataFilePath As String)
            For Each iFile As DataFile In DataFilesDelegates
                Dim fpath As String = DataFilePath & "/" & iFile.FilePath
                If (System.IO.File.Exists(fpath)) Then
                    iFile.FileDelegate(fpath)
                Else
                    MessageBox.Show(fpath & " missing !!!")
                End If
            Next
        End Sub

#Region "subs"

        Private Shared Sub LoadConstantsFile(fPath As String)
            Dim lineSplit As String()
            For Each line As String In ReadFileLines(fPath)
                lineSplit = line.Split(CChar("="))
                If (lineSplit.Length = 2) Then
                    Select Case lineSplit(0)

                        Case "RegistryPath" : RegistryPath = lineSplit(1)

                        Case "SlotDateFormatPattern" : SlotDateFormatPattern = lineSplit(1)
                        Case "SlotTextFormatPattern" : SlotTextFormatPattern = lineSplit(1)
                        Case "EmptySlotFormatPattern" : EmptySlotFormatPattern = lineSplit(1)
                        Case "GamesaveChangedIndicator" : GamesaveChangedIndicator = lineSplit(1)

                        Case "MaxLevel" : MaxLevel = CInt(lineSplit(1))
                        Case "MaxXP" : MaxXP = CInt(lineSplit(1))
                        Case "MaxCoins" : MaxCoins = CInt(lineSplit(1))
                        Case "MaxPlayTime" : MaxPlayTime = CInt(lineSplit(1))

                        Case "InventorySize" : InventorySize = CInt(lineSplit(1))
                        Case "SkillTreeSize" : SkillTreeSize = CInt(lineSplit(1))
                        Case "SkillTreeMaxPointsBearer" : SkillTreeMaxPointsBearer = CInt(lineSplit(1))
                        Case "SkillTreeMaxPointsErgo" : SkillTreeMaxPointsErgo = CInt(lineSplit(1))

                        Case "LevelExpIncreaseStep" : LevelExpIncreaseStep = CInt(lineSplit(1))
                        Case "LevelExpIncreaseStart" : LevelExpIncreaseStart = CInt(lineSplit(1))
                        Case "SavegameSlots" : SavegameSlots = CInt(lineSplit(1))
                        Case "SavegameMaxLength" : SavegameMaxLength = CInt(lineSplit(1))

                    End Select
                End If
            Next
            Locations.Clear()
            Inventory.Clear()
            Skills.ClearTreeNodes()
            'Skills.ClearSkillNames()
            Strings.Clear()
            KeyAliases.Clear()
        End Sub

        Private Shared Sub LoadStringsFile(fPath As String)
            Dim lineSplit As String()
            For Each line As String In ReadFileLines(fPath)
                lineSplit = line.Split(CChar("="))
                If (lineSplit.Length = 2) Then
                    Strings(lineSplit(0)) = lineSplit(1)
                End If
            Next
        End Sub

        Private Shared Sub LoadKeyAliasesFile(fPath As String)
            Dim lineSplit As String()
            For Each line As String In ReadFileLines(fPath)
                lineSplit = line.Split(CChar("="))
                If (lineSplit.Length = 2) Then
                    KeyAliases.Add(lineSplit(0), lineSplit(1))
                End If
            Next
        End Sub

        Private Shared Sub LoadSkillTreeNodeNamesFile(fPath As String)
            Dim lineSplit As String()
            For Each line As String In ReadFileLines(fPath)
                lineSplit = line.Split(CChar("="))
                If (lineSplit.Length = 2) Then
                    Skills.TreeNodes(CInt(lineSplit(0))).Name = lineSplit(1)
                End If
            Next
        End Sub

        Private Shared Sub LoadSkillTreeNodeLevelsFile(fPath As String)
            Dim lineSplit As String()
            For Each line As String In ReadFileLines(fPath)
                lineSplit = line.Split(CChar("="))
                If (lineSplit.Length = 2) Then
                    Skills.TreeNodes(CInt(lineSplit(0))).MaxLevel = CInt(lineSplit(1))
                End If
            Next
        End Sub

        'Private Shared Sub LoadSkillTreeNodeSkillsFile(fPath As String)
        '    Dim lineSplit As String()
        '    For Each line As String In ReadFileLines(fPath)
        '        lineSplit = line.Split("=")
        '        If (lineSplit.Length = 2) Then
        '            Dim sSplit As String() = lineSplit(1).Split(";")
        '            Dim tNode As Skills.TreeNode = Skills.TreeNodes(CInt(lineSplit(0)))
        '            Dim skill As New Skills.Skill(tNode, sSplit(0), sSplit(1), sSplit(2))
        '            Select Case skill.Target
        '                Case "bearer" : Skills.BearerSkills.Add(skill)
        '                Case "ergo" : Skills.ErgoSkills.Add(skill)
        '            End Select
        '            tNode.ActivateSkill = skill
        '        End If
        '    Next
        'End Sub

        'Private Shared Sub LoadSkillNamesFile(fPath As String)
        '    Dim lineSplit As String()
        '    For Each line As String In ReadFileLines(fPath)
        '        lineSplit = line.Split("=")
        '        Skills.SkillNames.Add(lineSplit(0), lineSplit(1))
        '    Next
        'End Sub

        Private Shared Sub LoadItemNamesFile(fPath As String)
            Dim lineSplit As String()
            For Each line As String In ReadFileLines(fPath)
                lineSplit = line.Split(CChar("="))
                If (lineSplit.Length = 2) Then
                    Dim nSplit As String() = lineSplit(1).Split(CChar(";"))
                    Inventory.Items(CInt(lineSplit(0))).Name = nSplit(0)
                    Inventory.Items(CInt(lineSplit(0))).Description = nSplit(1)
                End If
            Next
        End Sub

        Private Shared Sub LoadItemTypesFile(fPath As String)
            Dim lineSplit As String()
            For Each line As String In ReadFileLines(fPath)
                lineSplit = line.Split(CChar("="))
                If (lineSplit.Length = 2) Then
                    Dim tSplit As String() = lineSplit(1).Split(CChar(";"))
                    If (tSplit.Count = 2) Then
                        Dim II As Inventory.Item = Inventory.Items(CInt(lineSplit(0)))
                        II.TypeChar = CChar(tSplit(0).ToLower())
                        II.MaxCount = CInt(tSplit(1))
                    End If
                End If
            Next
        End Sub

        Private Shared Sub LoadItemEffectsFile(fPath As String)
            For Each line As String In ReadFileLines(fPath)
                Dim equalSplit As String() = line.Split(CChar("="))
                Dim II As Inventory.Item = Inventory.Items(CInt(equalSplit(0)))
                Dim effectsSplit As String() = equalSplit(1).Split(CChar(";"))
                For Each effStatsSplit As String In effectsSplit(0).Split(CChar(","))
                    Dim effectPair As String() = effStatsSplit.Split(CChar(":"))
                    II.StatEffects.Add(effectPair(0), CInt(effectPair(1)))
                Next
                II.SpecialEffect = effectsSplit(1)
            Next
        End Sub

        Private Shared Sub LoadLocationPlacesFile(fPath As String)
            Dim lineSplit As String()
            Dim rightSplit As String()
            Dim locationFullKey As String
            Dim locationAreaName As String
            Dim locationPlaceName As String
            Dim locationDescription As String
            For Each line As String In ReadFileLines(fPath)
                lineSplit = line.Split(CChar("="))
                If (lineSplit.Length = 2) Then
                    locationFullKey = lineSplit(0).ToLower().Trim()
                    rightSplit = lineSplit(1).Split(CChar(";"))
                    If (rightSplit.Length >= 2) Then
                        locationAreaName = rightSplit(0).Trim()
                        locationPlaceName = rightSplit(1).Trim()
                        locationDescription = ""
                        If (rightSplit.Length >= 3) Then
                            locationDescription = rightSplit(2)
                        End If
                        Locations.AddPlace(locationFullKey, locationAreaName, locationPlaceName, locationDescription)
                    End If
                End If
            Next
        End Sub

        Private Shared Sub LoadEffectNamesFile(fPath As String)
            Dim lineSplit As String()
            For Each line As String In ReadFileLines(fPath)
                lineSplit = line.Split(CChar("="))
                If (lineSplit.Length = 2) Then
                    Inventory.EffectNames.Add(lineSplit(0), lineSplit(1))
                End If
            Next
        End Sub

#End Region

    End Class

End Class
