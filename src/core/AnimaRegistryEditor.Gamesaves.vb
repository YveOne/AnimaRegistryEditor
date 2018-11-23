
Imports Microsoft.Win32

Partial Class AnimaRegistryEditor

    Public Class Gamesaves

        Class Gamesave

            Private _levelXP As Integer = 0
            Private _levelBearerSP As Integer = 0
            Private _levelErgoSP As Integer = 0
            Private _coins As Integer = 0
            Private _sphereTable As Byte()
            Private _inventory As New SortedList(Of Integer, Integer)
            Private _currentPlaceArea As String = ""
            Private _currentPlacePoint As String = ""
            Private _currentPlayTime As Integer = 0
            Private _dificultyLevel As Integer = 0
            Private _skillsBearer As String()
            Private _skillsErgo As String()
            Private _dateString As String = ""
            Private _gearSlots As New List(Of Integer)
            Private _playerAttr As New List(Of Integer)
            Private _switchs As New List(Of Integer)

            Private _Slot As Integer = 0
            Private _valuesChanged As Boolean = False
            Private RegHandler As RegistryHandler
            Private _LoadedFromRegistry As Boolean = False

            Private Delegate Sub LoadDelegate(val As Object)
            Private LoadDelegates As New SortedList(Of String, LoadDelegate) From {
                {"level", AddressOf LoadLevel},
                {"coins", AddressOf LoadCoins},
                {"sphereTable", AddressOf LoadSphereTable},
                {"inventory", AddressOf LoadInventory},
                {"currentPlace", AddressOf LoadCurrentPlace},
                {"dificultyLevel", AddressOf LoadDificultyLevel},
                {"skills", AddressOf LoadSkills},
                {"dateString", AddressOf LoadDateString},
                {"gear", AddressOf LoadGear},
                {"playerAttr", AddressOf LoadPlayerAttr},
                {"switchs", AddressOf LoadSwitchs}
            }

            Private Delegate Sub SaveDelegate(key As String)
            Private SaveDelegates As New SortedList(Of String, SaveDelegate) From {
                {"level", AddressOf SaveLevel},
                {"coins", AddressOf saveCoins},
                {"sphereTable", AddressOf SaveSphereTable},
                {"inventory", AddressOf SaveInventory},
                {"currentPlace", AddressOf SaveCurrentPlace},
                {"dificultyLevel", AddressOf saveDificultyLevel},
                {"skills", AddressOf SaveSkills},
                {"dateString", AddressOf SaveDateString},
                {"gear", AddressOf SaveGear},
                {"playerAttr", AddressOf SavePlayerAttr},
                {"switchs", AddressOf SaveSwitchs}
            }

            Public Sub New(Slot As Integer, RegHandler As RegistryHandler)
                _Slot = Slot
                Me.RegHandler = RegHandler
            End Sub


