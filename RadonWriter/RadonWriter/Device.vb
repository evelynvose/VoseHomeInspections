' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class Device

    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()

    End Sub

    Public Sub New(ByVal theManufacturerName As String, ByVal theModel As String, ByVal theSerialNumber As String, ByVal theCalibrationDate As String, ByVal theCalibrationFactor1 As Double, ByVal theCalibrationFactor2 As Double)
        ManufacturerName = theManufacturerName
        Model = theModel
        SerialNumber = theSerialNumber
        CalibrationDate = theCalibrationDate
        CalibrationFactor1 = theCalibrationFactor1
        CalibrationFactor2 = theCalibrationFactor2

    End Sub



    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************



    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 

    Public Property ManufacturerName As String
        Get
            Return m_ManufacturerName
        End Get
        Set(value As String)
            m_ManufacturerName = value
        End Set
    End Property
    Private m_ManufacturerName As String = "Sun Nuclear Corporation"

    Public Property Model As String
        Get
            Return m_Model
        End Get
        Set(value As String)
            m_Model = value
        End Set
    End Property
    Private m_Model As String = ""

    Public Property SerialNumber As String
        Get
            Return m_SerialNumber
        End Get
        Set(value As String)
            m_SerialNumber = value
        End Set
    End Property
    Private m_SerialNumber As String = ""

    Public Property CalibrationDate As Date
        Get
            Return m_CalibrationDate
        End Get
        Set(value As Date)
            m_CalibrationDate = value
        End Set
    End Property
    Private m_CalibrationDate As Date = #04/18/1959#

    Public Property CalibrationFactor1 As Double
        Get
            Return m_CalibrationFactor1
        End Get
        Set(value As Double)
            m_CalibrationFactor1 = value
        End Set
    End Property
    Private m_CalibrationFactor1 As Double

    Public Property CalibrationFactor2 As Double
        Get
            Return m_CalibrationFactor2
        End Get
        Set(value As Double)
            m_CalibrationFactor2 = value
        End Set
    End Property
    Private m_CalibrationFactor2 As Double





End Class
