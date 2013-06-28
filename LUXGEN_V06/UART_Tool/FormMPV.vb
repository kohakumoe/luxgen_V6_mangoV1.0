Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Imports System.IO
Imports ClassLibrary_INI
Imports ClassLibrary_TSC
Imports ClassLibrary_Access

Public Class FormMPV

    Private init_com_count As Int32
    Private coms As New Collection(Of String)
    Private use_com_name As String = ""
    Dim read(10) As Byte
    'Dim amp_buffer(10) As Byte
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
        Me.SerialPort1.Close()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Enum_COM()

        myINI = New iniClass(Application.StartupPath & "\sys.ini")
        If myINI.Section("Setting").Key("FW_Visable").Value = "True" Then
            Me.TextBox6.Visible = True
        Else
            Me.TextBox6.Visible = False
        End If

        If myINI.Section("Setting").Key("WriteData").Value = "True" Then
            Me.CheckBox1.Checked = True
        Else
            Me.CheckBox1.Checked = False
        End If

        CheckTSCDLL()
    End Sub

#Region " Methods "

    Private Function Enum_COM() As Int32
        init_com_count = My.Computer.Ports.SerialPortNames.Count ''計數COMport 數目
        cmbox.Items.Clear()   '欄位清空
        cmbox2.Items.Clear()
        For i As Int32 = 0 To init_com_count - 1
            coms.Add(My.Computer.Ports.SerialPortNames(i))                ''加入表單項目
            cmbox.Items.Add(My.Computer.Ports.SerialPortNames(i))
            cmbox2.Items.Add(My.Computer.Ports.SerialPortNames(i))
        Next
        cmbox.Sorted = True       ''排序
        cmbox2.Sorted = True
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

#Region " Create New Barcode "
    Private Function Create_New_Barcode() As String
        Dim returnValue As String = ""
        Dim table As DataTable = myData.SQL_Select_Last_Device_By_產品類別識別碼(3)
        Dim last_barcode As String = _
            myData.SQL_SELECT_產品類別顯示條碼_BY_辨識碼(3) & Format((Now.Year - 2000), "00") & Format(Now.Month, "00") & "0000"
        If table.Rows.Count = 1 Then
            last_barcode = table.Rows(0).Item("條碼")
        End If
        Dim y, m, sn As Int32
        Dim temp As String = ""
        temp &= last_barcode(2)
        temp &= last_barcode(3)
        y = CInt(temp) + 2000
        temp = ""
        temp &= last_barcode(4)
        temp &= last_barcode(5)
        m = CInt(temp)

        If y = Now.Year AndAlso m = Now.Month Then
            temp = ""
            temp &= last_barcode(6)
            temp &= last_barcode(7)
            temp &= last_barcode(8)
            temp &= last_barcode(9)
            sn = CInt(temp) + 1
        Else
            sn = 1
        End If

        y = Now.Year - 2000
        m = Now.Month
        returnValue = _
            myData.SQL_SELECT_產品類別顯示條碼_BY_辨識碼(3) & Format(y, "00") & Format(m, "00") & Format(sn, "0000")
        Return returnValue
    End Function
#End Region

#Region " Write New Data "
    Private Sub WriteNewData()
        Dim br As String = Me.Create_New_Barcode
        'Me.TextBox7.Text = ""
        Append_Message("產生新條碼 : " & br)
        Dim device_id As Int32
        device_id = myData.SQL_Insert_Device(br, Me.TextBox4.Text, Me.TextBox6.Text, 3)
        Append_Message("寫入新裝置 : " & br)
        If myData.SQL_Insert_Test_Report(device_id, "OK", Me.Amp_Min_Value) = True Then
            Append_Message("寫入測試報告完成 " & vbNewLine & "時間 : " & TimeString.ToString)
        End If
        Append_Message("列印條碼")
        PrientBarcode(Me.TextBox4.Text, br, br)
        PrientBarcode(Me.TextBox4.Text, br, br)
        PrientBarcode("", "", "")
    End Sub
#End Region

#Region " Print Barcode "
    Private Sub PrientBarcode(ByVal productName As String, ByVal barcode As String, ByVal sn As String)
        Dim myTSC As New ClassTSC(productName, barcode, sn)
        myTSC.DC_PrintLabel()
        myTSC.Dispose()
        myTSC = Nothing
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
        If com1_num = "" Then
            Me.check1.Text = "未選取"
            Me.check1.ForeColor = Color.Red
        End If
        If com2_num = "" Then
            Me.check2.Text = "未選取"
            Me.check2.ForeColor = Color.Red
        End If
        Enum_COM()
        If com1_num <> "" And com2_num <> "" Then
            Me.Timer2.Enabled = True
            Me.Timer1.Enabled = False
            Me.AmpControl1.Com_Enable = True
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

