
Imports System.Collections.ObjectModel

Public Class iniKey
    Dim myINI As INI_RW

    Public Sub New(ByVal iniPath As String, ByVal sectionName As String, ByVal keyName As String)
        Me.iniFilePath = iniPath
        Me.iniSectionName = sectionName
        Me.iniKeyName = keyName

        myINI = New INI_RW()
    End Sub


#Region " Propertys "
    Private m_filepath As String = ""
    Public Property iniFilePath() As String
        Get
            Return m_filepath
        End Get
        Set(ByVal value As String)
            m_filepath = value
        End Set
    End Property

    'Private m_filename As String = ""
    'Public Property iniFileName() As String
    '    Get
    '        Return m_filename
    '    End Get
    '    Set(ByVal value As String)
    '        m_filename = value
    '    End Set
    'End Property

    Private m_sectionname As String = ""
    Public Property iniSectionName() As String
        Get
            Return m_sectionname
        End Get
        Set(ByVal value As String)
            m_sectionname = value
        End Set
    End Property

    Private m_keyname As String = ""
    Public Property iniKeyName() As String
        Get
            Return m_keyname
        End Get
        Set(ByVal value As String)
            m_keyname = value
        End Set
    End Property

    Private m_value As String = ""
    Public WriteOnly Property SetValue() As String
        Set(ByVal value As String)
            m_value = value
            WriteValue()
        End Set
    End Property

#End Region

#Region " Events "

#End Region

#Region " Methods "

#Region " Value "
    Public Overloads Function Value() As String
        Dim newString As String = myINI.INIReadByKeyWord(Me.iniFilePath, Me.iniSectionName, Me.iniKeyName, "")
        Return newString
    End Function

    Public Overloads Function Value(ByVal DefaultValue As String) As String
        Dim newString As String = myINI.INIReadByKeyWord(Me.iniFilePath, Me.iniSectionName, Me.iniKeyName, "")
        If newString = "" Then
            Dim myINI As New INI_RW
            myINI.INIWriteByKeyWord(Me.iniFilePath, Me.iniSectionName, Me.iniKeyName, DefaultValue)
            Return DefaultValue
        Else
            Return newString
        End If
    End Function

    Private Sub WriteValue()
        Dim myINI As New INI_RW
        myINI.INIWriteByKeyWord(Me.iniFilePath, Me.iniSectionName, Me.iniKeyName, m_value)
    End Sub
#End Region

#End Region

End Class
