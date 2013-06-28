
Imports System.Collections.ObjectModel

Public Class iniSection
    Dim myINI As INI_RW

    Public Sub New(ByVal iniPath As String, ByVal sectionName As String)
        Me.iniFilePath = iniPath
        Me.iniSectionName = sectionName

        myINI = New INI_RW()

        Me.Keys = myINI.INIReadByKeyWord(Me.iniFilePath, Me.iniSectionName)
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

    Private m_keys As Collection(Of iniKey)
    Public Property Keys() As Collection(Of iniKey)
        Get
            Return m_keys
        End Get
        Set(ByVal value As Collection(Of iniKey))
            m_keys = value
        End Set
    End Property
#End Region

#Region " Events "

#End Region

#Region " Methods "

#Region " Key(ByVal Name As String) "
    Public Function Key(ByVal Name As String) As iniKey
        Dim newKey As New iniKey(Me.iniFilePath, Me.iniSectionName, Name)
        Return newKey
    End Function
#End Region

#Region " AddKey(ByVal Name As String, ByVal Value As String) "
    Public Sub AddKey(ByVal Name As String, ByVal Value As String)
        Me.myINI.INIWriteByKeyWord(Me.iniFilePath, Me.iniSectionName, Name, Value)
    End Sub
#End Region

#Region " DeleteKey(ByVal Name As String) "
    Public Sub DeleteKey(ByVal Name As String)
        Me.myINI.INIDeleteByKeyWord(Me.iniFilePath, Me.iniSectionName, Name)
    End Sub
#End Region

#End Region

End Class
