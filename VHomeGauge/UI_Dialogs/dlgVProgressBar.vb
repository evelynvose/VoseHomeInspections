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
    Implements IDoWorkManager
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
        ' Add the requisite ManagerDoWork event handler
        '
        AddHandler BackgroundWorker1.DoWork, AddressOf BackgroundWorker1_DoWork
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
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
    Public Sub LaunchDoWork() Implements IDoWorkManager.LaunchDoWork
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
    Friend WithEvents m_DoWorkClass As VDoWork
    Public Sub SetDoWorkClass(ByRef DoWorkClass As VDoWork) Implements IDoWorkManager.SetDoWorkClass
        ' 
        ' Set the pointer to the DoWorkClass
        '       Used by BackgroundWorker1_DoWork
        '
        m_DoWorkClass = DoWorkClass
        '
        ' Add an event handler for the particular DoWorkClass
        '     Note that this is a hack that will require adding a test for every DoWorkClass that we create.
        '
        AddHandler m_DoWorkClass.DoWorkEvent, AddressOf DoWorkEvent_Handler
        AddHandler m_DoWorkClass.VEvent, AddressOf VEvent_Handler
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
    Private Sub DoWorkEvent_Handler(ByVal sender As Object, ByVal e As VDoWorkEventArgs) Implements IDoWorkManager.DoWorkEvent_Handler
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
    ' *****     -VEvent_Handler(object, object)
    ' ***********************************************
    '
    Private Sub VEvent_Handler(ByVal sender As Object, ByVal e As VEventArgs)
        MsgBox(e.Message)
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
            If Not OKButtonVisible Then
                Close()
                '
            End If
            btnOK.Enabled = True
            '
        Else
            If ProgressBarAdv1.Value < 100 Then
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
    Private Event DoWorkEvent(ByVal sender As Object, ByVal e As DoWorkEventArgs) Implements IDoWorkManager.DoWorkEvent
    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
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
    Private Event RunWorkerCompletedEvent(sender As Object, e As RunWorkerCompletedEventArgs) Implements IDoWorkManager.RunWorkerCompletedEvent
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
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
    Private Property IsWorkCompleted As Boolean Implements IDoWorkManager.IsWorkCompleted
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
