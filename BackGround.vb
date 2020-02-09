Public Class BackGround
    Private time As Integer = 0
    Private Sub Form2_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate
        Me.Activate()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer.Tick
        time += 1
        Dim sec As Byte = time Mod 60
        Dim min As Byte = time \ 60
        Label.Text = "時間：" + TimeFormat(min) + " 分 " + TimeFormat(sec) + " 秒"
    End Sub
    Private Function TimeFormat(ByVal t) As String
        Dim strReturn As String
        If t < 10 Then
            strReturn = "0" + t.ToString()
        Else
            strReturn = t.ToString()
        End If
        Return strReturn
    End Function
End Class