#Region "Load Registry"

            Public Sub LoadFromCustom(Values As SortedList(Of String, Object))
                For Each k As String In LoadDelegates.Keys
                    LoadDelegates(k)(Values(k))
                Next
                _LoadedFromRegistry = False
                _valuesChanged = True
            End Sub

            Public Function LoadFromRegistry() As Boolean
                Dim vals As New SortedList(Of String, Object)
                For Each k As String In Me.LoadDelegates.Keys
                    Dim val As Object = RegHandler.GetRegVal(AnimaRegistryEditor.GetKeyAlias(k & _Slot))
                    If (val IsNot Nothing) Then
                        vals.Add(k, val)
                    Else
                        Return False
                    End If
                Next
                For Each k As String In Me.LoadDelegates.Keys
                    LoadDelegates(k)(vals(k))
                Next
                _LoadedFromRegistry = True
                _valuesChanged = False
                Return True
            End Function

            Public Sub LoadLevel(obj As Object)
                Dim val As Byte() = DropLastByte(CType(obj, Byte()))
                Dim s As String() = BytesToString(val).Split(CChar(";"))
                _levelXP = CInt(s(0))
                _levelBearerSP = CInt(s(1))
                _levelErgoSP = CInt(s(2))
            End Sub

            Public Sub LoadCoins(obj As Object)
                _coins = CInt(obj)
            End Sub

            Public Sub LoadSphereTable(obj As Object)
                Dim val As Byte() = DropLastByte(CType(obj, Byte()))
                _sphereTable = val
            End Sub

            Public Sub LoadInventory(obj As Object)
                Dim val As Byte() = DropLastByte(CType(obj, Byte()))
                Dim spl As String()
                For Each itemp As String In BytesToString(val).Split(CChar(";"))
                    spl = itemp.Split(CChar("#"))
                    If spl.Count = 2 Then
                        _inventory.Add(CInt(spl(0)), CInt(spl(1)))
                    End If
                Next
            End Sub

            Public Sub LoadCurrentPlace(obj As Object)
                Dim val As Byte() = DropLastByte(CType(obj, Byte()))
                Dim s As String() = BytesToString(val).Split(CChar(";"))
                _currentPlaceArea = s(0).ToLower()
                _currentPlacePoint = s(1).ToLower()
                _currentPlayTime = CInt(If(s(2) = "", "0", s(2)))
            End Sub

            Public Sub LoadDificultyLevel(obj As Object)
                _dificultyLevel = CInt(obj)
            End Sub

            Public Sub LoadSkills(obj As Object)
                Dim val As Byte() = DropLastByte(CType(obj, Byte()))
                Dim skillsStrings = BytesToString(val).Split(CChar(":"))
                _skillsBearer = skillsStrings(0).Split(CChar(","))
                _skillsErgo = skillsStrings(1).Split(CChar(","))
            End Sub

            Public Sub LoadDateString(obj As Object)
                Dim val As Byte() = DropLastByte(CType(obj, Byte()))
                _dateString = BytesToString(val)
            End Sub

            Public Sub LoadGear(obj As Object)
                Dim val As Byte() = DropLastByte(CType(obj, Byte()))
                _gearSlots.Clear()
                For Each id As String In BytesToString(val).Split(CChar(","))
                    _gearSlots.Add(CInt(id))
                Next
            End Sub

            Public Sub LoadPlayerAttr(obj As Object)
                Dim val As Byte() = DropLastByte(CType(obj, Byte()))
                _playerAttr.Clear()
                For Each id As String In BytesToString(val).Split(CChar(";"))
                    _playerAttr.Add(CInt(id))
                Next
            End Sub

            Public Sub LoadSwitchs(obj As Object)
                Dim val As Byte() = DropLastByte(CType(obj, Byte()))
                _switchs.Clear()
                For Each id As String In BytesToString(val).ToCharArray()
                    _switchs.Add(CInt(id))
                Next
            End Sub

#End Region

#Region "Save Registry"

            Public Sub SaveToRegistry(slot As Integer)
                For Each k As String In Me.LoadDelegates.Keys
                    SaveDelegates(k)(AnimaRegistryEditor.GetKeyAlias(k & slot))
                Next
                If (slot <> _Slot) Then
                    _Slot = slot
                    LoadSlot(_Slot)
                End If
                _valuesChanged = False
            End Sub

            Public Sub SaveToRegistry()
                SaveToRegistry(_Slot)
            End Sub

            Public Sub SaveLevel(key As String)
                Dim val As Byte() = AddLastByte(StringToBytes(Join({_levelXP, _levelBearerSP, _levelErgoSP}, ";")))
                RegHandler.SetRegVal(key, val, RegistryValueKind.Binary)
            End Sub

            Public Sub saveCoins(key As String)
                RegHandler.SetRegVal(key, _coins, RegistryValueKind.DWord)
            End Sub

            Public Sub SaveSphereTable(key As String)
                RegHandler.SetRegVal(key, AddLastByte(_sphereTable), RegistryValueKind.Binary)
            End Sub

            Public Sub SaveInventory(key As String)
                Dim items As New List(Of String)
                For Each id As Integer In _inventory.Keys
                    items.Add(id & "#" & _inventory(id))
                Next
                RegHandler.SetRegVal(key, AddLastByte(StringToBytes(Join(items.ToArray(), ";"))), RegistryValueKind.Binary)
            End Sub

            Public Sub SaveCurrentPlace(key As String)
                Dim val As Byte() = AddLastByte(StringToBytes(Join({_currentPlaceArea, _currentPlacePoint, _currentPlayTime}, ";")))
                RegHandler.SetRegVal(key, val, RegistryValueKind.Binary)
            End Sub

            Public Sub saveDificultyLevel(key As String)
                RegHandler.SetRegVal(key, _dificultyLevel, RegistryValueKind.DWord)
            End Sub

            Public Sub SaveSkills(key As String)
                Dim strSkills = Join({Join(_skillsBearer, ","), Join(_skillsErgo, ",")}, ":")
                RegHandler.SetRegVal(key, AddLastByte(StringToBytes(strSkills)), RegistryValueKind.Binary)
            End Sub

            Public Sub SaveDateString(key As String)
                RegHandler.SetRegVal(key, AddLastByte(StringToBytes(_dateString)), RegistryValueKind.Binary)
            End Sub

            Public Sub SaveGear(key As String)
                Dim s As New List(Of String)
                For Each id As Integer In _gearSlots
                    s.Add(id.ToString())
                Next
                RegHandler.SetRegVal(key, AddLastByte(StringToBytes(Join(s.ToArray(), ","))), RegistryValueKind.Binary)
            End Sub

            Public Sub SavePlayerAttr(key As String)
                Dim s As New List(Of String)
                For Each id As Integer In _playerAttr
                    s.Add(id.ToString())
                Next
                RegHandler.SetRegVal(key, AddLastByte(StringToBytes(Join(s.ToArray(), ";"))), RegistryValueKind.Binary)
            End Sub

            Public Sub SaveSwitchs(key As String)
                Dim s As New List(Of String)
                For Each id As Integer In _switchs
                    s.Add(id.ToString())
                Next
                RegHandler.SetRegVal(key, AddLastByte(StringToBytes(Join(s.ToArray(), ""))), RegistryValueKind.Binary)
            End Sub

