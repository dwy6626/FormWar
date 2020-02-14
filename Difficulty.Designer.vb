<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Difficulty
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonConfirm = New System.Windows.Forms.Button()
        Me.RadioEasy = New System.Windows.Forms.RadioButton()
        Me.RadioMedium = New System.Windows.Forms.RadioButton()
        Me.RadioHard = New System.Windows.Forms.RadioButton()
        Me.RadioHell = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'ButtonConfirm
        '
        Me.ButtonConfirm.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonConfirm.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonConfirm.ForeColor = System.Drawing.Color.White
        Me.ButtonConfirm.Location = New System.Drawing.Point(52, 148)
        Me.ButtonConfirm.Name = "ButtonConfirm"
        Me.ButtonConfirm.Size = New System.Drawing.Size(168, 50)
        Me.ButtonConfirm.TabIndex = 0
        Me.ButtonConfirm.Text = "確定"
        Me.ButtonConfirm.UseVisualStyleBackColor = False
        '
        'RadioEasy
        '
        Me.RadioEasy.AutoSize = True
        Me.RadioEasy.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RadioEasy.ForeColor = System.Drawing.Color.White
        Me.RadioEasy.Location = New System.Drawing.Point(52, 20)
        Me.RadioEasy.Name = "RadioEasy"
        Me.RadioEasy.Size = New System.Drawing.Size(72, 31)
        Me.RadioEasy.TabIndex = 1
        Me.RadioEasy.TabStop = True
        Me.RadioEasy.Text = "稍易"
        Me.RadioEasy.UseVisualStyleBackColor = True
        '
        'RadioMedium
        '
        Me.RadioMedium.AutoSize = True
        Me.RadioMedium.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RadioMedium.ForeColor = System.Drawing.Color.White
        Me.RadioMedium.Location = New System.Drawing.Point(52, 47)
        Me.RadioMedium.Name = "RadioMedium"
        Me.RadioMedium.Size = New System.Drawing.Size(72, 31)
        Me.RadioMedium.TabIndex = 2
        Me.RadioMedium.Text = "中等"
        Me.RadioMedium.UseVisualStyleBackColor = True
        '
        'RadioHard
        '
        Me.RadioHard.AutoSize = True
        Me.RadioHard.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RadioHard.ForeColor = System.Drawing.Color.White
        Me.RadioHard.Location = New System.Drawing.Point(52, 74)
        Me.RadioHard.Name = "RadioHard"
        Me.RadioHard.Size = New System.Drawing.Size(72, 31)
        Me.RadioHard.TabIndex = 3
        Me.RadioHard.TabStop = True
        Me.RadioHard.Text = "困難"
        Me.RadioHard.UseVisualStyleBackColor = True
        '
        'RadioHell
        '
        Me.RadioHell.AutoSize = True
        Me.RadioHell.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RadioHell.ForeColor = System.Drawing.Color.White
        Me.RadioHell.Location = New System.Drawing.Point(52, 101)
        Me.RadioHell.Name = "RadioHell"
        Me.RadioHell.Size = New System.Drawing.Size(156, 31)
        Me.RadioHell.TabIndex = 4
        Me.RadioHell.TabStop = True
        Me.RadioHell.Text = "不可能的任務"
        Me.RadioHell.UseVisualStyleBackColor = True
        '
        'Difficulty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(269, 210)
        Me.Controls.Add(Me.RadioHell)
        Me.Controls.Add(Me.RadioHard)
        Me.Controls.Add(Me.RadioMedium)
        Me.Controls.Add(Me.RadioEasy)
        Me.Controls.Add(Me.ButtonConfirm)
        Me.MaximumSize = New System.Drawing.Size(285, 249)
        Me.MinimumSize = New System.Drawing.Size(285, 249)
        Me.Name = "Difficulty"
        Me.ShowIcon = False
        Me.Text = "難易度"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonConfirm As System.Windows.Forms.Button
    Friend WithEvents RadioEasy As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMedium As System.Windows.Forms.RadioButton
    Friend WithEvents RadioHard As System.Windows.Forms.RadioButton
    Friend WithEvents RadioHell As System.Windows.Forms.RadioButton
End Class
