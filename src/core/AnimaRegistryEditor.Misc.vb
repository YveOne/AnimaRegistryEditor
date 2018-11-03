Partial Class AnimaRegistryEditor

    Public Class Misc

        Public Shared Function GetLevelByXP(xp As Integer) As Integer
            Dim increased As Integer = LevelExpIncreaseStart
            Dim level As Integer = 0
            Dim levelXP As Integer = 0
            While level < MaxLevel
                levelXP += increased
                increased += LevelExpIncreaseStep
                level += 1
                If levelXP > xp Then
                    Return level
                End If
            End While
            Return MaxLevel
        End Function

        Public Shared Function GetXPByLevel(lv As Integer) As Integer
            Dim increased As Integer = LevelExpIncreaseStart
            Dim level As Integer = 0
            Dim levelXP As Integer = 0
            While level <= MaxLevel
                level += 1
                If lv = level Then
                    Return levelXP
                End If
                levelXP += increased
                increased += LevelExpIncreaseStep
            End While
            Return levelXP
        End Function

    End Class

End Class
