<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GatewayControl
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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
        Me.components = New System.ComponentModel.Container
        Me.TimerRec = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TimerSend = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.picRec = New System.Windows.Forms.PictureBox
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker
        Me.picSend = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerRec
        '
        '
        'SerialPort1
        '
        Me.SerialPort1.ReadBufferSize = 8192
        Me.SerialPort1.WriteBufferSize = 4096
        '
        'TimerSend
        '
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'picRec
        '
        Me.picRec.Image = Global.UART_Tool.My.Resources.Resources.XSIMPLESILVER
        Me.picRec.Location = New System.Drawing.Point(31, 21)
        Me.picRec.Name = "picRec"
        Me.picRec.Size = New System.Drawing.Size(15, 15)
        Me.picRec.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRec.TabIndex = 5
        Me.picRec.TabStop = False
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerReportsProgress = True
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'picSend
        '
        Me.picSend.Image = Global.UART_Tool.My.Resources.Resources.XSIMPLESILVER
        Me.picSend.Location = New System.Drawing.Point(31, 6)
        Me.picSend.Name = "picSend"
        Me.picSend.Size = New System.Drawing.Size(15, 15)
        Me.picSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSend.TabIndex = 4
        Me.picSend.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.UART_Tool.My.Resources.Resources.GComputer
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 300
        '
        'GatewayControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.picRec)
        Me.Controls.Add(Me.picSend)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "GatewayControl"
        Me.Size = New System.Drawing.Size(48, 36)
        CType(Me.picRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimerRec As System.Windows.Forms.Timer
    Private WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents TimerSend As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents picRec As System.Windows.Forms.PictureBox
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents picSend As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
