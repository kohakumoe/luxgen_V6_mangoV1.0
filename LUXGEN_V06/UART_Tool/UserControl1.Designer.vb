<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DC_MSNStyleForm1 = New ClassLibrary_DC_Controls.DC_MSNStyleForm
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "條碼:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.CadetBlue
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(188, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "靜態電流:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.CadetBlue
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "測試時間:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.CadetBlue
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "完成燒機時間:"
        '
        'DC_MSNStyleForm1
        '
        Me.DC_MSNStyleForm1.BackColor = System.Drawing.Color.DimGray
        Me.DC_MSNStyleForm1.DC_ShowCloseButton = False
        Me.DC_MSNStyleForm1.DC_TextAlignment = ClassLibrary_DC_Controls.DC_MSNStyleForm.TextAlignments.MidCentre
        Me.DC_MSNStyleForm1.DC_TextAsHyperlink = False
        Me.DC_MSNStyleForm1.DC_TextCursorIcon = System.Windows.Forms.Cursors.Default
        Me.DC_MSNStyleForm1.DC_TextForceAntiAlias = False
        Me.DC_MSNStyleForm1.DC_TitleAlignment = System.Drawing.StringAlignment.Near
        Me.DC_MSNStyleForm1.DC_TitleFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.DC_MSNStyleForm1.DC_TitleForceAntiAlias = False
        Me.DC_MSNStyleForm1.DC_TitleForeColor = System.Drawing.Color.MidnightBlue
        Me.DC_MSNStyleForm1.DC_TitleImage = Nothing
        Me.DC_MSNStyleForm1.DC_TitleShadow = False
        Me.DC_MSNStyleForm1.DC_TitleShadowColor = System.Drawing.Color.Black
        Me.DC_MSNStyleForm1.DC_TitleShadowOpacity = 20
        Me.DC_MSNStyleForm1.DC_TitleText = "首次測試報告"
        Me.DC_MSNStyleForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DC_MSNStyleForm1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.DC_MSNStyleForm1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.DC_MSNStyleForm1.Location = New System.Drawing.Point(0, 0)
        Me.DC_MSNStyleForm1.Name = "DC_MSNStyleForm1"
        Me.DC_MSNStyleForm1.Size = New System.Drawing.Size(343, 91)
        Me.DC_MSNStyleForm1.TabIndex = 0
        Me.DC_MSNStyleForm1.Text = "My MSN Alert Text"
        '
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DC_MSNStyleForm1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(343, 91)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DC_MSNStyleForm1 As ClassLibrary_DC_Controls.DC_MSNStyleForm
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
