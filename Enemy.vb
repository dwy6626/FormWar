Public Class Enemy
    Public x_sign As SByte = 1
    Public y_sign As SByte = 1
    Public cheat1, cheat2, cheat3 As Short
    Public levelJump, levelSmoke, levelSummon,
        levelMsgAttack, levelInputAttack, levelSupMsgAttack, levelSupInputAttack,
        levelSpeedUp, levelMoreJump, levelAttackFreq As Byte
    ReadOnly maxFormNumber As Byte = 5
    'Basic: a(x) is of length x+1
    ReadOnly fakeForms(maxFormNumber - 1) As FakeForm
    ReadOnly maxKey As Byte = 10
    ReadOnly inputKeys As New List(Of String)
    ReadOnly keyCodeConverter As New KeysConverter
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
        ElseIf Val(Label1.Text) = 50 Then
            BackGround.Timer.Enabled = True
            TimerMove.Enabled = True
        End If
        If Val(Label1.Text) = levelSpeedUp Then
            SpeedScale += 10
            levelSpeedUp = 0
        End If
        If Val(Label1.Text) = levelMoreJump Then
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
            levelMoreJump = 0
        End If
        If Val(Label1.Text) = levelAttackFreq Then
            TimerMsg.Interval *= 0.75
            TimerInput.Interval *= 0.75
        End If
        Label1.Text = Val(Label1.Text) - 1
    End Sub
    Private Sub CheatKey(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Dim checkStream As String = ""
        If inputKeys.Count > maxKey Then
            inputKeys.RemoveAt(0)
        End If
        inputKeys.Add(keyCodeConverter.ConvertToString(e.KeyCode))
        For Each x In inputKeys
            If x.Length = 1 Then
                checkStream &= x
            Else
                inputKeys.Clear()
                Exit For
            End If
        Next
        If checkStream.Contains("SPEEDUP") Then
            SpeedScale *= 1.5
            inputKeys.Clear()
        ElseIf checkStream.Contains("SLOWDOWN") Then
            SpeedScale /= 1.5
            inputKeys.Clear()
        ElseIf checkStream.Contains("THEWORLD") Then
            TimerMove.Enabled = False
            TimerMsg.Enabled = False
            TimerInput.Enabled = False
            TimerJump.Enabled = False
            inputKeys.Clear()
        ElseIf checkStream.Contains("CRSCBEST") Then
            Label1.Text = "1"
            inputKeys.Clear()
        End If
    End Sub

    Private Sub Loading(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        For i = 0 To maxFormNumber - 1
            fakeForms(i) = New FakeForm
        Next

        TimerMsg.Interval = 8000 - 1000 * Level
        TimerInput.Interval = 15000 - 2000 * Level
        TimerJump.Interval = 5000 - 1000 * Level
        TimerSummon.Interval = TimerJump.Interval * (10 - Level)

        SizeScale = 0.27 - 0.03 * Level
        SpeedScale = 25 + 5 * Level

        Select Case Level
            Case 1
                levelMsgAttack = 40
                levelJump = 35
                levelSpeedUp = 25
                levelMoreJump = 15
                levelSmoke = 10
                levelInputAttack = 5
                levelSummon = 0
                levelSupMsgAttack = 0
                levelSupInputAttack = 0
            Case 2
                levelMsgAttack = 45
                levelInputAttack = 40
                levelJump = 35
                levelSmoke = 30
                levelSpeedUp = 25
                levelSupMsgAttack = 20
                levelMoreJump = 15
                levelSummon = 10
                levelAttackFreq = 5
                levelSupInputAttack = 0
            Case 3
                levelMsgAttack = 45
                levelInputAttack = 40
                levelJump = 35
                levelSmoke = 35
                levelSummon = 30
                levelSpeedUp = 25
                levelSupMsgAttack = 20
                levelMoreJump = 15
                levelAttackFreq = 10
                levelSupInputAttack = 5
            Case 4
                levelJump = 50
                levelMsgAttack = 45
                levelInputAttack = 40
                levelSmoke = 35
                levelSummon = 30
                levelSpeedUp = 25
                levelSupMsgAttack = 20
                levelMoreJump = 15
                levelAttackFreq = 13
                'ExtraSummon = 10
                levelSupInputAttack = 5
                'ExtraSummon = 4
        End Select
        FormReSize(Me)
    End Sub
    Private Sub Moving(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMove.Tick
        FormMove(Me)
    End Sub

    Private Sub SkillMsg(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMsg.Tick
        Randomize()
        If Level = 4 Then
            If Val(Label1.Text) < levelSupMsgAttack Then
                HellMsgBoxAttack()
            ElseIf Val(Label1.Text) < levelMsgAttack Then
                SuperMsgBoxAttack()
            End If
        Else
            If Val(Label1.Text) < levelSupMsgAttack Then
                SuperMsgBoxAttack()
            ElseIf Val(Label1.Text) < levelMsgAttack Then
                MsgBoxAttack()
            End If
        End If
    End Sub

    Private Sub SkillInput(ByVal sender As Object, ByVal e As EventArgs) Handles TimerInput.Tick
        Randomize()
        If Val(Label1.Text) < levelSupInputAttack Then
            If Level = 4 Then
                HellInputBoxAttack()
            Else
                SuperInputBoxAttack()
            End If
        ElseIf Val(Label1.Text) < levelInputAttack Then
            If Level = 4 Then
                SuperInputBoxAttack()
            Else
                InputBoxAttack()
            End If
        End If
    End Sub
    Private Sub Summoning(ByVal sender As Object, ByVal e As EventArgs) Handles TimerSummon.Tick
        Randomize()
        If Val(Label1.Text) < levelSummon Then
            FakeForm_Summon(fakeForms(1))
        End If
        If Level = 4 Then
            If Val(Label1.Text) < 10 Then
                FakeForm_Summon(fakeForms(2))
            End If
            If Val(Label1.Text) < 4 Then
                FakeForm_Summon(fakeForms(3))
                FakeForm_Summon(fakeForms(4))
            End If
        End If
    End Sub
    Private Sub Jumping(ByVal sender As Object, ByVal e As EventArgs) Handles TimerJump.Tick
        Randomize()
        If Val(Label1.Text) < levelSmoke Then
            FakeForm_Summon(fakeForms(0), True)
        End If
        If Val(Label1.Text) < levelJump Then
            SetDesktopLocation(Int(Rnd() * screenw), Int(Rnd() * screenh))
        End If
    End Sub
    Private Sub FakeForm_Summon(ByRef formAddr As FakeForm, Optional thisPosition As Boolean = False)
        If formAddr.Visible Then formAddr.Close()
        formAddr = New FakeForm
        formAddr.Show()
        If thisPosition Then
            formAddr.SetDesktopLocation(Me.Location.X, Me.Location.Y)
            formAddr.x_sign = x_sign
            formAddr.y_sign = y_sign
        Else
            formAddr.SetDesktopLocation(Int(Rnd() * screenw), Int(Rnd() * screenh))
        End If
    End Sub
End Class