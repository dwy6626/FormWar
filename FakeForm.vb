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
    End Sub
    Private Sub Attacked(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label1.MouseClick, Me.MouseClick
        Me.Close()
    End Sub
    Private Sub Moving(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMove.Tick
        FormMove(Me)
    End Sub
End Class