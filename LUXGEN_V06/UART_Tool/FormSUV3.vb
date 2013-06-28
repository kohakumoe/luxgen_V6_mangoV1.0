Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Imports ClassLibrary_INI
Imports ClassLibrary_Access

Public Class FormSUV3

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

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Enum_COM()

        myINI = New iniClass(Application.StartupPath & "\sys.ini")
        If myINI.Section("Setting").Key("FW_Visable").Value = "True" Then
            Me.TextBox5.Visible = True
        Else
            Me.TextBox5.Visible = False
        End If

        If myINI.Section("Setting").Key("WriteData").Value = "True" Then
            Me.CheckBox1.Checked = True
        Else
            Me.CheckBox1.Checked = False
        End If
    End Sub

#Region " Timers "

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim new_com_count As Int32 = My.Computer.Ports.SerialPortNames.Count
        If com1_num = "" Then
            Me.Label1.Text = "未搜尋到新的COM物件"
            Me.Label1.ForeColor = Color.Red
        End If

        If com2_num = "" Then
            Me.Label4.Text = "未搜尋到新的COM物件"
            Me.Label4.ForeColor = Color.Red
        End If


        If new_com_count = init_com_count + 1 Then

            For i As Int32 = 0 To new_com_count - 1
                If Me.coms.Contains(My.Computer.Ports.SerialPortNames(i)) = False Then
                    use_com_name = My.Computer.Ports.SerialPortNames(i)

                    Me.Label1.Text = "搜尋到新的COM物件 : " & Me.use_com_name
                    Me.Label1.ForeColor = Color.RoyalBlue
                    com1_num = Me.use_com_name
                    Me.SerialPort1.PortName = Me.use_com_name

                End If
            Next
        ElseIf new_com_count = init_com_count + 2 Then
            For i As Int32 = 0 To new_com_count - 1
                use_com_name = My.Computer.Ports.SerialPortNames(i)

                Me.Label4.Text = "搜尋到新的COM物件 : " & Me.use_com_name
                Me.Label4.ForeColor = Color.RoyalBlue
                com2_num = Me.use_com_name
                Me.SerialPort2.PortName = Me.use_com_name

            Next
        ElseIf new_com_count < init_com_count Then
            Enum_COM()
        End If

        If com1_num <> "" AndAlso com2_num <> "" Then
            Me.Timer1.Enabled = False
            Me.Timer2.Enabled = True
            Me.Timer3.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.SerialPort1.IsOpen = True Then
            Me.Label2.Text = "連接成功"
            Me.Label2.ForeColor = Color.RoyalBlue
            Me.PictureBox1.Image = My.Resources.XSIMPLEGREEN
        Else
            Me.Label2.Text = "未連接"
            Me.Label2.ForeColor = Color.Red
            Me.PictureBox1.Image = My.Resources.XSIMPLESILVER
            Try
                Me.SerialPort1.Open()
            Catch ex As Exception
                Me.Label2.Text = "無法連接"
                Me.Label2.ForeColor = Color.Red
            End Try
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If Me.SerialPort2.IsOpen = True Then
            Me.Label5.Text = "連接成功"
            Me.Label5.ForeColor = Color.RoyalBlue
            Me.PictureBox2.Image = My.Resources.XSIMPLEGREEN
            Me.Timer4.Enabled = True
        Else
            Me.Label5.Text = "未連接"
            Me.Label5.ForeColor = Color.Red
            Me.PictureBox2.Image = My.Resources.XSIMPLESILVER
            Me.Timer4.Enabled = False
            Try
                Me.SerialPort2.Open()
            Catch ex As Exception
                Me.Label5.Text = "無法連接"
                Me.Label5.ForeColor = Color.Red
            End Try
        End If
    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        d1()
        Me.TextBox9.Focus()
    End Sub
#End Region

#Region " Methods "

#Region " ENUM COM "
    Private Function Enum_COM() As Int32
        init_com_count = My.Computer.Ports.SerialPortNames.Count
        coms.Clear()
        For i As Int32 = 0 To init_com_count - 1
            coms.Add(My.Computer.Ports.SerialPortNames(i))
        Next

        Me.Timer1.Enabled = True
    End Function
#End Region

#Region " CRC 16 "
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

#Region " CRC Check "
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
#End Region

