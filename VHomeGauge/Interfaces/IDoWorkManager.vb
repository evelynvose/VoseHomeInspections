
Imports System.ComponentModel

Public Interface IDoWorkManager
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    '    
    Sub SetDoWorkClass(ByRef DoWorkClass As VDoWork)
    Sub LaunchDoWork()
    Sub DoWorkEvent_Handler(ByVal sender As Object, ByVal e As VDoWorkEventArgs)
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    '    
    Event DoWorkEvent(ByVal sender As Object, ByVal e As DoWorkEventArgs)
    Event RunWorkerCompletedEvent(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '    
    Property IsWorkCompleted As Boolean
    '
End Interface
