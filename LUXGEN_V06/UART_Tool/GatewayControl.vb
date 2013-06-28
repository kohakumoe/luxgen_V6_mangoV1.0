
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class GatewayControl

    Enum ReceivedDataTypeEnum
        TYPE_BYTE = 0
        TYPE_STRING = 1
    End Enum
    '計算滑鼠指標偏移變數
    Private mouse_offset As Drawing.Point
    ''' <summary>
    ''' ComPort直接接收到的Byte資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Com_ReceivedData As New Queue(Of Byte)
    ''' <summary>
    ''' ComPort直接接收到的String資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Com_ReceivedDataString As String
    ''' <summary>
    ''' 透過PLC類型解譯後，所接收到的資料
    ''' </summary>
    ''' <remarks></remarks>
    Public PLC_ReceivedData As New Queue(Of Byte)
    '紀錄當前傳送命令時所使用的PLC_TYPE
    Private Current_PLC_Type As PLC_TYPE
    '用來放置多項命令的暫存區塊
    Private CommandQueue As New Queue
    Private AsyncCommandIsBusy As Boolean = False

    Private Sub GatewayControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GatewayControl_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.ComPortClose()
    End Sub

    Private Sub GatewayControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, PictureBox1.MouseDown
        mouse_offset = New Drawing.Point(-e.X - Me.Parent.Location.X + Me.Offset_X, -e.Y - Me.Parent.Location.Y + Me.Offset_Y)
    End Sub

    Private Sub GatewayControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, PictureBox1.MouseMove
        If Me.UserMove = False Then Exit Sub
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim mousePos As Drawing.Point = MousePosition
            mousePos.Offset(mouse_offset.X, mouse_offset.Y)
            Me.Location = mousePos
        End If
    End Sub

#Region " 接收Com資料 "
    'TODO:序列埠事件
    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        If _ReceivedDataType = ReceivedDataTypeEnum.TYPE_BYTE Then
            'System.Threading.Thread.Sleep(100)
            Me.Com_ReceivedData.Enqueue(Me.SerialPort1.ReadByte)
            'If Me.Com_ReceivedData <> "" Then
            '    '回報狀態
            If Me.BackgroundWorker2.IsBusy = False Then
                Me.BackgroundWorker2.RunWorkerAsync(Me)
            End If
            'Else
            '    Me.PLC_ReceivedData = "NoAnswer"
            'End If

            Dim mi As New Windows.Forms.MethodInvoker(AddressOf DataReceived)
            Me.BeginInvoke(mi)
        ElseIf _ReceivedDataType = ReceivedDataTypeEnum.TYPE_STRING Then
            System.Threading.Thread.Sleep(200)
            Com_ReceivedDataString = Me.SerialPort1.ReadExisting
            Dim mi As New Windows.Forms.MethodInvoker(AddressOf DataReceived)
            Me.BeginInvoke(mi)
        End If
    End Sub

    Private Sub SerialPort1_ErrorReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles SerialPort1.ErrorReceived
        RaiseEvent Gateway_ErrorEvent(Me, New Gateway_ErrorEventArgs(e.ToString))
    End Sub

    Private Sub SerialPort1_PinChanged(ByVal sender As Object, ByVal e As System.IO.Ports.SerialPinChangedEventArgs) Handles SerialPort1.PinChanged

    End Sub

    Private Sub DataReceived()

        RaiseEvent Gateway_ComDataReceivedEvent(Me, New System.EventArgs)

    End Sub

#End Region

#Region " 燈號顯示 "
    'TODO:燈號顯示

    Private Sub Light_Send()
        Me.picSend.Image = My.Resources.XSIMPLEGREEN
        Me.TimerSend.Enabled = True
    End Sub

    Private Sub TimerSend_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSend.Tick
        Me.TimerSend.Enabled = False
        Me.picSend.Image = My.Resources.XSIMPLESILVER
    End Sub

    Private Sub Light_Rec( _
        ByVal worker As System.ComponentModel.BackgroundWorker, _
        ByVal e As System.ComponentModel.DoWorkEventArgs _
    )
        Me.picRec.Image = My.Resources.XSIMPLEGREEN
        System.Threading.Thread.Sleep(50)
        Me.picRec.Image = My.Resources.XSIMPLESILVER
    End Sub

#End Region