#End Region

#Region "SerialPort"
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
#End Region

#Region "start work"
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
                Me.TextBox6.Text = "韌體版本編號"
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
                Me.TextBox2.Text = "P檔OFF 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 10 Then
                Me.TextBox2.Text = "ACC OFF 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 11 Then
                Me.TextBox2.Text = "IGN OFF 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 12 Then
                Me.TextBox2.Text = "SET 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 13 Then
                Me.TextBox2.Text = "記憶1 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 14 Then
                Me.TextBox2.Text = "SET 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 15 Then
                Me.TextBox2.Text = "記憶2 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 26 Then
                Me.TextBox2.Text = "ST 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 27 Then
                Me.TextBox2.Text = "CANCEL 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 28 Then
                Me.TextBox2.Text = "DOOR 測試"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 29 Then
                Me.TextBox2.Text = "SPEED 測試"
            ElseIf test_step = 30 Then
                Me.TextBox2.Text = "讀取版本編號"
                Me.TextBox2.ForeColor = Color.RoyalBlue
            ElseIf test_step = 25 Then

                If last_step <> test_step Then
                    play_ok_sound_flag = True
                End If

                If Me.AmpControl1.Amp_Fix = True Then
                    'Amp_Fix_Count = 6
                    Me.CheckBox2.Checked = False
                    'Current Limit
                    Dim cl As Double = myINI.Section("Current Limit").Key("MPV_Limit").Value

                    Amp_Min_Value = Me.AmpControl1.Amp_Value

                    If play_ok_sound_flag = True Then
                        If Amp_Min_Value < cl Then
                            Me.TextBox2.Text = "測試結果 OK"
                            Me.TextBox2.ForeColor = Color.Chartreuse
                            Me.TextBox3.Text = "待機電流 : " & Format(Amp_Min_Value, "0.00") & " mA"
                            Me.TextBox3.ForeColor = Color.Chartreuse
                        Else
                            Me.TextBox3.Text = "待機電流 : " & Format(Amp_Min_Value, "0.00") & " mA"
                            Me.TextBox3.ForeColor = Color.Red
                        End If

                        play_ok_sound_flag = False
                        If Amp_Min_Value < cl Then
                            My.Computer.Audio.Play(Application.StartupPath & "\OK.wav")

                            If Me.CheckBox1.Checked = True Then
                                If Me.TextBox4.Text <> "" Then
                                    Me.WriteNewData()
                                Else
                                    Append_Message("沒有對應的版次...")
                                    Append_Message("寫入資料庫失敗!!!")
                                End If
                            Else
                                Append_Message("測試完成 " & vbNewLine & "時間 : " & TimeString.ToString)
                            End If
                        Else
                            Me.TextBox2.Text = "測試結果 NG"
                            Me.TextBox2.ForeColor = Color.Red
                            My.Computer.Audio.Play(Application.StartupPath & "\NG.wav")
                        End If

                    End If
                Else
                    If play_ok_sound_flag = True Then
                        Me.TextBox2.Text = "待機電流 測試"
                        Me.TextBox2.ForeColor = Color.RoyalBlue
                        Me.CheckBox2.Checked = True
                    End If
                End If

                If play_ok_sound_flag = True AndAlso Amp_Value <> Amp_Min_Value AndAlso Amp_Value > 0.05 Then
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
                End If
            End If

            last_step = test_step

            If test_step = 31 Then
                'Me.Label3.Text = myData.SQL_SELECT_產品類別顯示條碼_BY_辨識碼(3)
                'Me.TextBox4.Text = myINI.Section("Version Mapping").Key(myData.SQL_SELECT_產品類別顯示條碼_BY_辨識碼(3) & error_step).Value
                Me.TextBox4.Text = myINI.Section("Version Mapping").Key("M1" & error_step).Value
                If Me.TextBox4.Text = "" Then
                    Me.TextBox4.Text = "沒有對應版次"
                End If
                'Me.TextBox6.Text = myINI.Section("Firmware Mapping").Key(myData.SQL_SELECT_產品類別顯示條碼_BY_辨識碼(3) & error_step).Value
                Me.TextBox6.Text = myINI.Section("Firmware Mapping").Key("M1" & error_step).Value
                If Me.TextBox6.Text = "" Then
                    Me.TextBox6.Text = "沒有對應版次"
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
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "P檔 OFF"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 10 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "ACC OFF"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 11 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "IGN OFF"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 12 Or error_step = 14 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "SET ON" & vbNewLine & "P檔 ON" & vbNewLine & "ACC ON" & vbNewLine & "IGN ON" & vbNewLine & "Memory LED"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 13 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "Memory 1 SW" & vbNewLine & "Memory 1 LED"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 15 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "Memory 2 SW" & vbNewLine & "Memory 2 LED"
                ElseIf error_step = 26 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "ST ON"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 27 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "CANCEL ON"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 28 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "DOOR ON"
                    Me.TextBox3.ForeColor = Color.Red
                ElseIf error_step = 29 Then
                    Me.TextBox3.Text = "可能NG迴路" & vbNewLine & "SPEED"
                    Me.TextBox3.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub
