Imports System.Xml
Imports System.IO
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
    Inherits VDoWork
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     New (FileInfo)
    ' ***********************************************
    '
    Private m_FileInfo As FileInfo
    Public Sub New(ByVal theReportFileInfo As FileInfo)
        '
        ' Raise an event if the report path doesn't resolve to a report file
        '
        m_FileInfo = theReportFileInfo
        IsReportPathValid = True
        '
        ' Validate the report path
        '
        If IsNothing(theReportFileInfo) OrElse theReportFileInfo.Name = "" Then
            LastErrorMessage = "Can't process the report." & vbCrLf & "The report path is empty!"
            IsReportPathValid = False
            '
        End If
        '
        ' An HGI report file name must end in hr5 so this processor can understand its format and contents.
        '
        If Not theReportFileInfo.Name.ToLower.Contains(".hr5".ToLower) Then
            LastErrorMessage = "Can't process the report." & vbCrLf & "The file name doesn't end in .hr5!"
            IsReportPathValid = False
            '
        End If
        '
        ' Continue or exit depending on whether or not the report path is valid
        '
        If Not IsReportPathValid Then
            RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.ErrorCondition, LastErrorMessage))
            '
        End If
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
    ' *****     DoWork
    ' ***********************************************
    '
    Protected Overrides Sub TheDoWorkMethod()
        '
        ' This method serves solely to expose the report processor method and is
        '      a Vose requirement for vProgressBar.
        '
        ProcessTheReport()
        '
        ' Set the terrmination Message
        '
        Dim sTerminationMessage As String
        If ErrorList.Count = 0 Then
            sTerminationMessage = "Success!"

        Else
            sTerminationMessage = "Succes, but with errors!"
        End If
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Termination, sTerminationMessage))        '
    End Sub
    '
    ' ***********************************************
    ' *****     Process The Report ()
    ' ***********************************************
    '
    Private Function ProcessTheReport() As Boolean
        '
        ' Error Checking
        '
        If Not IsReportPathValid Then Return False
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
            For Each node In nodelist
                ParseAgentInformationFromNode(node)
                '
            Next
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
            LastErrorMessage = "ProcessTheReport()" & vbCrLf & ex.Message
            ' RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.ErrorCondition, LastErrorMessage))
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
    Private WithEvents m_Report As InspectionReport
    Private Sub ParseReportInformationFromNode(ByVal node As XmlNode)
        '
        ' Error Checking
        '
        If IsNothing(node) Then Exit Sub
        If m_ReportID.ToString = "" Then Exit Sub
        '
        ' Progress Update
        '
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, "Parsing report information.."))
        '
        ' Report Basic Information
        '
        Dim parser As New XMLParser(node)
        m_Report = New InspectionReport(m_ReportID)
        AddHandler m_Report.VEvent, AddressOf VEvent_Handler
        With m_Report
            If IsDate(parser.GetPropertyValue("RIDate")) Then
                .InspectionDate = Date.Parse(parser.GetPropertyValue("prop[@name='RIDate']"))

            End If
            .StartTime = parser.GetPropertyValue("prop[@name='RIStartTime']")
            .EndTime = parser.GetPropertyValue("prop[@name='RIStopTime']")
            .ReportNumber = parser.GetPropertyValue("prop[@name='RIReportNumber']")
            .SpecialNotes = parser.GetPropertyValue("prop[@name='RISpecialNotes']")
            .AppointmentID = New Guid(parser.GetPropertyValue("prop[@name='RIAppointmentId']"))
            .Update()
            '
        End With
        '
        ' Progress Update
        '
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, "Parsing inspection address.."))
        '
        ' Inspection Address
        '
        Dim theInspectionAddress As InspectionAddress
        theInspectionAddress = New InspectionAddress(m_ReportID)
        AddHandler theInspectionAddress.VEvent, AddressOf VEvent_Handler
        With theInspectionAddress
            .Address1 = parser.GetPropertyValue("prop[@name='RIAddress1']")
            .Address2 = parser.GetPropertyValue("prop[@name='RIAddress2']")
            .City = parser.GetPropertyValue("prop[@name='RICity']")
            .State = parser.GetPropertyValue("prop[@name='RIState']")
            .ZipCode = parser.GetPropertyValue("prop[@name='RIZip']")
            .County = parser.GetPropertyValue("prop[@name='RICounty']")
            .Update()
            '
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
    Private Sub ParseInspectorInformationFromNode(ByVal node As XmlNode)
        '
        ' Error checking
        '
        If IsNothing(node) Then Exit Sub
        '
        ' Progress Update
        '
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, "Parsing inspector information.."))
        '
        '
        '
        Dim parser As New XMLParser(node)
        Dim theInspector As New Inspector(parser.GetPropertyValue("prop[@name='RIInspector']"))
        AddHandler theInspector.VEvent, AddressOf VEvent_Handler
        theInspector.Update()
        '
    End Sub
    '
    ' ***********************************************    
    ' *****      Parse Client(s) From Node
    ' ***********************************************
    '
    Private Sub ParseClientsFromNode(ByVal node As XmlNode)
        '
        ' Error Checking
        '
        If IsNothing(node) Then Exit Sub
        '
        ' This is not an acceptable condition
        '
        Dim parser As New XMLParser(node)
        If parser.GetPropertyValue("prop[@name='CGuid']") = "" Then
            LastErrorMessage = "The report client does not have a GUID."
            RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.ErrorCondition, LastErrorMessage))
            Exit Sub
            '
        End If
        '
        ' Progress Update
        '
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, "Parsing client information.."))
        '
        ' Convert the string representation of the HG Report GUID to a GUID struct
        '
        Dim thePersonID As Guid = New Guid(parser.GetPropertyValue("prop[@name='CGuid']"))
        '
        ' ***********************************************
        ' *****      CLIENT NAME
        ' ***********************************************
        '
        Dim theClient As New Client(thePersonID)
        AddHandler theClient.VEvent, AddressOf VEvent_Handler
        With theClient
            .FirstName = parser.GetPropertyValue("prop[@name='CFName1']")
            .LastName = parser.GetPropertyValue("prop[@name='CLName1']")
            .UserName = parser.GetPropertyValue("prop[@name='CSHGIName']")
            .Update()
            '
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
        AddHandler theClientAddress.VEvent, AddressOf VEvent_Handler
        With theClientAddress
            .Address1 = parser.GetPropertyValue("prop[@name='CAddress']")
            .Address2 = parser.GetPropertyValue("prop[@name='CAddress2']")
            .City = parser.GetPropertyValue("prop[@name='CCity']")
            .State = parser.GetPropertyValue("prop[@name='CState']")
            .ZipCode = parser.GetPropertyValue("prop[@name='CZip']")
            .County = parser.GetPropertyValue("prop[@name='CCounty']")
            .Country = parser.GetPropertyValue("prop[@name='CCountry']")
            .Update()
            '
        End With
        '
        ' ***********************************************
        ' *****      Mobile Phone
        ' ***********************************************
        '
        If parser.GetPropertyValue("prop[@name='CMobilePhone']") <> "" Then
            Dim theMobilePhone As New PersonMobilePhone(thePersonID)
            AddHandler theMobilePhone.VEvent, AddressOf VEvent_Handler
            theMobilePhone.Number = parser.GetPropertyValue("prop[@name='CMobilePhone']")
            theMobilePhone.Update()
            '
        End If
        '
        ' ***********************************************
        ' *****      Home Phone
        ' ***********************************************
        '
        If parser.GetPropertyValue("prop[@name='CHomePhone']") <> "" Then
            Dim theHomePhone As New PersonHomePhone(thePersonID)
            AddHandler theHomePhone.VEvent, AddressOf VEvent_Handler
            theHomePhone.Number = parser.GetPropertyValue("prop[@name='CHomePhone']")
            theHomePhone.Update()
            '
        End If
        '
        ' ***********************************************
        ' *****      Work Phone
        ' ***********************************************
        '
        If parser.GetPropertyValue("prop[@name='CWorkPhone']") <> "" Then
            Dim theWorkPhone As New PersonWorkPhone(thePersonID)
            AddHandler theWorkPhone.VEvent, AddressOf VEvent_Handler
            theWorkPhone.Number = parser.GetPropertyValue("prop[@name='CWorkPhone']")
            theWorkPhone.Update()
            '
        End If
        '
        ' ***********************************************
        ' *****     Primary Email Address
        ' ***********************************************
        '
        If parser.GetPropertyValue("prop[@name='CEmail']") <> "" Then
            Dim thePrimaryEmailAddress As EmailAddress
            thePrimaryEmailAddress = New EmailAddress(thePersonID, EmailAddressTypes.Primary)
            AddHandler thePrimaryEmailAddress.VEvent, AddressOf VEvent_Handler
            thePrimaryEmailAddress.URL = parser.GetPropertyValue("prop[@name='CEmail']")
            thePrimaryEmailAddress.Update()
            '
        End If
        '
        ' ***********************************************
        ' *****     Second Email Address
        ' ***********************************************
        '
        If parser.GetPropertyValue("prop[@name='CEmail2']") <> "" Then
            Dim theSecondEmailAddress As EmailAddress
            theSecondEmailAddress = New EmailAddress(thePersonID, EmailAddressTypes.Second)
            AddHandler theSecondEmailAddress.VEvent, AddressOf VEvent_Handler
            theSecondEmailAddress.URL = parser.GetPropertyValue("prop[@name='CEmail2']")
            theSecondEmailAddress.Update()
            '
        End If
        '
        ' ***********************************************
        ' *****     Client's Role
        ' ***********************************************
        '
        ' Since this is an HG report, all clients are in the Buyer's role
        '
        If RoleInfo.Find(theClient, m_Report) = 0 Then
            Dim theRole As New RoleInfo
            Try
                With theRole
                    .PersonID = thePersonID
                    .ReportID = m_ReportID
                    .RoleLutID = RoleTypes.Client
                    .Update()
                    '
                End With
                '
            Catch ex As Exception
                MsgBox(ex)
                '
            End Try
        End If
    End Sub
    '
    ' ***********************************************
    ' *****      Parse Agent
    ' ***********************************************
    ' 
    Private Sub ParseAgentInformationFromNode(ByRef theParentNode As XmlNode)
        '
        ' Error checking
        '
        If IsNothing(theParentNode) Then Exit Sub
        '
        ' Progress Update
        '
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, "Parsing agent information.."))
        '
        ' Get the HGI assigned Agent Guid, bail if not found or is invalid
        '
        Dim tempGuid As Guid
        Try
            tempGuid = New Guid(theParentNode.SelectSingleNode("PGuid").FirstChild.Value)
            If tempGuid.Equals(New Guid) Then Exit Sub
            '
        Catch ex As Exception
            LastErrorMessage = "ParseAgentInformationFromNode" & vbCrLf & ex.Message
            RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.ErrorCondition, LastErrorMessage))
            Exit Sub
            '
        End Try
        '
        ' We probably have a valid Guid so we can instantiate the Agent Object and save the agent to the dB
        '
        Dim theAgent As New Agent(tempGuid)
        Dim theRole As New RoleInfo
        AddHandler theAgent.VEvent, AddressOf VEvent_Handler
        AddHandler theAgent.VEvent, AddressOf VEvent_Handler
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
                                theRole.RoleLutID = RoleTypes.BuyerAgent
                                '
                            Case "Listing Agent"
                                theRole.RoleLutID = RoleTypes.ListingAgent
                                '
                            Case "Agency Coordinator"
                                theRole.RoleLutID = RoleTypes.AgencyCoordinator
                                '
                            Case Else
                                theRole.RoleLutID = -1
                                '
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
                Try
                    If RoleInfo.Find(theAgent, m_Report) = 0 Then
                        With theRole
                            .PersonID = tempGuid
                            .ReportID = m_ReportID
                            .Update()
                            '
                        End With
                    End If
                    '
                Catch ex As Exception
                    LastErrorMessage = "ParseAgentInformationFromNode()" & vbCrLf & ex.Message
                    RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.ErrorCondition, LastErrorMessage))
                    '
                End Try
            Catch ex As Exception
                '
                LastErrorMessage = "ParseAgentInformationFromNode()" & vbCrLf & ex.Message
                RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.ErrorCondition, LastErrorMessage))
                '
            End Try
            '
        End With
        '
    End Sub
    '
    ' ***********************************************
    ' *****      -VEvent(object, object)
    ' ***********************************************
    ' 
    Private Sub VEvent_Handler(sender As Object, e As VEventArgs)
        RaiseVEvent(sender, e)

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties & Data
    ' ****
    ' **********************************************
    '
    Private m_ReportID As Guid = Guid.Empty
    Private m_IsReportPathValid As Boolean
    '
    ' ***********************************************
    ' *****      Is Report Path Valid
    ' ***********************************************
    ' 
    Private Property IsReportPathValid As Boolean
        Get
            Return m_IsReportPathValid
        End Get
        Set(value As Boolean)
            m_IsReportPathValid = value
        End Set
    End Property

End Class