#Region " Read Test Device "

    Private Sub d()
        If (CRC16_Check(read) = True) Then
            Dim mode_flag As Int32 = read(1)
            Dim test_step As Int32 = read(2)
            Dim error_step As Int32 = read(3)

            If mode_flag = 2 Then
                Me.TextBox1.Text = "待命中..."
            ElseIf mode_flag = 8 Then
                Me.TextBox1.Text = "測試進行中"
            End If

            If test_step = 0 Then
                Me.TextBox2.Text = ""
                Me.TextBox2.ForeColor = Color.RoyalBlue
                Me.TextBox3.Text = ""
                Me.TextBox4.Text = "版本編號"
                Me.TextBox5.Text = "韌體版本編號"
                Me.TextBox6.Text = "0.00 mA"
                Me.CheckBox2.Checked = False
                Amp_Min_Value = 999
                Amp_Fix_Count = 0
            ElseIf test_step = 1 Then
                Me.TextBox2.Text = "滑槽前進 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 2 Then
                Me.TextBox2.Text = "滑槽後退 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 3 Then
                Me.TextBox2.Text = "仰臥前進 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 4 Then
                Me.TextBox2.Text = "仰臥後退 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 5 Then
                Me.TextBox2.Text = "前昇降上昇 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 6 Then
                Me.TextBox2.Text = "前昇降下降 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 7 Then
                Me.TextBox2.Text = "後昇降上昇 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 8 Then
                Me.TextBox2.Text = "後昇降下降 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 9 Then
                Me.TextBox2.Text = "SET按鍵 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 10 Then
                Me.TextBox2.Text = "記憶按鍵1 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 11 Then
                Me.TextBox2.Text = "SET按鍵 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 12 Then
                Me.TextBox2.Text = "記憶按鍵2 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 13 Then
                Me.TextBox2.Text = "Door 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 14 Then
                Me.TextBox2.Text = "P檔 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 15 Then
                Me.TextBox2.Text = "IGN 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 16 Then
                Me.TextBox2.Text = "ACC 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 17 Then
                Me.TextBox2.Text = "ST 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 18 Then
                Me.TextBox2.Text = "CANCEL 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 19 Then
                Me.TextBox2.Text = "防盜按鍵燈號 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 20 Then
                Me.TextBox2.Text = "讀取版本編號"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 25 Then

                If last_step <> test_step Then
                    play_ok_sound_flag = True
                End If

                If Amp_Fix_Count >= 6 Then
                    Amp_Fix_Count = 6
                    Me.CheckBox2.Checked = False
                    'Current Limit
                    Dim cl As Double = myINI.Section("Current Limit").Key("Limit").Value
                    If Amp_Min_Value < cl Then
                        Me.TextBox2.Text = "測試結果 OK"
                        Me.TextBox2.ForeColor = Color.Chartreuse
                        Me.TextBox3.Text = "待機電流 : " & Format(Amp_Min_Value, "0.00") & " mA"
                        Me.TextBox3.ForeColor = Color.Chartreuse
                    Else
                        Me.TextBox3.Text = "待機電流 : " & Format(Amp_Min_Value, "0.00") & " mA"
                        Me.TextBox3.ForeColor = Color.Red
                    End If

                    If play_ok_sound_flag = True Then
                        play_ok_sound_flag = False
                        If Amp_Min_Value < cl Then
                            My.Computer.Audio.Play(Application.StartupPath & "\OK.wav")

                            If Me.CheckBox1.Checked = True Then
                                If Me.UserControl11.ReturnExist = True Then
                                    Me.WriteData(Me.UserControl11.DC_Barcode, "OK", Amp_Min_Value, 0)
                                    Me.UserControl11.ClearProperties()
                                Else
                                    Me.Append_Message("不符合寫入資料庫條件，請確認測試與燒機完成!")
                                    Me.UserControl11.ClearProperties()
                                End If
                            End If
                        Else
                            Me.TextBox2.Text = "測試結果 NG"
                            Me.TextBox2.ForeColor = Color.Red
                            My.Computer.Audio.Play(Application.StartupPath & "\NG.wav")
                            Me.WriteData(Me.UserControl11.DC_Barcode, "NG", Amp_Min_Value, 0)
                            Me.UserControl11.ClearProperties()
                        End If

                    End If
                Else
                    Me.TextBox2.Text = "待機電流 測試"
                    Me.TextBox2.ForeColor = Color.RoyalBlue
                    Me.CheckBox2.Checked = True
                End If

                If play_ok_sound_flag = True AndAlso Amp_Value < Amp_Min_Value AndAlso Amp_Value > 0.05 Then
                    Amp_Min_Value = Amp_Value
                    Amp_Fix_Count = 0
                ElseIf play_ok_sound_flag = True AndAlso Amp_Value = Amp_Min_Value AndAlso Amp_Value > 0.05 Then
                    Amp_Fix_Count += 1
                End If

            ElseIf test_step = 100 Then
                Me.TextBox2.Text = "測試結果 NG"
                Me.TextBox2.ForeColor = Color.Red
                If last_step <> test_step Then
                    My.Computer.Audio.Play(Application.StartupPath & "\NG.wav")
                    Me.WriteData(Me.UserControl11.DC_Barcode, "NG", 0, error_step)
                    Me.UserControl11.ClearProperties()
                End If
            End If

            last_step = test_step

            If test_step = 21 Then
                If error_step = 12 Then
                    Me.TextBox4.Text = myINI.Section("Version Mapping").Key(error_step).Value
                    Me.TextBox5.Text = myINI.Section("Firmware Mapping").Key(error_step).Value
                End If
            End If
            If test_step = 100 Then
                If error_step = 0 Then
                    Me.TextBox3.Text = ""
                    Me.TextBox3.ForeColor = Color.RoyalBlue
                ElseIf error_step = 1 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "滑槽前按鍵" & vbNewLine & "滑槽Relay" & vbNewLine & "編碼器電源"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 2 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "滑槽後按鍵" & vbNewLine & "滑槽Relay" & vbNewLine & "編碼器電源"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 3 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "仰臥前按鍵" & vbNewLine & "仰臥Relay" & vbNewLine & "編碼器電源"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 4 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "仰臥後按鍵" & vbNewLine & "仰臥Relay" & vbNewLine & "編碼器電源"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 5 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "前昇降上按鍵" & vbNewLine & "前昇降Relay" & vbNewLine & "編碼器電源"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 6 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "前昇降下按鍵" & vbNewLine & "前昇降Relay" & vbNewLine & "編碼器電源"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 7 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "後昇降上按鍵" & vbNewLine & "後昇降Relay" & vbNewLine & "編碼器電源"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 8 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "後昇降下按鍵" & vbNewLine & "後昇降Relay" & vbNewLine & "編碼器電源"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 9 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "SET 按鍵" & vbNewLine & "MEM 1 LED" & vbNewLine & "MEM 2 LED"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 10 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "MEM 1 按鍵" & vbNewLine & "MEM 1 LED"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 11 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "SET 按鍵" & vbNewLine & "MEM 1 LED" & vbNewLine & "MEM 2 LED"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 12 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "MEM 2 按鍵" & vbNewLine & "MEM 2 LED"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 13 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "Door"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 14 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "P檔"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 15 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "IGN"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 16 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "ACC"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 17 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "ST"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 18 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "CANCEL"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 19 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "防盜按鍵" & vbNewLine & "防盜LED"
                    Me.TextBox3.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub
