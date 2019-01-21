' **********************************************
' ****
' ******    Radon Data Point Class
' ****
' **********************************************
'
Public Class RadonDataPoint


    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 



    ' **********************************************
    ' ****
    ' ******    thods
    ' ****
    ' **********************************************
    ' 



    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    Public Property Time() As String
        Get
            Return m_Time
        End Get
        Set(value As String)
            m_Time = value
        End Set
    End Property
    Private m_Time As String

    Public Property Count() As String
        Get
            Return m_Count
        End Get
        Set(value As String)
            m_Count = value
        End Set
    End Property
    Private m_Count As String

    Public Property Flag() As String
        Get
            Return m_Flag
        End Get
        Set(value As String)
            m_Flag = value
        End Set
    End Property
    Private m_Flag As String


    Public Property PCIL() As Double
        Get
            Return m_PCIL
        End Get
        Set(value As Double)
            m_PCIL = value
        End Set
    End Property
    Private m_PCIL As Double

    Public Property ReadingDate As String
        Get
            Return m_ReadingDate
        End Get
        Set(value As String)
            m_ReadingDate = value
        End Set
    End Property
    Private m_ReadingDate As String

    Public Property Temperature As Double
        Get
            Return m_Temperature
        End Get
        Set(value As Double)
            m_Temperature = value
        End Set
    End Property
    Private m_Temperature As String


    Public Property Humidity As Double
        Get
            Return m_Humidity
        End Get
        Set(value As Double)
            m_Humidity = value
        End Set
    End Property
    Private m_Humidity As String

    Public Sub New(readingDate As String, time As String, count As String, flag As String, PCIL As Double)
        Me.ReadingDate = readingDate
        Me.Time = time
        Me.Count = count
        Me.Flag = flag
        Me.PCIL = PCIL
    End Sub

    Public Sub New(time As String, count As String, flag As String, PCIL As Double)
        Me.ReadingDate = "00/00/00"
        Me.Time = time
        Me.Count = count
        Me.Flag = flag
        Me.PCIL = PCIL
    End Sub

    Public Sub New(time As String, count As String, flag As String)
        Me.ReadingDate = "00/00/00"
        Me.Time = time
        Me.Count = count
        Me.Flag = flag
        Me.PCIL = 0
    End Sub


End Class

