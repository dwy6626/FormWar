<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Enemy
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TimerMove = New System.Windows.Forms.Timer(Me.components)
        Me.TimerMsg = New System.Windows.Forms.Timer(Me.components)
        Me.TimerInput = New System.Windows.Forms.Timer(Me.components)
        Me.TimerJump = New System.Windows.Forms.Timer(Me.components)
        Me.TimerSummon = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "50"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerMove
        '
        '
        'TimerMsg
        '
        Me.TimerMsg.Enabled = True
        Me.TimerMsg.Interval = 5000
        '
        'TimerInput
        '
        Me.TimerInput.Enabled = True
        Me.TimerInput.Interval = 9000
        '
        'TimerJump
        '
        Me.TimerJump.Enabled = True
        Me.TimerJump.Interval = 2000
        '
        'TimerSummon
        '
        Me.TimerSummon.Enabled = True
        Me.TimerSummon.Interval = 2000
        '
        'Enemy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(120, 61)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Enemy"
        Me.Text = "我是表單"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimerMove As System.Windows.Forms.Timer
    Friend WithEvents TimerMsg As System.Windows.Forms.Timer
    Friend WithEvents TimerInput As System.Windows.Forms.Timer
    Friend WithEvents TimerJump As System.Windows.Forms.Timer
    Public WithEvents Label1 As Label
    Friend WithEvents TimerSummon As Timer
End Class
