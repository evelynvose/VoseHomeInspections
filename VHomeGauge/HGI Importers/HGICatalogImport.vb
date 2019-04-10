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
Public Class HGICatalogImport
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
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Termination, "CatalogMaster Import Complete"))
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
            ' Find or create the top catalog item
            '
            Dim topCatalogItem As CatalogMaster = CatalogMaster.Find("Catalog")
            If topCatalogItem Is Nothing Then
                topCatalogItem = New CatalogMaster
                With topCatalogItem
                    .ID = New VGuid("CAT", Guid.NewGuid)
                    .Name = "Catalog"
                    .FK_Parent = New VGuid("CAT", Guid.NewGuid)
                    .Update()
                    '
                End With
            End If
            '
            ' Loop through the cats, determine if exists in db, if not then insert it, then process its children.
            '
            Dim nodelist As XmlNodeList
            nodelist = Xmld.SelectNodes("/template/cat")
            If nodelist IsNot Nothing Then
                For Each folder As XmlNode In nodelist
                    ProcessCatalogItem(folder, topCatalogItem.ID)
                    '
                Next
            End If
        Catch ex As Exception
            MsgBox(ex)
            '
        Finally
            ' Do nothing
        End Try
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -ProcessCatalogItem(xmlnode)
    ' ***********************************************
    '
    Private Sub ProcessCatalogItem(ByVal node As XmlNode, ByVal theParentID As VGuid)
        '
        ' Error checking
        '
        If node.FirstChild.InnerText Is Nothing Then Return
        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, "Title: " & node.FirstChild.InnerText))
        '
        ' Create the parent if it doesn't already exist
        '
        Dim theCatalogMaster As New CatalogMaster
        Try
            theCatalogMaster = CatalogMaster.Find(node.FirstChild.InnerText)
            If theCatalogMaster Is Nothing Then ' its a new Catalog Item
                theCatalogMaster = New CatalogMaster
                theCatalogMaster.ID = New VGuid("CAT", Guid.NewGuid)
                '
            End If
            With theCatalogMaster
                .Name = node.FirstChild.InnerText
                .FK_Parent = theParentID
                .Update()
                ' 
            End With
            '
        Catch ex As Exception
            MsgBox(ex)
            '
        End Try
        '
        ' Process the children
        '
        Try
            For Each childNode As XmlNode In node.ChildNodes
                Select Case childNode.Name
                    Case "catCID"   ' Comment Link
                        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, "Link CID: " & node.FirstChild.InnerText))
                        '
                        ' Is the link list pair already in the dB?  Add it if not.
                        '
                        Dim childGuid As New VGuid(childNode.FirstChild.InnerText)
                        If CatalogLinkList.Find(theCatalogMaster.ID.Guid, childGuid.Guid) Is Nothing Then
                            Dim newCatalogLinkList As New CatalogLinkList
                            With newCatalogLinkList
                                .ID = New VGuid("LL", Guid.NewGuid)
                                If theParentID.IsEmpty Then
                                    theParentID = theCatalogMaster.ID
                                    '
                                End If
                                .FK_Parent = theCatalogMaster.ID ' theParentID
                                .FK_Child = childGuid
                                .Update()
                                '
                            End With
                        End If
                        '
                    Case "cat" ' Now process any child master catalog items.  
                        RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, "Child Title: " & node.FirstChild.InnerText))
                        ProcessCatalogItem(childNode, theCatalogMaster.ID)
                        '
                    Case "catName"
                        ' Do nothing
                        '
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex)
            '
        End Try
        '
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
