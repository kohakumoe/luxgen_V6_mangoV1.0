Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Imports System.IO
Imports ClassLibrary_INI
Imports ClassLibrary_TSC
Imports ClassLibrary_Access

Public Class FormAmpTest2

    Private init_com_count As Int32
    Private coms As New Collection(Of String)
    Private use_com_name As String = ""
    Dim read(10) As Byte
    Dim amp_buffer(10) As Byte
    Dim last_step As Int32
    Dim myINI As iniClass
    Dim com1_num As String = ""
    Dim com2_num As String = ""
    Dim Amp_Value As Double
    Dim Amp_Min_Value As Double
    Dim Amp_Fix_Count As Int32
    Dim play_ok_sound_flag As Boolean

    Dim amp_buffer_queue As New Queue(Of Byte)

    Dim myData As New ClassAccess

    Private Sub Form3_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Enum_COM()

        myINI = New iniClass(Application.StartupPath & "\sys.ini")

        If Me.BackgroundWorker1.IsBusy = False Then
            Me.BackgroundWorker1.RunWorkerAsync(Me)
        End If
    End Sub

#Region " Methods "

    Private Function Enum_COM() As Int32
        init_com_count = My.Computer.Ports.SerialPortNames.Count
        coms.Clear()
        For i As Int32 = 0 To init_com_count - 1
            coms.Add(My.Computer.Ports.SerialPortNames(i))
        Next

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

    Private Function CRC16_Check(ByVal data() As Byte) As Boolean
        Dim b() As Byte = CRC16(data, 4)
        If b(0) = data(5) AndAlso b(1) = data(4) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CRC16_Check_Amp(ByVal data() As Byte) As Boolean
        Dim b() As Byte = CRC16(data, 5)
        If b(0) = data(6) AndAlso b(1) = data(5) Then
            Return True
        Else
            Return False
        End If
    End Function


#Region " Send Amp Command "
    Private Sub SendAmpCommand()
        Dim cmd(7) As Byte
        cmd(0) = &H1
        cmd(1) = &H3
        cmd(2) = &H0
        cmd(3) = &H2A
        cmd(4) = &H0
        cmd(5) = &H1

        Dim b() As Byte = CRC16(cmd, 6)

        cmd(6) = b(1)
        cmd(7) = b(0)

        Try

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region " Check TSC DLL "
    Private Sub CheckTSCDLL()
        If Not File.Exists("C:\WINDOWS\system\TSCLib.dll") Then
            File.Copy(Application.StartupPath & "\TSCLib.dll", "C:\WINDOWS\system\TSCLib.dll")
        End If
    End Sub
#End Region

#End Region

#Region " Timer "

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If Me.GatewayControl1.Com_IsOpen = True Then
        '    Me.Button1.Text = "Close"
        'Else
        '    Me.Button1.Text = "Open"
        'End If

        'If Me.GatewayControl1.Timer1.Enabled = True Then
        '    Me.Button2.Text = "Stop"
        'Else
        '    Me.Button2.Text = "Start"
        'End If
    End Sub
#End Region

    Private Sub 設定檔ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 設定檔ToolStripMenuItem.Click
        Process.Start(Application.StartupPath & "\sys.ini")
    End Sub

#Region " Menu "

    Private Sub 讀取最後一筆DeviceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 讀取最後一筆DeviceToolStripMenuItem.Click
        Dim table As DataTable = myData.SQL_Select_Last_Device
        MsgBox(table.Rows(0).Item(0))
        MsgBox(table.Rows(0).Item(1))
        MsgBox(table.Rows(0).Item(2))
        MsgBox(table.Rows(0).Item(3))
        MsgBox(table.Rows(0).Item(4))
    End Sub

    Private Sub 讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 讀取最後一筆DeviceBy產品類別識別碼ToolStripMenuItem.Click
        Dim table As DataTable = myData.SQL_Select_Last_Device_By_產品類別識別碼(1)
        MsgBox(table.Rows(0).Item(0))
        MsgBox(table.Rows(0).Item(1))
        MsgBox(table.Rows(0).Item(2))
        MsgBox(table.Rows(0).Item(3))
        MsgBox(table.Rows(0).Item(4))
    End Sub

    Private Sub 條碼列印測試ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 條碼列印測試ToolStripMenuItem.Click
        Dim myTSC As New ClassTSC("IT-82XXX-XX", "GG12345678", "GG12345678")
        myTSC.DC_PrintLabel()
        myTSC.Dispose()
    End Sub
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.AmpControl1.Com_Enable = True

        'If Me.Button1.Text = "Open" Then
        '    Me.GatewayControl1.ComPortOpen()
        'ElseIf Me.Button1.Text = "Close" Then
        '    Me.GatewayControl1.ComPortClose()
        'End If
    End Sub


    Private Sub d1()
        If Me.amp_buffer_queue.Count < 7 Then
            Exit Sub
        ElseIf Me.amp_buffer_queue.Count > 30 Then
            Me.amp_buffer_queue.Clear()
            Exit Sub
        End If

        amp_buffer(0) = Me.amp_buffer_queue.Dequeue
        If amp_buffer(0) <> 1 Then
            Exit Sub
        End If

        amp_buffer(1) = Me.amp_buffer_queue.Dequeue
        If amp_buffer(1) <> 3 Then
            Exit Sub
        End If

        For i As Int32 = 2 To 6
            amp_buffer(i) = Me.amp_buffer_queue.Dequeue
        Next

        If (CRC16_Check_Amp(amp_buffer) = True) Then
            Amp_Value = (amp_buffer(3) * 256 + amp_buffer(4)) / 100
            Me.TextBox6.Text = Format(Amp_Value, "0.00") & " mA"
        End If
    End Sub

    Private Sub DataReceived( _
        ByVal worker As System.ComponentModel.BackgroundWorker, _
        ByVal e As System.ComponentModel.DoWorkEventArgs _
    )
        If Me.amp_buffer_queue.Count < 7 Then
            Exit Sub
        ElseIf Me.amp_buffer_queue.Count > 30 Then
            Me.amp_buffer_queue.Clear()
            Exit Sub
        End If

        amp_buffer(0) = Me.amp_buffer_queue.Dequeue
        If amp_buffer(0) <> 1 Then
            worker.ReportProgress(50)
            Exit Sub
        End If

        amp_buffer(1) = Me.amp_buffer_queue.Dequeue
        If amp_buffer(1) <> 3 Then
            worker.ReportProgress(50)
            Exit Sub
        End If

        For i As Int32 = 2 To 6
            amp_buffer(i) = Me.amp_buffer_queue.Dequeue
        Next

        If (CRC16_Check_Amp(amp_buffer) = True) Then
            Amp_Value = (amp_buffer(3) * 256 + amp_buffer(4)) / 100
            If Me.Amp_Min_Value <> Me.Amp_Value Then
                Me.Amp_Fix_Count = 0
                Amp_Min_Value = Amp_Value
            Else
                Amp_Fix_Count += 1
                
            End If
            worker.ReportProgress(100)
        Else
            worker.ReportProgress(50)
        End If
    End Sub

    

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      
    End Sub

    Private Sub AmpControl1_Amp_Value_Fix_Event(ByVal sender As Object, ByVal e As System.EventArgs) Handles AmpControl1.Amp_Value_Fix_Event
        If Me.AmpControl1.Amp_Fix = True Then
            Me.CheckBox1.Checked = True
        Else
            Me.CheckBox1.Checked = False
        End If
    End Sub
End Class