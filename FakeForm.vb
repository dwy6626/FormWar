Public Class FakeForm
    Public x_sign As SByte = 1
    Public y_sign As SByte = 1
    Private Sub Loading(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        FormReSize(Me)
        Randomize()
        Label1.Text = Int(Rnd() * Val(Enemy.Label1.Text))
        'Random initial moving direction
        If Rnd() > 0.5 Then
            x_sign = -1
        End If
        If Rnd() > 0.5 Then
            y_sign = -1
        End If
        Randomize()
        TimerJump.Interval = Int(Enemy.TimerJump.Interval * (Rnd() * 0.5 + 1))
        TimerMsg.Interval = Int(Enemy.TimerMsg.Interval * (Rnd() * 0.5 + 2))
    End Sub
    Private Sub Attacked(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label1.MouseClick, Me.MouseClick
        Me.Close()
    End Sub
    Private Sub Moving(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMove.Tick
        FormMove(Me)
    End Sub
    Private Sub Jumping(ByVal sender As Object, ByVal e As EventArgs) Handles TimerJump.Tick
        If Enemy.theWorld Then
            Exit Sub
        End If
        Randomize()
        SetDesktopLocation(Int(Rnd() * screenw), Int(Rnd() * screenh))
        TimerJump.Interval = Int(Enemy.TimerJump.Interval * (Rnd() * 0.5 + 1))
    End Sub
    Private Sub SkillMsg(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMsg.Tick
        If Enemy.theWorld Then
            Exit Sub
        End If
        If Val(Enemy.Label1.Text) < Enemy.levelFakeFormAttack And Me.Visible Then
            MsgBoxAttack()
            TimerMsg.Interval = Int(Enemy.TimerMsg.Interval * (Rnd() * 0.5 + 2))
        End If
    End Sub
End Class