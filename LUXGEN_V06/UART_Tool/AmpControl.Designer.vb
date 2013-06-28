<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AmpControl
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
        Me.components = New System.ComponentModel.Container
        Me.txtAmp = New System.Windows.Forms.TextBox
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.DC_MSNStyleForm1 = New ClassLibrary_DC_Controls.DC_MSNStyleForm
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAmp
        '
        Me.txtAmp.BackColor = System.Drawing.Color.Black
        Me.txtAmp.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtAmp.Location = New System.Drawing.Point(9, 30)
        Me.txtAmp.Name = "txtAmp"
        Me.txtAmp.Size = New System.Drawing.Size(195, 48)
        Me.txtAmp.TabIndex = 0
        Me.txtAmp.Text = "199.99mA"
        Me.txtAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 19200
        Me.SerialPort1.ReceivedBytesThreshold = 7
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'DC_MSNStyleForm1
        '
        Me.DC_MSNStyleForm1.BackColor = System.Drawing.Color.RoyalBlue
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
        Me.DC_MSNStyleForm1.DC_TitleText = "0~199.99mA DC 數位電流表"
        Me.DC_MSNStyleForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DC_MSNStyleForm1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.DC_MSNStyleForm1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.DC_MSNStyleForm1.Location = New System.Drawing.Point(0, 0)
        Me.DC_MSNStyleForm1.Name = "DC_MSNStyleForm1"
        Me.DC_MSNStyleForm1.Size = New System.Drawing.Size(211, 88)
        Me.DC_MSNStyleForm1.TabIndex = 1
        Me.DC_MSNStyleForm1.Text = "DC_MSNStyleForm1"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Black
        Me.PictureBox2.Image = Global.UART_Tool.My.Resources.Resources.Red_light
        Me.PictureBox2.Location = New System.Drawing.Point(10, 31)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(21, 20)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Image = Global.UART_Tool.My.Resources.Resources.Green_light
        Me.PictureBox1.Location = New System.Drawing.Point(10, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'AmpControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtAmp)
        Me.Controls.Add(Me.DC_MSNStyleForm1)
        Me.Name = "AmpControl"
        Me.Size = New System.Drawing.Size(211, 88)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAmp As System.Windows.Forms.TextBox
    Friend WithEvents DC_MSNStyleForm1 As ClassLibrary_DC_Controls.DC_MSNStyleForm
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

End Class
