Partial Class AnimaRegistryEditor

    Public Class Locations

        Public Shared PlacesByFullKey As New SortedList(Of String, LocationPlace)
        Public Shared Places As New List(Of LocationPlace)

        Public Class LocationPlace
            Public AreaKey As String
            Public PointKey As String
            Public Title As String
            Public Subtitle As String
            Public Info As String
            Public Sub New(AreaKey As String, PointKey As String, Title As String, Subtitle As String, Info As String)
                Me.AreaKey = AreaKey.ToLower()
                Me.PointKey = PointKey.ToLower()
                Me.Title = Title
                Me.Subtitle = Subtitle
                Me.Info = Info
            End Sub
            Public ReadOnly Property Key As String
                Get
                    Return areaKey & ";" & pointKey
                End Get
            End Property
            Public ReadOnly Property Text As String
                Get
                    Return If(Subtitle.Length > 0, Subtitle, Title) & If(Info.Length > 0, " (" & Info & ")", "")
                End Get
            End Property
        End Class

        Public Shared Sub Clear()
            Places.Clear()
            PlacesByFullKey.Clear()
        End Sub

        Public Shared Sub AddPlace(fullKey As String, title As String, subtitle As String, info As String)
            Dim leftSplit As String()
            leftSplit = fullKey.Split(CChar(";"))
            If (leftSplit.Length = 2) Then
                Dim areaKey As String = leftSplit(0)
                Dim pointKey As String = leftSplit(1)
                Dim p As New LocationPlace(areaKey, pointKey, title, subtitle, info)
                Places.Add(p)
                PlacesByFullKey.Add(fullKey, p)
            End If
        End Sub

        Public Shared Function ContainsPlace(fullKey As String) As Boolean
            Return PlacesByFullKey.ContainsKey(fullKey)
        End Function

        Public Shared Function GetPlace(fullKey As String) As LocationPlace
            If PlacesByFullKey.ContainsKey(fullKey) Then
                Return PlacesByFullKey(fullKey)
            End If
            Return Nothing
        End Function

    End Class

End Class
