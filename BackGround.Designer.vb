<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackGround
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
        Me.Label = New System.Windows.Forms.Label()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Font = New System.Drawing.Font("微軟正黑體", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label.ForeColor = System.Drawing.Color.White
        Me.Label.Location = New System.Drawing.Point(12, 9)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(830, 120)
        Me.Label.TabIndex = 0
        Me.Label.Text = "時間：00 分 00 秒"
        '
        'Timer
        '
        Me.Timer.Interval = 10
        '
        'BackGround
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BackGround"
        Me.Text = "我是背景"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents Timer As System.Windows.Forms.Timer
End Class
