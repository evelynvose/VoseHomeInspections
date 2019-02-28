Public Interface IDoWorkWorker
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    '    
    Sub DoWork()
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    '    
    Event RaiseDoWorkEvent(ByVal sender As Object, ByVal theEventArgs As VDoWorkEventArgs)
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '    
    Property LastErrorMessage As String
    '
End Interface
