Public Class Results

    Private Sub Loading(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Select Case Level
            Case 3
                LabelAward.Text = "恭喜你贏得了這場腦殘的戰爭 XD

順便跟你講一個小秘密喔
遊戲中對著「我是表單」
鍵入「speedup」再繼續玩
會有意想不到的效果
連續輸入很多次效果會更明顯！

歡迎繼續挑戰不可能的任務喔！
"
            Case 4
                LabelAward.Text = "恭喜你達成了不可能的任務！

你已經完成了表單大戰的最高難度了
我表單願稱你為最強
希望這個遊戲能夠讓你在苦澀的人生中得到一點樂趣
如果沒有
就再玩一次吧

另外附上一個神祕獎勵
遊戲中對著「我是表單」
鍵入「CRSCBEST」
會有意想不到的效果！
"
            Case Else
                LabelAward.Text = "恭喜你贏得了這場腦殘的戰爭 XD

有一個神祕的獎勵喔
就是：講師幫你的小隊加分 XDD

CRSC BEST!!

什麼，還想要別的獎勵？
雙擊主畫面底下的「dw」
會發生神奇的事喔 XDD
"
        End Select
    End Sub

    Private Sub CloseResult(ByVal sender As Object, ByVal e As MouseEventArgs) Handles LabelClose.MouseDoubleClick
        BackGround.Close()
        Main.Show()
        Me.Close()
    End Sub
End Class