#End Region

#Region " Read Amp Data "
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
#End Region

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

#Region " WriteData "
    Private Sub WriteData(ByVal br As String, ByVal result As String, ByVal amp As Double, ByVal error_num As Int32)
        If myData.SQL_UPDATE_TEST_REPORT_SECOND(br, result, amp, error_num) = True Then
            Append_Message("寫入測試報告完成 " & vbNewLine & "時間 : " & TimeString.ToString)
        End If
    End Sub
#End Region

#Region " Append Message "
    Private Sub Append_Message(ByVal txt As String)
        Me.TextBox7.Text &= txt & vbNewLine
        Me.TextBox7.Select(Me.TextBox7.Text.Length - 1, 0)
        Me.TextBox7.ScrollToCaret()

        If Me.TextBox7.TextLength > 1024 Then
            Me.TextBox7.Text = ""
        End If
    End Sub
#End Region

#End Region

    Private Sub TextBox9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox9.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim br As String = Me.TextBox9.Text
            Dim table As DataTable
            table = myData.SQL_SELECT_產品與測報_BY_BARCODE(br)
            If table.Rows.Count = 0 Then
                Append_Message("條碼 : " & br & " 並無測試合格記錄!! ")
                Me.UserControl11.ClearProperties()
            Else
                If table.Rows(0).Item("產品類別") <> "大陸 SUV" Then
                    Append_Message("條碼 : " & br & " 不是大陸向SUV !! ")
                Else
                    Me.UserControl11.DC_Barcode = br
                    Me.UserControl11.DC_TestTime = table.Rows(0).Item("首次測試時間")
                    Me.UserControl11.DC_AMP = table.Rows(0).Item("首次待機電流")
                    If Not table.Rows(0).Item("燒機測試") Is DBNull.Value Then
                        Me.UserControl11.DC_BurnFlag = True
                        Me.UserControl11.DC_BurnTime = table.Rows(0).Item("燒機測試時間")
                    Else
                        Me.UserControl11.DC_BurnFlag = False
                        Me.UserControl11.DC_BurnTime = Nothing
                    End If

                    If Not table.Rows(0).Item("二次測試結果") Is DBNull.Value Then
                        Append_Message("條碼 : " & br & " 調閱測試記錄完成!! ")
                        Append_Message("此裝置已完成所有測試項目!!")
                        Append_Message("請替換裝置...")
                    Else
                        Append_Message("條碼 : " & br & " 調閱測試記錄完成!! ")
                        Append_Message("可開始測試...")
                    End If

                End If
            End If

            Me.TextBox9.Text = ""
        End If
    End Sub

#Region " Serial "

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Me.SerialPort1.Read(read, 0, Me.SerialPort1.ReceivedBytesThreshold)
        Catch ex As Exception

        End Try

        If read(0) <> 6 Then
            Try
                Me.SerialPort1.Close()
                Me.SerialPort1.Open()
            Catch ex As Exception

            End Try
        Else
            Dim mi As New Windows.Forms.MethodInvoker(AddressOf d)
            Try
                Me.BeginInvoke(mi)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub SerialPort2_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        amp_buffer_queue.Enqueue(Me.SerialPort2.ReadByte)
    End Sub
#End Region

End Class