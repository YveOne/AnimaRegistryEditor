Partial Class AnimaRegistryEditor

    Public Class Inventory

        Public Class Item
            Public ID As Integer
            Public Name As String = ""
            Public Description As String = ""
            Public TypeChar As Char = CChar("?")
            Public MaxCount As Integer = 0
            Public StatEffects As New SortedList(Of String, Integer)
            Public SpecialEffect As String = ""
            Public Sub New(ID As Integer)
                Me.ID = ID
            End Sub
            Public ReadOnly Property TypeName As String
                Get
                    Return GetString(ItemTypeNames(TypeChar))
                End Get
            End Property
        End Class
        Public Shared Items As New List(Of Item)

        Public Shared Sub Clear()
            Items.Clear()
            For i As Integer = 1 To InventorySize
                Items.Add(New Item(Items.Count))
            Next
            EffectNames.Clear()
        End Sub

        Public Shared EffectNames As New SortedList(Of String, String)
        Public Shared Function GetEffectName(EffectKey As String) As String
            Return EffectNames(EffectKey)
        End Function

    End Class

End Class