#Region " Propertys "
    'TODO:屬性

    Private m_user_move As Boolean = False
    ''' <summary>
    ''' 屬性::取得或設定使用者是否可在RunTime移動控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("使用者是否可在RunTime移動控制項")> _
    Public Property UserMove() As Boolean
        Get
            Return m_user_move
        End Get
        Set(ByVal value As Boolean)
            m_user_move = value
        End Set
    End Property
    Private m_offset_x As Integer = -3
    ''' <summary>
    ''' 屬性::取得或設定拖拉控制項時的X軸偏移量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("拖拉控制項時的X軸偏移量，在XP作業系統預設為-3(視窗的寬度)")> _
    Public Property Offset_X() As Integer
        Get
            Return m_offset_x
        End Get
        Set(ByVal value As Integer)
            m_offset_x = value
        End Set
    End Property

    Private m_offset_y As Integer = -30
    ''' <summary>
    ''' 屬性::取得或設定拖拉控制項時的Y軸偏移量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("拖拉控制項時的Y軸偏移量，在XP作業系統預設為-30(視窗的高度)")> Public Property Offset_Y() As Integer
        Get
            Return m_offset_y
        End Get
        Set(ByVal value As Integer)
            m_offset_y = value
        End Set
    End Property

    Private m_use_defaule_com_setting As Boolean = False
    ''' <summary>
    ''' 屬性::取得或設定是否使用預設Com設定
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否使用預設Com設定，當設定為True時每次與RS232通訊時，會自動套用各種PLC預設的通訊協定")> _
    Public Property Use_Defaule_Com_Setting() As Boolean
        Get
            Return m_use_defaule_com_setting
        End Get
        Set(ByVal value As Boolean)
            m_use_defaule_com_setting = value
        End Set
    End Property
    ''' <summary>
    ''' 屬性::取得或設定序列埠要使用的傳輸速率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("序列埠要使用的傳輸速率")> _
    Public Property Com_BaudRate() As Integer
        Get
            Return Me.SerialPort1.BaudRate
        End Get
        Set(ByVal value As Integer)
            Me.SerialPort1.BaudRate = value
        End Set
    End Property
    ''' <summary>
    ''' 屬性::取得或設定每一傳送/接收位元組的資料位元數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("每一傳送/接收位元組的資料位元數")> _
    Public Property Com_DataBits() As Integer
        Get
            Return Me.SerialPort1.DataBits
        End Get
        Set(ByVal value As Integer)
            Me.SerialPort1.DataBits = value
        End Set
    End Property
    ''' <summary>
    ''' 屬性::取得或設定同位檢查方式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("同位檢查方式")> _
    Public Property Com_Parity() As System.IO.Ports.Parity
        Get
            Return Me.SerialPort1.Parity
        End Get
        Set(ByVal value As System.IO.Ports.Parity)
            Me.SerialPort1.Parity = value
        End Set
    End Property
    ''' <summary>
    ''' 屬性::取得或設定通訊埠的名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("通訊埠的名稱")> _
    Public Property Com_PortName() As String
        Get
            Return Me.SerialPort1.PortName
        End Get
        Set(ByVal value As String)
            Me.SerialPort1.PortName = value
        End Set
    End Property
    ''' <summary>
    ''' 屬性::取得或設定每一傳送/接收位元組的停止位元數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("每一傳送/接收位元組的停止位元數")> _
    Public Property Com_StopBits() As System.IO.Ports.StopBits
        Get
            Return Me.SerialPort1.StopBits
        End Get
        Set(ByVal value As System.IO.Ports.StopBits)
            Me.SerialPort1.StopBits = value
        End Set
    End Property
    ''' <summary>
    ''' 屬性::取得Com物件的開啟／關閉狀態
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("Com物件的開啟／關閉狀態，這是唯讀屬性")> _
    Public ReadOnly Property Com_IsOpen() As Boolean
        Get
            Return Me.SerialPort1.IsOpen
        End Get
    End Property
    Private _ReceivedDataType As ReceivedDataTypeEnum = ReceivedDataTypeEnum.TYPE_BYTE
    ''' <summary>
    ''' 屬性::設定Com物件接收資料的型別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Com_ReceivedDataType() As ReceivedDataTypeEnum
        Get
            Return _ReceivedDataType
        End Get
        Set(ByVal value As ReceivedDataTypeEnum)
            _ReceivedDataType = value
        End Set
    End Property
    ''' <summary>
    ''' 屬性::設定Com物件DtrEnable
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Com_DtrEnable() As Boolean
        Get
            Return Me.SerialPort1.DtrEnable
        End Get
        Set(ByVal value As Boolean)
            Me.SerialPort1.DtrEnable = value
        End Set
    End Property
    ''' <summary>
    ''' 屬性::設定Com物件RtsEnable
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Com_RtsEnable() As Boolean
        Get
            Return Me.SerialPort1.RtsEnable
        End Get
        Set(ByVal value As Boolean)
            Me.SerialPort1.RtsEnable = value
        End Set
    End Property
