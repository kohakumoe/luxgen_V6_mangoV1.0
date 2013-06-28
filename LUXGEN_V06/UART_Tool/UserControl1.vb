Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class UserControl1

    Private Sub UserControl1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DC_MSNStyleForm1.Text = ""
    End Sub

#Region " Properties "

    Private _Barcode As String = ""
    <Description("條碼")> _
    Public Property DC_Barcode() As String
        Get
            Return _Barcode
        End Get
        Set(ByVal value As String)
            _Barcode = value
            If value = "" Then
                Me.Label1.BackColor = Color.Red
            Else
                Me.Label1.Text = "條碼: " & value
                Me.Label1.BackColor = Color.LimeGreen
            End If
        End Set
    End Property

    Private _Amp As Double
    Public Property DC_AMP() As Double
        Get
            Return Me._Amp
        End Get
        Set(ByVal value As Double)
            Me._Amp = value
            If value = 0 Then
                Me.Label2.BackColor = Color.Red
            Else
                Me.Label2.Text = "靜態電流: " & value & " mA"
                Me.Label2.BackColor = Color.LimeGreen
            End If
        End Set
    End Property

    Private _TestTime As DateTime
    Public Property DC_TestTime() As DateTime
        Get
            Return Me._TestTime
        End Get
        Set(ByVal value As DateTime)
            If value = Nothing Then
                Me.Label3.BackColor = Color.Red
            Else
                Me._TestTime = value
                Me.Label3.Text = "測試時間: " & value.ToString
                Me.Label3.BackColor = Color.LimeGreen
            End If
        End Set
    End Property

    Private _BurnFalg As Boolean
    Public Property DC_BurnFlag() As Boolean
        Get
            Return Me._BurnFalg
        End Get
        Set(ByVal value As Boolean)
            Me._BurnFalg = value
        End Set
    End Property

    Private _BurnTime As DateTime
    Public Property DC_BurnTime() As DateTime
        Get
            Return Me._BurnTime
        End Get
        Set(ByVal value As DateTime)
            If value = Nothing Then
                Me.Label4.BackColor = Color.Red
            Else
                Me._BurnTime = value
                Me.Label4.Text = "測試時間: " & value.ToString
                Me.Label4.BackColor = Color.LimeGreen
            End If

        End Set
    End Property
#End Region

#Region " Methods "

#Region " ClearProperties "
    Public Sub ClearProperties()
        Me.Label1.Text = "條碼:"
        Me.Label2.Text = "靜態電流:"
        Me.Label3.Text = "測試時間:"
        Me.Label4.Text = "完成燒機時間:"

        Me.DC_AMP = 0
        Me.DC_Barcode = ""
        Me.DC_BurnFlag = False
        Me.DC_TestTime = Nothing
        Me.DC_BurnTime = Nothing

        Me.Label1.BackColor = Color.CadetBlue
        Me.Label2.BackColor = Color.CadetBlue
        Me.Label3.BackColor = Color.CadetBlue
        Me.Label4.BackColor = Color.CadetBlue
    End Sub
#End Region

#Region " Return Exist "
    Public Function ReturnExist() As Boolean
       
        If Me.DC_Barcode <> "" AndAlso Me.DC_AMP <> 0 Then
            Return True
        Else
            Return False
        End If

        'If Me.DC_Barcode <> "" AndAlso Me.DC_AMP <> 0 AndAlso Me.DC_BurnFlag = True Then
        '    Return True
        'Else
        '    Return False
        'End If

    End Function
#End Region

#End Region

End Class
