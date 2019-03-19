'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Public Class VGuid
    Inherits VObject        ' Everything inherits VObject
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     +New()
    ' ***********************************************
    '
    ' Force the class to be typed by providing only one constructor
    '
    Public Sub New(ByVal thePrefix As String)
        Prefix = thePrefix
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     +TryParse(string, Guid):bool
    ' ***********************************************
    '
    ' Input is preserved
    ' Guid, the result, will either be empty or filled
    '
    Public Function TryParse(ByVal theInput As String, ByRef theResult As Guid) As Boolean
        '
        ' Test the input to see if it has a prefix attached. The prefix has to match this object's type.
        '      T) Remove the prefix and then parse the input. 
        '      F) Try parsing the input anyway
        '
        Dim sTest As String = theInput
        If Left(sTest, Prefix.Length()) = Prefix Then ' remove the prefix
            sTest = theInput.Replace(Prefix, "")
            '
        End If
        If Guid.TryParse(sTest, Me.Guid) Then
            theResult = Me.Guid
            Return True
            '
        End If
        '
        Me.Guid = Guid.Empty
        Return False
    End Function
    ' 
    ' ***********************************************
    ' *****     +NewGuid():guid
    ' ***********************************************
    '
    Public Function NewGuid() As VGuid
        Me.Guid = Guid.NewGuid
        Return Me
        '
    End Function
    ' 
    ' ***********************************************
    ' *****     +ToString():string
    ' ***********************************************
    '
    Public Overrides Function ToString() As String
        Dim s As String
        s = String.Format("{0}-{1}", Prefix, Me.Guid.ToString)
        Return s
    End Function
    ' 
    ' ***********************************************
    ' *****     +Equals(object):bool
    ' ***********************************************
    '
    Public Overrides Function Equals(obj As Object) As Boolean
        Dim theGuid = TryCast(obj, VGuid)
        Return theGuid IsNot Nothing AndAlso
               m_Guid.Equals(theGuid.m_Guid) AndAlso
               m_Prefix = theGuid.m_Prefix
        '
    End Function
    ' 
    ' ***********************************************
    ' *****     +Equals(VGuid):bool
    ' ***********************************************
    '
    Public Overloads Function Equals(theVGuid As VGuid) As Boolean
        Return Equals(theVGuid)
        '
    End Function
    ' 
    ' ***********************************************
    ' *****     +Equals(guid):bool
    ' ***********************************************
    '
    Public Overloads Function Equals(theGuid As Guid) As Boolean
        Return Me.Guid.Equals(theGuid)
        '
    End Function
    ' 
    ' ***********************************************
    ' *****     +Equals(guid, guid):bool
    ' ***********************************************
    '
    Public Overloads Function Equals(ByVal objA As Guid, ByVal objB As Guid) As Boolean
        Return Guid.Equals(objA, objB)
        '
    End Function
    ' 
    ' ***********************************************
    ' *****     +Equals(VGuid, VGuid):bool
    ' ***********************************************
    '
    Public Overloads Function Equals(ByVal objA As VGuid, ByVal objB As VGuid) As Boolean
        Return objA IsNot Nothing AndAlso objB IsNot Nothing AndAlso objA.Prefix = objB.Prefix AndAlso Guid.Equals(objA, objB)
        '
    End Function
    ' 
    ' ***********************************************
    ' *****     +Equals(VGuid, VGuid):bool
    ' ***********************************************
    '
    Public Function Empty() As VGuid
        Me.Guid = Guid.Empty
        Return Me
        '
    End Function
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     Encapsulated Members
    ' ***********************************************
    '
    Private m_Guid As Guid
    Private m_Prefix As String
    '
    ' ***********************************************
    ' *****     +Guid(string):string
    ' ***********************************************
    '
    Public Property Guid As Guid
        Get
            Return m_Guid
        End Get
        Set(value As Guid)
            m_Guid = value
        End Set
    End Property

    Public Property Prefix As String
        Get
            Return m_Prefix
        End Get
        Set(value As String)
            m_Prefix = value
        End Set
    End Property

    Public Shared Operator =(guid1 As VGuid, guid2 As VGuid) As Boolean
        Return EqualityComparer(Of VGuid).Default.Equals(guid1, guid2)
    End Operator

    Public Shared Operator <>(guid1 As VGuid, guid2 As VGuid) As Boolean
        Return Not guid1 = guid2
    End Operator
End Class
