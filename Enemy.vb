Public Class Enemy
    Public x_sign As SByte = 1
    Public y_sign As SByte = 1
    Public cheat1, cheat2, cheat3 As Short
    Public levelJump, levelSmoke, levelSummon, levelHeal,
        levelMsgAttack, levelInputAttack, levelSupMsgAttack, levelSupInputAttack,
        levelSpeedUp, levelMoreJump, levelAttackFreq,
        levelFakeFormAttack, levelBlock, levelBlockBlink As Byte
    Public HealCount As Byte = 0
    ReadOnly maxFormNumber As Byte = 5
    'Basic: a(x) is of length x+1
    ReadOnly fakeForms(maxFormNumber - 1) As FakeForm
    ReadOnly maxKey As Byte = 10
    ReadOnly inputKeys As New List(Of String)
    ReadOnly keyCodeConverter As New KeysConverter
    ReadOnly maxBlockNumber As Integer = 15
    ReadOnly blinkBlocks(maxBlockNumber - 1) As Block
    Private blockPtr As Integer = 0
    Private blockX, blockY As Integer
    Public theWorld As Boolean = False
    Private Sub Attacked(ByVal ByValsender As Object, ByVal e As EventArgs) Handles Label1.MouseClick,
        Label1.DoubleClick, Me.MouseClick, Me.DoubleClick
        Label1.Text = Val(Label1.Text) - 1
    End Sub
    Private Sub Label1_TextChanged(sender As Object, e As EventArgs) Handles Label1.TextChanged
        If Visible Then
            '1 -> 0: close all and show results 
            'unidirectional
            If Val(Label1.Text) = 0 Then
                Close()
                Exit Sub
            End If

            '50 -> 49: start!
            TimerMove.Enabled = Val(Label1.Text) < 50
            If Val(Label1.Text) < 50 Then
                BackGround.Timer.Enabled = True
            End If

            'Change and enable only
            TimerMsg.Enabled = Val(Label1.Text) < Math.Max(levelMsgAttack, levelSupMsgAttack)
            TimerInput.Enabled = Val(Label1.Text) < Math.Max(levelInputAttack, levelSupInputAttack)
            TimerJump.Enabled = Val(Label1.Text) < levelJump

            'Change to trigger
            If Val(Label1.Text) < levelSummon Then
                If Not TimerSummon.Enabled Then
                    Summoning(Nothing, Nothing)
                    TimerSummon.Enabled = True
                End If
            Else
                TimerSummon.Enabled = False
            End If
            If Val(Label1.Text) < levelHeal Then
                If Not TimerHeal.Enabled Then
                    Healing(Nothing, Nothing)
                    TimerHeal.Enabled = True
                End If
            Else
                TimerHeal.Enabled = False
            End If
            If Val(Label1.Text) < levelBlock Then
                If Not TimerBlock.Enabled Then
                    BlockSummon(Nothing, Nothing)
                    TimerBlock.Enabled = True
                End If
            Else
                BlockClose()
                TimerBlock.Enabled = False
            End If
            If Val(Label1.Text) < levelBlockBlink Then
                If Not TimerBlockAttack.Enabled Then
                    SkillBlockAttack(Nothing, Nothing)
                    TimerBlockAttack.Enabled = True
                End If
            Else
                TimerBlockAttack.Enabled = False
            End If

            'Change once and disable check
            If Val(Label1.Text) < levelSpeedUp Then
                If Level = 4 Then
                    SpeedScale *= 1.25
                Else
                    SpeedScale *= 1.5
                End If
                levelSpeedUp = 0
            End If
            If Val(Label1.Text) < levelMoreJump Then
                TimerJump.Interval *= 0.5
                levelMoreJump = 0
            End If
            If Val(Label1.Text) < levelAttackFreq Then
                TimerMsg.Interval *= 0.75
                TimerInput.Interval *= 0.75
                levelAttackFreq = 0
            End If

            'Make all fake form < this form
            For i = 0 To maxFormNumber - 1
                If fakeForms(i).Visible And Val(fakeForms(i).Label1.Text) >= Val(Label1.Text) Then
                    fakeForms(i).Label1.Text = Int(Rnd() * Val(Label1.Text))
                End If
            Next
        End If
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
        ElseIf checkStream.Contains("REDO") Then
            Label1.Text = "50"
            inputKeys.Clear()
        ElseIf checkStream.Contains("CRSCBEST") Then
            Label1.Text = "1"
            inputKeys.Clear()
        ElseIf checkStream.Contains("THEWORLD") Then
            theWorld = Not theWorld
            inputKeys.Clear()
        End If
    End Sub

    Private Sub Loading(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        For i = 0 To maxFormNumber - 1
            fakeForms(i) = New FakeForm
        Next
        For i = 0 To maxBlockNumber - 1
            blinkBlocks(i) = New Block
            blinkBlocks(i).Size = New Size(Size.Width \ 2, Size.Height \ 2)
        Next
        Dim width As Integer = screenw \ 3
        Dim height As Integer = screenh \ 3
        Block.Size = New Size(width, height)
        Block.MaximumSize = Block.Size
        Block.MinimumSize = Block.Size

        TimerMsg.Interval = 7000 - 500 * Level
        TimerInput.Interval = 13000 - 1000 * Level
        TimerJump.Interval = 4500 - 500 * Level
        TimerSummon.Interval = TimerJump.Interval * (10 - Level)
        TimerHeal.Interval = 13000
        TimerDoNotHeal.Interval = TimerHeal.Interval - 2500
        TimerBlockAttack.Interval = 11200 - 2000 * Level
        TimerBlockStop.Interval = 1000 + 500 * Level

        SizeScale = 0.19 - 0.02 * Math.Min(Level, 3)
        SpeedScale = Int((0.28 + 0.02 * Level) * Size.Width)

        Select Case Level
            Case 1
                levelMsgAttack = 40
                levelJump = 35
                levelSpeedUp = 25
                levelMoreJump = 20
                levelSmoke = 15
                levelInputAttack = 10
                levelHeal = 5
                levelAttackFreq = 5
                levelSummon = 0
                levelFakeFormAttack = 0
                levelSupMsgAttack = 0
                levelSupInputAttack = 0
                levelBlock = 0
                levelBlockBlink = 0
            Case 2
                levelMsgAttack = 45
                levelJump = 40
                levelInputAttack = 35
                levelSmoke = 30
                levelSpeedUp = 25
                levelAttackFreq = 25
                levelSummon = 20
                levelMoreJump = 20
                levelBlockBlink = 15
                levelHeal = 10
                levelSupMsgAttack = 5
                levelSupInputAttack = 3
                levelBlock = 0
                levelFakeFormAttack = 0
            Case 3
                levelMsgAttack = 45
                levelJump = 45
                levelInputAttack = 35
                levelSmoke = 35
                levelSummon = 30
                levelSpeedUp = 25
                levelAttackFreq = 25
                levelMoreJump = 20
                levelFakeFormAttack = 20
                levelHeal = 15
                levelBlockBlink = 15
                levelBlock = 10
                levelSupMsgAttack = 5
                levelSupInputAttack = 3
            Case 4
                levelJump = 50
                levelHeal = 50
                levelMsgAttack = 50
                levelInputAttack = 45
                levelSmoke = 40
                levelSummon = 35
                levelFakeFormAttack = 30
                levelMoreJump = 25
                levelAttackFreq = 20
                levelBlockBlink = 20
                levelBlock = 15
                'ExtraSummon = 10
                levelSpeedUp = 8
                levelSupMsgAttack = 5
                'ExtraSummon = 5
                levelSupInputAttack = 3
        End Select
        FormReSize(Me)
        SetDesktopLocation(screenw \ 2, screenh \ 2)
    End Sub
    Private Sub Moving(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMove.Tick
        FormMove(Me)
    End Sub

    Private Sub SkillMsg(ByVal sender As Object, ByVal e As EventArgs) Handles TimerMsg.Tick
        If theWorld Then
            Exit Sub
        End If
        If Level = 4 Then
            If Val(Label1.Text) < levelSupMsgAttack Then
                HellMsgBoxAttack()
            Else
                SuperMsgBoxAttack()
            End If
        Else
            If Val(Label1.Text) < levelSupMsgAttack Then
                SuperMsgBoxAttack()
            Else
                MsgBoxAttack()
            End If
        End If
    End Sub

    Private Sub SkillInput(ByVal sender As Object, ByVal e As EventArgs) Handles TimerInput.Tick
        If theWorld Then
            Exit Sub
        End If
        If Val(Label1.Text) < levelSupInputAttack Then
            If Level = 4 Then
                HellInputBoxAttack()
            Else
                SuperInputBoxAttack()
            End If
        Else
            If Level = 4 Then
                SuperInputBoxAttack()
            Else
                InputBoxAttack()
            End If
        End If
    End Sub
    Private Sub SkillBlockAttack(ByVal sender As Object, ByVal e As EventArgs) Handles TimerBlockAttack.Tick
        If theWorld Then
            Exit Sub
        End If
        Randomize()
        blockX = Int(Rnd() * screenw \ 2)
        blockY = Int(Rnd() * screenh \ 2)
        TimerBlockStop.Enabled = True
        TimerBlockBlink.Enabled = True
    End Sub
    Private Sub SkillBlockBlink(ByVal sender As Object, ByVal e As EventArgs) Handles TimerBlockBlink.Tick
        If blockPtr >= maxBlockNumber Then
            blockPtr = 0
        End If
        If Not blinkBlocks(blockPtr).Visible Then
            blinkBlocks(blockPtr) = New Block
            blinkBlocks(blockPtr).Size = New Size(Size.Width, Size.Height)
            blinkBlocks(blockPtr).Show()
        End If
        blinkBlocks(blockPtr).TimerClose.Enabled = True
        blinkBlocks(blockPtr).BackColor = Color.FromArgb(
                Int(Rnd() * 256), Int(Rnd() * 256), Int(Rnd() * 256)
                )
        blinkBlocks(blockPtr).SetDesktopLocation(
            Int(blockX + Rnd() * screenw / 2),
            Int(blockY + Rnd() * screenh / 2)
        )
        blockPtr += 1
    End Sub
    Private Sub SkillBlockStop(ByVal sender As Object, ByVal e As EventArgs) Handles TimerBlockStop.Tick
        TimerBlockBlink.Enabled = False
        TimerBlockStop.Enabled = False
    End Sub
    Private Sub Summoning(ByVal sender As Object, ByVal e As EventArgs) Handles TimerSummon.Tick
        If theWorld Then
            Exit Sub
        End If
        Randomize()
        FakeForm_Summon(fakeForms(1))
        If Level = 4 Then
            If Val(Label1.Text) < 10 Then
                FakeForm_Summon(fakeForms(2))
            End If
            If Val(Label1.Text) < 5 Then
                FakeForm_Summon(fakeForms(3))
                FakeForm_Summon(fakeForms(4))
            End If
        End If
    End Sub
    Private Sub Jumping(ByVal sender As Object, ByVal e As EventArgs) Handles TimerJump.Tick
        If theWorld Then
            Exit Sub
        End If
        Randomize()
        If Val(Label1.Text) < levelSmoke Then
            FakeForm_Summon(fakeForms(0), True)
        End If
        SetDesktopLocation(Int(Rnd() * screenw), Int(Rnd() * screenh))
    End Sub
    Private Sub Healing(ByVal sender As Object, ByVal e As EventArgs) Handles TimerHeal.Tick
        If theWorld Then
            Exit Sub
        End If
        If Not TimerDoNotHeal.Enabled Then
            HealCount = 0
            TimerHealEffect.Enabled = True
            TimerDoNotHeal.Enabled = True
        End If
    End Sub
    Private Sub TimerDoNotHeal_Tick(sender As Object, e As EventArgs) Handles TimerDoNotHeal.Tick
        TimerDoNotHeal.Enabled = False
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
        If theWorld Then
            Exit Sub
        End If
        If Not Block.Visible Then
            Block.Show()
        End If
        Block.SetDesktopLocation(
            Int(Rnd() * (screenw - Block.Size.Width)),
            Int(Rnd() * (screenh - Block.Size.Height))
        )
    End Sub
    Private Sub BlockClose()
        If Block.Visible Then
            Block.Close()
        End If
    End Sub
    Private Sub FakeForm_Summon(ByRef formAddr As FakeForm, Optional thisPosition As Boolean = False)
        If theWorld Then
            Exit Sub
        End If
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

    Private Sub Enemy_Closed(sender As Object, e As EventArgs) Handles Me.Closing
        BackGround.Timer.Enabled = False
        TimerBlockBlink.Enabled = False
        TimerBlock.Enabled = False
        TimerInput.Enabled = False
        TimerMsg.Enabled = False
        TimerHeal.Enabled = False
        BlockClose()
        For i = 0 To maxFormNumber - 1
            If fakeForms(i).Visible Then
                fakeForms(i).Close()
            End If
        Next
        Results.Show()
        Results.SetDesktopLocation(
            (screenw - Results.Size.Width) \ 2,
            (screenh - Results.Size.Height) \ 2
        )
    End Sub
End Class