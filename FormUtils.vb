Module FormUtils
    Public screenw, screenh As Integer
    Public SpeedShift As Short = 10
    Public SpeedScale As Short
    Public SizeScale As Double = 0.15
    ReadOnly FontSizeScale As Double = 0.4
    Public Sub FormReSize(ByRef form)
        Dim width As Integer = Int(SizeScale * screenh)
        Dim height As Integer = width - 10
        form.Size = New Size(width, height)
        form.MaximumSize = form.Size
        form.MinimumSize = form.Size
        form.Label1.Size = form.ClientSize
        form.Label1.Location = New Point(0, 0)
        form.Label1.Font = New Font("Arial", Int(FontSizeScale * width))
    End Sub
    Public Sub FormMove(ByRef form)
        Randomize()
        form.SetDesktopLocation(
            form.Location.X + form.x_sign * (Int(Rnd() * SpeedScale) + SpeedShift),
            form.Location.Y + form.y_sign * (Int(Rnd() * SpeedScale) + SpeedShift)
        )
        If form.Location.X + form.Size.Width \ 2 > screenw And form.x_sign = 1 Then
            form.x_sign = -1
        ElseIf form.Location.Y + form.Size.Height \ 2 > screenh And form.y_sign = 1 Then
            form.y_sign = -1
        ElseIf form.Location.Y - form.Size.Height \ 2 < 0 And form.y_sign = -1 Then
            form.y_sign = 1
        ElseIf form.Location.X - form.Size.Width \ 2 < 0 And form.x_sign = -1 Then
            form.x_sign = 1
        End If
    End Sub
End Module