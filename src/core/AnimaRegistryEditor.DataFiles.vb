
Partial Class AnimaRegistryEditor

    Private Class DataFiles

        Private Shared lineSplitChar As Char = CChar("=")
        Private Shared valueSplitChar As Char = CChar(";")

        Private Delegate Function ReadDataFileLine(i As Integer, key As String, value As String) As Boolean
        Private Shared Sub ReadDataFileLines(fPath As String, func As ReadDataFileLine)
            Dim i As Integer = 0
            Dim KeyValuePair As String()
            Dim Key As String
            Dim Value As String
            For Each line As String In System.IO.File.ReadAllLines(fPath)
                line = line.Trim()
                If line.StartsWith("//") Then
                    line = ""
                End If
                If (line.Length > 0) Then
                    KeyValuePair = line.Split(lineSplitChar)
                    Key = KeyValuePair(0).Trim()
                    Value = If(KeyValuePair.Length >= 2, KeyValuePair(1).Trim(), "")
                    If Not func(i, Key, Value) Then
                        MessageBox.Show("Error in """ & fPath & """ (" & i & ")")
                    End If
                End If
                i = i + 1
            Next
        End Sub

        Private Shared ReadOnly DataFilesExtension As String = ".txt"
        Private Shared ReadOnly DataFilesList As New List(Of String) From {
            "constants",
            "strings",
            "keyaliases",
            "skilltreenodenames",
            "skilltreeNodelevels",
            "itemnames",
            "itemtypes",
            "itemeffects",
            "locationplaces",
            "effectnames"
        }

        Private Delegate Sub DataFileDelegate(fpath As String)
        Private Shared ReadOnly DataFileDelegates As New SortedList(Of String, DataFileDelegate) From {
            {"constants", AddressOf LoadConstantsFile},
            {"strings", AddressOf LoadStringsFile},
            {"keyaliases", AddressOf LoadKeyAliasesFile},
            {"skilltreenodenames", AddressOf LoadSkillTreeNodeNamesFile},
            {"skilltreeNodelevels", AddressOf LoadSkillTreeNodeLevelsFile},
            {"itemnames", AddressOf LoadItemNamesFile},
            {"itemtypes", AddressOf LoadItemTypesFile},
            {"itemeffects", AddressOf LoadItemEffectsFile},
            {"locationplaces", AddressOf LoadLocationPlacesFile},
            {"effectnames", AddressOf LoadEffectNamesFile}
        }

        Public Shared Sub LoadFiles(DataFilePath As String)
            For Each DataFileName As String In DataFilesList
                Dim fpath As String = DataFilePath & "/" & DataFileName & DataFilesExtension
                If (System.IO.File.Exists(fpath)) Then
                    DataFileDelegates(DataFileName)(fpath)
                Else
                    MessageBox.Show("Data file """ & DataFileName & """ missing")
                End If
            Next
        End Sub

#Region "subs"

        Private Shared Sub LoadConstantsFile(fpath As String)
            Locations.Clear()
            Inventory.Clear()
            Skills.ClearTreeNodes()
            'Skills.ClearSkillNames()
            Strings.Clear()
            KeyAliases.Clear()
            ReadDataFileLines(fpath, Function(i As Integer, key As String, value As String)
                                         If (key <> "" And value <> "") Then
                                             Select Case key

                                                 Case "RegistryPath" : RegistryPath = value

                                                 Case "SlotDateFormatPattern" : SlotDateFormatPattern = value
                                                 Case "SlotTextFormatPattern" : SlotTextFormatPattern = value
                                                 Case "EmptySlotFormatPattern" : EmptySlotFormatPattern = value
                                                 Case "GamesaveChangedIndicator" : GamesaveChangedIndicator = value

                                                 Case "MaxLevel" : MaxLevel = CIntSave(value)
                                                 Case "MaxXP" : MaxXP = CIntSave(value)
                                                 Case "MaxCoins" : MaxCoins = CIntSave(value)
                                                 Case "MaxPlayTime" : MaxPlayTime = CIntSave(value)

                                                 Case "InventorySize" : InventorySize = CIntSave(value)
                                                 Case "SkillTreeSize" : SkillTreeSize = CIntSave(value)
                                                 Case "SkillTreeMaxPointsBearer" : SkillTreeMaxPointsBearer = CIntSave(value)
                                                 Case "SkillTreeMaxPointsErgo" : SkillTreeMaxPointsErgo = CIntSave(value)

                                                 Case "LevelExpIncreaseStep" : LevelExpIncreaseStep = CIntSave(value)
                                                 Case "LevelExpIncreaseStart" : LevelExpIncreaseStart = CIntSave(value)
                                                 Case "SavegameSlots" : SavegameSlots = CIntSave(value)
                                                 Case "SavegameMaxLength" : SavegameMaxLength = CIntSave(value)

                                                 Case Else : Return False
                                             End Select
                                             Return True
                                         End If
                                         Return False
                                     End Function)
        End Sub

        Private Shared Sub LoadStringsFile(fpath As String)
            ReadDataFileLines(fpath, Function(i As Integer, key As String, value As String)
                                         If (key <> "") Then
                                             Strings(key) = value
                                             Return True
                                         End If
                                         Return False
                                     End Function)
        End Sub

        Private Shared Sub LoadKeyAliasesFile(fpath As String)
            ReadDataFileLines(fpath, Function(i As Integer, key As String, value As String)
                                         If (key <> "" And value <> "") Then
                                             KeyAliases.Add(key, value)
                                             Return True
                                         End If
                                         Return False
                                     End Function)
        End Sub

        Private Shared Sub LoadSkillTreeNodeNamesFile(fpath As String)
            ReadDataFileLines(fpath, Function(i As Integer, key As String, value As String)
                                         If (key <> "" And value <> "") Then
                                             Skills.TreeNodes(CIntSave(key)).Name = value
                                             Return True
                                         End If
                                         Return False
                                     End Function)
        End Sub

        Private Shared Sub LoadSkillTreeNodeLevelsFile(fpath As String)
            ReadDataFileLines(fpath, Function(i As Integer, key As String, value As String)
                                         If (key <> "" And value <> "") Then
                                             Skills.TreeNodes(CIntSave(key)).MaxLevel = CIntSave(value)
                                             Return True
                                         End If
                                         Return False
                                     End Function)
        End Sub

        Private Shared Sub LoadItemNamesFile(fpath As String)
            ReadDataFileLines(fpath, Function(i As Integer, key As String, value As String)
                                         If (key <> "" And value <> "") Then
                                             Dim nSplit As String() = value.Split(valueSplitChar)
                                             Inventory.Items(CIntSave(key)).Name = nSplit(0)
                                             Inventory.Items(CIntSave(key)).Description = nSplit(1)
                                             Return True
                                         End If
                                         Return False
                                     End Function)
        End Sub

        Private Shared Sub LoadItemTypesFile(fpath As String)
            ReadDataFileLines(fpath, Function(i As Integer, key As String, value As String)
                                         If (key <> "" And value <> "") Then
                                             Dim tSplit As String() = value.Split(valueSplitChar)
                                             If (tSplit.Count = 2) Then
                                                 Dim II As Inventory.Item = Inventory.Items(CIntSave(key))
                                                 II.TypeChar = CChar(tSplit(0).ToLower())
                                                 II.MaxCount = CInt(tSplit(1))
                                                 Return True
                                             End If
                                         End If
                                         Return False
                                     End Function)
        End Sub

        Private Shared Sub LoadItemEffectsFile(fpath As String)
            Dim effStatSplitChar As Char = CChar(",")
            Dim effPairSplitChar As Char = CChar(":")
            ReadDataFileLines(fpath, Function(i As Integer, key As String, value As String)
                                         If (key <> "" And value <> "") Then
                                             Dim II As Inventory.Item = Inventory.Items(CIntSave(key))
                                             Dim effectsSplit As String() = value.Split(valueSplitChar)
                                             For Each effStatsSplit As String In effectsSplit(0).Split(effStatSplitChar)
                                                 Dim effectPair As String() = effStatsSplit.Split(effPairSplitChar)
                                                 II.StatEffects.Add(effectPair(0), CIntSave(effectPair(1)))
                                             Next
                                             II.SpecialEffect = effectsSplit(1)
                                             Return True
                                         End If
                                         Return False
                                     End Function)
        End Sub

        Private Shared Sub LoadLocationPlacesFile(fpath As String)
            ReadDataFileLines(fpath, Function(i As Integer, key As String, value As String)
                                         If (key <> "" And value <> "") Then
                                             Dim locationFullKey As String = key
                                             Dim rightSplit As String() = value.Split(valueSplitChar)
                                             If (rightSplit.Length >= 2) Then
                                                 Dim locationAreaName As String = rightSplit(0).Trim()
                                                 Dim locationPlaceName As String = rightSplit(1).Trim()
                                                 Dim locationDescription As String = If(rightSplit.Length >= 3, rightSplit(2), "")
                                                 Locations.AddPlace(locationFullKey, locationAreaName, locationPlaceName, locationDescription)
                                                 Return True
                                             End If
                                         End If
                                         Return False
                                     End Function)
        End Sub

        Private Shared Sub LoadEffectNamesFile(fpath As String)
            ReadDataFileLines(fpath, Function(i As Integer, key As String, value As String)
                                         If (key <> "" And value <> "") Then
                                             Inventory.EffectNames.Add(key, value)
                                             Return True
                                         End If
                                         Return False
                                     End Function)
        End Sub

        'Private Shared Sub LoadSkillTreeNodeSkillsFile(lines As String())
        '    Dim lineSplit As String()
        '    For Each line As String In lines
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

        'Private Shared Sub LoadSkillNamesFile(lines As String())
        '    Dim lineSplit As String()
        '    For Each line As String In lines
        '        lineSplit = line.Split("=")
        '        Skills.SkillNames.Add(lineSplit(0), lineSplit(1))
        '    Next
        'End Sub

#End Region

    End Class

End Class
