Imports ClassLibrary_TSC
Imports ClassLibrary_Access

Public Class FormPrintLabel
    Dim myData As New ClassAccess


    Private Sub FormPrintLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.TextBox4.Focus()
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TextBox7.Text = ""

            If Me.TextBox4.Text <> "" Then
                Dim br As String
                Dim pn As String
                Dim table As DataTable = myData.SQL_SELECT_產品與測報_BY_BARCODE(Me.TextBox4.Text)

                If table.Rows.Count = 1 Then
                    br = table.Rows(0).Item("條碼")
                    pn = table.Rows(0).Item("ModelName")

                    PrientBarcode(pn, br, br)

                    'Message
                    Append_Message("產品類別 : " & table.Rows(0).Item("產品類別"))
                    Append_Message("產品名稱 : " & pn)
                    Append_Message("條碼 : " & br)
                    Append_Message("首次測試時間 : " & table.Rows(0).Item("首次測試時間"))
                    Append_Message("待機電流 : " & table.Rows(0).Item("首次待機電流"))
                Else
                    Exit Sub
                End If
            End If

            Me.TextBox4.Text = ""
        End If
    End Sub


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

End Class