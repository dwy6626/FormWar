<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Results
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
        Me.LabelAward = New System.Windows.Forms.Label()
        Me.LabelClose = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelAward
        '
        Me.LabelAward.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabelAward.Location = New System.Drawing.Point(12, 9)
        Me.LabelAward.Name = "LabelAward"
        Me.LabelAward.Size = New System.Drawing.Size(588, 495)
        Me.LabelAward.TabIndex = 0
        Me.LabelAward.Text = "1111"
        Me.LabelAward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelClose
        '
        Me.LabelClose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelClose.AutoSize = True
        Me.LabelClose.Font = New System.Drawing.Font("微軟正黑體", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LabelClose.ForeColor = System.Drawing.Color.Navy
        Me.LabelClose.Location = New System.Drawing.Point(211, 481)
        Me.LabelClose.Name = "LabelClose"
        Me.LabelClose.Size = New System.Drawing.Size(172, 25)
        Me.LabelClose.TabIndex = 1
        Me.LabelClose.Text = "滑鼠雙擊此處關閉"
        '
        'Results
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 538)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelClose)
        Me.Controls.Add(Me.LabelAward)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(628, 577)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(628, 577)
        Me.Name = "Results"
        Me.Text = "過關獎勵"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelAward As System.Windows.Forms.Label
    Friend WithEvents LabelClose As System.Windows.Forms.Label
End Class
