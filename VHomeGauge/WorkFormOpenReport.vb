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

        Dim parser As New XMLParser(node)

        ' Report
        Dim theReport As InspectionReport
        theReport = New InspectionReport(m_ReportID)
        With theReport
            '
            ' Inspection date
            '
            If IsDate(parser.GetPropertyValue("RIDate")) Then
                .InspectionDate = Date.Parse(parser.GetPropertyValue("prop[@name='RIDate']"))

            End If
            '
            ' Vose doesn't track start and stop times, but it is available so we'll capture it
            '
            .StartTime = parser.GetPropertyValue("prop[@name='RIStartTime']")
            .EndTime = parser.GetPropertyValue("prop[@name='RIStopTime']")
            '
            ' Report Number
            '
            .ReportNumber = parser.GetPropertyValue("prop[@name='RIReportNumber']")
            '
            ' The notes
            '
            .SpecialNotes = parser.GetPropertyValue("prop[@name='RISpecialNotes']")
            '
            ' As of this momement I'm guessing that this is the appointment in the HGI Dashboard if one was created.
            '
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

        ' We'll need a found flag
        Dim IsFound As Boolean
        '
        ' ***********************************************
        ' *****      Inspector
        ' ***********************************************
        '
        Using dt As vreportsDataSet.PersonDataTable = New vreportsDataSet.PersonDataTable
            Using ta = New vreportsDataSetTableAdapters.PersonTableAdapter

                ' Let's keep a new row opject pointer handy
                Dim newRow As vreportsDataSet.PersonRow

                ' Fill the data table using the Inspector type as we have no idea (yet) what the PersonID is.
                ta.FillByType(dt, PersonTypes.Inspector)
                '
                ' Check to see if the record exists and if it does, move onto the Company information
                IsFound = False

                ' We're going to use variables for the first and last name to make the code more readable
                Dim theInspector As String = parser.GetPropertyValue("prop[@name='RIInspector']")
                For Each Row As vreportsDataSet.PersonRow In dt
                    With Row
                        If .Type = PersonTypes.Inspector AndAlso theInspector.Contains(.FirstName) AndAlso theInspector.Contains(.LastName) Then
                            ' Do nothing!
                            IsFound = True
                            Exit For

                        End If
                    End With
                Next

                ' Didn't find an existing record to update let's insert a new record
                If Not IsFound Then
                    ' We'll parse the Inspector's name and pull the first and last, but not the middle
                    ' First we see if an inspector was found in the report. This is a report error condition so just abort
                    If theInspector = "" Then Exit Sub
                    Dim NameParts() As String = theInspector.Split(" ")
                    newRow = dt.NewPersonRow
                    With newRow
                        .ID = Guid.NewGuid()
                        ' the first name is easy as it is the first element of the array, but what if there 
                        ' is no name at all? We'll create a placeholder with a hint for the user to correct the record
                        If NameParts.Count = 0 Then .FirstName = "No First Name: " & parser.GetPropertyValue("prop[@name='RIReportNumber']")
                        If NameParts.Count > 0 Then .FirstName = NameParts(0)

                        ' the last name is not so easy because there may be a middle name so we have to see
                        ' how many elements there are in the array
                        If NameParts.Count = 2 Then .LastName = NameParts(1)
                        If NameParts.Count = 3 Then .LastName = NameParts(2)
                        '
                        ' the above is not foulproof, and so... worst off is that we end up with an Inspector
                        ' in the Person table with just a first name.  The user can update the record by hand, but
                        ' we will at least have a GUID to reference in the VoseHI database report
                        '
                        ' Type the record!
                        .Type = PersonTypes.Inspector

                    End With
                    dt.AddPersonRow(newRow)
                End If

                Try
                    ta.Update(dt)

                Catch ex As Exception
                    MsgBox(" ParseInspectorInformationFromNode()" & vbCrLf & ex.Message)

                End Try

            End Using 'ta
        End Using 'dt

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

        ' We'll need a found flag
        Dim IsFound As Boolean
        '
        ' ***********************************************
        ' *****      PHONE NUMBERS
        ' ***********************************************
        '
        Using dt As vreportsDataSet.PhoneDataTable = New vreportsDataSet.PhoneDataTable
            Using ta = New vreportsDataSetTableAdapters.PhoneTableAdapter

                ' Let's keep a new row opject pointer handy
                Dim newRow As vreportsDataSet.PhoneRow

                ' Fill the data table (if the person ID exists)
                ta.FillByPersonID(dt, thePersonID)

                '
                ' ***********************************************
                ' *****     Mobile Phone
                ' ***********************************************
                '
                ' Check to see if the phone record exists and if it does, update it with the new phone number
                IsFound = False
                For Each Row As vreportsDataSet.PhoneRow In dt
                    With Row
                        If .PersonID = thePersonID AndAlso .Type = PhoneTypes.Mobile Then
                            .Number = parser.GetPropertyValue("prop[@name='CMobilePhone']")
                            IsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing phone record to update let's insert the
                ' preconfigured new phone record
                If Not IsFound Then
                    newRow = dt.NewPhoneRow
                    With newRow
                        .ID = Guid.NewGuid()
                        .PersonID = thePersonID
                        .Number = parser.GetPropertyValue("prop[@name='CMobilePhone']")
                        .Type = PhoneTypes.Mobile

                    End With
                    dt.AddPhoneRow(newRow)

                End If

                '
                ' ***********************************************
                ' *****     Home Phone
                ' ***********************************************
                '
                ' Check to see if the phone record exists and if it does, update it with the new phone number
                IsFound = False
                For Each Row As vreportsDataSet.PhoneRow In dt
                    With Row
                        If .PersonID = thePersonID AndAlso .Type = PhoneTypes.Home Then
                            .Number = parser.GetPropertyValue("prop[@name='CHomePhone']")
                            IsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing phone record to update let's insert the
                ' preconfigured new phone record
                If Not IsFound Then
                    IsFound = False
                    newRow = dt.NewPhoneRow
                    With newRow
                        .ID = Guid.NewGuid()
                        .PersonID = thePersonID
                        .Number = parser.GetPropertyValue("prop[@name='CHomePhone']")
                        .Type = PhoneTypes.Home

                    End With
                    dt.AddPhoneRow(newRow)
                End If
                '
                ' ***********************************************
                ' *****     Work Phone
                ' ***********************************************
                '
                ' Check to see if the phone record exists and if it does, update it with the new phone number
                IsFound = False
                For Each Row As vreportsDataSet.PhoneRow In dt
                    With Row
                        If .PersonID = thePersonID AndAlso .Type = PhoneTypes.Work Then
                            .Number = parser.GetPropertyValue("prop[@name='CWorkPhone']")
                            IsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing phone record to update let's insert the
                ' preconfigured new phone record
                If Not IsFound Then
                    IsFound = False
                    newRow = dt.NewPhoneRow
                    With newRow
                        .ID = Guid.NewGuid()
                        .PersonID = thePersonID
                        .Number = parser.GetPropertyValue("prop[@name='CWorkPhone']")
                        .Type = PhoneTypes.Work

                    End With
                    dt.AddPhoneRow(newRow)
                End If

                Try
                    ta.Update(dt)

                Catch ex As Exception
                    MsgBox(" ParseClientsFromNode()" & vbCrLf & ex.Message)

                End Try

            End Using 'dt
        End Using 'ta
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
        ' ***********************************************
        ' *****     Third Email Address
        ' ***********************************************
        '
        If parser.GetPropertyValue("prop[@name='CEmail3']") <> "" Then
            Dim theThirdEmailAddress As EmailAddress
            theThirdEmailAddress = New EmailAddress(thePersonID, EmailAddressTypes.Third)
            theThirdEmailAddress.URL = parser.GetPropertyValue("prop[@name='CEmail3']")
            theThirdEmailAddress.Update()

        End If
        '
        ' ***********************************************
        ' *****      CLIENT NAMES
        ' ***********************************************
        '
        Using dt As vreportsDataSet.PersonDataTable = New vreportsDataSet.PersonDataTable
            Using ta = New vreportsDataSetTableAdapters.PersonTableAdapter

                ' Let's keep a new row opject pointer handy
                Dim newRow As vreportsDataSet.PersonRow

                ' Fill the data table (if the person ID exists)
                ta.FillByPersonID(dt, thePersonID)
                '
                ' ***********************************************
                ' *****     First Client
                ' ***********************************************
                '
                ' Check to see if the person record exists and if it does, update it with the new names
                IsFound = False
                For Each Row As vreportsDataSet.PersonRow In dt
                    With Row
                        If .ID = thePersonID AndAlso .Type = PersonTypes.Client Then
                            .FirstName = parser.GetPropertyValue("prop[@name='CFName1']")
                            .LastName = parser.GetPropertyValue("prop[@name='CLName1']")
                            .HGUserName = parser.GetPropertyValue("prop[@name='CSHGIName']")
                            IsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing phone record to update let's insert the
                ' preconfigured new phone record
                If Not IsFound Then
                    newRow = dt.NewPersonRow
                    With newRow
                        .ID = thePersonID
                        .FirstName = parser.GetPropertyValue("prop[@name='CFName1']")
                        .LastName = parser.GetPropertyValue("prop[@name='CLName1']")
                        .HGUserName = parser.GetPropertyValue("prop[@name='CSHGIName']")
                        .Type = PersonTypes.Client

                    End With
                    dt.AddPersonRow(newRow)
                End If

                Try
                    ta.Update(dt)

                Catch ex As Exception
                    MsgBox("Create or Update Client()" & vbCrLf & ex.Message)

                End Try

            End Using 'dt
        End Using 'ta
        '
        ' ***********************************************
        ' *****      PHYSICAL ADDRESSES
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


    End Sub
    '
End Class
