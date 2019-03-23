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
    ' *****     +New(string)
    ' ***********************************************
    '
    ' Force the class to be typed by providing only typed constructors
    '
    Public Sub New(ByVal thePrefix As String)
        Prefix = thePrefix
        m_Guid = Guid.NewGuid
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +New(string, Guid)
    ' ***********************************************
    '
    Public Sub New(ByVal thePrefix As String, ByVal theGuid As Guid)
        Prefix = thePrefix
        m_Guid = theGuid
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +New(string, string)
    ' ***********************************************
    '
    Public Sub New(ByVal thePrefix As String, ByVal theHGIGuid As String)
        Prefix = thePrefix
        Guid.TryParse(Right(theHGIGuid, thePrefix.Length), m_Guid)
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
        m_Guid = Guid.Empty
        Return False
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
        Return theVGuid IsNot Nothing AndAlso
               m_Guid.Equals(theVGuid.m_Guid) AndAlso
               m_Prefix = theVGuid.m_Prefix
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
    Public Shared Function Empty(ByVal theprefix As String) As VGuid
        Return New VGuid(theprefix)
        '
    End Function
    ' 
    ' ***********************************************
    ' *****     +Operator = (VGuid, VGuid):bool
    ' ***********************************************
    '
    Public Shared Operator =(guid1 As VGuid, guid2 As VGuid) As Boolean
        Return EqualityComparer(Of VGuid).Default.Equals(guid1, guid2)
    End Operator
    ' 
    ' ***********************************************
    ' *****     +Operator <> (VGuid, VGuid):bool
    ' ***********************************************
    '
    Public Shared Operator <>(guid1 As VGuid, guid2 As VGuid) As Boolean
        Return Not guid1 = guid2
    End Operator

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
    Public ReadOnly Property Guid As Guid
        Get
            Return m_Guid
        End Get
        'Set(value As Guid)
        '    If IsNothing(value) Then value = Guid.Empty
        '    m_Guid = value
        'End Set
    End Property
    '
    ' ***********************************************
    ' *****     +Prefix(string):string
    ' ***********************************************
    '
    Public Property Prefix As String
        Get
            Return m_Prefix
        End Get
        Set(value As String)
            If value Is Nothing OrElse value = String.Empty Then value = ""
            m_Prefix = value
        End Set
    End Property

End Class
