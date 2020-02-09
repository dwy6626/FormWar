Public Class Difficulty
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonConfirm.Click
        If RadioEasy.Checked Then
            Level = 1
        ElseIf RadioMedium.Checked Then
            Level = 2
        ElseIf RadioHard.Checked Then
            Level = 3
        Else
            Level = 4
        End If
        Hide()
    End Sub

    Private Sub Form7_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Select Case Level
            Case 0 : RadioMedium.Checked = 1
            Case 1 : RadioEasy.Checked = 1
            Case 2 : RadioMedium.Checked = 1
            Case 3 : RadioHard.Checked = 1
            Case 4 : RadioHell.Checked = 1
        End Select
    End Sub
End Class