Imports System.Xml
Imports System.IO
'
' **********************************************
' ****
' ******    Class: ReportInfo
' ****
' **********************************************
'
Public Class ReportInfo
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    '
    Public Sub New()

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    '
    '
    ' ***********************************************
    ' *****     Set Path (to the report)
    ' ***********************************************
    '
    Public Sub SetPath(ByVal fp As String)
        m_FileInfoObject = New FileInfo(fp)
        ParseTheReport()

    End Sub
    '
    ' ***********************************************
    ' *****     Parse The Report
    ' ***********************************************
    '
    Private Sub ParseTheReport()
        Try
            '
            ' Create the XML Document
            '
            Dim xmlDoc = New XmlDocument()
            '
            'Load the Xml file
            '
            xmlDoc.Load(ReportFullName)
            '
            ' Set the namespace
            '
            Dim oManager As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
            oManager.AddNamespace("ns", "Report")
            '
            ' Get the report's GUID, or bail out.
            '
            Dim node As XmlNode
            node = xmlDoc.SelectSingleNode("Report/ReportGUID")
            If IsNothing(node) Then Exit Sub    ' Might as well bail out without a report ID
            m_ReportID = New Guid(node.FirstChild.Value)
            '
            ' Report Information (RI)
            '
            Dim nodeList As XmlNodeList
            nodeList = xmlDoc.SelectNodes("/Report/ReportInfo")
            '
            ' Loop through the nodes
            '
            For Each node In nodeList
                Dim parser As New XMLParser(node)
                Address = parser.GetPropertyValue("prop[@name='RIAddress1']")
                City = parser.GetPropertyValue("prop[@name='RICity']")
                ZipCode = parser.GetPropertyValue("prop[@name='RIZip']")
                ReportNumber = parser.GetPropertyValue("prop[@name='RIReportNumber']")

            Next
            '
            ' Agent Information Information (P) 
            '
            node = xmlDoc.SelectSingleNode("/Report/ReportInfo/Person/PFName")
            If Not IsNothing(node) Then AgentName = node.FirstChild.Value
            '
            node = xmlDoc.SelectSingleNode("/Report/ReportInfo/Person/PLName")
            If Not IsNothing(node) Then
                AgentName &= " " & node.FirstChild.Value
            End If
            '
            ' Client Information (CL) 
            '
            nodeList = xmlDoc.SelectNodes("/Report/ClientData")
            '
            ' Loop through the nodes
            '
            For Each node In nodeList
                Dim parser As New XMLParser(node)
                ClientName = String.Format("{0} {1}", parser.GetPropertyValue("prop[@name='CFName1']"), parser.GetPropertyValue("prop[@name='CLName1']"))

            Next
            '
        Catch ex As Exception
            '
            ' Error trapping
            '
            MsgBox("ParseTheReport()" & vbCrLf & ex.Message,, "ReportRepository Class")

        End Try

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_FileInfoObject As FileInfo
    Private m_ReportID As Guid = Guid.Empty
    Private m_ReportNumber As String
    Private m_Version As String
    Private m_Address As String
    Private m_City As String
    Private m_ZipCode As String
    Private m_AgentName As String
    Private m_ClientName As String
    '
    ' ***********************************************
    ' *****     File Full Name
    ' ***********************************************
    '
    Public ReadOnly Property ReportFullName As String
        Get
            Return m_FileInfoObject.FullName
        End Get

    End Property
    '
    ' ***********************************************
    ' *****     File Name
    ' ***********************************************
    '
    Public ReadOnly Property FileName As String
        Get
            Return m_FileInfoObject.Name
        End Get
    End Property
    '
    ' ***********************************************
    ' *****     Report Number
    ' ***********************************************
    '
    Public Property ReportNumber As String
        Get
            Return m_ReportNumber
        End Get
        Set(value As String)
            '
            ' Report Number
            '
            Dim reportSplits() As String
            reportSplits = value.Split(" ")
            If reportSplits.Count > 0 Then
                m_ReportNumber = reportSplits(0)
                '
            End If
            '
            ' Version Number
            '
            m_Version = "1.0"
            If reportSplits.Count > 1 Then
                m_Version = reportSplits(1)

            End If
            Dim sTemp As String
            sTemp = m_Version.TrimStart("v")
            m_Version = sTemp.Trim("V")
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Version
    ' ***********************************************
    '
    Public ReadOnly Property Version As String
        Get
            Return m_Version
        End Get
    End Property
    '
    ' ***********************************************
    ' *****     Path
    ' ***********************************************
    '
    Public ReadOnly Property Path As String
        Get
            Return m_FileInfoObject.FullName.Remove(FileName)
        End Get
    End Property
    '
    ' ***********************************************
    ' *****     File Info Object
    ' ***********************************************
    '
    Public ReadOnly Property FileInfoObject As FileInfo
        Get
            Return m_FileInfoObject
        End Get
    End Property
    '
    ' ***********************************************
    ' *****     Address
    ' ***********************************************
    '    
    Public Property Address As String
        Get
            Return m_Address
        End Get
        Set(value As String)
            m_Address = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     City
    ' ***********************************************
    '
    Public Property City As String
        Get
            Return m_City
        End Get
        Set(value As String)
            m_City = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Zip Code
    ' ***********************************************
    '
    Public Property ZipCode As String
        Get
            Return m_ZipCode
        End Get
        Set(value As String)
            m_ZipCode = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Agent Name
    ' ***********************************************
    '
    Public Property AgentName As String
        Get
            Return m_AgentName
        End Get
        Set(value As String)
            m_AgentName = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Client Name
    ' ***********************************************
    '
    Public Property ClientName As String
        Get
            Return m_ClientName
        End Get
        Set(value As String)
            m_ClientName = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Report ID
    ' ***********************************************
    '
    Public ReadOnly Property ReportID As Guid
        Get
            Return m_ReportID
        End Get
    End Property
End Class

