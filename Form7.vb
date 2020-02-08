Public Class Form7

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            Form1.Level = 1
        ElseIf RadioButton2.Checked Then
            Form1.Level = 2
        ElseIf RadioButton3.Checked Then
            Form1.Level = 3
        Else
            Form1.Level = 4
        End If
        Hide()
    End Sub

    Private Sub Form7_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case Form1.Level
            Case 0 : RadioButton2.Checked = 1
            Case 1 : RadioButton1.Checked = 1
            Case 2 : RadioButton2.Checked = 1
            Case 3 : RadioButton3.Checked = 1
            Case 4 : RadioButton4.Checked = 1
        End Select
    End Sub
End Class