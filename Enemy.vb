Public Class Enemy
    Public x_sign As SByte = 1
    Public y_sign As SByte = 1
    Public cheat1, cheat2, cheat3 As Short
    Dim maxFormNumber As Integer = 5
    'Basic: a(x) is of length x+1
    Dim fakeForms(maxFormNumber - 1) As FakeForm
    Private Sub Label1_Click(ByVal ByValsender As Object, ByVal e As EventArgs) Handles Label1.MouseClick
        Label1.Text = Val(Label1.Text) - 1
    End Sub
    Private Sub Form3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseClick
        Label1.Text = Val(Label1.Text) - 1
    End Sub

    Private Sub Label1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label1.MouseDoubleClick
        Label1.Text = Val(Label1.Text) - 1
    End Sub
    Private Sub Form3_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
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
                    Timer1.Enabled = False
                    Timer2.Enabled = False
                    Timer3.Enabled = False
                    Timer4.Enabled = False
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

    Private Sub Form3_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        BackGround.ButtleEnd = 0
        For i = 0 To maxFormNumber - 1
            fakeForms(i) = New FakeForm
        Next
        Select Case Main.Level
            Case 1
                Timer2.Interval = 7000
                Timer3.Interval = 13000
                Timer4.Interval = 4000
                SizeScale = 0.25
                SpeedScale = 20
            Case 3
                Timer2.Interval = 5000
                Timer3.Interval = 7000
                Timer4.Interval = 1500
                SizeScale = 0.15
                SpeedScale = 40
            Case 4
                Timer2.Interval = 3000
                Timer3.Interval = 5000
                Timer4.Interval = 1000
                SizeScale = 0.1
                SpeedScale = 50
            Case Else
                Timer2.Interval = 5000
                Timer3.Interval = 9000
                Timer4.Interval = 2000
                SizeScale = 0.18
                SpeedScale = 30
        End Select
        FormReSize(Me)
    End Sub
    Private Sub Label1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Label1.TextChanged
        If Label1.Text = "0" Then
            BackGround.ButtleEnd = 1
            BackGround.Timer1.Enabled = False
            Hide()
            For i = 0 To maxFormNumber - 1
                If fakeForms(i).Visible Then
                    fakeForms(i).Close()
                End If
            Next
            Close()
            Results.Show()
            Results.SetDesktopLocation(screenw \ 2, screenh \ 2)
        ElseIf Label1.Text = "49" Then
            Timer1.Enabled = True
        ElseIf Label1.Text = "24" Then
            SpeedScale += 10
            Timer1.Enabled = True
        ElseIf Label1.Text = "14" Then
            Select Case Main.Level
                Case 1
                    Timer4.Interval = 2000
                Case 3
                    Timer4.Interval = 750
                Case 4
                    Timer4.Interval = 750
                Case Else
                    Timer4.Interval = 1000
            End Select
        ElseIf Label1.Text = "4" Then
            Select Case Main.Level
                Case 1
                    Timer3.Interval = 9000
                Case 3
                    Timer3.Interval = 4000
                Case 4
                    Timer3.Interval = 2000
                Case Else
                    Timer3.Interval = 6000
            End Select
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        FormMove(Me)
    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer2.Tick
        Randomize()
        If Val(Label1.Text) < 20 Then
            Select Case Main.Level
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
            Select Case Main.Level
                Case 4
                    MsgBox("超Message Box攻擊!!", 48 + 256, "攻擊")
                    MsgBox("超Message Box攻擊!!", 48 + 256, "攻擊")
                    MsgBox("超Message Box攻擊!!", 48 + 256, "攻擊")
                Case Else
                    MsgBox("Message Box攻擊!!", 16, "攻擊")
            End Select
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer3.Tick
        Randomize()
        If Val(Label1.Text) < 13 Then
            Select Case Main.Level
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
            Select Case Main.Level
                Case 4
                    InputBox("強Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
                    InputBox("強Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
                Case Else
                    InputBox("Input Box攻擊!!", "攻擊", , Int(Rnd() * screenw) - 100, Int(Rnd() * screenh))
            End Select
        End If
    End Sub

    Private Sub Timer4_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer4.Tick
        Randomize()
        Select Case Main.Level
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

    Private Sub Form3_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDoubleClick
        Label1.Text = Val(Label1.Text) - 1
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