#End Region

#Region "Properties"

            ReadOnly Property ValuesChanged As Boolean
                Get
                    Return _valuesChanged
                End Get
            End Property

            ReadOnly Property CurrentPlaceArea As String
                Get
                    Return _currentPlaceArea
                End Get
            End Property

            ReadOnly Property CurrentPlacePoint As String
                Get
                    Return _currentPlacePoint
                End Get
            End Property

            Property CurrentPlayTime As Integer
                Get
                    Return _currentPlayTime
                End Get
                Set(value As Integer)
                    If (value < 0) Then
                        value = 0
                    End If
                    _currentPlayTime = value
                    _valuesChanged = True
                End Set
            End Property

            Property CurrentPlace As String
                Get
                    Return _currentPlaceArea & ";" & _currentPlacePoint
                End Get
                Set(value As String)
                    Dim s() As String = value.Split(CChar(";"))
                    If (s.Length = 2) Then
                        s(0) = s(0).ToLower()
                        value = Join(s, ";")
                        If (Locations.ContainsPlace(value)) Then
                            _currentPlaceArea = s(0)
                            _currentPlacePoint = s(1)
                            _valuesChanged = True
                        End If
                    End If
                End Set
            End Property

            ReadOnly Property Slot As Integer
                Get
                    Return _Slot
                End Get
            End Property

            Public Property XP As Integer
                Get
                    Return _levelXP
                End Get
                Set(value As Integer)
                    If (value < 0) Then
                        value = 0
                    End If
                    _levelXP = value
                    _valuesChanged = True
                End Set
            End Property

            Public Property BearerSP As Integer
                Get
                    Return _levelBearerSP
                End Get
                Set(value As Integer)
                    If (value < 0) Then
                        value = 0
                    End If
                    _levelBearerSP = value
                    _valuesChanged = True
                End Set
            End Property

            Public Property ErgoSP As Integer
                Get
                    Return _levelErgoSP
                End Get
                Set(value As Integer)
                    If (value < 0) Then
                        value = 0
                    End If
                    _levelErgoSP = value
                    _valuesChanged = True
                End Set
            End Property

            Public Property Level As Integer
                Get
                    Return AnimaRegistryEditor.Misc.GetLevelByXP(_levelXP)
                End Get
                Set(value As Integer)
                    If (value < 0) Then
                        value = 0
                    Else
                        If (value > AnimaRegistryEditor.MaxLevel) Then
                            value = AnimaRegistryEditor.MaxLevel
                        End If
                    End If
                    _levelXP = AnimaRegistryEditor.Misc.GetXPByLevel(value)
                    _valuesChanged = True
                End Set
            End Property

            Public Property Coins As Integer
                Get
                    Return _coins
                End Get
                Set(value As Integer)
                    If (value < 0) Then
                        value = 0
                    End If
                    _coins = value
                    _valuesChanged = True
                End Set
            End Property

            Public Property DateString As String
                Get
                    Return _dateString
                End Get
                Set(value As String)
                    _dateString = value
                    _valuesChanged = True
                End Set
            End Property

            Public Property Dificulty As Integer
                Get
                    Return _dificultyLevel
                End Get
                Set(value As Integer)
                    If (value < 0) Then
                        value = 0
                    Else
                        If (value > 2) Then
                            value = 2
                        End If
                    End If
                    _dificultyLevel = value
                    _valuesChanged = True
                End Set
            End Property

            Public ReadOnly Property BearerUsedSkillPoints As Integer
                Get
                    Dim sp As Integer = 0
                    For i As Integer = 1 To 29
                        sp += _sphereTable(i) - 48
                    Next
                    Return sp
                End Get
            End Property

            Public ReadOnly Property ErgoUsedSkillPoints As Integer
                Get
                    Dim sp As Integer = 0
                    For i As Integer = 30 To 58
                        sp += _sphereTable(i) - 48
                    Next
                    Return sp
                End Get
            End Property