#End Region

#Region "setup"

    Private Sub 設定檔ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 設定檔ToolStripMenuItem.Click
        Process.Start(Application.StartupPath & "\sys.ini")
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            myINI.Section("Setting").Key("WriteData").SetValue = "True"
        Else
            myINI.Section("Setting").Key("WriteData").SetValue = "False"
        End If
    End Sub
#End Region

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

    Private Sub 建立新條碼ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 建立新條碼ToolStripMenuItem.Click
        MsgBox(Create_New_Barcode())
    End Sub


    Private Sub 條碼列印測試ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 條碼列印測試ToolStripMenuItem.Click
        Dim myTSC As New ClassTSC("IT-82XXX-XX", "GG12345678", "GG12345678")
        myTSC.DC_PrintLabel()
        myTSC.Dispose()
    End Sub

    Private Sub 列印最後一筆條碼ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 列印最後一筆條碼ToolStripMenuItem.Click
        Dim table As DataTable = myData.SQL_Select_Last_Device

        Dim br As String
        Dim pn As String
        Dim table2 As DataTable = myData.SQL_SELECT_產品與測報_BY_BARCODE(table.Rows(0).Item(1))

        If table.Rows.Count = 1 Then
            br = table.Rows(0).Item("條碼")
            pn = table.Rows(0).Item("ModelName")

            PrientBarcode(pn, br, br)
        Else
            Exit Sub
        End If
    End Sub
#End Region

    Private Sub 條碼列印ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 條碼列印ToolStripMenuItem.Click
        Dim input As String = InputBox("請輸入條碼", "TSC 條碼列印")

        If input <> "" Then
            Dim br As String
            Dim pn As String
            Dim table As DataTable = myData.SQL_SELECT_產品與測報_BY_BARCODE(input)

            If table.Rows.Count = 1 Then
                br = table.Rows(0).Item("條碼")
                pn = table.Rows(0).Item("ModelName")

                PrientBarcode(pn, br, br)
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub 版本測試ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 版本測試ToolStripMenuItem.Click
        Dim input As String = InputBox("請輸入版號", "版本測試")
        Dim vr As String = myINI.Section("Version Mapping").Key("myData.SQL_SELECT_產品類別顯示條碼_BY_辨識碼(2)" & input).Value
        MsgBox(vr)
    End Sub
#Region "PORT SELECT"
    Private Sub cmbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbox.SelectedIndexChanged
        Me.use_com_name = cmbox.SelectedItem.ToString
        Me.check1.Text = "已選取" & Me.use_com_name
        Me.check1.ForeColor = Color.RoyalBlue
        com1_num = Me.use_com_name
        Me.SerialPort1.PortName = Me.use_com_name
        If com1_num <> "" Then
            Me.Timer2.Enabled = True
            Me.Timer1.Enabled = False
        End If
    End Sub

    Private Sub cmbox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbox2.SelectedIndexChanged
        Me.use_com_name = cmbox2.SelectedItem.ToString
        Me.check2.Text = "已選取" & Me.use_com_name
        Me.check2.ForeColor = Color.RoyalBlue
        com2_num = Me.use_com_name
        Me.AmpControl1.Com_PortName = com2_num
        If com2_num <> "" Then
            Me.Timer2.Enabled = True
            Me.Timer1.Enabled = False
            Me.AmpControl1.Com_Enable = True
        End If
    End Sub
#End Region
    Private Sub 關閉程式ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 關閉程式ToolStripMenuItem.Click
        Me.Timer2.Enabled = False
        Me.Timer1.Enabled = False
        Me.AmpControl1.Com_Enable = False
        Me.Close()
    End Sub
End Class