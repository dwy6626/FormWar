Public Class Results

    Private Sub Form6_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case Main.Level
            Case 3
                Label1.Text = "恭喜您贏得了這場腦殘的戰爭XD" & vbCrLf & vbCrLf & "有一個神祕的獎勵喔，" & vbCrLf & "就是：講師幫你的小隊加分XDD" & vbCrLf & vbCrLf & "CRSC BEST!!" & vbCrLf & vbCrLf & "什麼，還想要別的獎勵??" & vbCrLf & "雙擊主畫面底下的「Made by YDW」" & vbCrLf & "會發生神奇的事喔XDD"
            Case 4
                Label1.Text = "恭喜您達成了不可能的任務!!!!" & vbCrLf & vbCrLf & "有一個神祕的獎勵喔，" & vbCrLf & "就是：講師幫你的小隊加分XDD" & vbCrLf & vbCrLf & "CRSC BEST!!" & vbCrLf & vbCrLf & "順便跟你講一個小秘密喔" & vbCrLf & "遊戲中對著「我是表單」" & vbCrLf & "輸入「speedup」再繼續玩" & vbCrLf & "會有意想不到的效果!" & vbCrLf & "連續輸入很多次效果會更明顯!" & vbCrLf & vbCrLf & "什麼，還想要別的獎勵??" & vbCrLf & "雙擊主畫面底下的「Made by YDW」" & vbCrLf & "會發生神奇的事喔XDD"
            Case Else
                Label1.Text = "恭喜您贏得了這場腦殘的戰爭XD" & vbCrLf & vbCrLf & "想得到神秘的獎勵嗎??" & vbCrLf & "請用困難以上的難度再破一次吧!" & vbCrLf & "祝您成功!!"
        End Select
    End Sub

    Private Sub Label2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDoubleClick
        BackGround.Close()
        Main.Show()
        Main.SetDesktopLocation(300, 200)
        Me.Close()
    End Sub
End Class