Imports Syncfusion.Windows.Forms

' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class PeopleInfoForm
    Inherits MetroForm
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     New
    ' *****
    ' ***********************************************
    '
    Private m_PersonInfo As Person
    Public Sub New(ByRef thePerson As Person)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_PersonInfo = thePerson

    End Sub
    '
    '
    ' ***********************************************
    ' *****     Load
    ' ***********************************************
    '
    Private Sub PeopleInfoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Initialize the fields
        Initialize()
        SetTypeRadioButtons()
        SetTypeMessage()

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     Initialize
    ' ***********************************************
    '
    Private m_IsInitialized As Boolean
    Private Sub Initialize()

        ' Keeps this sub from being called over and over again!
        If m_IsInitialized Then Exit Sub
        m_IsInitialized = True

        With m_PersonInfo
            tbFirstName.Text = .FirstName
            tbLastName.Text = .LastName
            tbCompany.Text = .CompanyName
            tbPhone.Text = .Phone
            tbEmail.Text = .eMail
            tbEmail2.Text = .eMail2
            tbEmail3.Text = .eMail3
            tbWebsite.Text = .Website
            tbHGUserName.Text = .HGUserName
            tbAddress1.Text = .Address1
            tbAddress2.Text = .Address2
            tbCity.Text = .City
            tbState.Text = .State
            tbPostalCode.Text = .PostalCode
            tbNote.Text = .Note

        End With
    End Sub
    '
    ' ***********************************************
    ' *****     Set Type Radio Buttons
    ' ***********************************************
    '
    Private Sub SetTypeRadioButtons()
        If m_PersonInfo.Type = "Client" Or m_PersonInfo.Type = "Customer" Then
            radClient.Checked = True
            radAgent.Checked = False

        Else
            radClient.Checked = False
            radAgent.Checked = True

        End If

    End Sub
    '
    ' ***********************************************
    ' *****     Set Type Message Method
    ' ***********************************************
    '
    Private Sub SetTypeMessage()
        If m_PersonInfo.HGUserName = "" Then
            labTypeMessage.Text = "Person type can be changed until a HG User Name is assigned!"

        Else
            labTypeMessage.Text = "Person type can't be changed because a HG User Name is assigned!"

        End If
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
    ' *****     OK Buton Event
    ' ***********************************************
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        MsgBox("Data Save not implemented")
        DialogResult = DialogResult.OK
        Me.Close()

    End Sub
    '
    ' ***********************************************
    ' *****     Cancel Button Event
    ' ***********************************************
    '
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub
    '
    ' ***********************************************
    ' *****     Help Button Event
    ' ***********************************************
    '
    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MsgBox("Help not implemented!")

    End Sub
    '
    ' ***********************************************
    ' *****     Client Radio Button Changed
    ' *****     Lack of action silences the action!
    ' ***********************************************
    '
    Private Sub radClient_CheckChanged(sender As Object, e As EventArgs) Handles radClient.CheckChanged
        SetTypeRadioButtons()
        SetTypeMessage()

    End Sub   '
    ' ***********************************************
    ' *****     Agent Radio Button Changed
    ' *****     Lack of action silences the action!
    ' ***********************************************
    '
    Private Sub radAgent_CheckChanged(sender As Object, e As EventArgs) Handles radAgent.CheckChanged
        SetTypeRadioButtons()
        SetTypeMessage()

    End Sub
End Class