#End Region

#Region "Getter Methods"

            Public Function GetItemCount(itemId As Integer) As Integer
                If (_inventory.ContainsKey(itemId)) Then
                    Return _inventory(itemId)
                Else
                    Return 0
                End If
            End Function

            Public Function GetBearerSkill(skillSlot As Integer) As String
                Return _skillsBearer(skillSlot)
            End Function

            Public Function GetErgoSkill(skillSlot As Integer) As String
                Return _skillsErgo(skillSlot)
            End Function

            Public Function GetErgoGear(gearSlot As Integer) As Integer
                Return _gearSlots(gearSlot + 0)
            End Function

            Public Function GetBearerGear(gearSlot As Integer) As Integer
                Return _gearSlots(gearSlot + 4)
            End Function

            Public Function GetPlayerAttr(attrSlot As Integer) As Integer
                Return _playerAttr(attrSlot)
            End Function

            Public Function GetSwitch(i As Integer) As Integer
                Return _switchs(i)
            End Function

            Public Function GetSphereNodeLevel(NodeID As Integer) As Integer
                Return _sphereTable(NodeID) - 48
            End Function

#End Region

#Region "Setter Methods"

            Public Sub SetItemCount(itemId As Integer, count As Integer)
                If (count < 0) Then
                    count = 0
                End If
                If (count > 0) Then
                    If (_inventory.ContainsKey(itemId)) Then
                        _inventory(itemId) = count
                    Else
                        _inventory.Add(itemId, count)
                    End If
                Else
                    If (_inventory.ContainsKey(itemId)) Then
                        _inventory.Remove(itemId)
                    End If
                End If
                _valuesChanged = True
            End Sub

            Public Sub SetBearerSkill(skillSlot As Integer, skillKey As String)
                _skillsBearer(skillSlot) = skillKey
                _valuesChanged = True
            End Sub

            Public Sub SetErgoSkill(skillSlot As Integer, skillKey As String)
                _skillsErgo(skillSlot) = skillKey
                _valuesChanged = True
            End Sub

            Public Sub SetErgoGear(gearSlot As Integer, itemId As Integer)
                _gearSlots(gearSlot + 0) = itemId
                _valuesChanged = True
            End Sub

            Public Sub SetBearerGear(gearSlot As Integer, itemId As Integer)
                _gearSlots(gearSlot + 4) = itemId
                _valuesChanged = True
            End Sub

            Public Sub SetPlayerAttr(attrSlot As Integer, attr As Integer)
                _playerAttr(attrSlot) = attr
                _valuesChanged = True
            End Sub

            Public Sub SetSwitch(i As Integer, v As Integer)
                _switchs(i) = v
                _valuesChanged = True
            End Sub

            Public Sub ClearBearerSkillPoints()
                For i As Integer = 1 To 29
                    _sphereTable(i) = 48
                Next
                _valuesChanged = True
            End Sub

            Public Sub ClearErgoSkillPoints()
                For i As Integer = 30 To 58
                    _sphereTable(i) = 48
                Next
                _valuesChanged = True
            End Sub