#End Region

#Region " Events "
    'TODO:事件

    Public Delegate Sub Gateway_ComDataReceivedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' 事件::Com物件接收回傳資料完成事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Event Gateway_ComDataReceivedEvent As Gateway_ComDataReceivedEventHandler

    'Public Delegate Sub Gateway_PLCDataReceivedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    '''' <summary>
    '''' 事件::PLC接收回傳資料完成事件
    '''' </summary>
    '''' <remarks></remarks>
    'Public Event Gateway_PLCDataReceivedEvent As Gateway_PLCDataReceivedEventHandler

    Public Delegate Sub Gateway_ErrorEventHandler(ByVal sender As Object, ByVal e As Gateway_ErrorEventArgs)
    ''' <summary>
    ''' 事件::錯誤發生時所引發的事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Event Gateway_ErrorEvent As Gateway_ErrorEventHandler
#End Region

#Region " Methods "
    'TODO:方法

#Region " 開啟Com連線 "
    ''' <summary>
    ''' 方法::開啟Com連線
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ComPortOpen()
        Try
            If Me.SerialPort1.IsOpen = False Then Me.SerialPort1.Open()
        Catch ex As Exception
            RaiseEvent Gateway_ErrorEvent(Me, New Gateway_ErrorEventArgs(ex.ToString))
        End Try
    End Sub
#End Region

#Region " 關閉Com連線 "
    ''' <summary>
    ''' 方法::關閉Com連線
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ComPortClose()
        Try
            If Me.SerialPort1.IsOpen = True Then Me.SerialPort1.Close()
        Catch ex As Exception
            RaiseEvent Gateway_ErrorEvent(Me, New Gateway_ErrorEventArgs(ex.ToString))
        End Try
    End Sub
#End Region

#Region " 更改Com設定 "
    Private Sub ChangeComSetting(ByVal plc_type As PLC_TYPE)
        'TODO:針對不同PLC更改Com設定
        Select Case plc_type
            Case GatewayControl.PLC_TYPE.TYPE_OMRON_CQM1_CPM1
                Me.Com_BaudRate = 9600
                Me.Com_DataBits = 7
                Me.Com_Parity = IO.Ports.Parity.Even
                Me.Com_StopBits = IO.Ports.StopBits.Two
            Case GatewayControl.PLC_TYPE.TYPE_MITSUBISHI_A
                Me.Com_BaudRate = 2400
                Me.Com_DataBits = 8
                Me.Com_Parity = IO.Ports.Parity.Even
                Me.Com_StopBits = IO.Ports.StopBits.Two
        End Select
    End Sub
#End Region

