
Imports System.Collections.ObjectModel

Public Class iniClass
    Dim myINI As New INI_RW

    Public Sub New(ByVal iniPath As String)
        Me.iniFilePath = iniPath

        Me.Sections = myINI.INIReadSectionNames(Me.iniFilePath)
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

    Private m_sections As Collection(Of iniSection)
    Public Property Sections() As Collection(Of iniSection)
        Get
            Return m_sections
        End Get
        Set(ByVal value As Collection(Of iniSection))
            m_sections = value
        End Set
    End Property
#End Region

#Region " Events "

#End Region

#Region " Methods "

#Region " Section(name as string) "
    Public Function Section(ByVal name As String) As iniSection
        Dim newSection As New iniSection(Me.iniFilePath, name)
        Return newSection
    End Function
#End Region

#Region " AddSection(ByVal SectionName As String, ByVal KeyName As String, ByVal Value As String) "
    Public Sub AddSection(ByVal SectionName As String, ByVal KeyName As String, ByVal Value As String)
        Me.myINI.INIWriteByKeyWord(Me.iniFilePath, SectionName, KeyName, Value)
    End Sub
#End Region

#Region " DeleteSection(ByVal Name As String) "
    Public Sub DeleteSection(ByVal Name As String)
        Me.myINI.INIDeleteBySectionName(Me.iniFilePath, Name)
    End Sub
#End Region

#End Region

End Class
