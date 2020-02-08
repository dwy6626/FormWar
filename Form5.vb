Public Class Form5

    Dim x_add, y_add As Boolean

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        Label1.Text = Int(Rnd() * Val(Form3.Label1.Text))
    End Sub
    Private Sub Label1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseClick
        Me.Close()
    End Sub

    Private Sub Form3_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.Close()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Randomize()
        If Val(Label1.Text) < 25 Then
            If Me.Location.X < Form3.screenw And Me.Location.Y < Form3.screenh And x_add = True And y_add = True Then
                Me.SetDesktopLocation(Me.Location.X + Int(Rnd() * (Form3.Speed + 10)) + 10, Me.Location.Y + Int(Rnd() * (Form3.Speed + 10)) + 10)
            ElseIf Me.Location.X > 50 And Me.Location.Y < Form3.screenh And x_add = False And y_add = True Then
                Me.SetDesktopLocation(Me.Location.X - Int(Rnd() * (Form3.Speed + 10)) - 10, Me.Location.Y + Int(Rnd() * (Form3.Speed + 10)) + 10)
            ElseIf Me.Location.X > 50 And Me.Location.Y > 50 And x_add = False And y_add = False Then
                Me.SetDesktopLocation(Me.Location.X - Int(Rnd() * (Form3.Speed + 10)) - 10, Me.Location.Y - Int(Rnd() * (Form3.Speed + 10)) - 10)
            ElseIf Me.Location.X < Form3.screenw And Me.Location.Y > 50 And x_add = True And y_add = False Then
                Me.SetDesktopLocation(Me.Location.X + Int(Rnd() * (Form3.Speed + 10)) + 10, Me.Location.Y - Int(Rnd() * (Form3.Speed + 10)) - 10)
            End If
        Else
            If Me.Location.X < Form3.screenw And Me.Location.Y < Form3.screenh And x_add = True And y_add = True Then
                Me.SetDesktopLocation(Me.Location.X + Int(Rnd() * Form3.Speed) + 10, Me.Location.Y + Int(Rnd() * Form3.Speed) + 10)
            ElseIf Me.Location.X > 50 And Me.Location.Y < Form3.screenh And x_add = False And y_add = True Then
                Me.SetDesktopLocation(Me.Location.X - Int(Rnd() * Form3.Speed) - 10, Me.Location.Y + Int(Rnd() * Form3.Speed) + 10)
            ElseIf Me.Location.X > 50 And Me.Location.Y > 50 And x_add = False And y_add = False Then
                Me.SetDesktopLocation(Me.Location.X - Int(Rnd() * Form3.Speed) - 10, Me.Location.Y - Int(Rnd() * Form3.Speed) - 10)
            ElseIf Me.Location.X < Form3.screenw And Me.Location.Y > 50 And x_add = True And y_add = False Then
                Me.SetDesktopLocation(Me.Location.X + Int(Rnd() * Form3.Speed) + 10, Me.Location.Y - Int(Rnd() * Form3.Speed) - 10)
            End If
        End If
        If Me.Location.X >= Form3.screenw And x_add = True Then
            x_add = False
        ElseIf Me.Location.Y >= Form3.screenh And y_add = True Then
            y_add = False
        ElseIf Me.Location.Y <= 50 And y_add = False Then
            y_add = True
        ElseIf Me.Location.X <= 50 And x_add = False Then
            x_add = True
        End If
    End Sub
End Class