Imports ClassLibrary_INI
Imports ClassLibrary_TSC
Imports ClassLibrary_Access

Public Class FormUpdate

    Dim myData As New ClassAccess
    Dim class_table As DataTable
    Dim myINI As iniClass
    Dim br_map As String

    Private Sub FormUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myINI = New iniClass(Application.StartupPath & "\sys.ini")
        Enum_產品類別()
        Enum_版本()
    End Sub

#Region " Methods "

#Region " enum 產品類別 "
    Private Sub Enum_產品類別()
        Me.ComboBox1.Items.Clear()

        class_table = myData.SQL_SELECT_產品類別()
        For i As Int32 = 0 To class_table.Rows.Count - 1
            Me.ComboBox1.Items.Add(class_table.Rows(i).Item("產品類別"))
        Next

    End Sub
#End Region

#Region " enum 版本 "
    Private Sub Enum_版本()
        Me.ComboBox2.Items.Clear()
        Me.ComboBox3.Items.Clear()

        For Each k As iniKey In myINI.Section("Version Mapping").Keys
            Me.ComboBox2.Items.Add(k.Value)
        Next

        For Each k As iniKey In myINI.Section("Firmware Mapping").Keys
            Me.ComboBox3.Items.Add(k.Value)
        Next
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

#Region " Update 版本 "
    Private Sub Update版本(ByVal br As String)
        If br = "" Then
            Exit Sub
        End If

        If Me.ComboBox2.SelectedIndex = -1 OrElse Me.ComboBox3.SelectedIndex = -1 Then
            Exit Sub
        End If

        If br.Substring(0, 2) = br_map Then
            If myData.SQL_UPDATE_Table_產品列表(br, Me.ComboBox2.Text, Me.ComboBox3.Text) = True Then
                Dim p_br As String
                Dim p_pn As String
                Dim table As DataTable = myData.SQL_SELECT_產品與測報_BY_BARCODE(br)

                If table.Rows.Count = 1 Then
                    p_br = table.Rows(0).Item("條碼")
                    p_pn = table.Rows(0).Item("ModelName")

                    PrientBarcode(p_pn, p_br, p_br)
                Else
                    Exit Sub
                End If
            End If
        End If
    End Sub
#End Region

#End Region

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        For i As Int32 = 0 To class_table.Rows.Count - 1
            If class_table.Rows(i).Item("產品類別") = Me.ComboBox1.Text Then
                Me.Label1.Text = "產品類別碼 : " & class_table.Rows(i).Item("顯示條碼")
                br_map = class_table.Rows(i).Item("顯示條碼")
                Continue For
            End If
        Next
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.TextBox1.Text = "" Then
                Exit Sub
            Else
                Update版本(Me.TextBox1.Text)
            End If

            Me.TextBox1.Text = ""
        End If
    End Sub
End Class