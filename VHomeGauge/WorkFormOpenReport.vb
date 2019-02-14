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

            'Get the associate Client's names.  There is usually one, but there can be none or any number. 
            m_nodelist = m_xmld.SelectNodes("/Report/ClientData")

            'Loop through the nodes
            For Each m_node In m_nodelist
                ParseReportPersonFromNode(m_node)

            Next

            ' Move on to the report information 
            m_nodelist = m_xmld.SelectNodes("/Report/ReportInfo")

            'Loop through the nodes
            For Each m_node In m_nodelist
                ParseInspectorInformationFromNode(m_node)
                ParseReportInformationFromNode(m_node)

            Next

        Catch ex As Exception
            'Error trapping
            MsgBox(ex.Message)

        End Try
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

        ' We'll need a found flag
        Dim IsFound As Boolean

        ' Check if the job site address exists and 1) get the AddressID, or 2) update the address 
        Dim jobAddress As Guid
        jobAddress = AddressUpdate(
                                parser.GetPropertyValue("prop[@name='RIAddress1']"),
                                parser.GetPropertyValue("prop[@name='RIAddress2']"),
                                parser.GetPropertyValue("prop[@name='RICity']"),
                                parser.GetPropertyValue("prop[@name='RIState']"),
                                parser.GetPropertyValue("prop[@name='RIZip']"),
                                parser.GetPropertyValue("prop[@name='RICounty']"),
                                AddressTypes.JobSite
                                )

        Using dt As vreportsDataSet.ReportMasterDataTable = New vreportsDataSet.ReportMasterDataTable
            Using ta = New vreportsDataSetTableAdapters.ReportMasterTableAdapter


                ' Let's keep a new row opject pointer handy
                Dim newRow As vreportsDataSet.ReportMasterRow

                ' Fill the data table using the Inspector type as we have no idea (yet) what the PersonID is.
                ta.FillByReportID(dt, m_ReportID)
                '
                ' Check to see if the record exists and if it does update the report
                IsFound = False

                For Each Row As vreportsDataSet.ReportMasterRow In dt
                    If Row.ID.Equals(m_ReportID) Then ' they match
                        IsFound = True

                        With Row
                            ' The report number should be broken into two parts, the report number and the version.  More than two parts is not
                            ' a recognized format so we'll do the best we can and let the user make corrections.
                            Dim reportSplits() As String
                            reportSplits = parser.GetPropertyValue("prop[@name='RIReportNumber']").Split(" ")
                            If reportSplits.Count > 0 AndAlso reportSplits(0) <> "" Then
                                .ReportNumber = reportSplits(0)
                                If reportSplits.Count = 1 Then
                                    Array.Resize(reportSplits, reportSplits.Length + 1)
                                    reportSplits(1) = "1.0"

                                End If
                                If reportSplits.Count > 1 Then
                                    .Version = reportSplits(1)

                                End If
                            End If

                            ' Inspection date
                            If IsDate(parser.GetPropertyValue("RIDate")) Then
                                .InspectionDate = Date.Parse(parser.GetPropertyValue("prop[@name='RIDate']"))

                            End If

                            ' Address
                            .AddressID = jobAddress

                            ' Vose doesn't track start and stop times, but it is available so we'll capture it
                            .StartTime = parser.GetPropertyValue("prop[@name='RIStartTime']")
                            .EndTime = parser.GetPropertyValue("prop[@name='RIStopTime']")

                            ' The notes
                            .SpecialNotes = parser.GetPropertyValue("prop[@name='RISpecialNotes']")

                            ' As of this momement I'm guessing that this is the appointment in the HGI Dashboard if one was created.
                            .AppointmentID = New Guid(parser.GetPropertyValue("prop[@name='RIAppointmentId']"))

                        End With
                    End If

                Next

                ' Didn't find an existing record to update let's insert a new record
                If Not IsFound Then
                    newRow = dt.NewReportMasterRow
                    With newRow
                        .ID = m_ReportID

                        ' The report number should be broken into two parts, the report number and the version.  More than two parts is not
                        ' a recognized format so we'll do the best we can and let the user make corrections.
                        Dim reportSplits() As String
                        reportSplits = parser.GetPropertyValue("prop[@name='RIReportNumber']").Split(" ")

                        ' parser will return at least "" so there should be at least one element in the array
                        If reportSplits.Count = 1 AndAlso reportSplits(0) = "" Then ' there isn't a report number so format one
                            Array.Resize(reportSplits, reportSplits.Length + 2)
                            reportSplits(0) = "0000000000 "
                            reportSplits(1) = "1.0"

                        End If

                        ' In this case, there is a report number (see above), but no version, since the array should have 2 elements
                        If reportSplits.Count = 1 Then
                            Array.Resize(reportSplits, reportSplits.Length + 1)
                            reportSplits(1) = "1.0"

                        End If

                        ' by now we should have an array with at least 2 elements so we are safe
                        If reportSplits.Count > 1 Then
                            .ReportNumber = reportSplits(0)
                            .Version = reportSplits(1)

                        End If

                        ' Address
                        .AddressID = jobAddress

                        ' Inspection date
                        If IsDate(parser.GetPropertyValue("prop[@name='RIDate']")) Then
                            .InspectionDate = Date.Parse(parser.GetPropertyValue("prop[@name='RIDate']"))

                        End If

                        ' Vose doesn't track start and stop times, but it is available so we'll capture it. These are saved as string values.
                        .StartTime = parser.GetPropertyValue("prop[@name='RIStartTime']")
                        .EndTime = parser.GetPropertyValue("prop[@name='RIStopTime']")

                        ' The notes
                        .SpecialNotes = parser.GetPropertyValue("prop[@name='RISpecialNotes']")

                        ' As of this momement I'm guessing that this is the appointment in the HGI Dashboard if one was created.
                        Try
                            Dim AppointmentID As Guid = New Guid(parser.GetPropertyValue("prop[@name='RIAppointmentId']"))
                            .AppointmentID = AppointmentID

                        Catch ex As Exception

                        End Try

                    End With

                    dt.AddReportMasterRow(newRow)

                End If

                ' Update the data table
                Try
                    ta.Update(dt)

                Catch ex As Exception
                    MsgBox("ParseReportInformationFromNode()" & vbCrLf & ex.Message)

                End Try

            End Using 'ta
        End Using 'dt

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
    ' *****      Parse Report Person From Node
    ' ***
    ' ***********************************************
    ' ***********************************************
    '
    Public Sub ParseReportPersonFromNode(ByVal node As XmlNode)
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
                    MsgBox(" ParseReportPersonFromNode()" & vbCrLf & ex.Message)

                End Try

            End Using 'dt
        End Using 'ta
        '
        ' ***********************************************
        ' *****      EMAIL ADDRESSES
        ' ***********************************************
        '
        Using dt As vreportsDataSet.EmailAddressDataTable = New vreportsDataSet.EmailAddressDataTable
            Using ta = New vreportsDataSetTableAdapters.EmailAddressTableAdapter

                ' Let's keep a new row opject pointer handy
                Dim newRow As vreportsDataSet.EmailAddressRow

                ' Fill the data table (if the person ID exists)
                ta.FillByPersonID(dt, thePersonID)

                '
                ' ***********************************************
                ' *****     Primary Email
                ' ***********************************************
                '
                ' Check to see if the  record exists and if it does, update it.
                IsFound = False
                For Each Row As vreportsDataSet.EmailAddressRow In dt
                    With Row
                        If .PersonID = thePersonID AndAlso .Type = EmailTypes.Primary Then
                            .URL = parser.GetPropertyValue("prop[@name='CEmail']")
                            IsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing record to update let's insert a new one.
                If Not IsFound Then
                    newRow = dt.NewEmailAddressRow
                    With newRow
                        .ID = Guid.NewGuid()
                        .PersonID = thePersonID
                        .URL = parser.GetPropertyValue("prop[@name='CEmail']")
                        .Type = EmailTypes.Primary

                    End With
                    dt.AddEmailAddressRow(newRow)
                End If

                '
                ' ***********************************************
                ' *****     Second Email
                ' ***********************************************
                '
                ' Check to see if the record exists and if it does, update it.r
                IsFound = False
                For Each Row As vreportsDataSet.EmailAddressRow In dt
                    With Row
                        If .PersonID = thePersonID AndAlso .Type = EmailTypes.Second Then
                            .URL = parser.GetPropertyValue("prop[@name='CEmail2']")
                            IsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing record to update let's insert a new one.
                If Not IsFound Then
                    IsFound = False
                    newRow = dt.NewEmailAddressRow
                    With newRow
                        .ID = Guid.NewGuid()
                        .PersonID = thePersonID
                        .URL = parser.GetPropertyValue("prop[@name='CEmail2']")
                        .Type = EmailTypes.Second

                    End With
                    dt.AddEmailAddressRow(newRow)
                End If
                '
                ' ***********************************************
                ' *****     Third Email
                ' ***********************************************
                '
                ' Check to see if the record exists and if it does, update it.
                IsFound = False
                For Each Row As vreportsDataSet.EmailAddressRow In dt
                    With Row
                        If .PersonID = thePersonID AndAlso .Type = EmailTypes.Third Then
                            .URL = parser.GetPropertyValue("prop[@name='CEmail3']")
                            IsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing phone record to update so let's insert a new one.
                If Not IsFound Then
                    IsFound = False
                    newRow = dt.NewEmailAddressRow
                    With newRow
                        .ID = Guid.NewGuid()
                        .PersonID = thePersonID
                        .URL = parser.GetPropertyValue("prop[@name='CEmail3']")
                        .Type = EmailTypes.Third

                    End With
                    dt.AddEmailAddressRow(newRow)
                End If
                ta.Update(dt)
            End Using 'dt
        End Using 'ta
        '
        ' ***********************************************
        ' *****      PHYSICAL ADDRESSES
        ' ***********************************************
        '
        Using dt As vreportsDataSet.AddressDataTable = New vreportsDataSet.AddressDataTable
            Using ta = New vreportsDataSetTableAdapters.AddressTableAdapter

                ' Let's keep a new row opject pointer handy
                Dim newRow As vreportsDataSet.AddressRow

                ' Fill the data table (if the person ID exists)
                ta.FillByPersonID(dt, thePersonID)
                '
                ' ***********************************************
                ' *****     Current/Billing Address
                ' ***********************************************
                '
                ' Check to see if the record exists and if it does, update it.
                IsFound = False
                For Each Row As vreportsDataSet.AddressRow In dt
                    With Row
                        If .PersonId = thePersonID AndAlso .Type = AddressTypes.Current Then
                            .Address1 = parser.GetPropertyValue("prop[@name='CAddress']")
                            .Address2 = parser.GetPropertyValue("prop[@name='CAddress2']")
                            .City = parser.GetPropertyValue("prop[@name='CCity']")
                            .State = parser.GetPropertyValue("prop[@name='CState']")
                            .ZipCode = parser.GetPropertyValue("prop[@name='CZip']")
                            .Country = parser.GetPropertyValue("prop[@name='CCountry']")
                            IsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing phone record to update so let's insert a new one.
                If Not IsFound Then
                    newRow = dt.NewAddressRow
                    With newRow
                        .ID = Guid.NewGuid()
                        .PersonId = thePersonID
                        .Address1 = parser.GetPropertyValue("prop[@name='CAddress']")
                        .Address2 = parser.GetPropertyValue("prop[@name='CAddress2']")
                        .City = parser.GetPropertyValue("prop[@name='CCity']")
                        .State = parser.GetPropertyValue("prop[@name='CState']")
                        .ZipCode = parser.GetPropertyValue("prop[@name='CZip']")
                        .Country = parser.GetPropertyValue("prop[@name='CCountry']")
                        .Type = AddressTypes.Current

                    End With
                    dt.AddAddressRow(newRow)
                End If
                ta.Update(dt)
            End Using 'dt
        End Using 'ta
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

                ta.Update(dt)
            End Using 'dt
        End Using 'ta

    End Sub
    '
    ' ***********************************************    
    ' ***********************************************
    ' ***
    ' *****     Address Match
    ' ***       returns either a record GUID or
    ' ***       a virgin GUID
    ' ***
    ' ***********************************************
    ' ***********************************************
    '
    Public Function AddressMatch(ByVal address As String, ByVal city As String, ByVal state As String, ByVal type As AddressTypes) As Guid
        Using ta As New vreportsDataSetTableAdapters.AddressTableAdapter
            Using dt As vreportsDataSet.AddressDataTable = ta.GetDataByAddressCityState(address, city, state, type)
                If dt.Count > 0 Then
                    Dim row As vreportsDataSet.AddressRow = dt.Rows(0)
                    Return row.ID

                End If
            End Using 'dt
        End Using 'ta

        Return New Guid
    End Function
    '
    ' ***********************************************    
    ' ***********************************************
    ' ***
    ' *****      Address Update
    ' ***
    ' ***********************************************
    ' ***********************************************
    '
    Public Function AddressUpdate(ByVal address1 As String, ByVal address2 As String, ByVal city As String, ByVal state As String, ByVal zipcode As String, ByVal county As String, ByVal type As AddressTypes) As Guid

        Dim matchAddressId As Guid
        matchAddressId = AddressMatch(address1, city, state, type)

        Using dt As New vreportsDataSet.AddressDataTable
            Using ta As New vreportsDataSetTableAdapters.AddressTableAdapter
                Dim row As vreportsDataSet.AddressRow

                Dim IsNewRecord As Boolean

                If matchAddressId.Equals(New Guid) Then
                    matchAddressId = Guid.NewGuid()
                    IsNewRecord = True

                Else
                    ta.FillByID(dt, matchAddressId)

                End If

                ' Get an existing row
                If dt.Count > 0 Then
                    row = dt.Rows(0)

                Else ' make a new row
                    row = dt.NewAddressRow '

                End If

                With row
                    If IsNewRecord Then .ID = matchAddressId
                    .Address1 = address1
                    .Address2 = address2
                    .City = city
                    .State = state
                    .ZipCode = zipcode
                    .County = county
                    .Country = "US"
                    .Type = type

                End With

                ' put the row into the data table
                If IsNewRecord Then
                    dt.AddAddressRow(row)

                End If

                ' Send the update to the database
                Try
                    ta.Update(dt)

                Catch ex As Exception
                    MsgBox("UpdateAddress()" & vbCrLf & ex.Message)

                End Try

            End Using 'ta
        End Using 'dt


        Return matchAddressId

    End Function
End Class
