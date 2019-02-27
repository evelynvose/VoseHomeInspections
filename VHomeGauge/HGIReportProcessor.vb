Imports System.Xml
Imports System.IO
'
' TODO Add a DoWork() method.
' TODO Remove any ability to call a method other than DoWork().
' TODO Convert all message box messages to raised events.
' TODO Update the project flowchart.
' TODO Change frmReportBrowser form to use the new DoWork protocol re this class.
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
' This is a DoWork compliant task. It is meant to be run as a background process/thread
' and code design complies to those requirements such as: 1) Has a DoWork() Method that is called
' by the background thread start process. No arguments are allowed. 2) All error messages as raised through
' events. No message box messages are allowed. 3) Runtime parameters are set as properties of this class
' prior to the background processor invoking DoWork() method.
'
Public Class HGIReportProcessor
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     New ()
    ' ***********************************************
    '
    Public Sub New()
        ' Do Nothing
    End Sub
    '
    ' ***********************************************
    ' *****     New (FileInfo)
    ' ***********************************************
    '
    Private m_FileInfo As FileInfo
    Public Sub New(ByVal theReportFullName As FileInfo)
        m_FileInfo = theReportFullName
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
    ' *****     Process The Report (FileInfo)
    ' ***********************************************
    '
    Public Function ProcessTheReport(ByVal theFileInfo As FileInfo) As Boolean
        m_FileInfo = theFileInfo
        Return ProcessTheReport()

    End Function
    '
    ' ***********************************************
    ' *****     DoWork
    ' ***********************************************
    '
    Public Sub DoWork()
        ProcessTheReport()

    End Sub
    '
    ' ***********************************************
    ' *****     Process The Report ()
    ' ***********************************************
    '
    Public Function ProcessTheReport() As Boolean
        If IsNothing(m_FileInfo) OrElse m_FileInfo.FullName = "" Then
            '
            MsgBox("ProcessReport()" & vbCrLf & "The report path is an empty string!",, "HGIReportProcessor Class")
            Return False
            '
        End If
        '
        ' Begin Processing
        '
        Try
            '
            ' Create the XML Document
            '
            Dim Xmld As New XmlDocument()
            '
            ' Load the Xml file
            '
            Xmld.Load(m_FileInfo.FullName)
            '
            ' Set the namespace
            '
            Dim oManager As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
            oManager.AddNamespace("ns", "Report")
            '
            ' Get the report's GUID, or bail out.
            '
            Dim node As XmlNode
            node = Xmld.SelectSingleNode("/Report/ReportGUID")
            If IsNothing(node) Then Return False    ' Might as well bail out without a report ID
            m_ReportID = New Guid(node.FirstChild.Value)
            '
            ' Report Information (RI)
            '
            Dim nodelist As XmlNodeList
            nodelist = Xmld.SelectNodes("/Report/ReportInfo")
            '
            ' Loop through the nodes
            '
            For Each node In nodelist
                ParseInspectorInformationFromNode(node)
                ParseReportInformationFromNode(node)
                '
            Next
            '
            ' Agent Information (P)
            '
            nodelist = node.SelectNodes("Person")
            ' nodelist = Xmld.SelectNodes("/Report/ReportInfo/Person")
            For Each node In nodelist
                ParseAgentInformationFromNode(node)

            Next
            'node = Xmld.SelectSingleNode("Report/ReportInfo/Person")
            'ParseAgentInformationFromNode(Xmld)
            '
            ' Client Information (CL) 
            '
            nodelist = Xmld.SelectNodes("/Report/ClientData")
            '
            ' Loop through the nodes
            '
            For Each node In nodelist
                ParseClientsFromNode(node)
                '
            Next
            '
        Catch ex As Exception
            '
            'Error trapping
            '
            MsgBox("btnOpen_Click" & vbCrLf & ex.Message,, "frmOpemReport Class")
            Return False
            '
        End Try
        '
        Return True
        '
    End Function
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
    '
    ' ***********************************************
    ' *****      Parse Agent
    ' ***********************************************
    ' 
    Public Sub ParseAgentInformationFromNode(ByRef theParentNode As XmlNode)
        '
        If IsNothing(theParentNode) Then Exit Sub
        '
        ' Get the HGI assigned Agent Guid, bail if not found or is invalid
        '
        Dim tempGuid As Guid
        Try
            tempGuid = New Guid(theParentNode.SelectSingleNode("PGuid").FirstChild.Value)
            If tempGuid.Equals(New Guid) Then Exit Sub

        Catch ex As Exception
            MsgBox("ParseAgentInformationFromNode" & vbCrLf & ex.Message,, "HGReportProcessor Class")
            Exit Sub

        End Try
        '
        ' We probably have a valid Guid so we can instantiate the Agent Object and save the agent to the dB
        '
        Dim theAgent As New Agent(tempGuid)
        With theAgent
            For Each node As XmlNode In theParentNode.ChildNodes
                Select Case node.Name
                    Case "PFName"
                        .FirstName = node.FirstChild.Value
                        '
                    Case "PLName"
                        .LastName = node.FirstChild.Value
                        '
                    Case "PSHGIName"
                        .UserName = node.FirstChild.Value
                        '
                    Case "PRole"
                        Select Case node.FirstChild.Value
                            Case "Buyer Agent"
                                .Role = PersonRoles.BuyerAgent

                            Case "Listing Agent"
                                .Role = PersonRoles.SellerAgent

                            Case "Agency Coordinator"
                                .Role = PersonRoles.AgencyCoordinator

                            Case Else
                                .Role = -1

                        End Select
                        '
                    Case Else
                        ' Do nothing
                        '
                End Select
            Next
            '
            ' Saving the Agent Information to the dB would be nice!
            '
            Try
                .Update()
                '
            Catch ex As Exception
                '
                MsgBox("ParseAgentInformationFromNode()" & vbCrLf & ex.Message,, "HGIReportParser Class")
                '
            End Try
            '
        End With
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_ReportID As Guid = Guid.Empty

    Public ReadOnly Property ReportID As Guid
        Get
            Return m_ReportID
        End Get
    End Property
End Class
