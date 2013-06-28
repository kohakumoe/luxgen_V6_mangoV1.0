
Imports System.Collections.ObjectModel
Imports System.Runtime.InteropServices

Friend Class INI_RW
    Public Sub New()

    End Sub

#Region " Propertys "

#End Region

#Region "API Calls"
    ' standard API declarations for INI access
    ' changing only "As Long" to "As Int32" (As Integer would work also)
    Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" _
    Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String, _
        ByVal lpKeyName As String, ByVal lpString As String, _
        ByVal lpFileName As String) As Int32

    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" _
    Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String, _
        ByVal lpKeyName As String, ByVal lpDefault As String, _
        ByVal lpReturnedString As String, ByVal nSize As Int32, _
        ByVal lpFileName As String) As Int32

    Private Declare Unicode Function GetPrivateProfileSectionNames Lib "kernel32" _
    Alias "GetPrivateProfileSectionNamesW" (ByVal lpszReturnBuffer As String, _
        ByVal nSize As Int32, ByVal lpFileName As String) As Int32


#End Region

#Region " 讀取所有Section名稱 "

    'Public Overloads Function INIReadSectionNames() As Collection
    '    Dim returnCollection As New Collection

    '    Dim n As Int32
    '    Dim sData As String
    '    sData = Space$(1024)
    '    Dim gData As String
    '    Dim pp As Char

    '    n = GetPrivateProfileSectionNames(sData, sData.Length, Me.INIPath)

    '    For i As Integer = 0 To n
    '        pp = sData.Substring(i, 1)
    '        If Asc(pp) = 0 Then
    '            gData = gData + ","
    '        Else
    '            gData = gData + pp
    '        End If
    '    Next

    '    Dim mystring() As String
    '    If n > 0 Then ' return whatever it gave us
    '        mystring = gData.Substring(0, n).Split(",")
    '        For i As Integer = 0 To mystring.GetUpperBound(0) - 1
    '            returnCollection.Add(mystring(i))
    '        Next
    '        Return returnCollection
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    Public Overloads Function INIReadSectionNames(ByVal INIPath As String) As Collection(Of iniSection)
        Dim returnCollection As New Collection(Of iniSection)

        Dim n As Int32
        Dim sData As String
        sData = Space$(1024)
        Dim gData As String = ""
        Dim pp As Char

        n = GetPrivateProfileSectionNames(sData, sData.Length, INIPath)

        For i As Integer = 0 To n
            pp = sData.Substring(i, 1)
            If Asc(pp) = 0 Then
                gData = gData + ","
            Else
                gData = gData + pp
            End If
        Next

        Dim mystring() As String
        If n > 0 Then ' return whatever it gave us
            mystring = gData.Substring(0, n).Split(",")
            For i As Integer = 0 To mystring.GetUpperBound(0) - 1
                Dim newSection As New iniSection(INIPath, mystring(i))
                returnCollection.Add(newSection)
            Next
            Return returnCollection
        Else
            Return Nothing
        End If
    End Function
#End Region

#Region " 讀取INI方法(KeyWord) "

    Public Overloads Function INIReadByKeyWord(ByVal iniPath As String, _
        ByVal SectionName As String, ByVal KeyName As String, _
        ByVal DefaultValue As String) As String
        ' primary version of call gets single value given all parameters
        Dim n As Int32
        Dim sData As String
        sData = Space$(1024) ' allocate some room 

        n = GetPrivateProfileString(SectionName, KeyName, DefaultValue, _
        sData, sData.Length, iniPath)
        If n > 0 Then ' return whatever it gave us
            Return sData.Substring(0, n)
        Else
            Return ""
        End If
    End Function

    Public Overloads Function INIReadByKeyWord(ByVal iniPath As String, _
        ByVal SectionName As String, ByVal KeyName As String) As String
        ' overload 1 assumes zero-length default
        Return INIReadByKeyWord(iniPath, SectionName, KeyName, "")
    End Function

    Public Overloads Function INIReadByKeyWord(ByVal iniPath As String, _
    ByVal SectionName As String) As Collection(Of iniKey)

        Dim returnCollection As New Collection(Of iniKey)

        ' overload 2 returns all keys in a given section of the given file
        Dim n As Int32
        Dim sData As String
        sData = Space$(1024) ' allocate some room 
        Dim gData As String = ""
        Dim pp As Char

        n = GetPrivateProfileString(SectionName, Nothing, "", _
        sData, sData.Length, iniPath)
        For i As Integer = 0 To n
            pp = sData.Substring(i, 1)
            If Asc(pp) = 0 Then
                gData = gData + ","
            Else
                gData = gData + pp
            End If
        Next

        Dim mystring() As String
        If n > 0 Then ' return whatever it gave us
            mystring = gData.Substring(0, n).Split(",")
            For i As Integer = 0 To mystring.GetUpperBound(0) - 1
                Dim newKey As New iniKey(iniPath, SectionName, mystring(i))
                returnCollection.Add(newKey)
            Next
            Return returnCollection
        Else
            Return Nothing
        End If
    End Function

    'Public Overloads Function INIReadByKeyWord(ByVal INIPath As String) As String
    '    ' overload 3 returns all section names given just path
    '    Return INIReadByKeyWord(INIPath, Nothing, Nothing, "")
    'End Function

#End Region

#Region " 寫入INI方法(KeyWord) "

    Public Sub INIWriteByKeyWord(ByVal INIPath As String, ByVal SectionName As String, _
    ByVal KeyName As String, ByVal TheValue As String)
        Call WritePrivateProfileString(SectionName, KeyName, TheValue, INIPath)
    End Sub

#End Region

#Region " 刪除INI方法 "

    Public Overloads Sub INIDeleteByKeyWord(ByVal INIPath As String, ByVal SectionName As String, _
        ByVal KeyName As String) ' delete single line from section
        Call WritePrivateProfileString(SectionName, KeyName, Nothing, INIPath)
    End Sub

    Public Overloads Sub INIDeleteBySectionName(ByVal INIPath As String, ByVal SectionName As String)
        ' delete section from INI file
        Call WritePrivateProfileString(SectionName, Nothing, Nothing, INIPath)
    End Sub

#End Region

End Class
