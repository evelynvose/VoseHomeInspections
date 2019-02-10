Imports Syncfusion.Windows.Forms
Imports System.Xml

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
        m_Report = New Report

        Try
            'Create the XML Document
            m_xmld = New XmlDocument()

            'Load the Xml file
            m_xmld.Load(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\190202192E 1.2\report.hr5")

            ' Set the namespace
            Dim oManager As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
            oManager.AddNamespace("ns", "Report")

            ' Get the GUID 
            m_node = m_xmld.SelectSingleNode("Report/ReportGUID")
            m_Report.Guid = m_node.FirstChild.Value

            'Get the list of name nodes 
            m_nodelist = m_xmld.SelectNodes("/Report/ClientData")

            'Loop through the nodes
            For Each m_node In m_nodelist
                Dim theClient As New ReportClient()
                theClient.LoadFromNode(m_node)
                m_Report.ClientList.Add(theClient)

            Next

        Catch errorVariable As Exception
            'Error trapping
            Console.Write(errorVariable.ToString())

        End Try
    End Sub
End Class
