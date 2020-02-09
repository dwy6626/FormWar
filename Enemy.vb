Public Class Enemy
    Public x_sign As SByte = 1
    Public y_sign As SByte = 1
    Public cheat1, cheat2, cheat3 As Short
    Dim maxFormNumber As Integer = 5
    'Basic: a(x) is of length x+1
    Dim fakeForms(maxFormNumber - 1) As FakeForm
    Private Sub Attacked(ByVal ByValsender As Object, ByVal e As EventArgs) Handles Label1.MouseClick, Me.MouseClick
        If Label1.Text = "1" Then
            BackGround.Timer.Enabled = False
            Hide()
            For i = 0 To maxFormNumber - 1
                If fakeForms(i).Visible Then
                    fakeForms(i).Close()
                End If
            Next
            Close()
            Results.Show()
            Results.SetDesktopLocation(screenw \ 2, screenh \ 2)
        ElseIf Label1.Text = "50" Then
            BackGround.Timer.Enabled = True
            TimerMove.Enabled = True
        ElseIf Label1.Text = "25" Then
            SpeedScale += 10
            TimerMove.Enabled = True
        ElseIf Label1.Text = "15" Then
            Select Case Level
                Case 1
                    TimerJump.Interval = 2000
                Case 3
                    TimerJump.Interval = 750
                Case 4
                    TimerJump.Interval = 750
                Case Else
                    TimerJump.Interval = 1000
            End Select
        ElseIf Label1.Text = "5" Then
            Select Case Level
                Case 1
                    TimerInput.Interval = 9000
                Case 3
                    TimerInput.Interval = 4000
                Case 4
                    TimerInput.Interval = 2000
                Case Else
                    TimerInput.Interval = 6000
            End Select
        End If
        Label1.Text = Val(Label1.Text) - 1
    End Sub
    Private Sub CheatKey(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.C
                If cheat1 = 0 Then
                    cheat1 += 1
                    cheat2 = 0
                    cheat3 = 0
                ElseIf cheat1 = 3 Then
                    cheat1 += 1
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.F
                If cheat2 = 0 Then
                    cheat2 += 1
                    cheat3 = 0
                    cheat1 = 0
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.R
                If cheat1 = 1 Then
                    cheat1 += 1
                ElseIf cheat2 = 1 Then
                    cheat2 += 1
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.S
                If cheat1 = 2 Then
                    cheat1 += 1
                ElseIf cheat3 = 0 Then
                    cheat3 += 1
                    cheat2 = 0
                    cheat1 = 0
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.P
                If cheat3 = 1 Then
                    cheat3 += 1
                    cheat2 = 0
                    cheat1 = 0
                ElseIf cheat3 = 6 Then
                    cheat3 = 0
                    SpeedScale *= 1.5
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.D
                If cheat3 = 4 Then
                    cheat3 += 1
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.U
                If cheat3 = 5 Then
                    cheat3 += 1
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.B
                If cheat1 = 4 Then
                    cheat1 += 1
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.E
                If cheat1 = 5 Then
                    cheat1 += 1
                ElseIf cheat2 = 2 Or cheat2 = 3 Then
                    cheat2 += 1
                ElseIf cheat3 = 2 Or cheat3 = 3 Then
                    cheat3 += 1
                ElseIf cheat2 = 5 Then
                    TimerMove.Enabled = False
                    TimerMsg.Enabled = False
                    TimerInput.Enabled = False
                    TimerJump.Enabled = False
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.Z
                If cheat2 = 4 Then
                    cheat2 += 1
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.S
                If cheat1 = 6 Then
                    cheat1 += 1
                Else
                    cheat1 = 0
                    cheat2 = 0
                    cheat3 = 0
                End If
            Case Keys.T
                Label1.Text = "0"
            Case Else
                cheat1 = 0
                cheat2 = 0
                cheat3 = 0
        End Select
    End Sub

    Private Sub Loading(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        For i = 0 To maxFormNumber - 1
            fakeForms(i) = New FakeForm
        Next
        Select Case Level
            Case 1
                TimerMsg.Interval = 7000
                TimerInput.Interval = 13000
                TimerJump.Interval = 4000
                SizeScale = 0.25
                SpeedScale = 25
            Case 3
                TimerMsg.Interval = 5000
                TimerInput.Interval = 7000
                TimerJump.Interval = 1500
                SizeScale = 0.15
                SpeedScale = 45
            Case 4
                TimerMsg.Interval = 3000
                TimerInput.Interval = 5000
                TimerJump.Interval = 1000
                SizeScale = 0.1
                SpeedScale = 55
            Case Else
                TimerMsg.Interval = 5000
                TimerInput.Interval = 9000
                TimerJump.Interval = 2000
                SizeScale = 0.18
                SpeedScale = 35
        End Select
        FormReSize(Me)
    End Sub
    Private Sub Moving(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMove.Tick
        FormMove(Me)
    End Sub

    Private Sub SkillMsg(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMsg.Tick
        Randomize()
        If Val(Label1.Text) < 20 Then
            Select Case Level
                Case 1
                    MsgBox("Message Box攻擊!!", 16, "攻擊")
                Case 4
                    MsgBox("不可能的任務之Message Box攻擊!!", 48 + 256, "攻擊")
                    MsgBox("不可能的任務之Message Box攻擊!!", 48 + 256, "攻擊")
                    MsgBox("不可能的任務之Message Box攻擊!!", 48 + 256, "攻擊")
                    MsgBox("不可能的任務之Message Box攻擊!!", 48 + 256, "攻擊")
                    MsgBox("不可能的任務之Message Box攻擊!!", 48 + 256, "攻擊")
                Case Else
                    MsgBox("超Message Box攻擊!!", 48 + 256, "攻擊")
                    MsgBox("超Message Box攻擊!!", 48 + 256, "攻擊")
                    MsgBox("超Message Box攻擊!!", 48 + 256, "攻擊")
            End Select
        ElseIf Val(Label1.Text) < 45 Then
            Select Case Level
                Case 4
                    MsgBox("超Message Box攻擊!!", 48 + 256, "攻擊")
                    MsgBox("超Message Box攻擊!!", 48 + 256, "攻擊")
                    MsgBox("超Message Box攻擊!!", 48 + 256, "攻擊")
                Case Else
                    MsgBox("Message Box攻擊!!", 16, "攻擊")
            End Select
        End If
    End Sub

    Private Sub SkillInput(ByVal sender As Object, ByVal e As EventArgs) Handles TimerInput.Tick
        Randomize()
        If Val(Label1.Text) < 13 Then
            Select Case Level
                Case 3
                    InputBox("強Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
                    InputBox("強Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
                Case 4
                    InputBox("超Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
                    InputBox("超Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
                    InputBox("超Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
                Case Else
                    InputBox("Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
            End Select
        ElseIf Val(Label1.Text) < 40 Then
            Select Case Level
                Case 4
                    InputBox("強Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
                    InputBox("強Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
                Case Else
                    InputBox("Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
            End Select
        End If
    End Sub

    Private Sub Jumping(ByVal sender As Object, ByVal e As EventArgs) Handles TimerJump.Tick
        Randomize()
        Select Case Level
            Case 1
                If Val(Label1.Text) < 10 Then
                    FakeForm_Summon(fakeForms(0), True)
                End If
                If Val(Label1.Text) < 35 Then
                    SetDesktopLocation(Int(Rnd() * screenw), Int(Rnd() * screenh))
                End If
            Case 3
                If Val(Label1.Text) < 10 Then
                    FakeForm_Summon(fakeForms(1))
                End If
                If Val(Label1.Text) < 35 Then
                    FakeForm_Summon(fakeForms(0), True)
                    SetDesktopLocation(Int(Rnd() * screenw), Int(Rnd() * screenh))
                End If
            Case 4
                If Val(Label1.Text) < 30 Then
                    FakeForm_Summon(fakeForms(0))
                End If
                If Val(Label1.Text) < 10 Then
                    FakeForm_Summon(fakeForms(1))
                End If
                If Val(Label1.Text) < 4 Then
                    FakeForm_Summon(fakeForms(3))
                End If
                If Val(Label1.Text) < 35 Then
                    FakeForm_Summon(fakeForms(2), True)
                End If
                If Val(Label1.Text) < 50 Then
                    SetDesktopLocation(Int(Rnd() * screenw), Int(Rnd() * screenh))
                End If
            Case Else
                If Val(Label1.Text) < 30 Then
                    FakeForm_Summon(fakeForms(0), True)
                End If
                If Val(Label1.Text) < 10 Then
                    FakeForm_Summon(fakeForms(1))
                End If
                If Val(Label1.Text) < 35 Then
                    SetDesktopLocation(Int(Rnd() * screenw), Int(Rnd() * screenh))
                End If
        End Select

    End Sub
    Private Sub FakeForm_Summon(ByRef formAddr As FakeForm, Optional thisPosition As Boolean = False)
        If formAddr.Visible Then formAddr.Close()
        formAddr = New FakeForm
        formAddr.Show()
        If thisPosition Then
            formAddr.SetDesktopLocation(Me.Location.X, Me.Location.Y)
        Else
            formAddr.SetDesktopLocation(Int(Rnd() * screenw), Int(Rnd() * screenh))
        End If
    End Sub
End Class