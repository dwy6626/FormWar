Public Class Main
    Public Level As Short
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MsgBox("規則很簡單：" & vbCrLf & vbCrLf & "開始遊戲後，你會看到一個表單，" & vbCrLf & "你的任務就是點那個表單，" & vbCrLf & "每點一下表單上的數字都會減一，" & vbCrLf & "你的任務就是讓表單上的數字歸零，" & vbCrLf & "隨著數字減少，難度也將增高，" & vbCrLf & "最後，不管再怎麼挫折，都要記住以下這句：" & vbCrLf & vbCrLf & "請好好愛惜你的電腦..." & vbCrLf & vbCrLf & "小建議：" & vbCrLf & "把除了本遊戲以外的視窗全部最小化，" & vbCrLf & "可以避免背景跑掉。" & vbCrLf & vbCrLf & "註：要關掉遊戲請善用工作管理員" & vbCrLf & "　　把處理程序裡的" & Chr(34) & "表單大戰" & Chr(34) & "關閉即可", , "說明")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("準備好要開始這場" & Chr(22) & "表單大戰" & Chr(22) & "了嗎??", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            BackGround.Show()
            Enemy.SetDesktopLocation(400, 400)
            Me.Hide()
            Enemy.Show()
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Difficulty.Show()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Shell("cmd.exe /c start " & "https://dwy6626.github.io")
    End Sub
End Class
