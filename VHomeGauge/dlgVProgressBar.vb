Imports Syncfusion.Windows.Forms
Imports System.ComponentModel
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class dlgVProgressBar
    Inherits MetroForm
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '
        ' Initialize the visual elements
        '      Note: The caller will reinitialize these settings as desired by
        '            setting properties prior to calling the launch method.
        '
        ProgressBarAdv1.Value = 0
        ProgressBarAdv1.Visible = True
        lblStatus.Text = ""
        lblStatus.Visible = False
        btnOK.Visible = False
        btnOK.Enabled = False
        lblAnnouncement.Text = ""
        lblAnnouncement.Visible = False
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Load
    ' ***********************************************
    '
    ' Private m_ReportProcessor As HGIReportProcessor
    Private Sub dlgReportImportProgressBar_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    '
    '
    ' ***********************************************
    ' *****     Report Is Imported
    ' ***********************************************
    '
    ' This is the heart of this dialog's purpose. The user kicks off the
    ' background thread and the progress bar in parallel with each other. Once RunAsyncWorker is called
    ' the event, BackgroundWorker1_DoWork, fires and that's where the "DoWork" method is called in the m_DoWorkClass
    ' class pointer reference.
    '
    Public Sub Launch()
        '
        ' The heart of this dialog is the DoWorkClass object.
        ' Without that we may as well go home since there is no work to be done!
        '
        If IsNothing(m_DoWorkClass) Then
            MsgBox("Launch()" & vbCrLf & "The class reference is not valid!",, "VProgressBar Class")
            Exit Sub
            '
        End If
        '
        ' Fire the event that calls the DoWork method of the DoWork Class
        '
        BackgroundWorker1.RunWorkerAsync()
        '
        ' Starting the timer causes the progress bar to advance.
        '
        StartTimer()
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Start Timer
    ' ***********************************************
    '
    Public Sub StartTimer()
        '
        ' Starts the timer
        '
        Timer1.Enabled = True
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Kill Timer()
    ' ***********************************************
    '
    Private Sub KillTimer()
        '
        '  Enabling the timer causes the tick event to fire
        '
        Timer1.Enabled = False
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Set Do Work Class()
    ' ***********************************************
    '
    Friend WithEvents m_DoWorkClass As Object
    Public Sub SetDoWorkClass(ByRef DoWorkClass As Object)
        ' 
        ' Set the pointer to the DoWorkClass
        '       Used by BackgroundWorker1_DoWork
        m_DoWorkClass = DoWorkClass
        '
        ' Add an event handler for the particular DoWorkClass
        '     Note that this is a hack that will require adding a test for every DoWorkClass that we create.
        '
        If m_DoWorkClass.ToString().Contains("HGIReportProcessor") Then
            AddHandler CType(m_DoWorkClass, HGIReportProcessor).DoWorkEvent, AddressOf DoWorkEventHandlingFunction
            '
        End If
        '
    End Sub

    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    '    
    '
    ' ***********************************************
    ' *****     DoWork Event Handling Function
    ' ***********************************************
    '
    Private Sub DoWorkEventHandlingFunction(ByVal sender As Object, ByVal e As VDoWorkEventArgs)
        Select Case e.EventType
            Case VDoWorkEventArgTypes.Informational
                InfoMessage = e.Message
                '
            Case VDoWorkEventArgTypes.ErrorCondition
                If e.EventType = VDoWorkEventArgTypes.ErrorCondition Then
                    If MsgBox("An error occured." & vbCrLf & e.Message & vbCrLf & "Continue?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then
                        Close()
                        '
                    End If
                End If
                '
            Case VDoWorkEventArgTypes.Termination
                AnnouncementText = e.Message
                '
            Case Else
                ' Do Nothing
                '
        End Select
        If e.EventType = VDoWorkEventArgTypes.Informational Then
            '
        End If
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Timer 1_Tick
    ' ***********************************************
    '
    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        '
        ' Display the informational messages, if any.
        '
        lblStatus.Text = InfoMessage
        '
        ' Stop the timer if the report is imported
        '
        If IsWorkCompleted Then
            KillTimer()
            ProgressBarAdv1.Visible = False
            lblStatus.Visible = False
            lblAnnouncement.Text = AnnouncementText
            lblAnnouncement.Visible = AnnouncementVisible
            btnOK.Enabled = True
            '
        Else
            If ProgressBarAdv1.Value < 200 Then
                ProgressBarAdv1.Value += 1
                '
            Else
                ProgressBarAdv1.Value = 0
                '
            End If
        End If
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Background Worker 1_DoWork
    ' ***********************************************
    '
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        '
        ' Call the DoWork method in the DoWork Class.
        '
        m_DoWorkClass.DoWork()
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Background Worker 1_RunWorkerCompleted
    ' ***********************************************
    '
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        '
        ' The next progress bar tick will note that the IsWorkCompleted flag is Ture and it will disable the timer.
        '
        IsWorkCompleted = True
        '
    End Sub
    '
    ' ***********************************************
    ' *****     btnOK Click
    ' ***********************************************
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        '
        '
        Close()
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    Private m_IsWorkCompleted As Boolean
    Private m_AnnouncementVisible As Boolean
    Private m_AnnouncementText As String = ""
    Private m_InfoMessage As String = ""
    '
    ' ***********************************************
    ' *****     Is Work Completed?
    ' ***********************************************
    '
    Private Property IsWorkCompleted As Boolean
        Get
            Return m_IsWorkCompleted
        End Get
        Set(value As Boolean)
            m_IsWorkCompleted = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     OK Button Visible
    ' ***********************************************
    '
    Public Property OKButtonVisible As Boolean
        Get
            Return btnOK.Visible
        End Get
        Set(value As Boolean)
            btnOK.Visible = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Announcement Label Visible
    ' ***********************************************
    '
    Public Property AnnouncementVisible As Boolean
        Get
            Return m_AnnouncementVisible
        End Get
        Set(value As Boolean)
            m_AnnouncementVisible = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Running Status Visible
    ' ***********************************************
    '
    Public Property RunningStatusVisible As String
        Get
            Return lblStatus.Visible
        End Get
        Set(value As String)
            lblStatus.Visible = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Announcement Text
    ' ***********************************************
    '
    Public Property AnnouncementText As String
        Get
            Return m_AnnouncementText
        End Get
        Set(value As String)
            m_AnnouncementText = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Informational Message
    ' ***********************************************
    '
    Public Property InfoMessage As String
        Get
            Return m_InfoMessage
        End Get
        Set(value As String)
            m_InfoMessage = value
        End Set
    End Property
End Class
