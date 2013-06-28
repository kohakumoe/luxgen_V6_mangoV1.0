Imports ClassLibrary_TSC

Public Class FormUserLabel

    Private Sub FormUserLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


#Region " Print Barcode "
    Private Sub PrientBarcode(ByVal productName As String, ByVal barcode As String, ByVal sn As String)
        Dim myTSC As New ClassTSC(productName, barcode, sn)
        myTSC.DC_PrintLabel()
        myTSC.Dispose()
        myTSC = Nothing
    End Sub
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PrientBarcode(Me.TextBox1.Text, Me.TextBox2.Text, Me.TextBox3.Text)
    End Sub
End Class