Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Imports System.IO
Imports ClassLibrary_INI
Imports ClassLibrary_TSC
Imports ClassLibrary_Access

Public Class FormAmpTest

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
        Me.SerialPort2.Close()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Enum_COM()

        myINI = New iniClass(Application.StartupPath & "\sys.ini")

    End Sub

#Region " Methods "

    Private Function Enum_COM() As Int32
        init_com_count = My.Computer.Ports.SerialPortNames.Count
        coms.Clear()
        For i As Int32 = 0 To init_com_count - 1
            coms.Add(My.Computer.Ports.SerialPortNames(i))
        Next

        Me.Timer1.Enabled = True
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
            Me.SerialPort2.Write(cmd, 0, 8)
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
        Dim new_com_count As Int32 = My.Computer.Ports.SerialPortNames.Count
        If com1_num = "" Then
            Me.Label1.Text = "未搜尋到新的COM物件"
            Me.Label1.ForeColor = Color.Red
        End If

        If new_com_count = init_com_count + 1 Then

            For i As Int32 = 0 To new_com_count - 1
                If Me.coms.Contains(My.Computer.Ports.SerialPortNames(i)) = False Then
                    use_com_name = My.Computer.Ports.SerialPortNames(i)

                    Me.Label1.Text = "搜尋到新的COM物件 : " & Me.use_com_name
                    Me.Label1.ForeColor = Color.RoyalBlue
                    com1_num = Me.use_com_name
                    Me.SerialPort2.PortName = Me.use_com_name

                End If
            Next
        ElseIf new_com_count < init_com_count Then
            Enum_COM()
        End If

        If com1_num <> "" Then
            Me.Timer1.Enabled = False
            Me.Timer3.Enabled = True
        End If
    End Sub



    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If Me.SerialPort2.IsOpen = True Then
            Me.Label2.Text = "連接成功"
            Me.Label2.ForeColor = Color.RoyalBlue
            Me.PictureBox1.Image = My.Resources.XSIMPLEGREEN
            Me.Timer4.Enabled = True
        Else
            Me.Label2.Text = "未連接"
            Me.Label2.ForeColor = Color.Red
            Me.PictureBox1.Image = My.Resources.XSIMPLESILVER
            Me.Timer4.Enabled = False
            Try
                Me.SerialPort2.Open()
            Catch ex As Exception
                Me.Label2.Text = "無法連接"
                Me.Label2.ForeColor = Color.Red
            End Try
        End If
    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        d1()
        'If Me.amp_buffer_queue.Count >= 7 Then
        '    d1()
        'Else
        '    Dim cmd(7) As Byte
        '    cmd(0) = &H1
        '    cmd(1) = &H3
        '    cmd(2) = &H0
        '    cmd(3) = &H2A
        '    cmd(4) = &H0
        '    cmd(5) = &H1

        '    Dim b() As Byte = CRC16(cmd, 6)

        '    cmd(6) = b(1)
        '    cmd(7) = b(0)

        '    Try
        '        Me.SerialPort2.Write(cmd, 0, 8)
        '    Catch ex As Exception

        '    End Try
        'End If
    End Sub
#End Region

    Private Sub SerialPort2_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        'Dim bc As Int32 = Me.SerialPort2.ReadBufferSize
        'For i As Int32 = 1 To bc
        '    Try
        amp_buffer_queue.Enqueue(Me.SerialPort2.ReadByte)
        '    Catch ex As Exception

        '    End Try
        'Next

        'Dim mi As New Windows.Forms.MethodInvoker(AddressOf d1)
        'Try
        '    Me.BeginInvoke(mi)
        'Catch ex As Exception

        'End Try

        'Me.SerialPort2.Read(amp_buffer, 0, Me.SerialPort2.ReceivedBytesThreshold)
        'If amp_buffer(0) <> 1 Then
        '    Try
        '        Me.SerialPort2.Close()
        '        Me.SerialPort2.Open()
        '    Catch ex As Exception

        '    End Try
        'Else
        '    Dim mi As New Windows.Forms.MethodInvoker(AddressOf d1)
        '    Try
        '        Me.BeginInvoke(mi)
        '    Catch ex As Exception

        '    End Try
        'End If
    End Sub

    Private Sub d1()
        If Me.amp_buffer_queue.Count < 7 Then
            If Me.CheckBox2.Checked Then Me.SendAmpCommand()
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

End Class