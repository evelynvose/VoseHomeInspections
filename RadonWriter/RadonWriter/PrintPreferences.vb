' **********************************************
' ****
' ******    Print Preferences
' ****
' **********************************************
' 
Public Class PrintPreferences

    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 




    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 



    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Public Property IncludeTemperature As Boolean
        Get
            Return My.Settings.IncludeTemperature
        End Get
        Set(value As Boolean)
            My.Settings.IncludeTemperature = value
        End Set
    End Property

    Public Property IncludeHumidity As Boolean
        Get
            Return My.Settings.IncludeHumidity
        End Get
        Set(value As Boolean)
            My.Settings.IncludeHumidity = value
        End Set
    End Property
End Class
