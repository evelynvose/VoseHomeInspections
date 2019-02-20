Imports Syncfusion.Windows.Forms
Imports System.Xml
Imports System.Data

'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class WorkFormOpenReport
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
    Private Sub bthRefreshDb_Click(sender As Object, e As EventArgs) Handles bthRefreshDb.Click

        Try
            'Create the XML Document
            m_xmld = New XmlDocument()

            'Load the Xml file
            m_xmld.Load(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\190202192E\report.hr5")

            ' Set the namespace
            Dim oManager As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
            oManager.AddNamespace("ns", "Report")

            ' Get the report's GUID 
            m_node = m_xmld.SelectSingleNode("Report/ReportGUID")
            m_ReportID = New Guid(m_node.FirstChild.Value)
            '
            ' Report Information (RI)
            '
            m_nodelist = m_xmld.SelectNodes("/Report/ReportInfo")

            ' Loop through the nodes
            For Each m_node In m_nodelist
                ParseInspectorInformationFromNode(m_node)
                ParseReportInformationFromNode(m_node)

            Next
            '
            ' Client Information (CL) 
            '
            m_nodelist = m_xmld.SelectNodes("/Report/ClientData")

            'Loop through the nodes
            For Each m_node In m_nodelist
                ParseClientsFromNode(m_node)

            Next



        Catch ex As Exception
            'Error trapping
            MsgBox(ex.Message)

        End Try
        '
        ' Tell the world that we are done!
        '
        MsgBox("Report is Imported!",, "Report Import")
        '
        '
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
    ' ***********************************************
    ' ***
    ' *****      Parse Report Information From Node
    ' ***
    ' ***********************************************
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
    ' ***********************************************
    ' ***
    ' *****      Parse Inspector Information From Node
    ' ***
    ' ***********************************************
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
    ' ***********************************************
    ' ***
    ' *****      Parse Client(s) From Node
    ' ***
    ' ***********************************************
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
End Class
