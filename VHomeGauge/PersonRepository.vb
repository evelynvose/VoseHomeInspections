Imports System.ComponentModel
Imports System.IO



#Region "PersonRepository Class"
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class PersonRepository
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()

    End Sub



    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    Public Function GetList(ByVal fileinfo As FileInfo, ByVal type As PersonType) As BindingList(Of Person)

        Dim listDetails As New BindingList(Of Person)

        If IsNothing(fileinfo) Or Not IsNothing(fileinfo) AndAlso fileinfo.FullName.Contains("Null") Then    ' Set the default person
            listDetails.Add(New Person("Evelyn", "Vose", "160 Christina Ave", "", "Smithfield", "NC", "27577", "(919) 634-5235", "evelyn@esvose.com"))

        Else
            ' Open the file and assign it to a stream reader
            Dim reader As StreamReader
            Try
                reader = New StreamReader(fileinfo.FullName, True)

            Catch e As Exception
                MsgBox(e.Message)
                Return listDetails

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
                        .Address1 = CType(splitArray(2), String)
                        .Address2 = CType(splitArray(3), String)
                        .City = CType(splitArray(4), String)
                        .State = CType(splitArray(5), String)
                        .PostalCode = CType(splitArray(6), String)
                        .eMail = CType(splitArray(8), String)
                        .Phone = CType(splitArray(11), String)
                        .Type = CType(splitArray(22), String)

                    End With

                    If thePerson.Type.Contains([Enum].GetName(GetType(PersonType), type)) Then
                        listDetails.Add(thePerson)

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End While


        End If


        Return listDetails

    End Function




    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '

    '
    '
    Public Enum PersonType
        Customer
        Rep
    End Enum

End Class
#End Region