#End Region

        End Class

        Public Shared ReadOnly Keys As String() = {"level", "coins", "sphereTable", "inventory", "currentPlace", "dificultyLevel", "skills", "dateString", "gear", "playerAttr", "switchs"}
        Private Shared ReadOnly StartValues As New SortedList(Of String, Object) From {
            {"level", (New List(Of Byte) From {&H30, &H3B, &H30, &H3B, &H30, &H0}).ToArray()},
            {"coins", &H0},
            {"sphereTable", (New List(Of Byte) From {
                &H31, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H0}).ToArray()
            },
            {"inventory", (New List(Of Byte) From {&H0}).ToArray()},
            {"currentPlace", (New List(Of Byte) From {
                &H63, &H69, &H75, &H64, &H61, &H64, &H20, &H69,
                &H6E, &H69, &H63, &H69, &H61, &H6C, &H20, &H70,
                &H72, &H75, &H65, &H62, &H61, &H3B, &H45, &H6E,
                &H74, &H72, &H61, &H64, &H61, &H31, &H3B, &H30,
                &H0}).ToArray()
            },
            {"dificultyLevel", 1},
            {"skills", (New List(Of Byte) From {
                &H2C, &H2C, &H2C, &H2C, &H2C, &H2C, &H2C, &H2C,
                &H2C, &H2C, &H2C, &H3A, &H2C, &H2C, &H2C, &H2C,
                &H2C, &H2C, &H2C, &H2C, &H2C, &H2C, &H2C, &H0}).ToArray()
            },
            {"dateString", (New List(Of Byte) From {&H0}).ToArray()},
            {"gear", (New List(Of Byte) From {
                &H2D, &H31, &H2C, &H2D, &H31, &H2C, &H2D, &H31,
                &H2C, &H2D, &H31, &H2C, &H2D, &H31, &H2C, &H2D,
                &H31, &H2C, &H2D, &H31, &H2C, &H2D, &H31, &H0}).ToArray()
            },
            {"playerAttr", (New List(Of Byte) From {
                &H32, &H30, &H30, &H30, &H30, &H3B, &H31, &H30,
                &H30, &H30, &H30, &H3B, &H31, &H30, &H30, &H30,
                &H30, &H3B, &H2D, &H31, &H3B, &H32, &H30, &H30,
                &H30, &H30, &H3B, &H30, &H3B, &H2D, &H31, &H3B,
                &H2D, &H31, &H0}).ToArray()
            },
            {"switchs", (New List(Of Byte) From {
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H31, &H31, &H31, &H31, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H30, &H30, &H30, &H30,
                &H30, &H30, &H30, &H30, &H0}).ToArray()
            }
        }

        Private Shared Items As New List(Of Gamesave)
        Public Shared SelectedItem As Gamesave = Nothing

        Public Shared Function SelectSlot(slot As Integer) As Gamesave
            Dim GS As Gamesave = GetSlot(slot)
            If GS Is Nothing Then
                If MessageBox.Show("Create empty Savegame in Slot" & slot & "?", "", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    CreateFromStartValues(slot)
                    GS = GetSlot(slot)
                Else
                    Return Nothing
                End If
            End If
            SelectedItem = GS
            Return GS
        End Function

        Public Shared Function IsSlotSelected(Slot As Integer) As Boolean
            Return (SelectedItem IsNot Nothing AndAlso SelectedItem.Slot = Slot)
        End Function

        Public Shared Sub LoadSlot(Slot As Integer)
            Dim gs As New Gamesave(Slot, RegHandler)
            If (gs.LoadFromRegistry()) Then
                Items(Slot - 1) = gs
            Else
                Items(Slot - 1) = Nothing
            End If
            SelectedItem = Nothing
        End Sub

        Public Shared Sub LoadSlots()
            Items.Clear()
            For i = 1 To SavegameSlots
                Items.Add(Nothing)
                LoadSlot(i)
            Next
        End Sub

        Public Shared Function GetSlot(slot As Integer) As Gamesave
            Return Items(slot - 1)
        End Function

        Public Shared Function GetSlotText(slot As Integer) As String
            Dim GS As Gamesave = Items(slot - 1)
            If GS IsNot Nothing Then
                Dim charLoc As Locations.LocationPlace = Locations.GetPlace(GS.CurrentPlace)
                Dim charPlace As String = Join({charLoc.Title, charLoc.Subtitle}, " ").Trim()
                If charPlace.Length > SavegameMaxLength Then
                    charPlace = charLoc.Subtitle
                End If
                Return String.Format(SlotTextFormatPattern, slot, GS.Level, charPlace, GS.DateString) & If(GS.ValuesChanged, GamesaveChangedIndicator, "")
            Else
                Return String.Format(EmptySlotFormatPattern, slot)
            End If
        End Function

        Public Shared Sub DeleteSlot(slot As Integer)
            For Each k As String In Keys
                RegHandler.DelRegVal(AnimaRegistryEditor.GetKeyAlias(k & slot))
            Next
            Items(slot - 1) = Nothing
        End Sub

        Public Shared Sub CreateFromStartValues(slot As Integer)
            Dim GS = New Gamesave(slot, RegHandler)
            GS.LoadFromCustom(StartValues)
            GS.DateString = Now.ToString(SlotDateFormatPattern)
            Items(slot - 1) = GS
        End Sub

        Public Shared Function SlotExist(slot As Integer) As Boolean
            Return Items(slot - 1) IsNot Nothing
        End Function

    End Class

End Class

