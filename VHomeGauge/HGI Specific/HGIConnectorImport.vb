Imports System.IO
Imports System.Xml
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Public Class HGIConnectorImport
    Inherits VDoWork
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     +New()
    ' ***********************************************
    '
    Public Sub New()
        ' 
        Initialize()
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     +New(fileinfo)
    ' ***********************************************
    '
    Public Sub New(ByVal fileinfo As FileInfo)
        Me.TemplateFile = fileinfo
        Initialize()
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     -Initialize()
    ' ***********************************************
    '
    Private Sub Initialize()
        '
        ' Do nothing on purpose!
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     +TheDoWorkMethod()
    ' ***********************************************
    '
    Protected Overrides Sub TheDoWorkMethod()
        ProcessTheTemplate()
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Termination, "Connector Import Complete"))
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -ProcessTheTemplate()
    ' ***********************************************
    '
    Private Sub ProcessTheTemplate()
        If Not m_TemplateFile.Extension.Contains("ht5") Then
            RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.ErrorCondition, "File name does not end in .ht5"))
            Exit Sub
        End If
        '
        ' Open the file and parese for cons and con tags
        '
        Dim Xmld As New XmlDocument()
        Try
            '
            ' Load the Xml file
            '
            Xmld.Load(TemplateFile.FullName)
            '
            ' Loop through the cons, determine if exists in db, if not then insert it.
            '
            Dim nodelist As XmlNodeList
            nodelist = Xmld.SelectNodes("/template/cons")
            If Not IsNothing(nodelist) AndAlso nodelist.Count > 0 Then
                nodelist = nodelist.Item(0).ChildNodes
                For Each node As XmlNode In nodelist
                    If Not IsNothing(node.FirstChild.Value) AndAlso IsNothing(RConnector.Find(node.FirstChild.Value)) Then
                        Dim newConn As New RConnector
                        With newConn
                            .ID = Guid.NewGuid()
                            .XNode = node.Name
                            .XValue = node.FirstChild.Value
                            .XParentNode = node.ParentNode.Name
                            .Update()
                            '
                        End With
                    End If
                    '
                Next
            End If
        Catch ex As Exception
            MsgBox(ex)
            '
        Finally
            ' Do nothing
        End Try
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     Encapsulated Members
    ' ***********************************************
    '
    Private m_TemplateFile As FileInfo = New FileInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\HomeGauge\Templates\")
    '
    ' ***********************************************
    ' *****     +TemplateFile(fileinfo):fileinfo
    ' ***********************************************
    '
    Public Property TemplateFile As FileInfo
        Get
            Return m_TemplateFile
        End Get
        Set(value As FileInfo)
            If Not IsNothing(value) Then
                m_TemplateFile = value
            End If
        End Set
    End Property
End Class
