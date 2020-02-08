Public Class Form2
    Public c As Int64
    Public ButtleEnd As Boolean
    Private Sub Form2_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Activate()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LabelSec.Text = Val(LabelSec.Text) + 1
        If Val(LabelSec.Text) < 10 Then LabelSec.Text = "0" + LabelSec.Text
        If LabelSec.Text = "60" Then
            LabelSec.Text = "00"
            LabelMin.Text = Val(LabelMin.Text) + 1
            If Val(LabelMin.Text) < 10 Then LabelMin.Text = "0" + LabelMin.Text
        End If
    End Sub

End Class