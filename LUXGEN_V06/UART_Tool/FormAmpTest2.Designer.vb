﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAmpTest2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAmpTest2))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.系統SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.說明ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.測試TToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.讀取最後一筆DeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.建立新條碼ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.條碼列印測試ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.Button2 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.設定檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AmpControl1 = New UART_Tool.AmpControl
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.系統SToolStripMenuItem, Me.說明ToolStripMenuItem, Me.測試TToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(404, 24)
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
        '測試TToolStripMenuItem
        '
        Me.測試TToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.讀取最後一筆DeviceToolStripMenuItem, Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem, Me.建立新條碼ToolStripMenuItem, Me.條碼列印測試ToolStripMenuItem})
        Me.測試TToolStripMenuItem.Name = "測試TToolStripMenuItem"
        Me.測試TToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.測試TToolStripMenuItem.Text = "測試&(T)"
        '
        '讀取最後一筆DeviceToolStripMenuItem
        '
        Me.讀取最後一筆DeviceToolStripMenuItem.Name = "讀取最後一筆DeviceToolStripMenuItem"
        Me.讀取最後一筆DeviceToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.讀取最後一筆DeviceToolStripMenuItem.Text = "讀取最後一筆Device"
        '
        '讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem
        '
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Name = "讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem"
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Text = "讀取最後一筆Device By 產品類別識別碼"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 21)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "電流狀態"
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.SystemColors.ControlText
        Me.TextBox6.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBox6.Location = New System.Drawing.Point(30, 160)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(343, 36)
        Me.TextBox6.TabIndex = 11
        Me.TextBox6.TabStop = False
        Me.TextBox6.Text = "0mA"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(298, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(298, 69)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(271, 136)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(39, 16)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Fix"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(34, 105)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(49, 16)
        Me.CheckBox2.TabIndex = 16
        Me.CheckBox2.Text = "Error"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        '設定檔ToolStripMenuItem
        '
        Me.設定檔ToolStripMenuItem.Image = Global.UART_Tool.My.Resources.Resources.doc3
        Me.設定檔ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.設定檔ToolStripMenuItem.Name = "設定檔ToolStripMenuItem"
        Me.設定檔ToolStripMenuItem.Size = New System.Drawing.Size(122, 38)
        Me.設定檔ToolStripMenuItem.Text = "設定檔"
        '
        'AmpControl1
        '
        Me.AmpControl1.Com_Enable = False
        Me.AmpControl1.Com_PortName = "COM6"
        Me.AmpControl1.Location = New System.Drawing.Point(81, 244)
        Me.AmpControl1.Name = "AmpControl1"
        Me.AmpControl1.Size = New System.Drawing.Size(211, 88)
        Me.AmpControl1.TabIndex = 17
        '
        'FormAmpTest2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 390)
        Me.Controls.Add(Me.AmpControl1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAmpTest2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GPS半成品測試"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 系統SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 說明ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 設定檔ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents 測試TToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 讀取最後一筆DeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 建立新條碼ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 條碼列印測試ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents AmpControl1 As UART_Tool.AmpControl
End Class