#Region " 傳送命令方法 "
    ''' <summary>
    ''' 方法::通用傳送指令方法
    ''' </summary>
    ''' <param name="cmd"></param>
    ''' <remarks></remarks>
    Public Sub SendCommand(ByVal cmd As Byte, ByVal CRLF As Boolean)
        Me.CommandQueue.Enqueue(cmd)
        If CRLF = True Then
            Me.CommandQueue.Enqueue(vbCrLf)
        End If
        'If Me.AsyncCommandIsBusy = False Then
        '    Me.StartThread()
        'End If
    End Sub

    Private Overloads Sub AsyncSendCommand()
        Try
            If Me.CommandQueue.Count = 0 Then Exit Sub
            Me.AsyncCommandIsBusy = True

            'Me.ComPortClose()

            'Me.ComPortOpen()
            
            Me.SerialPort1.Write(Me.CommandQueue.Dequeue)

            '顯示燈號
            Me.Light_Send()

        Catch ex As Exception
            RaiseEvent Gateway_ErrorEvent(Me, New Gateway_ErrorEventArgs(ex.ToString))
        Finally
            Me.AsyncCommandIsBusy = False
            If Me.CommandQueue.Count > 0 Then
                'System.Threading.Thread.Sleep(100)
                AsyncSendCommand()
            End If
        End Try
    End Sub

    '啟動執行緒
    Public Sub StartThread()
        If Me.BackgroundWorker1.IsBusy = False Then Me.BackgroundWorker1.RunWorkerAsync(Me)
    End Sub

    Private Overloads Sub AsyncSendCommand( _
        ByVal worker As System.ComponentModel.BackgroundWorker, _
        ByVal e As System.ComponentModel.DoWorkEventArgs _
    )
        Try
            'If Me.CommandQueue.Count = 0 Then Exit Sub
            'Dim cmd_text As Byte = Me.CommandQueue.Dequeue
            Me.SerialPort1.Close()
            System.Threading.Thread.Sleep(50)
            Me.SerialPort1.Open()

            'Me.SerialPort1.Write(cmd_text)
            'If Me.CommandQueue.Count >= 8 Then
            Dim bf(8) As Byte
            bf(0) = &H1
            bf(1) = &H3
            bf(2) = &H0
            bf(3) = &H2A
            bf(4) = &H0
            bf(5) = &H1
            bf(6) = 165
            bf(7) = 194
            Me.SerialPort1.Write(bf, 0, 8)
            'End If
            '顯示燈號
            Me.picSend.Image = My.Resources.XSIMPLEGREEN
            '等待
            'System.Threading.Thread.Sleep(150)
            '顯示燈號
            Me.picSend.Image = My.Resources.XSIMPLESILVER
            ''接收回傳值
            'Me.Com_ReceivedData = Me.SerialPort1.ReadExisting
            ''判斷回傳值
            'If Me.Com_ReceivedData <> "" Then
            '    '回報狀態
            '    worker.ReportProgress(100)
            'Else
            '    Me.PLC_ReceivedData = "NoAnswer"
            'End If

            System.Threading.Thread.Sleep(100)
        Catch ex As Exception
            RaiseEvent Gateway_ErrorEvent(Me, New Gateway_ErrorEventArgs(ex.ToString))
        Finally

        End Try
    End Sub

#End Region

#Region " 終止方法 "
    Public Sub StopSendCommand()
        Me.CommandQueue.Clear()
    End Sub
#End Region

#End Region

#Region " Enum "
    'TODO:列舉PLC型別
    Enum PLC_TYPE
        TYPE_NONE = 0
        TYPE_OMRON_CQM1_CPM1 = 1
        TYPE_MITSUBISHI_A = 2
        TYPE_PFM2_MODBUS = 3
    End Enum
#End Region

#Region " Class "

    Public Class Gateway_ErrorEventArgs
        Inherits System.EventArgs

        Public Sub New(ByVal error_message As String)
            Me.ErrorMessage = error_message
        End Sub

        Private m_error_message As String
        Public Property ErrorMessage() As String
            Get
                Return m_error_message
            End Get
            Set(ByVal value As String)
                m_error_message = value
            End Set
        End Property
    End Class
#End Region

#Region " 背景執行緒 "
    'TODO:背景執行緒

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)

        ' Get the Works object and call the main method.
        Dim WC As GatewayControl = CType(e.Argument, GatewayControl)
        'System.Threading.Thread.Sleep(100)
        WC.AsyncSendCommand(worker, e)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If Me.BackgroundWorker2.IsBusy = False Then
            Me.BackgroundWorker2.RunWorkerAsync(Me)
        End If
        '引發事件
        RaiseEvent Gateway_ComDataReceivedEvent(Me, New System.EventArgs)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.StartThread()
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)

        ' Get the Works object and call the main method.
        Dim WC As GatewayControl = CType(e.Argument, GatewayControl)
        WC.Light_Rec(worker, e)
    End Sub

#End Region

    Private Sub TimerRec_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRec.Tick

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If Me.Com_IsOpen = False Then
        '    Exit Sub
        'End If

        Dim cmd(7) As Byte
        cmd(0) = &H1
        cmd(1) = &H3
        cmd(2) = &H0
        cmd(3) = &H2A
        cmd(4) = &H0
        cmd(5) = &H1
        cmd(6) = 165
        cmd(7) = 194

        Me.SendCommand(cmd(0), False)
        Me.SendCommand(cmd(1), False)
        Me.SendCommand(cmd(2), False)
        Me.SendCommand(cmd(3), False)
        Me.SendCommand(cmd(4), False)
        Me.SendCommand(cmd(5), False)
        Me.SendCommand(cmd(6), False)
        Me.SendCommand(cmd(7), False)
    End Sub

End Class
