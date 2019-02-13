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
    Private m_Report As Report


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
            m_Report = New Report(m_node.FirstChild.Value)

            'Get the associate Client's names.  There is usually one, but there can be none or any number. 
            m_nodelist = m_xmld.SelectNodes("/Report/ClientData")

            'Loop through the nodes
            For Each m_node In m_nodelist
                ParseReportPersonFromNode(m_node)

            Next

        Catch ex As Exception
            'Error trapping
            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub ParseReportPersonFromNode(ByVal node As XmlNode)
        If IsNothing(node) Then Exit Sub

        Dim parser As New XMLParser(node)

        ' This is not an acceptable condition
        If parser.GetPropertyValue("prop[@name='CGuid']") = "" Then Exit Sub

        ' Convert the string representation of the HG Report GUID to a GUID struct
        Dim thePersonID As Guid = New Guid(parser.GetPropertyValue("prop[@name='CGuid']"))

        ' Let's keep a new row opject pointer handy
        Dim newRow As vreportsDataSet.PhoneRow

        ' We'll ne a found flag
        Dim bIsFound As Boolean

        Using dt As vreportsDataSet.PhoneDataTable = New vreportsDataSet.PhoneDataTable
            Using ta = New vreportsDataSetTableAdapters.PhoneTableAdapter

                ' Fill the data table (if the person ID exists)
                ta.FillByPersonID(dt, thePersonID)

                '
                ' ***********************************************
                ' *****     Mobile Phone
                ' ***********************************************
                '
                ' Check to see if the phone record exists and if it does, update it with the new phone number
                For Each mobileRow As vreportsDataSet.PhoneRow In dt
                    With mobileRow
                        If .PersonID = thePersonID AndAlso .Type = PhoneTypes.Mobile Then
                            .Number = parser.GetPropertyValue("prop[@name='CMobilePhone']")
                            bIsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing phone record to update let's insert the
                ' preconfigured new phone record
                If Not bIsFound Then
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
                For Each mobileRow As vreportsDataSet.PhoneRow In dt
                    With mobileRow
                        If .PersonID = thePersonID AndAlso .Type = PhoneTypes.Home Then
                            .Number = parser.GetPropertyValue("prop[@name='CHomePhone']")
                            bIsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing phone record to update let's insert the
                ' preconfigured new phone record
                If Not bIsFound Then
                    bIsFound = False
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
                For Each mobileRow As vreportsDataSet.PhoneRow In dt
                    With mobileRow
                        If .PersonID = thePersonID AndAlso .Type = PhoneTypes.Work Then
                            .Number = parser.GetPropertyValue("prop[@name='CWorkPhone']")
                            bIsFound = True

                        End If
                    End With
                Next

                ' Didn't find an existing phone record to update let's insert the
                ' preconfigured new phone record
                If Not bIsFound Then
                    bIsFound = False
                    newRow = dt.NewPhoneRow
                    With newRow
                        .ID = Guid.NewGuid()
                        .PersonID = thePersonID
                        .Number = parser.GetPropertyValue("prop[@name='CWorkPhone']")
                        .Type = PhoneTypes.Work

                    End With
                    dt.AddPhoneRow(newRow)
                End If
                ta.Update(dt)
            End Using 'dt
        End Using 'ta


        ' First email, if any
        '    Dim tae As vreportsDataSetTableAdapters.EmailsTableAdapter
        '    tae = New vreportsDataSetTableAdapters.EmailsTableAdapter
        '    Dim dte As vreportsDataSet.EmailsDataTable
        '    dte = New vreportsDataSet.EmailsDataTable
        '    value = parser.GetPropertyValue("prop[@name='CEmail']")
        '    If value <> "" Then
        '        tae.InsertQuery(Guid.NewGuid(), thePersonID, value, 0)
        '        tae.Update(dte)

        '    End If
        'FirstName = GetPropertyValue("prop[@name='CFName1']")
        'LastName = GetPropertyValue("prop[@name='CLName1']")
        'Email2 = GetPropertyValue("prop[@name='CEmail2']")
        '    Email3 = GetPropertyValue("prop[@name='CEmail3']")
        '    Address1 = GetPropertyValue("prop[@name='CAddress']")
        '    Address2 = GetPropertyValue("prop[@name='CAddress2']")
        '    City = GetPropertyValue("prop[@name='CCity']")
        '    State = GetPropertyValue("prop[@name='CState']")
        '    ZipCode = GetPropertyValue("prop[@name='Zip']")
        '    Country = GetPropertyValue("prop[@name='CCountry']")
        '    HGUserName = GetPropertyValue("prop[@name='CSHGIName']")



    End Sub

End Class
