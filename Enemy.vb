Public Class Enemy
    Public x_sign As SByte = 1
    Public y_sign As SByte = 1
    Public cheat1, cheat2, cheat3 As Short
    Public levelJump, levelSmoke, levelSummon, levelHeal,
        levelMsgAttack, levelInputAttack, levelSupMsgAttack, levelSupInputAttack,
        levelSpeedUp, levelMoreJump, levelAttackFreq,
        levelFakeFormAttack, levelBlock As Byte
    Public HealCount As Byte = 0
    ReadOnly maxFormNumber As Byte = 5
    'Basic: a(x) is of length x+1
    ReadOnly fakeForms(maxFormNumber - 1) As FakeForm
    ReadOnly maxKey As Byte = 10
    ReadOnly inputKeys As New List(Of String)
    ReadOnly keyCodeConverter As New KeysConverter
    Private Sub Attacked(ByVal ByValsender As Object, ByVal e As EventArgs) Handles Label1.MouseClick,
        Label1.DoubleClick, Me.MouseClick, Me.DoubleClick
        If Val(Label1.Text) = 1 Then
            If Block.Visible Then
                Block.Close()
            End If
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
            TimerJump.Interval *= 0.75
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
            Dim toBool = Not TimerMsg.Enabled
            TimerMsg.Enabled = toBool
            TimerMove.Enabled = toBool
            TimerInput.Enabled = toBool
            TimerJump.Enabled = toBool
            TimerSummon.Enabled = toBool
            TimerHeal.Enabled = toBool
            TimerBlock.Enabled = toBool
            For i = 0 To maxFormNumber - 1
                fakeForms(i).TimerMsg.Enabled = toBool
            Next
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

        Dim width As Integer = screenw \ 3
        Dim height As Integer = screenh \ 3
        Block.Size = New Size(width, height)
        Block.MaximumSize = Block.Size
        Block.MinimumSize = Block.Size

        TimerMsg.Interval = 8000 - 1000 * Level
        TimerInput.Interval = 15000 - 2000 * Level
        TimerJump.Interval = 5500 - 500 * Level
        TimerSummon.Interval = TimerJump.Interval * (10 - Level)
        TimerHeal.Interval = 10000 - 5000 * Math.Max(Level - 3, 0)

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
                levelFakeFormAttack = 0
                levelSupMsgAttack = 0
                levelSupInputAttack = 0
                levelHeal = 0
                levelBlock = 0
            Case 2
                levelMsgAttack = 45
                levelInputAttack = 40
                levelJump = 35
                levelSmoke = 30
                levelSpeedUp = 25
                levelSupMsgAttack = 20
                levelMoreJump = 15
                levelSummon = 10
                levelHeal = 10
                levelAttackFreq = 5
                levelFakeFormAttack = 0
                levelSupInputAttack = 0
                levelBlock = 0
            Case 3
                levelMsgAttack = 45
                levelInputAttack = 40
                levelJump = 35
                levelSmoke = 35
                levelSummon = 30
                levelSpeedUp = 25
                levelSupMsgAttack = 20
                levelMoreJump = 15
                levelAttackFreq = 15
                levelHeal = 10
                levelBlock = 8
                levelSupInputAttack = 5
                levelFakeFormAttack = 5
            Case 4
                levelJump = 50
                levelHeal = 50
                levelMsgAttack = 45
                levelInputAttack = 40
                levelSmoke = 35
                levelSummon = 30
                levelSpeedUp = 25
                levelSupMsgAttack = 20
                levelMoreJump = 15
                levelAttackFreq = 15
                levelBlock = 13
                'ExtraSummon = 10
                levelSupInputAttack = 8
                'ExtraSummon = 3
                levelFakeFormAttack = 5
        End Select
        FormReSize(Me)
    End Sub
    Private Sub Moving(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMove.Tick
        FormMove(Me)
    End Sub

    Private Sub SkillMsg(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMsg.Tick
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
            If Val(Label1.Text) < 3 Then
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
    Private Sub Healing(ByVal sender As Object, ByVal e As EventArgs) Handles TimerHeal.Tick
        If Val(Label1.Text) < levelHeal Then
            HealCount = 0
            TimerHealEffect.Enabled = True
        End If
    End Sub
    Private Sub HealEffect(ByVal sender As Object, ByVal e As EventArgs) Handles TimerHealEffect.Tick
        If HealCount Mod 2 = 1 Then
            Label1.ForeColor = Color.DarkGreen
        Else
            Label1.ForeColor = Color.PaleGreen
        End If
        HealCount += 1
        If HealCount = 4 Then
            Label1.Text = Val(Label1.Text) + 1
        ElseIf HealCount = 6 Then
            TimerHealEffect.Enabled = False
            Label1.ForeColor = Color.Black
        End If
    End Sub
    Private Sub BlockSummon(ByVal sender As Object, ByVal e As EventArgs) Handles TimerBlock.Tick
        If Not Block.Visible And Val(Label1.Text) < levelBlock Then
            Block.Show()
        End If
        Block.SetDesktopLocation(
            Int(Rnd() * (screenw - Block.Size.Width)),
            Int(Rnd() * (screenh - Block.Size.Height))
        )
    End Sub
    Private Sub FakeForm_Summon(ByRef formAddr As FakeForm, Optional thisPosition As Boolean = False)
        If Not formAddr.Visible Then
            formAddr = New FakeForm
            formAddr.Show()
            If Not thisPosition Then
                formAddr.SetDesktopLocation(Int(Rnd() * screenw), Int(Rnd() * screenh))
            End If
        End If
        If thisPosition Then
            formAddr.SetDesktopLocation(Me.Location.X, Me.Location.Y)
            formAddr.x_sign = x_sign
            formAddr.y_sign = y_sign
        End If
    End Sub
End Class