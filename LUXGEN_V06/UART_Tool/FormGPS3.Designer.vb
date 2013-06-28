<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGPS3
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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
        Me.components = New System.ComponentModel.Container()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.AmpControl1 = New UART_Tool.AmpControl()
        Me.UserControl11 = New UART_Tool.UserControl1()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(415, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(214, 26)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "電流表COM 狀態"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(92, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 26)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "COM 啟動狀態"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 26)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "測試治具COM 狀態"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'SerialPort1
        '
        Me.SerialPort1.ReceivedBytesThreshold = 6
        '
        'Timer4
        '
        Me.Timer4.Enabled = True
        Me.Timer4.Interval = 200
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(733, 9)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(91, 19)
        Me.CheckBox2.TabIndex = 21
        Me.CheckBox2.Text = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox7.ForeColor = System.Drawing.Color.Chartreuse
        Me.TextBox7.Location = New System.Drawing.Point(430, 412)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox7.Size = New System.Drawing.Size(399, 145)
        Me.TextBox7.TabIndex = 30
        Me.TextBox7.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(426, 384)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 26)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "訊息視窗"
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox5.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox5.Location = New System.Drawing.Point(430, 330)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(399, 42)
        Me.TextBox5.TabIndex = 26
        Me.TextBox5.TabStop = False
        Me.TextBox5.Text = "韌體版本編號"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox4.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox4.Location = New System.Drawing.Point(430, 281)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(399, 42)
        Me.TextBox4.TabIndex = 25
        Me.TextBox4.TabStop = False
        Me.TextBox4.Text = "版本編號"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox3.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Chartreuse
        Me.TextBox3.Location = New System.Drawing.Point(19, 300)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox3.Size = New System.Drawing.Size(399, 257)
        Me.TextBox3.TabIndex = 24
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "錯誤回報"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox2.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Chartreuse
        Me.TextBox2.Location = New System.Drawing.Point(19, 251)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(399, 42)
        Me.TextBox2.TabIndex = 23
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "測試步驟"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox1.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Chartreuse
        Me.TextBox1.Location = New System.Drawing.Point(19, 202)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(399, 42)
        Me.TextBox1.TabIndex = 22
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "測具狀態"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.MediumBlue
        Me.CheckBox1.Location = New System.Drawing.Point(19, 89)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(182, 33)
        Me.CheckBox1.TabIndex = 31
        Me.CheckBox1.Text = "寫入資料庫"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 26)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "輸入條碼"
        '
        'TextBox9
        '
        Me.TextBox9.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox9.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox9.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox9.Location = New System.Drawing.Point(19, 153)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(399, 42)
        Me.TextBox9.TabIndex = 34
        Me.TextBox9.TabStop = False
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.UART_Tool.My.Resources.Resources.XSIMPLESILVER
        Me.PictureBox1.Location = New System.Drawing.Point(19, 38)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(66, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'AmpControl1
        '
        Me.AmpControl1.Com_Enable = False
        Me.AmpControl1.Com_PortName = "COM1"
        Me.AmpControl1.Location = New System.Drawing.Point(420, 37)
        Me.AmpControl1.Name = "AmpControl1"
        Me.AmpControl1.Size = New System.Drawing.Size(246, 103)
        Me.AmpControl1.TabIndex = 36
        '
        'UserControl11
        '
        Me.UserControl11.BackColor = System.Drawing.Color.Transparent
        Me.UserControl11.DC_AMP = 0.0R
        Me.UserControl11.DC_Barcode = ""
        Me.UserControl11.DC_BurnFlag = False
        Me.UserControl11.DC_BurnTime = New Date(CType(0, Long))
        Me.UserControl11.DC_TestTime = New Date(CType(0, Long))
        Me.UserControl11.Location = New System.Drawing.Point(426, 153)
        Me.UserControl11.Name = "UserControl11"
        Me.UserControl11.Size = New System.Drawing.Size(400, 106)
        Me.UserControl11.TabIndex = 35
        '
        'FormGPS3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 589)
        Me.Controls.Add(Me.AmpControl1)
        Me.Controls.Add(Me.UserControl11)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormGPS3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GPS成品測試"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer4 As System.Windows.Forms.Timer
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents UserControl11 As UART_Tool.UserControl1
    Friend WithEvents AmpControl1 As UART_Tool.AmpControl
End Class
