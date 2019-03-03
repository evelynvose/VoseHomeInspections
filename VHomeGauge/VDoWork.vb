'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class VDoWork
    Inherits VObject
    Implements IDoWorkWorker
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    '  
    '
    ' ***********************************************
    ' *****     DoWork
    ' ***********************************************
    '
    Public Sub DoWork() Implements IDoWorkWorker.DoWork
        TheDoWorkMethod()

    End Sub
    '
    ' ***********************************************
    ' *****     The Do Work Method
    ' ***********************************************
    '
    Protected MustOverride Sub TheDoWorkMethod() Implements IDoWorkWorker.TheDoWorkMethod
    '
    ' ***********************************************
    ' *****      HGI Report Processor Event
    ' ***********************************************
    ' 
    Protected Sub RaiseDoWorkEvent(ByVal sender As Object, ByVal e As VDoWorkEventArgs) Implements IDoWorkWorker.RaiseDoWorkEvent
        RaiseEvent DoWorkEvent(sender, e)
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    ' 
    Public Event DoWorkEvent(sender As Object, theEventArgs As VDoWorkEventArgs) Implements IDoWorkWorker.DoWorkEvent
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '  
    Private m_ErrorList As IList(Of String) = New List(Of String)
    '
    ' ***********************************************
    ' *****      Last Error Message
    ' ***********************************************
    ' 
    Public Property LastErrorMessage As String Implements IDoWorkWorker.LastErrorMessage
        Get
            If m_ErrorList.Count = 0 Then
                Return ""
            End If
            Return m_ErrorList(m_ErrorList.Count - 1)
        End Get
        Set(value As String)
            m_ErrorList.Add(value)
        End Set
    End Property
    '
    ' ***********************************************
    ' *****      Error List
    ' ***********************************************
    ' 
    Public ReadOnly Property ErrorList As IList(Of String) Implements IDoWorkWorker.ErrorList
        Get
            Return m_ErrorList
        End Get
    End Property
    '
End Class
