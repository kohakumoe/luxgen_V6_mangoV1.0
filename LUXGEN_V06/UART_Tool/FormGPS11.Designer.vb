<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGPS11
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGPS11))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.系統SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.說明ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.設定檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.測試TToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.讀取最後一筆DeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.建立新條碼ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.條碼列印測試ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.條碼列印ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.版本測試ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.列印最後一筆條碼ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.AmpControl1 = New UART_Tool.AmpControl
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "測試治具COM 狀態"
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(93, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "COM 啟動狀態"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox1.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Chartreuse
        Me.TextBox1.Location = New System.Drawing.Point(30, 153)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(343, 36)
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
        Me.TextBox2.Location = New System.Drawing.Point(30, 195)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(343, 36)
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
        Me.TextBox3.Location = New System.Drawing.Point(30, 237)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox3.Size = New System.Drawing.Size(343, 221)
        Me.TextBox3.TabIndex = 5
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "錯誤回報"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox4.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox4.Location = New System.Drawing.Point(379, 153)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(343, 36)
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
        Me.TextBox5.Location = New System.Drawing.Point(379, 195)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(343, 36)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(754, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '系統SToolStripMenuItem
        '
        Me.系統SToolStripMenuItem.Name = "系統SToolStripMenuItem"
        Me.系統SToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.系統SToolStripMenuItem.Text = "系統&(S)"
        '
        '說明ToolStripMenuItem
        '
        Me.說明ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.設定檔ToolStripMenuItem})
        Me.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem"
        Me.說明ToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.說明ToolStripMenuItem.Text = "說明&(H)"
        '
        '設定檔ToolStripMenuItem
        '
        Me.設定檔ToolStripMenuItem.Image = Global.UART_Tool.My.Resources.Resources.doc3
        Me.設定檔ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.設定檔ToolStripMenuItem.Name = "設定檔ToolStripMenuItem"
        Me.設定檔ToolStripMenuItem.Size = New System.Drawing.Size(122, 38)
        Me.設定檔ToolStripMenuItem.Text = "設定檔"
        '
        '測試TToolStripMenuItem
        '
        Me.測試TToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.讀取最後一筆DeviceToolStripMenuItem, Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem, Me.建立新條碼ToolStripMenuItem, Me.條碼列印測試ToolStripMenuItem, Me.條碼列印ToolStripMenuItem, Me.版本測試ToolStripMenuItem, Me.列印最後一筆條碼ToolStripMenuItem})
        Me.測試TToolStripMenuItem.Name = "測試TToolStripMenuItem"
        Me.測試TToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.測試TToolStripMenuItem.Text = "測試&(T)"
        '
        '讀取最後一筆DeviceToolStripMenuItem
        '
        Me.讀取最後一筆DeviceToolStripMenuItem.Name = "讀取最後一筆DeviceToolStripMenuItem"
        Me.讀取最後一筆DeviceToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.讀取最後一筆DeviceToolStripMenuItem.Text = "讀取最後一筆Device"
        Me.讀取最後一筆DeviceToolStripMenuItem.Visible = False
        '
        '讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem
        '
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Name = "讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem"
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Text = "讀取最後一筆Device By 產品類別識別碼"
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Visible = False
        '
        '建立新條碼ToolStripMenuItem
        '
        Me.建立新條碼ToolStripMenuItem.Name = "建立新條碼ToolStripMenuItem"
        Me.建立新條碼ToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.建立新條碼ToolStripMenuItem.Text = "建立新條碼"
        '
        '條碼列印測試ToolStripMenuItem
        '
        Me.條碼列印測試ToolStripMenuItem.Name = "條碼列印測試ToolStripMenuItem"
        Me.條碼列印測試ToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.條碼列印測試ToolStripMenuItem.Text = "條碼列印測試"
        '
        '條碼列印ToolStripMenuItem
        '
        Me.條碼列印ToolStripMenuItem.Name = "條碼列印ToolStripMenuItem"
        Me.條碼列印ToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.條碼列印ToolStripMenuItem.Text = "條碼列印"
        '
        '版本測試ToolStripMenuItem
        '
        Me.版本測試ToolStripMenuItem.Name = "版本測試ToolStripMenuItem"
        Me.版本測試ToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.版本測試ToolStripMenuItem.Text = "版本測試"
        Me.版本測試ToolStripMenuItem.Visible = False
        '
        '列印最後一筆條碼ToolStripMenuItem
        '
        Me.列印最後一筆條碼ToolStripMenuItem.Name = "列印最後一筆條碼ToolStripMenuItem"
        Me.列印最後一筆條碼ToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.列印最後一筆條碼ToolStripMenuItem.Text = "列印最後一筆條碼"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.MediumBlue
        Me.CheckBox1.Location = New System.Drawing.Point(30, 112)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(279, 28)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "產生條碼與寫入資料庫"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(375, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(174, 21)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "電流表COM 狀態"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(379, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 21)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "訊息視窗"
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox7.ForeColor = System.Drawing.Color.Chartreuse
        Me.TextBox7.Location = New System.Drawing.Point(383, 266)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox7.Size = New System.Drawing.Size(343, 192)
        Me.TextBox7.TabIndex = 16
        Me.TextBox7.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.UART_Tool.My.Resources.Resources.XSIMPLESILVER
        Me.PictureBox1.Location = New System.Drawing.Point(30, 56)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(57, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(642, 36)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(80, 16)
        Me.CheckBox2.TabIndex = 17
        Me.CheckBox2.Text = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'AmpControl1
        '
        Me.AmpControl1.Com_Enable = False
        Me.AmpControl1.Com_PortName = "COM1"
        Me.AmpControl1.Location = New System.Drawing.Point(379, 59)
        Me.AmpControl1.Name = "AmpControl1"
        Me.AmpControl1.Size = New System.Drawing.Size(211, 88)
        Me.AmpControl1.TabIndex = 18
        '
        'FormGPS11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 477)
        Me.Controls.Add(Me.AmpControl1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormGPS11"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GPS半成品測試"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
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
    Friend WithEvents 列印最後一筆條碼ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
