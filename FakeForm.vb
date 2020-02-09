Public Class FakeForm
    Public x_sign As SByte = 1
    Public y_sign As SByte = 1
    Private Sub Form4_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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
    Private Sub Label1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label1.MouseClick
        Me.Close()
    End Sub

    Private Sub Form3_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseClick
        Me.Close()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        FormMove(Me)
    End Sub
End Class