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
Public Class HGISmartTextImport
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
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Termination, "Smart Text Import Complete"))
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
            Dim sValueMessage As String ' Same as above but for a value
            Dim nodelist As XmlNodeList
            nodelist = Xmld.SelectNodes("/template/st")
            If Not IsNothing(nodelist) AndAlso nodelist.Count > 0 Then
                For Each node As XmlNode In nodelist

                    If Not IsNothing(node.Item("stKey")) AndAlso node.Item("stKey").InnerText <> "" Then ' not nothing or blank
                        '
                        ' Send progress information to the progress bar
                        '
                        sMessage = "Import: " & node.Item("stKey").InnerText
                        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, sMessage))
                        '
                        ' First import the key into the dB
                        '   
                        Dim theKey As RSmartTextKey
                        theKey = RSmartTextKey.Find(node.Item("stKey").InnerText)
                        If IsNothing(theKey) Then ' not a duplicate
                            theKey = New RSmartTextKey
                            With theKey
                                .ID = Guid.NewGuid()
                                .Key = node.Item("stKey").InnerText
                                .Update()
                                '
                            End With
                        End If
                        '
                        ' Second, inport the values into the dB
                        '
                        For Each childNode As XmlNode In node.ChildNodes
                            If childNode.Name = "stVal" AndAlso childNode.InnerText <> "" Then
                                '
                                ' Update the message
                                '                                    
                                sValueMessage = String.Format("{0}, Value: {1}", sMessage, childNode.InnerText)
                                RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, sValueMessage))
                                '
                                If IsNothing(RSmartTextValue.Find(theKey, childNode.InnerText)) Then
                                    Dim newChildObject As New RSmartTextValue
                                    With newChildObject
                                        .ID = Guid.NewGuid()
                                        .FK_Key = theKey.ID
                                        .Value = childNode.InnerText
                                        .Update()
                                    End With
                                End If
                            End If
                        Next
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
