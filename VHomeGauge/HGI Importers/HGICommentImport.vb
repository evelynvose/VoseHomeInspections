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
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Termination, "Comment Import Complete"))
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
                    ' HGI annoyingly preceeds their Guids with a letter that represents what type of object
                    '   the Guid represents.  In this case, the format will be: C-080878FA-8774-49AD-8DEC-24D8E9B5C99D.
                    '   The prefix will have to be removed in order to use the data as a Guid.
                    ' 
                    Dim s As String = Guid.Empty.ToString           ' Preset to fail!
                    Dim a As XmlAttribute
                    a = node.Attributes("id")
                    If Not IsNothing(a) Then            ' XmlDocument functions return empty objects!
                        s = a.Value                     ' Take a chance on the attribute being formatted with a prefix
                        s = s.Remove(0, "C-".Length)    ' and remove the prefix (if any).
                        '
                    End If
                    '
                    ' Parse the Guid to see if what remains is a Guid. The method will set g to guid.empty or a valid structure is populated.
                    '
                    Dim g As Guid

                    If Not Guid.TryParse(s, g) OrElse g.Equals(Guid.Empty) Then
                        '
                        ' Not a valid Guid, so abort with and error message
                        '
                        MsgBox(New Exception(String.Format("Comment: {0} is not a valid Guid!", g)))
                        '
                    Else
                        '
                        ' Send progress information to the progress bar
                        '
                        sMessage = "Import: " & node.Item("comName").InnerText
                        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, sMessage))
                        '
                        ' Instantiate the object, SetAttr the variables and import to dB
                        '     Note: If the fields fail the object's rules test the object will not update the dB
                        '
                        Dim theObject As RComment
                        theObject = RComment.Find(g)    ' See if already in the dB
                        If IsNothing(theObject) Then    ' not a duplicate, proceed
                            theObject = New RComment
                            With theObject
                                .ID = g
                                If Not IsNothing(node.Item("comName")) Then
                                    .Name = node.Item("comName").InnerText
                                    '
                                End If
                                If Not IsNothing(node.Item("comText")) Then
                                    .Text = node.Item("comText").InnerText
                                    '
                                End If
                                If Not IsNothing(node.Item("comAuto")) Then
                                    If node.Item("comAuto").InnerText = "1" Then
                                        .Auto = True
                                        '
                                    End If
                                End If
                                If Not IsNothing(node.Item("commentSumID")) Then
                                    s = node.Item("commentSumID").InnerText
                                    s = s.Remove(0, "SUM-".Length)
                                    Guid.TryParse(s, .FK_SumID)
                                    '
                                End If

                                If Not .Update() Then ' send a message
                                    MsgBox(New Exception(String.Format("Comment: {0}, {1}, {2} did not import. Check the rules!", g, .Name, .Text)))
                                    '
                                End If
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
