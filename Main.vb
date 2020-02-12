Public Class Main
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        MsgBox("規則很簡單：

開始遊戲後
你會看到一個表單（視窗）
你的任務就是點那個表單
每點一下表單上的數字都會 -1
你的任務就是讓表單上的數字歸零

隨著數字減少
難度也將增高
善用你的智慧與反應來通關吧！


最後，不管再怎麼挫折，都要記住以下這句：
「螢幕是無辜的，請不要砸他。」

啊還有，
「滑鼠跟鍵盤也是。」


註：要關掉遊戲請善用工作管理員", Title:="說明")
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If MsgBox("準備好要開始這場「表單大戰」了嗎？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            BackGround.Show()
            Enemy.SetDesktopLocation(screenw \ 2, screenh \ 2)
            Me.Hide()
            Enemy.Show()
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Difficulty.Show()
    End Sub

    Private Sub Label1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label1.Click
        Shell("cmd.exe /c start " & "https://dwy6626.github.io")
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        screenw = Screen.PrimaryScreen.Bounds.Width
        screenh = Screen.PrimaryScreen.Bounds.Height
    End Sub
End Class
