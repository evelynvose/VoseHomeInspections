
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 

Public Class TemperaturePoint




    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()

    End Sub


    Public Sub New(ByVal dataID As Integer, ByVal time As Date, ByVal temperature As Double, ByVal highalarm As Double, ByVal lowalarm As Double, ByVal rh As Double, ByVal dewpoint As Double, ByVal comment As String, ByVal serialnumber As String)
        Me.DataID = dataID
        Me.Time = time
        Me.Temperature = temperature
        Me.HighAlarm = highalarm
        Me.LowAlarm = lowalarm
        Me.RH = rh
        Me.DewPoint = dewpoint
        Me.Comment = comment
        Me.SerialNumber = serialnumber

    End Sub



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
    Private m_DataID As Integer
    Private m_Time As Date
    Private m_Temperature As Double
    Private m_HighAlarm As Double
    Private m_LowAlarm As Double
    Private m_RH As Double
    Private m_DewPoint As Double
    Private m_Comment As String
    Private m_SerialNumber As String

    Public Property DataID As Integer
        Get
            Return m_DataID
        End Get
        Set(value As Integer)
            m_DataID = value
        End Set
    End Property

    Public Property Time As Date
        Get
            Return m_Time
        End Get
        Set(value As Date)
            m_Time = value
        End Set
    End Property

    Public Property Temperature As Double
        Get
            Return m_Temperature
        End Get
        Set(value As Double)
            m_Temperature = value
        End Set
    End Property

    Public Property HighAlarm As Double
        Get
            Return m_HighAlarm
        End Get
        Set(value As Double)
            m_HighAlarm = value
        End Set
    End Property

    Public Property LowAlarm As Double
        Get
            Return m_LowAlarm
        End Get
        Set(value As Double)
            m_LowAlarm = value
        End Set
    End Property

    Public Property RH As Double
        Get
            Return m_RH
        End Get
        Set(value As Double)
            m_RH = value
        End Set
    End Property

    Public Property DewPoint As Double
        Get
            Return m_DewPoint
        End Get
        Set(value As Double)
            m_DewPoint = value
        End Set
    End Property

    Public Property Comment As String
        Get
            Return m_Comment
        End Get
        Set(value As String)
            m_Comment = value
        End Set
    End Property

    Public Property SerialNumber As String
        Get
            Return m_SerialNumber
        End Get
        Set(value As String)
            m_SerialNumber = value
        End Set
    End Property
End Class
