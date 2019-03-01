Public Interface IDoWorkWorker
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    '    
    Sub DoWork()
    Sub TheDoWorkMethod()
    Sub RaiseDoWorkEvent(sender As Object, theEventArgs As VDoWorkEventArgs)
    '
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    '    
    Event DoWorkEvent(ByVal sender As Object, ByVal theEventArgs As VDoWorkEventArgs)
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '    
    Property LastErrorMessage As String
    ReadOnly Property ErrorList As IList(Of String)
    '
End Interface
