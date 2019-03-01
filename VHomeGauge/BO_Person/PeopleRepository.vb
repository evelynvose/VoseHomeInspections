Imports System.ComponentModel
Imports System.IO



#Region "PersonRepository Class"
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class PeopleRepository
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Protected Friend Sub New(ByVal thepeoplepath As FileInfo, ByVal thepeopletype As String)

        PeoplePath = thepeoplepath
        m_PeopleType = thepeopletype
        GetList()

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    Public Function GetList() As BindingList(Of Person)

        ' Let's make sure we don't keep adding and adding to the list!
        If IsLoaded Then
            Return PeopleList
        End If

        ' Open the file and assign it to a stream reader
        Dim reader As StreamReader
        Try
            reader = New StreamReader(PeoplePath.FullName, True)

        Catch e As Exception
            MsgBox(e.Message)
            Return PeopleList

        End Try

        ' Blow off the first line because it contains header information
        reader.ReadLine()

        ' Process the rest of the file
        While Not reader.EndOfStream
            Dim splitArray() As String = reader.ReadLine.Split(",")

            Dim thePerson As New Person
            Try
                With thePerson
                    .FirstName = CType(splitArray(0), String)
                    .LastName = CType(splitArray(1), String)
                    .CompanyName = CType(splitArray(2), String)
                    .Address1 = CType(splitArray(3), String)
                    .Address2 = CType(splitArray(4), String)
                    .City = CType(splitArray(5), String)
                    .State = CType(splitArray(6), String)
                    .PostalCode = CType(splitArray(7), String)
                    ' Skip on purpose
                    .eMail = CType(splitArray(9), String)
                    .eMail2 = CType(splitArray(10), String)
                    .eMail3 = CType(splitArray(11), String)
                    .Phone = CType(splitArray(12), String)
                    ' Skip on purpose
                    .Note = CType(splitArray(18), String)
                    .HGUserName = CType(splitArray(19), String)
                    .Website = CType(splitArray(20), String)
                    .GUID = CType(splitArray(21), String)
                    .Type = CType(splitArray(22), String)

                End With

                ' Translate Client (or Agent) to Customer (or Rep)
                Dim testType As String
                If PeopleType = "Client" Then
                    testType = "Customer"

                ElseIf PeopleType = "Agent" Then
                    testType = "Rep"

                Else
                    testType = PeopleType

                End If


                If thePerson.Type.Contains(testType) Then
                    PeopleList.Add(thePerson)

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End While

        ' making sure we don't keep adding and adding to the list!
        m_IsLoaded = True
        Return PeopleList

    End Function
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private ReadOnly m_PeopleType As String = ""
    Public Overridable ReadOnly Property PeopleType As String
        Get
            Return m_PeopleType

        End Get
    End Property

    Private m_PeoplePath As FileInfo
    Protected Friend Property PeoplePath As FileInfo
        Get
            Return m_PeoplePath
        End Get
        Set(value As FileInfo)
            If IsNothing(value) Then value = New FileInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments)
            m_PeoplePath = value
        End Set
    End Property

    Private m_list As BindingList(Of Person)
    Protected Friend Property PeopleList As IList(Of Person)
        Get
            If IsNothing(m_list) Then m_list = New BindingList(Of Person)()
            Return m_list
        End Get
        Set(value As IList(Of Person))
            If IsNothing(value) Then value = New BindingList(Of Person)()
            m_list = value
        End Set
    End Property

    Private m_IsLoaded As Boolean
    Public ReadOnly Property IsLoaded As Boolean
        Get
            Return m_IsLoaded
        End Get
    End Property



End Class
#End Region
