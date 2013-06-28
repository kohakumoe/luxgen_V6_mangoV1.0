
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class AmpControl
    Dim send_flag As Boolean = False
    Dim amp_buffer(10) As Byte
    Dim fix_count As Int32
    Dim temp_amp As Double

    Private Sub AmpControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.BackgroundWorker1.IsBusy = False Then Me.BackgroundWorker1.RunWorkerAsync(Me)
    End Sub


#Region " Properties "
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

    Private _Com_Enable As Boolean = False
    ''' <summary>
    ''' 屬性::取得或設定是否開始通訊
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Com_Enable() As Boolean
        Get
            Return _Com_Enable
        End Get
        Set(ByVal value As Boolean)
            _Com_Enable = value
        End Set
    End Property

    Private _Amp_Value As Double = 0
    Public ReadOnly Property Amp_Value() As Double
        Get
            Return _Amp_Value
        End Get
    End Property

    Private _Amp_Fix As Boolean = False
    Public ReadOnly Property Amp_Fix() As Boolean
        Get
            Return _Amp_Fix
        End Get
    End Property

#End Region

#Region " Events "
    Event Amp_Value_Fix_Event(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

#Region " Methods "

#Region " 表頭通訊 "
    Private Sub Amp_Command( _
        ByVal worker As System.ComponentModel.BackgroundWorker, _
        ByVal e As System.ComponentModel.DoWorkEventArgs _
    )
        System.Threading.Thread.Sleep(50)
        If _Com_Enable = False Then
            Exit Sub
        End If

        If send_flag = True Then
            Exit Sub
        End If
        'Check Data
        If amp_buffer(0) = 1 AndAlso amp_buffer(1) = 3 Then
            Me._Amp_Value = (amp_buffer(3) * 256 + amp_buffer(4)) / 100

            If temp_amp <> Me._Amp_Value Then
                fix_count = 0
                temp_amp = Me._Amp_Value
            Else
                fix_count += 1
            End If
            worker.ReportProgress(50)
        Else
            worker.ReportProgress(60)
        End If


        'Send Command
        System.Threading.Thread.Sleep(50)
        Try
            Me.SerialPort1.Open()
            send_flag = True

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
        Catch ex As Exception

        End Try
       
    End Sub
#End Region

#Region " CRC16_Check_Amp "
    Private Function CRC16_Check_Amp(ByVal data() As Byte) As Boolean
        Dim b() As Byte = CRC16(data, 5)
        If b(0) = data(6) AndAlso b(1) = data(5) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function CRC16(ByVal data() As Byte, ByVal len As Integer) As Byte()
        Dim CRC16Lo As Byte, CRC16Hi As Byte   'CRC暫存器
        Dim CL As Byte, CH As Byte        '多項式碼&HA001
        Dim SaveHi As Byte, SaveLo As Byte
        Dim i As Integer
        Dim Flag As Integer
        CRC16Lo = &HFF
        CRC16Hi = &HFF
        CL = &H1
        CH = &HA0
        For i = 0 To len - 1
            CRC16Lo = CRC16Lo Xor data(i) '每一個資料與CRC暫存器進行異或
            For Flag = 0 To 7
                SaveHi = CRC16Hi
                SaveLo = CRC16Lo
                CRC16Hi = CRC16Hi \ 2      '高位右移一位
                CRC16Lo = CRC16Lo \ 2      '低位右移一位
                If ((SaveHi And &H1) = &H1) Then '如果高位字節最後一位為1
                    CRC16Lo = CRC16Lo Or &H80   '則低位字節右移後前面補1
                End If              '否則自動補0
                If ((SaveLo And &H1) = &H1) Then '如果LSB為1，則與多項式碼進行異或
                    CRC16Hi = CRC16Hi Xor CH
                    CRC16Lo = CRC16Lo Xor CL
                End If
            Next Flag
        Next i
        Dim ReturnData(1) As Byte
        ReturnData(0) = CRC16Hi       'CRC高位
        ReturnData(1) = CRC16Lo       'CRC低位
        Return ReturnData
    End Function
#End Region

#End Region

#Region " BackgroundWorker "

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)

        ' Get the Works object and call the main method.
        Dim WC As AmpControl = CType(e.Argument, AmpControl)

        WC.Amp_Command(worker, e)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If e.ProgressPercentage = 50 Then
            Me.txtAmp.Text = Format(Me._Amp_Value, "0.00") & " mA"

            If fix_count >= 3 Then
                fix_count = 3
                If _Amp_Fix = False Then
                    _Amp_Fix = True
                    RaiseEvent Amp_Value_Fix_Event(Me, New System.EventArgs)
                End If
                Me.PictureBox1.Visible = True
                _Amp_Fix = True
            Else
                Me.PictureBox1.Visible = False
                If _Amp_Fix = True Then
                    _Amp_Fix = False
                    RaiseEvent Amp_Value_Fix_Event(Me, New System.EventArgs)
                End If
                _Amp_Fix = False
            End If
            Me.PictureBox2.Visible = False
        ElseIf e.ProgressPercentage = 60 Then
            Me.PictureBox2.Visible = True
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If Me.BackgroundWorker1.IsBusy = False Then Me.BackgroundWorker1.RunWorkerAsync(Me)
    End Sub
#End Region

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        System.Threading.Thread.Sleep(50)

        For i As Int32 = 0 To 6
            amp_buffer(i) = Me.SerialPort1.ReadByte
        Next

        Me.SerialPort1.Close()
        send_flag = False
    End Sub

End Class
