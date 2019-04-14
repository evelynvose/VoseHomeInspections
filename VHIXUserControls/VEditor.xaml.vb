'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports System.IO
Imports Syncfusion.Windows.Controls.RichTextBoxAdv
'
Public Class VEditor
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

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Text = ""
        ' EditorMargin(New Windows.Thickness(5))
        EditorExt.LayoutType = LayoutType.Continuous
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
    ' *****     +Margin(Thickness)
    ' ***********************************************
    '
    Private m_Margin As Thickness
    '
    Public Sub EditorMargin(ByVal margins As Thickness)
        If EditorExt.Document Is Nothing Then Return
        m_Margin = margins
        EditorExt.Document.Sections.Item(0).SectionFormat.PageMargin = m_Margin
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     +Margin():Thickness
    ' ***********************************************
    '
    Public Function EditorMargin() As Thickness
        If EditorExt.Document Is Nothing Then Return New Thickness(0)
        m_Margin = EditorExt.Document.Sections.Item(0).SectionFormat.PageMargin
        Return m_Margin
        ' 
    End Function
    ' 
    ' ***********************************************
    ' *****     +PageSize(Size)
    ' ***********************************************
    '
    Private m_PageSize As Size
    '
    Public Sub PageSize(ByVal page_size As Size)
        If EditorExt.Document Is Nothing Then Return
        Dim w As Integer = page_size.Width + conWidthAdjustment
        If w < 1 Then w = 100
        Dim h As Integer = page_size.Height
        If h < 1 Then h = 100
        m_PageSize.Width = w
        m_PageSize.Height = h
        EditorExt.Document.Sections.Item(0).SectionFormat.PageSize = m_PageSize
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     +PageSize():Size
    ' ***********************************************
    '
    Public Function PageSize() As Size
        If EditorExt.Document Is Nothing Then Return New Size(0, 0)
        m_PageSize = EditorExt.Document.Sections.Item(0).SectionFormat.PageSize
        Return m_PageSize
        '
    End Function
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     +cntlHost_SizeChanged(object, EventArgs)
    ' ***********************************************
    '
    'Private Sub cntlHost_SizeChanged(sender As Object, e As EventArgs) Handles cntlHost.SizeChanged
    '    If cntlHost.Width + conWidthAdjustment < 100 Then Return
    '    PageSize(New Size(cntlHost.Width + conWidthAdjustment, cntlHost.Height))
    '    '
    'End Sub
    '
    ' ***********************************************
    ' *****     -Editor_ContentChanged(object, ContentChangedEventArgs)
    ' ***********************************************
    '
    Public Event ContentChanged(ByVal sender As Object, e As EventArgs)
    '
    Private Sub Editor_ContentChanged(obj As Object, args As ContentChangedEventArgs) Handles EditorExt.ContentChanged
        RaiseEvent ContentChanged(EditorExt, New EventArgs)

    End Sub
    '
    ' ***********************************************
    ' *****     -EditorError(object, ContentChangedEventArgs)
    ' ***********************************************
    '
    Public Event EditorError(ByVal sender As Object, e As EventArgs)
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     +Text(string):string
    ' ***********************************************
    '
    Public Property Text As String
        Get
            Dim tempString As String
            Using ms As New MemoryStream
                EditorExt.Save(ms, FormatType.Html)
                ms.Position = 0
                Dim sr As New StreamReader(ms)
                tempString = sr.ReadToEnd
                sr.Dispose()
            End Using
            Return tempString
        End Get
        Set(value As String)
            If value Is Nothing Then
                value = conGreekText
                '
            End If
            If value <> "" Then
                Dim strFile As String = "temp.html"
                Dim fileExists As Boolean = File.Exists(strFile)
                Using sw As New StreamWriter(File.Open(strFile, FileMode.Create))
                    sw.WriteLine(value)
                    '
                End Using
                EditorExt.Load(strFile)
                '
            Else
                Dim tba() As Byte = System.Text.Encoding.ASCII.GetBytes(value)
                EditorExt.Load(New MemoryStream(tba), FormatType.Docx)
                '
            End If
            '
            ' Pretty up the document!
            '
            EditorMargin(m_Margin)
            PageSize(m_PageSize)
            '
        End Set
    End Property
    ' 
    ' ***********************************************
    ' *****     +Title(string):string
    ' ***********************************************
    '
    Public Property Title As String
        Get
            Return EditorExt.DocumentTitle
        End Get
        Set(value As String)
            If value Is Nothing Then
                value = ""
                '
            End If
            EditorExt.DocumentTitle = value
            '
        End Set
    End Property
    ' 
    ' ***********************************************
    ' *****     +PageLayout(LayoutType):LayoutType
    ' ***********************************************
    '
    Public Property PageLayout As LayoutType
        Get
            Return EditorExt.LayoutType
        End Get
        Set(value As LayoutType)
            Try
                EditorExt.LayoutType = value
                '
            Catch ex As Exception
                RaiseEvent EditorError(EditorExt, New VEditorEventArgs(ex))
                '
            End Try
            '
        End Set
    End Property

    Public Property PageWidth As Double
        Get
            Return m_PageSize.Width
        End Get
        Set(value As Double)
            PageSize(New Size(value, m_PageSize.Height))
        End Set
    End Property
    '
    Private Const conGreekText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
    Private Const conWidthAdjustment = -100
    '
End Class