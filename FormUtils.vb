Module FormUtils
    Public Level As Short = 2
    Public screenw, screenh As Integer
    Public SpeedScale As Short
    Public SizeScale As Double = 0.15
    ReadOnly FontSizeScale As Double = 0.4
    Public Sub FormReSize(ByRef form)
        Dim width, height As Integer
        If screenh > screenw Then
            width = Int(SizeScale * screenw)
        Else
            width = Int(SizeScale * screenh)
        End If
        height = width - 10
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
            form.Location.X + form.x_sign * SpeedScale,
            form.Location.Y + form.y_sign * SpeedScale
        )
        If form.Location.X + form.Size.Width > screenw And form.x_sign = 1 Then
            form.x_sign = -1
        End If
        If form.Location.Y + form.Size.Height > screenh And form.y_sign = 1 Then
            form.y_sign = -1
        End If
        If form.Location.Y < 0 And form.y_sign = -1 Then
            form.y_sign = 1
        End If
        If form.Location.X < 0 And form.x_sign = -1 Then
            form.x_sign = 1
        End If
    End Sub
    Public Sub MsgBoxAttack()
        MsgBox("Message Box攻擊!!", 16, "攻擊")
    End Sub
    Public Sub SuperMsgBoxAttack()
        For i = 1 To 3
            MsgBox("超Message Box攻擊!!", 48 + 256, "攻擊")
        Next
    End Sub
    Public Sub HellMsgBoxAttack()
        For i = 1 To 5
            MsgBox("不可能的任務之Message Box攻擊!!", 48 + 256, "攻擊")
        Next
    End Sub
    Public Sub InputBoxAttack()
        InputBox("Input Box攻擊!!", "攻擊", XPos:=Int(Rnd() * screenw) - 100, YPos:=Int(Rnd() * screenh))
    End Sub
    Public Sub SuperInputBoxAttack()
        For i = 1 To 2
            InputBox("強Input Box攻擊!!", "攻擊", XPos:=Int(Rnd() * screenw) - 100, YPos:=Int(Rnd() * screenh))
        Next
    End Sub
    Public Sub HellInputBoxAttack()
        For i = 1 To 3
            InputBox("超Input Box攻擊!!", "攻擊", XPos:=Int(Rnd() * screenw) - 100, YPos:=Int(Rnd() * screenh))
        Next
    End Sub
End Module