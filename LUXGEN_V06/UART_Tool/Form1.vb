
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel

Public Class Form1

    Dim Queue As New Collection(Of Byte)
    Dim Head_Collection As New Collection(Of Byte)

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.GatewayControl1.ComPortClose()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.GatewayControl1.ComPortOpen()
        'Insert_Head()
    End Sub

    Private Sub GatewayControl1_Gateway_ComDataReceivedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles GatewayControl1.Gateway_ComDataReceivedEvent
        If Me.GatewayControl1.Com_ReceivedData.Count = 0 Then Exit Sub

        'Do
        Me.TextBox1.Text &= Hex(Me.GatewayControl1.Com_ReceivedData.Dequeue)
        Me.TextBox1.Text &= vbNewLine
        'Loop While Me.GatewayControl1.Com_ReceivedData.Count > 0

        'Me.TextBox1.Text &= Me.GatewayControl1.Com_ReceivedDataString

        'Me.TextBox1.Text &= vbNewLine

        'Me.GatewayControl1.Com_ReceivedData.Clear()

        TextBox1.SelectionStart = TextBox1.Text.Length

        TextBox1.ScrollToCaret()

        If Me.TextBox1.Text.Length > 8192 Then
            Me.TextBox1.Text = ""
        End If

        'Me.Queue.Clear()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If Queue.Count >= 2 Then
        '    If Check_Head(Queue(0)) = False Then
        '        Queue.Clear()
        '        Exit Sub
        '    Else
        '        If Queue.Count >= Queue(1) + 2 Then
        '            For i As Int32 = 0 To Queue(1) + 1
        '                Me.TextBox1.Text &= Hex(Queue(i)) & ","
        '            Next
        '            Me.TextBox1.Text &= vbNewLine
        '            TextBox1.SelectionStart = TextBox1.Text.Length
        '            TextBox1.ScrollToCaret()
        '            If Me.TextBox1.Text.Length > 8192 Then
        '                Me.TextBox1.Text = ""
        '            End If
        '            Queue.Clear()
        '        End If
        '    End If
        'End If
    End Sub

    Private Function Check_Head(ByVal head_byte As Byte) As Boolean
        If Head_Collection.Contains(head_byte) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Insert_Head()
        Head_Collection.Add(&H10)
        Head_Collection.Add(&H11)
        Head_Collection.Add(&H12)
        Head_Collection.Add(&H13)
        Head_Collection.Add(&H16)
        Head_Collection.Add(&H17)
        Head_Collection.Add(&H1F)
        Head_Collection.Add(&H23)
        Head_Collection.Add(&H24)
        Head_Collection.Add(&H25)
        Head_Collection.Add(&H26)
        Head_Collection.Add(&H28)
        Head_Collection.Add(&H29)
        Head_Collection.Add(&H2A)
        Head_Collection.Add(&H2B)
        Head_Collection.Add(&H2E)
        Head_Collection.Add(&H2F)
        Head_Collection.Add(&H30)
        Head_Collection.Add(&H32)
        Head_Collection.Add(&H33)
        Head_Collection.Add(&H35)
        Head_Collection.Add(&H3B)
        Head_Collection.Add(&H4E)
        Head_Collection.Add(&H4F)
        Head_Collection.Add(&H55)
        Head_Collection.Add(&H80)
        Head_Collection.Add(&H81)
        Head_Collection.Add(&H82)
        Head_Collection.Add(&H83)
        Head_Collection.Add(&H84)
        Head_Collection.Add(&H85)
        Head_Collection.Add(&H86)
        Head_Collection.Add(&H89)
        Head_Collection.Add(&H8A)
        Head_Collection.Add(&H8B)
        Head_Collection.Add(&H8D)
        Head_Collection.Add(&H8E)
        Head_Collection.Add(&H8F)
        Head_Collection.Add(&H95)
        Head_Collection.Add(&H97)
        Head_Collection.Add(&HAC)
        Head_Collection.Add(&HB9)
        Head_Collection.Add(&HBB)
        Head_Collection.Add(&HBE)
        Head_Collection.Add(&HDB)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.GatewayControl1.SendCommand("status")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Me.GatewayControl1.SendCommand("@0open")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Me.GatewayControl1.SendCommand("@0close")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.GatewayControl1.Com_PortName = Me.TextBox2.Text
        Me.GatewayControl1.ComPortOpen()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.GatewayControl1.ComPortClose()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.SerialPort1.Open()
        Me.SerialPort2.Open()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        SetRedail(Me.SerialPort2)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        IND_SCO_ON(Me.SerialPort1)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        IND_SCO_OFF(Me.SerialPort1)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        SetPair(Me.SerialPort2)
    End Sub

#Region " Methods "

#Region " Set Pair "
    Private Sub SetPair(ByRef com As System.IO.Ports.SerialPort)
        Dim buffer As Byte() = {&H1F, &H1, &H1}
        com.Write(buffer, 0, 3)
    End Sub
#End Region

#Region " Set Redail "
    Private Sub SetRedail(ByRef com As System.IO.Ports.SerialPort)
        Dim buffer As Byte() = {&H2E, &H0}
        com.Write(buffer, 0, 2)
    End Sub
#End Region

#Region " IND SCO ON "
    Private Sub IND_SCO_ON(ByRef com As System.IO.Ports.SerialPort)
        Dim buffer As Byte() = {&H85, &H2, &H1, &H1}
        com.Write(buffer, 0, 4)
    End Sub
#End Region

#Region " IND SCO OFF "
    Private Sub IND_SCO_OFF(ByRef com As System.IO.Ports.SerialPort)
        Dim buffer As Byte() = {&H85, &H2, &H0, &H1}
        com.Write(buffer, 0, 4)
    End Sub
#End Region

#End Region


End Class
