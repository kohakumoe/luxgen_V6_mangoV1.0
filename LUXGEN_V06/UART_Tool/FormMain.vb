Imports ClassLibrary_DC_Controls

Public Class FormMain

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DC_MSNStyleForm1.Text = ""
    End Sub

    Private Sub DC_ActiveButton1_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton1.DC_ButtonClicked
        Dim f As New FormSUV11
        f.ShowDialog()
    End Sub

    Private Sub DC_ActiveButton2_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton2.DC_ButtonClicked
        Dim f As New FormBurn
        f.ShowDialog()
    End Sub

    Private Sub DC_ActiveButton3_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton3.DC_ButtonClicked
        Dim f As New FormSUV3
        f.ShowDialog()
    End Sub

    Private Sub DC_ActiveButton6_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton6.DC_ButtonClicked
        Dim f As New FormGPS11
        f.ShowDialog()
    End Sub

    Private Sub DC_ActiveButton7_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton7.DC_ButtonClicked
        Dim f As New FormGPK1
        f.ShowDialog()
    End Sub

    Private Sub DC_ActiveButton8_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton8.DC_ButtonClicked
        Dim f As New FormGPS3
        f.ShowDialog()
    End Sub

    Private Sub DC_ActiveButton9_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton9.DC_ButtonClicked

    End Sub

    Private Sub DC_ActiveButton10_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton10.DC_ButtonClicked
        Dim f As New FormMPV
        f.ShowDialog()
    End Sub

    Private Sub DC_ActiveButton11_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton11.DC_ButtonClicked

    End Sub

    Private Sub DC_ActiveButton1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton1.MouseMove
        Me.TextBox1.Text = "LUXGEN 7 SUV PCB半成品檢測" & vbNewLine
        Me.TextBox1.Text &= "塑膠外殼尚未鎖附前測試，包含電流測試與I/O測試" & vbNewLine
        Me.TextBox1.Text &= "測試後合格品，自動列印條碼，並且貼附於塑膠外殼上"
    End Sub

    Private Sub DC_ActiveButton2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton2.MouseMove
        Me.TextBox1.Text = "LUXGEN 系列燒機檢測登錄" & vbNewLine
        Me.TextBox1.Text &= "完成半成測與外殼鎖附後施行燒機測試" & vbNewLine
        Me.TextBox1.Text &= "燒機結束後，以條碼掃瞄機記錄測試時間"
    End Sub

    Private Sub DC_ActiveButton3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton3.MouseMove
        Me.TextBox1.Text = "LUXGEN 7 SUV PCB成品檢測" & vbNewLine
        Me.TextBox1.Text &= "塑膠外殼鎖附後成品測試，包含電流測試與I/O測試" & vbNewLine
        Me.TextBox1.Text &= "測試後合格品，以條碼掃瞄機記錄測試結果"
    End Sub

    Private Sub DC_ActiveButton4_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton4.DC_ButtonClicked

    End Sub

    Private Sub DC_ActiveButton5_DC_ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_ActiveButton5.DC_ButtonClicked

    End Sub

    Private Sub DC_ActiveButton4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton4.MouseMove
        Me.TextBox1.Text = "LUXGEN 座椅ECU系列裝箱登錄" & vbNewLine
        Me.TextBox1.Text &= "將多個ECU成品打包成箱，在往後出貨登錄時，可一次完成出貨登錄動作" & vbNewLine
        Me.TextBox1.Text &= "測試不合格品，無法登錄裝箱!"
    End Sub

    Private Sub DC_ActiveButton5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton5.MouseMove
        Me.TextBox1.Text = "LUXGEN 座椅ECU系列出貨登錄" & vbNewLine
        Me.TextBox1.Text &= "將ECU成品作出貨登錄，可單獨ECU條碼登錄，也可以裝箱條碼登錄一次完成出貨動作" & vbNewLine
        Me.TextBox1.Text &= "測試不合格品，無法登錄出貨!"
    End Sub

    Private Sub DC_ActiveButton6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton6.MouseMove
        Me.TextBox1.Text = "LUXGEN GPS1 PCB半成品檢測" & vbNewLine
        Me.TextBox1.Text &= "塑膠外殼尚未鎖附前測試，包含電流測試與I/O測試" & vbNewLine
        Me.TextBox1.Text &= "測試後合格品，自動列印條碼，並且貼附於塑膠外殼上"
    End Sub

    Private Sub DC_ActiveButton7_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton7.MouseMove
        Me.TextBox1.Text = "LUXGEN GPK1 PCB半成品檢測" & vbNewLine
        Me.TextBox1.Text &= "塑膠外殼尚未鎖附前測試，包含電流測試與I/O測試" & vbNewLine
        Me.TextBox1.Text &= "測試後合格品，自動列印條碼，並且貼附於塑膠外殼上"
    End Sub

    Private Sub DC_ActiveButton8_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton8.MouseMove
        Me.TextBox1.Text = "LUXGEN GPS1 PCB成品檢測" & vbNewLine
        Me.TextBox1.Text &= "塑膠外殼鎖附後成品測試，包含電流測試與I/O測試" & vbNewLine
        Me.TextBox1.Text &= "測試後合格品，以條碼掃瞄機記錄測試結果"
    End Sub

    Private Sub DC_ActiveButton9_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton9.MouseMove
        Me.TextBox1.Text = "LUXGEN GPK1 PCB成品檢測" & vbNewLine
        Me.TextBox1.Text &= "塑膠外殼鎖附後成品測試，包含電流測試與I/O測試" & vbNewLine
        Me.TextBox1.Text &= "測試後合格品，以條碼掃瞄機記錄測試結果"
    End Sub

    Private Sub DC_ActiveButton10_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton10.MouseMove
        Me.TextBox1.Text = "LUXGEN MPV PCB半成品檢測" & vbNewLine
        Me.TextBox1.Text &= "塑膠外殼尚未鎖附前測試，包含電流測試與I/O測試" & vbNewLine
        Me.TextBox1.Text &= "測試後合格品，自動列印條碼，並且貼附於塑膠外殼上"
    End Sub

    Private Sub DC_ActiveButton11_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DC_ActiveButton11.MouseMove
        Me.TextBox1.Text = "LUXGEN MPV PCB成品檢測" & vbNewLine
        Me.TextBox1.Text &= "塑膠外殼鎖附後成品測試，包含電流測試與I/O測試" & vbNewLine
        Me.TextBox1.Text &= "測試後合格品，以條碼掃瞄機記錄測試結果"
    End Sub

    Private Sub DC_MSNStyleForm1_DC_CloseButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DC_MSNStyleForm1.DC_CloseButtonClick
        Me.Close()
    End Sub

    Private Sub DC_ActiveButton12_Click(sender As Object, e As EventArgs) Handles DC_ActiveButton12.Click
        Me.Close()
    End Sub
End Class