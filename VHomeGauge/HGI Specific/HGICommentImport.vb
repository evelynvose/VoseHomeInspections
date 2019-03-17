'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports System.IO
Imports System.Xml
'
Public Class HGICommentImport
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
            Dim sMessage As String  ' The current key/value pair message for the progress bar information post area
            Dim nodelist As XmlNodeList
            nodelist = Xmld.SelectNodes("/template/com")
            If Not IsNothing(nodelist) AndAlso nodelist.Count > 0 Then
                For Each node As XmlNode In nodelist
                    '
                    Dim e As XmlAttribute
                    e = node.Attributes("id")
                    Dim s As String = e.Value
                    If Not IsNothing(node.OuterXml) Then ' not nothing
                        '
                        ' Send progress information to the progress bar
                        '
                        sMessage = "Import: " & node.Item("comName").InnerText
                        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, sMessage))
                        '
                        ' First import the key into the dB
                        '   
                        Dim theComment As RComment
                        theComment = RComment.Find(node.Item("comName").InnerText)
                        If IsNothing(theComment) Then ' not a duplicate
                            theComment = New RComment
                            With theComment
                                .ID = Guid.NewGuid()
                                .Name = node.Item("comName").InnerText
                                .Text = node.Item("comText").InnerText
                                .Update()
                                '
                            End With
                        End If
                    End If
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
