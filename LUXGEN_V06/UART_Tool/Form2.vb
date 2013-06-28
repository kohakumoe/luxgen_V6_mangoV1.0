Public Class Form2

    Dim usart_id As Int32 = 1

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.SerialPort1.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SerialPort1.Open()
        Me.ComboBox1.SelectedIndex = 0
        Me.ComboBox2.SelectedIndex = 0
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cmd(7) As Byte
        cmd(0) = &H1
        cmd(1) = &H6
        cmd(2) = &H0
        cmd(3) = &H1C
        cmd(4) = &HB
        cmd(5) = &HB8

        Dim b() As Byte = CRC16(cmd, 6)

        cmd(6) = b(1)
        cmd(7) = b(0)

        Me.SerialPort1.Write(cmd, 0, 8)
        'Me.SerialPort1.Write(vbCrLf)
    End Sub

#Region " Methods "

    Private Sub CRC16_Calculate()

    End Sub

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
        Dim b() As Byte = CRC16(data, 5)
        If b(0) = data(6) AndAlso b(1) = data(5) Then
            Dim value As Int16 = 0
            value = value Or data(3)
            value = value << 8
            value = value Or data(4)


            If data(0) = 1 Then
                Me.TextBox1.Text = value.ToString
            ElseIf data(0) = 2 Then
                Me.TextBox2.Text = value.ToString
            End If

        End If
    End Function

#End Region

    Dim read(20) As Byte
    Dim readIndex As Int32 = 0

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'System.Threading.Thread.Sleep(50)
        For i As Int32 = 0 To 5
            read(i) = Me.SerialPort1.ReadByte
        Next
        ' read(readIndex) = Me.SerialPort1.Read(read, 0, 7)
        'readIndex += 1        

        Dim mi As New Windows.Forms.MethodInvoker(AddressOf d)
        Me.BeginInvoke(mi)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.ListBox1.Items.Clear()

        For i As Int32 = 0 To 6
            Me.ListBox1.Items.Add("0x" & Hex(read(i)))
            read(i) = 0
        Next
        readIndex = 0

    End Sub

    Private Sub d()
        Me.ListBox1.Items.Clear()

        If (CRC16_Check(read) = True) Then

        End If

        For i As Int32 = 0 To 6
            Me.ListBox1.Items.Add("0x" & Hex(read(i)))
            read(i) = 0
        Next
        readIndex = 0
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim cmd(7) As Byte
        cmd(0) = usart_id
        cmd(1) = &H3
        cmd(2) = &H0
        cmd(3) = &H2A
        cmd(4) = &H0
        cmd(5) = &H1

        Dim b() As Byte = CRC16(cmd, 6)

        cmd(6) = b(1)
        cmd(7) = b(0)

        Me.SerialPort1.Write(cmd, 0, 8)

        usart_id += 1
        If usart_id >= 3 Then
            usart_id = 1
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmd(7) As Byte
        cmd(0) = &H3
        cmd(1) = &H1
        cmd(2) = Me.ComboBox1.SelectedItem
        cmd(3) = Me.ComboBox2.SelectedIndex

        Dim b() As Byte = CRC16(cmd, 4)

        cmd(4) = b(1)
        cmd(5) = b(0)

        Me.SerialPort1.Write(cmd, 0, 6)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
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

        Me.SerialPort1.Write(cmd, 0, 8)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim cmd(7) As Byte
        cmd(0) = &H2
        cmd(1) = &H3
        cmd(2) = &H0
        cmd(3) = &H2A
        cmd(4) = &H0
        cmd(5) = &H1

        Dim b() As Byte = CRC16(cmd, 6)

        cmd(6) = b(1)
        cmd(7) = b(0)

        Me.SerialPort1.Write(cmd, 0, 8)
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.Timer1.Enabled = True Then
            Me.Button6.Text = "Disbale"
        Else
            Me.Button6.Text = "Enable"
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Timer1.Enabled = Not Me.Timer1.Enabled
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim cmd(7) As Byte
        cmd(0) = &H4
        cmd(1) = &H1
        cmd(2) = Me.ComboBox1.SelectedItem
        cmd(3) = Me.ComboBox2.SelectedIndex

        Dim b() As Byte = CRC16(cmd, 4)

        cmd(4) = b(1)
        cmd(5) = b(0)

        Me.SerialPort1.Write(cmd, 0, 6)
    End Sub
End Class