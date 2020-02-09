﻿Public Class Difficulty
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            Main.Level = 1
        ElseIf RadioButton2.Checked Then
            Main.Level = 2
        ElseIf RadioButton3.Checked Then
            Main.Level = 3
        Else
            Main.Level = 4
        End If
        Hide()
    End Sub

    Private Sub Form7_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Select Case Main.Level
            Case 0 : RadioButton2.Checked = 1
            Case 1 : RadioButton1.Checked = 1
            Case 2 : RadioButton2.Checked = 1
            Case 3 : RadioButton3.Checked = 1
            Case 4 : RadioButton4.Checked = 1
        End Select
    End Sub
End Class