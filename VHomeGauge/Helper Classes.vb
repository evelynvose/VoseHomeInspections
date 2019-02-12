Imports System.Xml
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class XMLParser
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Protected Friend Sub New(ByVal node As XmlNode)
        m_Node = node

    End Sub
    '
    ' ***********************************************
    ' *****     Get Property Value
    ' ***********************************************
    '
    Private m_Node As XmlNode
    Public Function GetPropertyValue(ByVal prop As String) As String
        Dim s As String
        Try
            s = m_Node.SelectSingleNode(prop).InnerText

        Catch ex As Exception
            s = ""

        End Try

        Return s

    End Function

End Class

Public Enum PhoneTypes
    Mobile
    Home
    Work
End Enum
