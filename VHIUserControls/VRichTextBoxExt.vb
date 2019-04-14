'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports System.IO
Imports Syncfusion.Windows.Controls.RichTextBoxAdv
Imports System.Windows
'
Public Class VRichTextBoxExt
    '
    Private WithEvents m_RichTextBox As SfRichTextBoxAdv
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
        m_RichTextBox = New SfRichTextBoxAdv
        cntlHost.Child = m_RichTextBox
        Text = ""
        Margin(New Windows.Thickness(5))
        PageSize(New Size(cntlHost.Width, cntlHost.Height))
        RichTextBox.LayoutType = LayoutType.Continuous
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
    Public Shadows Sub Margin(ByVal margins As Thickness)
        If RichTextBox.Document Is Nothing Then Return
        m_Margin = margins
        RichTextBox.Document.Sections.Item(0).SectionFormat.PageMargin = m_Margin
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     +Margin():Thickness
    ' ***********************************************
    '
    Public Shadows Function Margin() As Thickness
        If RichTextBox.Document Is Nothing Then Return New Thickness(0)
        m_Margin = RichTextBox.Document.Sections.Item(0).SectionFormat.PageMargin
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
        If RichTextBox.Document Is Nothing Then Return
        m_PageSize = page_size
        RichTextBox.Document.Sections.Item(0).SectionFormat.PageSize = m_PageSize
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     +PageSize():Size
    ' ***********************************************
    '
    Public Function PageSize() As Size
        If RichTextBox.Document Is Nothing Then Return New Size(0, 0)
        m_PageSize = RichTextBox.Document.Sections.Item(0).SectionFormat.PageSize
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
    Private Sub cntlHost_SizeChanged(sender As Object, e As EventArgs) Handles cntlHost.SizeChanged
        If cntlHost.Width + conWidthAdjustment < 100 Then Return
        PageSize(New Size(cntlHost.Width + conWidthAdjustment, cntlHost.Height))
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +cntlHost_SizeChanged(object, EventArgs)
    ' ***********************************************
    '
    Public Event ContentChanged(ByVal sender As Object, e As EventArgs)
    '
    Private Sub m_RichTextBox_ContentChanged(obj As Object, args As ContentChangedEventArgs) Handles m_RichTextBox.ContentChanged
        RaiseEvent ContentChanged(m_RichTextBox, New EventArgs)
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
    ' *****     +RichTextBox(SfRichTextBoxAdv)
    ' ***********************************************
    '
    Public ReadOnly Property RichTextBox As SfRichTextBoxAdv
        Get
            If m_RichTextBox Is Nothing Then
                m_RichTextBox = New SfRichTextBoxAdv
                cntlHost.Child = m_RichTextBox
                '
            End If
            Return m_RichTextBox
        End Get
    End Property
    ' 
    ' ***********************************************
    ' *****     +Text(string):string
    ' ***********************************************
    '
    Public Overrides Property Text As String
        Get
            Dim tempString As String
            Using ms As New MemoryStream
                RichTextBox.Save(ms, FormatType.Html)
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
                RichTextBox.Load(strFile)
                '
            Else
                Dim tba() As Byte = System.Text.Encoding.ASCII.GetBytes(value)
                RichTextBox.Load(New MemoryStream(tba), FormatType.Docx)
                '
            End If
            '
            ' Pretty up the document!
            '
            Margin(m_Margin)
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
            Return RichTextBox.DocumentTitle
        End Get
        Set(value As String)
            If value Is Nothing Then
                value = ""
                '
            End If
            RichTextBox.DocumentTitle = value
            '
        End Set
    End Property
    '
    Private Const conGreekText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
    Private Const conWidthAdjustment = -80
End Class
