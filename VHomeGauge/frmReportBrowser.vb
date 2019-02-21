Imports Syncfusion.Windows.Forms
Imports System.Xml
Imports System.Data
Imports System.IO

'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class frmReportBrowser
    Inherits MetroForm

    Private m_xmld As XmlDocument
    Private m_nodelist As XmlNodeList
    Private m_node As XmlNode
    Private m_ReportID As Guid
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     Refresh (the grid) Click
    ' ***********************************************
    '
    Private Sub bthRefreshDb_Click(sender As Object, e As EventArgs) Handles bthRefreshDb.Click
        dgReports.DataSource = BuildReportRepsitory()

    End Sub
    '
    ' ***********************************************
    ' *****     Import Click
    ' ***********************************************
    '
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        '
        ' Check to see if a report has been selected.
        '
        If IsNothing(dgReports.CurrentItem) Then
            MsgBox("Select a report from the grid!",, "Report Browser")
            Exit Sub
            '
        End If
        '
        ' Attempt to open and read the report into the database.
        '   First, check to see if it is already in the database.
        '
        If InspectionReport.FindByID(TryCast(dgReports.SelectedItem, ReportInfo).ReportID) Then
            MsgBox("The report is already in the dB.",, "Report Browser")
            Exit Sub
            '
        End If
        '
        ' OK - rock and roll
        '
        Try
            '
            ' Create the XML Document
            '
            m_xmld = New XmlDocument()
            '
            ' Load the Xml file
            '
            m_xmld.Load(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\190202192E\report.hr5")
            '
            ' Set the namespace
            '
            Dim oManager As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
            oManager.AddNamespace("ns", "Report")
            '
            ' Get the report's GUID, or bail out.
            '
            m_node = m_xmld.SelectSingleNode("Report/ReportGUID")
            If IsNothing(m_node) Then Exit Sub    ' Might as well bail out without a report ID
            m_ReportID = New Guid(m_node.FirstChild.Value)
            '
            ' Report Information (RI)
            '
            m_nodelist = m_xmld.SelectNodes("/Report/ReportInfo")
            '
            ' Loop through the nodes
            '
            For Each m_node In m_nodelist
                ParseInspectorInformationFromNode(m_node)
                ParseReportInformationFromNode(m_node)
                '
            Next
            '
            ' Client Information (CL) 
            '
            m_nodelist = m_xmld.SelectNodes("/Report/ClientData")
            '
            ' Loop through the nodes
            '
            For Each m_node In m_nodelist
                ParseClientsFromNode(m_node)
                '
            Next
            '
        Catch ex As Exception
            '
            'Error trapping
            '
            MsgBox("btnOpen_Click" & vbCrLf & ex.Message,, "frmOpemReport Class")
            '
        End Try
        '
        ' Tell the world that we are done!
        '
        MsgBox("Report is Imported!",, "Report Import")
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Open HG
    ' ***********************************************
    '
    Private Sub btnOpenHG_Click(sender As Object, e As EventArgs) Handles btnOpenHG.Click
        '
        ' Check to see if a report has been selected.
        '
        If IsNothing(dgReports.CurrentItem) Then
            MsgBox("Select a report from the grid!",, "Report Browser")
            Exit Sub
            '
        End If
        '
        ' Launch HG with the report.
        '
        Dim startInfo As New ProcessStartInfo
        startInfo.FileName = TryCast(dgReports.CurrentItem, ReportInfo).ReportFullName
        ' startInfo.Arguments = f
        Process.Start(startInfo)
    End Sub
    '
    ' ***********************************************
    ' *****     Open dB
    ' ***********************************************
    '
    Private Sub btnOpenDb_Click(sender As Object, e As EventArgs) Handles btnOpenDb.Click
        '
        ' Not Implemented
        '
        MsgBox("Feature not yet implemented!",, "Report Browser")
        '
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
    ' *****      Parse Report Information From Node
    ' ***********************************************
    ' 
    Public Sub ParseReportInformationFromNode(ByVal node As XmlNode)

        ' traffic lights
        If IsNothing(node) Then Exit Sub
        If m_ReportID.ToString = "" Then Exit Sub
        '
        Dim parser As New XMLParser(node)
        '
        ' Report Basic Information
        '
        Dim theReport As InspectionReport
        theReport = New InspectionReport(m_ReportID)
        With theReport
            If IsDate(parser.GetPropertyValue("RIDate")) Then
                .InspectionDate = Date.Parse(parser.GetPropertyValue("prop[@name='RIDate']"))

            End If
            .StartTime = parser.GetPropertyValue("prop[@name='RIStartTime']")
            .EndTime = parser.GetPropertyValue("prop[@name='RIStopTime']")
            .ReportNumber = parser.GetPropertyValue("prop[@name='RIReportNumber']")
            .SpecialNotes = parser.GetPropertyValue("prop[@name='RISpecialNotes']")
            .AppointmentID = New Guid(parser.GetPropertyValue("prop[@name='RIAppointmentId']"))
            .Update()
        End With
        '
        ' Inspection Address
        '
        Dim theInspectionAddress As InspectionAddress
        theInspectionAddress = New InspectionAddress(m_ReportID)
        With theInspectionAddress
            .Address1 = parser.GetPropertyValue("prop[@name='RIAddress1']")
            .Address2 = parser.GetPropertyValue("prop[@name='RIAddress2']")
            .City = parser.GetPropertyValue("prop[@name='RICity']")
            .State = parser.GetPropertyValue("prop[@name='RIState']")
            .ZipCode = parser.GetPropertyValue("prop[@name='RIZip']")
            .County = parser.GetPropertyValue("prop[@name='RICounty']")
            .Update()

        End With

    End Sub
    '
    ' ***********************************************    
    ' *****      Parse Inspector Information From Node
    ' ***********************************************
    ' 
    ' Because reports are historical legal documents, HGI captures the inspector information
    ' in the report. But... since VoseHI publishes PDF renditions, there is no need to preserve
    ' the historical aspects of the inspector information.  Instead, we will only check to see
    ' if the inspector already exists in the Person table as type Inspector, and if not, we will
    ' create the initial Person record.
    ' 
    Public Sub ParseInspectorInformationFromNode(ByVal node As XmlNode)
        If IsNothing(node) Then Exit Sub

        Dim parser As New XMLParser(node)

        Dim theInspector As New Inspector(parser.GetPropertyValue("prop[@name='RIInspector']"))
        theInspector.Update()

    End Sub
    '
    ' ***********************************************    
    ' *****      Parse Client(s) From Node
    ' ***********************************************
    '
    Public Sub ParseClientsFromNode(ByVal node As XmlNode)
        If IsNothing(node) Then Exit Sub

        Dim parser As New XMLParser(node)

        ' This is not an acceptable condition
        If parser.GetPropertyValue("prop[@name='CGuid']") = "" Then Exit Sub

        ' Convert the string representation of the HG Report GUID to a GUID struct
        Dim thePersonID As Guid = New Guid(parser.GetPropertyValue("prop[@name='CGuid']"))
        '
        ' ***********************************************
        ' *****      CLIENT NAME
        ' ***********************************************
        '
        Dim theClient As New Client(thePersonID)
        With theClient
            .FirstName = parser.GetPropertyValue("prop[@name='CFName1']")
            .LastName = parser.GetPropertyValue("prop[@name='CLName1']")
            .UserName = parser.GetPropertyValue("prop[@name='CSHGIName']")
            .Update()
        End With
        '
        ' ***********************************************
        ' *****      PHYSICAL ADDRESS
        ' ***********************************************
        '
        ' This has to come after the PersonID is created in the dB, otherwise, the object won't know how
        ' to type the object.
        '
        Dim theClientAddress As ClientAddress = New ClientAddress(thePersonID)
        '
        With theClientAddress
            .Address1 = parser.GetPropertyValue("prop[@name='CAddress']")
            .Address2 = parser.GetPropertyValue("prop[@name='CAddress2']")
            .City = parser.GetPropertyValue("prop[@name='CCity']")
            .State = parser.GetPropertyValue("prop[@name='CState']")
            .ZipCode = parser.GetPropertyValue("prop[@name='CZip']")
            .County = parser.GetPropertyValue("prop[@name='CCounty']")
            .Country = parser.GetPropertyValue("prop[@name='CCountry']")
            .Update()

        End With
        '
        ' ***********************************************
        ' *****      Mobile Phone
        ' ***********************************************
        '
        Dim theMobilePhone As New PersonMobilePhone(thePersonID)
        theMobilePhone.Number = parser.GetPropertyValue("prop[@name='CMobilePhone']")
        theMobilePhone.Update()
        '
        ' ***********************************************
        ' *****      Home Phone
        ' ***********************************************
        '
        Dim theHomePhone As New PersonHomePhone(thePersonID)
        theHomePhone.Number = parser.GetPropertyValue("prop[@name='CHomePhone']")
        theHomePhone.Update()
        '
        ' ***********************************************
        ' *****      Work Phone
        ' ***********************************************
        '
        Dim theWorkPhone As New PersonWorkPhone(thePersonID)
        theWorkPhone.Number = parser.GetPropertyValue("prop[@name='CWorkPhone']")
        theWorkPhone.Update()
        '
        ' ***********************************************
        ' *****     Primary Email Address
        ' ***********************************************
        '
        If parser.GetPropertyValue("prop[@name='CEmail']") <> "" Then
            Dim thePrimaryEmailAddress As EmailAddress
            thePrimaryEmailAddress = New EmailAddress(thePersonID, EmailAddressTypes.Primary)
            thePrimaryEmailAddress.URL = parser.GetPropertyValue("prop[@name='CEmail']")
            thePrimaryEmailAddress.Update()

        End If
        '
        ' ***********************************************
        ' *****     Second Email Address
        ' ***********************************************
        '
        If parser.GetPropertyValue("prop[@name='CEmail2']") <> "" Then
            Dim theSecondEmailAddress As EmailAddress
            theSecondEmailAddress = New EmailAddress(thePersonID, EmailAddressTypes.Second)
            theSecondEmailAddress.URL = parser.GetPropertyValue("prop[@name='CEmail2']")
            theSecondEmailAddress.Update()

        End If
        '
    End Sub
    '   '
    ' ***********************************************    
    ' *****      Build Report Repository
    ' ***********************************************
    '
    Private Function BuildReportRepsitory() As IList(Of ReportInfo)
        '
        Dim reportRepos As IList(Of ReportInfo) = New List(Of ReportInfo)
        '
        ' Open ever file that fits the filter: report.hr5.
        ' Because HG stores reports in folders and the filename is always Report.hr5, we have
        '   to filter our superfluous folders such as temporary reports and HG supplied sample reports.
        '
        Try
            For Each f As String In Directory.GetFiles(My.Settings.HomeGaugeReportsPath, "report.hr5", SearchOption.AllDirectories)
                If f.Contains("00000") Then Continue For ' Typical temporary directories start with at least five zeros: 00000
                If f.Contains("sample") Then Continue For ' Sample reports
                If f.Contains("Sample") Then Continue For ' Sample reports
                '
                ' Okay - let's go!
                '
                Dim theReportFile As New ReportInfo
                theReportFile.SetPath(f)        ' set the path, which kicks off an XML file parser to fill the FileInfo's data from the report.
                reportRepos.Add(theReportFile)
                '
            Next
        Catch ex As Exception
            MsgBox("BuildReportRepository()" & vbCrLf & ex.Message,, "frmOpenReport Class")
            '
        End Try
        '
        Return reportRepos
        '
    End Function
    '
End Class
' /////////////////////////////////////////////////  END CLASS  /////////////////////////////////////////////////////////////////

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
            m_ReportNumber = reportSplits(0)
            '
            ' Version Number
            '
            m_Version = "1.0"
            If reportSplits.Count > 0 Then
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
