Partial Class AnimaRegistryEditor

    Public Class Skills

        Public Class TreeNode
            Public ID As Integer
            Public Name As String = ""
            Public MaxLevel As Integer = 0
            Public Sub New(ID As Integer)
                Me.ID = ID
            End Sub
        End Class
        Public Shared TreeNodes As New List(Of TreeNode)

        Public Shared Sub ClearTreeNodes()
            TreeNodes.Clear()
            For i As Integer = 1 To SkillTreeSize
                TreeNodes.Add(New TreeNode(TreeNodes.Count))
            Next
        End Sub

    End Class

End Class
