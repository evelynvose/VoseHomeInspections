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
            ' Loop through the cats, determine if exists in db, if not then insert it, then process its children.
            '
            Dim nodelist As XmlNodeList
            nodelist = Xmld.SelectNodes("/template/cat")
            If nodelist IsNot Nothing Then
                For Each folder As XmlNode In nodelist
                    ProcessCatalogItem(folder)
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
    ' ***********************************************
    ' *****     -ProcessCatalogItem(xmlnode)
    ' ***********************************************
    '
    Private Sub ProcessCatalogItem(ByVal node As XmlNode)
        '
        ' Check if the catalog item exists.  If no, create it. Set aside exiting or new to tag its  children
        '
        Dim theCatalogMaster As New CatalogMaster
        If node.FirstChild.InnerText IsNot Nothing Then
            theCatalogMaster = CatalogMaster.Find(node.FirstChild.InnerText)
            If theCatalogMaster Is Nothing Then ' its a new Catalog Item
                theCatalogMaster = New CatalogMaster
                With theCatalogMaster
                    .ID = New VGuid("CAT")
                    .Name = node.FirstChild.InnerText
                    .FK_Parent = .ID
                    .Update()
                    '
                End With
                '
            End If
        End If
        '
        ' Now add any comment IDs to the linked list.  
        ' Assumes that the comment is already imported, or will be imported by another import processor
        '
        For Each ComNode As XmlNode In node.ChildNodes
            If ComNode.Item("catCID") IsNot Nothing Then
                '
                ' Is the link list pair already in the dB?  Add it if not.
                '
                Dim childGuid As Guid
                Guid.TryParse(ComNode.Item("catCID").InnerText.Replace("C-", ""), childGuid)
                If CatalogLinkList.Find(theCatalogMaster.ID.Guid, childGuid) Is Nothing Then
                    Dim newCatalogLinkList As New CatalogLinkList
                    With newCatalogLinkList
                        .ID = New VGuid("C")
                        .FK_Parent = theCatalogMaster.ID
                        .FK_Child = New VGuid("CBool", childGuid)
                        .Update()
                        '
                    End With
                End If
            End If
        Next
        '
        ' Now process any child master catalog items.  
        '
        For Each CatNode As XmlNode In node.ChildNodes
            If CatNode.Item("cat") IsNot Nothing Then
                ProcessCatalogItem(CatNode)
                '
            End If
        Next

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
