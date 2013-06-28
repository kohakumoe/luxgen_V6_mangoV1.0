Imports ClassLibrary_Access

Public Class FormBurn

    Dim myData As New ClassAccess

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.TextBox4.Focus()
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Label3.Text = Me.TextBox4.Text

            Dim br As String = Me.TextBox4.Text
            Dim table As DataTable
            table = myData.SQL_SELECT_產品與測報_BY_BARCODE(br)
            If table.Rows.Count = 0 Then
                AppendMessage("條碼 : " & br & " 並無測試合格記錄!! ")
            Else
                Me.Label4.Text = table.Rows(0).Item("首次測試時間")
                Me.Label7.Text = table.Rows(0).Item("首次待機電流") & " mA"
                Me.Label9.Text = table.Rows(0).Item("ModelName")
                If table.Rows(0).Item("燒機測試") Is DBNull.Value Then
                    myData.SQL_UPDATE_TEST_REPORT_BURN(br)
                    AppendMessage("登錄燒機完成，條碼 : " & br)
                    AppendMessage("登錄時間 : " & TimeString.ToString)
                Else
                    AppendMessage("條碼 : " & br)
                    AppendMessage("已登錄過，不允許再次登錄")
                End If
            End If

            Me.TextBox4.Text = ""
        End If
    End Sub

#Region " Methods "
#Region " AppendMessage "
    Private Sub AppendMessage(ByVal txt As String)
        Me.TextBox1.Text &= txt & vbNewLine
        Me.TextBox1.Select(Me.TextBox1.Text.Length - 1, 0)
        Me.TextBox1.ScrollToCaret()

        If Me.TextBox1.TextLength > 1024 Then
            Me.TextBox1.Text = ""
        End If
    End Sub
#End Region
#End Region

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class