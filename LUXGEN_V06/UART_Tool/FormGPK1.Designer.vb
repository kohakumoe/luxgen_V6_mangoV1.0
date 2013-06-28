<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGPK1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGPK1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.系統SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.刪除條碼ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.關閉ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.說明ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.設定檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.測試TToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.讀取最後一筆DeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.建立新條碼ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.條碼列印測試ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.條碼列印ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.版本測試ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.AmpControl1 = New UART_Tool.AmpControl()
        Me.check2 = New System.Windows.Forms.Label()
        Me.check1 = New System.Windows.Forms.Label()
        Me.cmbox2 = New System.Windows.Forms.ComboBox()
        Me.cmbox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'SerialPort1
        '
        Me.SerialPort1.ReceivedBytesThreshold = 6
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(108, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 26)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "COM 啟動狀態"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox1.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Chartreuse
        Me.TextBox1.Location = New System.Drawing.Point(35, 178)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(399, 42)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "測具狀態"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox2.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Chartreuse
        Me.TextBox2.Location = New System.Drawing.Point(35, 227)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(399, 42)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "測試步驟"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox3.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Chartreuse
        Me.TextBox3.Location = New System.Drawing.Point(35, 276)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox3.Size = New System.Drawing.Size(399, 257)
        Me.TextBox3.TabIndex = 5
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "錯誤回報"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox4.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox4.Location = New System.Drawing.Point(537, 178)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(399, 42)
        Me.TextBox4.TabIndex = 6
        Me.TextBox4.TabStop = False
        Me.TextBox4.Text = "版本編號"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox5.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox5.Location = New System.Drawing.Point(537, 226)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(399, 42)
        Me.TextBox5.TabIndex = 7
        Me.TextBox5.TabStop = False
        Me.TextBox5.Text = "韌體版本編號"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.系統SToolStripMenuItem, Me.說明ToolStripMenuItem, Me.測試TToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 27)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '系統SToolStripMenuItem
        '
        Me.系統SToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.刪除條碼ToolStripMenuItem, Me.關閉ToolStripMenuItem})
        Me.系統SToolStripMenuItem.Name = "系統SToolStripMenuItem"
        Me.系統SToolStripMenuItem.Size = New System.Drawing.Size(70, 23)
        Me.系統SToolStripMenuItem.Text = "系統&(S)"
        '
        '刪除條碼ToolStripMenuItem
        '
        Me.刪除條碼ToolStripMenuItem.Name = "刪除條碼ToolStripMenuItem"
        Me.刪除條碼ToolStripMenuItem.Size = New System.Drawing.Size(138, 24)
        Me.刪除條碼ToolStripMenuItem.Text = "刪除條碼"
        '
        '關閉ToolStripMenuItem
        '
        Me.關閉ToolStripMenuItem.Name = "關閉ToolStripMenuItem"
        Me.關閉ToolStripMenuItem.Size = New System.Drawing.Size(138, 24)
        Me.關閉ToolStripMenuItem.Text = "關閉"
        '
        '說明ToolStripMenuItem
        '
        Me.說明ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.設定檔ToolStripMenuItem})
        Me.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem"
        Me.說明ToolStripMenuItem.Size = New System.Drawing.Size(72, 23)
        Me.說明ToolStripMenuItem.Text = "說明&(H)"
        '
        '設定檔ToolStripMenuItem
        '
        Me.設定檔ToolStripMenuItem.Image = Global.UART_Tool.My.Resources.Resources.doc3
        Me.設定檔ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.設定檔ToolStripMenuItem.Name = "設定檔ToolStripMenuItem"
        Me.設定檔ToolStripMenuItem.Size = New System.Drawing.Size(139, 38)
        Me.設定檔ToolStripMenuItem.Text = "設定檔"
        '
        '測試TToolStripMenuItem
        '
        Me.測試TToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.讀取最後一筆DeviceToolStripMenuItem, Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem, Me.建立新條碼ToolStripMenuItem, Me.條碼列印測試ToolStripMenuItem, Me.條碼列印ToolStripMenuItem, Me.版本測試ToolStripMenuItem})
        Me.測試TToolStripMenuItem.Name = "測試TToolStripMenuItem"
        Me.測試TToolStripMenuItem.Size = New System.Drawing.Size(69, 23)
        Me.測試TToolStripMenuItem.Text = "測試&(T)"
        '
        '讀取最後一筆DeviceToolStripMenuItem
        '
        Me.讀取最後一筆DeviceToolStripMenuItem.Name = "讀取最後一筆DeviceToolStripMenuItem"
        Me.讀取最後一筆DeviceToolStripMenuItem.Size = New System.Drawing.Size(344, 24)
        Me.讀取最後一筆DeviceToolStripMenuItem.Text = "讀取最後一筆Device"
        '
        '讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem
        '
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Name = "讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem"
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Size = New System.Drawing.Size(344, 24)
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Text = "讀取最後一筆Device By 產品類別識別碼"
        '
        '建立新條碼ToolStripMenuItem
        '
        Me.建立新條碼ToolStripMenuItem.Name = "建立新條碼ToolStripMenuItem"
        Me.建立新條碼ToolStripMenuItem.Size = New System.Drawing.Size(344, 24)
        Me.建立新條碼ToolStripMenuItem.Text = "建立新條碼"
        '
        '條碼列印測試ToolStripMenuItem
        '
        Me.條碼列印測試ToolStripMenuItem.Name = "條碼列印測試ToolStripMenuItem"
        Me.條碼列印測試ToolStripMenuItem.Size = New System.Drawing.Size(344, 24)
        Me.條碼列印測試ToolStripMenuItem.Text = "條碼列印測試"
        '
        '條碼列印ToolStripMenuItem
        '
        Me.條碼列印ToolStripMenuItem.Name = "條碼列印ToolStripMenuItem"
        Me.條碼列印ToolStripMenuItem.Size = New System.Drawing.Size(344, 24)
        Me.條碼列印ToolStripMenuItem.Text = "條碼列印"
        '
        '版本測試ToolStripMenuItem
        '
        Me.版本測試ToolStripMenuItem.Name = "版本測試ToolStripMenuItem"
        Me.版本測試ToolStripMenuItem.Size = New System.Drawing.Size(344, 24)
        Me.版本測試ToolStripMenuItem.Text = "版本測試"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.MediumBlue
        Me.CheckBox1.Location = New System.Drawing.Point(35, 131)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(332, 33)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "產生條碼與寫入資料庫"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'SerialPort2
        '
        Me.SerialPort2.BaudRate = 19200
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(545, 276)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 26)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "訊息視窗"
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox7.ForeColor = System.Drawing.Color.Chartreuse
        Me.TextBox7.Location = New System.Drawing.Point(537, 311)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox7.Size = New System.Drawing.Size(399, 223)
        Me.TextBox7.TabIndex = 16
        Me.TextBox7.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.UART_Tool.My.Resources.Resources.XSIMPLESILVER
        Me.PictureBox1.Location = New System.Drawing.Point(35, 65)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(66, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(869, 227)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(91, 19)
        Me.CheckBox2.TabIndex = 17
        Me.CheckBox2.Text = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'AmpControl1
        '
        Me.AmpControl1.Com_Enable = False
        Me.AmpControl1.Com_PortName = "COM1"
        Me.AmpControl1.Location = New System.Drawing.Point(537, 72)
        Me.AmpControl1.Name = "AmpControl1"
        Me.AmpControl1.Size = New System.Drawing.Size(246, 103)
        Me.AmpControl1.TabIndex = 18
        '
        'check2
        '
        Me.check2.Font = New System.Drawing.Font("新細明體", 15.02609!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.check2.Location = New System.Drawing.Point(866, 35)
        Me.check2.Name = "check2"
        Me.check2.Size = New System.Drawing.Size(171, 29)
        Me.check2.TabIndex = 28
        Me.check2.Text = "未連接"
        '
        'check1
        '
        Me.check1.Font = New System.Drawing.Font("新細明體", 15.02609!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.check1.Location = New System.Drawing.Point(358, 34)
        Me.check1.Name = "check1"
        Me.check1.Size = New System.Drawing.Size(168, 32)
        Me.check1.TabIndex = 27
        Me.check1.Text = "未連接"
        '
        'cmbox2
        '
        Me.cmbox2.Font = New System.Drawing.Font("新細明體", 11.89565!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbox2.FormattingEnabled = True
        Me.cmbox2.Location = New System.Drawing.Point(730, 35)
        Me.cmbox2.Name = "cmbox2"
        Me.cmbox2.Size = New System.Drawing.Size(121, 27)
        Me.cmbox2.TabIndex = 26
        '
        'cmbox
        '
        Me.cmbox.Font = New System.Drawing.Font("新細明體", 11.89565!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbox.FormattingEnabled = True
        Me.cmbox.Location = New System.Drawing.Point(231, 33)
        Me.cmbox.Name = "cmbox"
        Me.cmbox.Size = New System.Drawing.Size(121, 27)
        Me.cmbox.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(532, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 26)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "電流表COM "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 26)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "測試治具COM "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(59, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(8, 8)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormGPK1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 559)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.check2)
        Me.Controls.Add(Me.check1)
        Me.Controls.Add(Me.cmbox2)
        Me.Controls.Add(Me.cmbox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AmpControl1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormGPK1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GPK半成品測試"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 系統SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 說明ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 設定檔ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents SerialPort2 As System.IO.Ports.SerialPort
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents 測試TToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 讀取最後一筆DeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 建立新條碼ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents 條碼列印測試ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AmpControl1 As UART_Tool.AmpControl
    Friend WithEvents 條碼列印ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 版本測試ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 刪除條碼ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents check2 As System.Windows.Forms.Label
    Friend WithEvents check1 As System.Windows.Forms.Label
    Friend WithEvents cmbox2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents 關閉ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
