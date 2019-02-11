Imports Syncfusion.Windows.Forms
Imports System.Xml
Imports System.Data.Common

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
            m_xmld.Load(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\190202192E 1.2\report.hr5")

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

        Catch errorVariable As Exception
            'Error trapping
            Console.Write(errorVariable.ToString())

        End Try
    End Sub

    Public Sub ParseReportPersonFromNode(ByVal node As XmlNode)
        If IsNothing(node) Then Exit Sub

        Dim parser As New XMLParser(node)
        Dim set1 As New dsPerson
        Dim thePersonGuid As New Guid(parser.GetPropertyValue("prop[@name='CGuid']"))
        Dim value As String

        Dim tap As vreportsDataSetTableAdapters.PhonesTableAdapter
        tap = New vreportsDataSetTableAdapters.PhonesTableAdapter
        value = parser.GetPropertyValue("prop[@name='CMobilePhone']")
        If value <> "" Then
            If tap.GetDataByPersonIDandType(thePersonGuid, 0).Count > 0 Then
                tap.InsertQuery(Guid.NewGuid(), thePersonGuid, value, 0)

            End If
        End If

        ' First email, if any
        Dim tae As vreportsDataSetTableAdapters.EmailsTableAdapter
        tae = New vreportsDataSetTableAdapters.EmailsTableAdapter
        Dim dte As vreportsDataSet.EmailsDataTable
        dte = New vreportsDataSet.EmailsDataTable
        value = parser.GetPropertyValue("prop[@name='CEmail']")
        If value <> "" Then
            tae.InsertQuery(Guid.NewGuid(), thePersonGuid, value, 0)
            tae.Update(dte)

        End If



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
