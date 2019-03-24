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
    'Public Sub New()
    '    Initialize()
    '    '
    'End Sub
    '
    ' ***********************************************
    ' *****     +New(string, Guid)
    ' ***********************************************
    '
    ' Use Case: We want tp create an HGI Guid from scratch
    '
    Public Sub New(ByVal thePrefix As String, ByVal theGuid As Guid)
        Initialize()
        '
        ' Error checking: Legal preFix?
        '
        ' Clean the prefix of any "-". Note that this isn't perfect, but we have to expect the 
        '     coder to attempt to use this class properly. Adding the trailing "-" is the most commonly
        '     overlooked mistake.
        '
        m_IsValid = True ' preset the valid flag
        '
        thePrefix.Trim("-")
        If Not My.Settings.HGIGuidPrefixes.Contains(thePrefix) Then
            m_IsValid = False
            MsgBox(New Exception("The prefix given is not in the my.settings collection!"))
            '
        Else
            m_Prefix = thePrefix
            '
        End If
        '
        ' Save the Guid
        '
        m_Guid = theGuid
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +New(string)
    ' ***********************************************
    '
    Public Sub New(ByVal theHGIGuid As String)
        Initialize()
        '
        ' Error Checking: Nothing or incorrect length
        '
        If theHGIGuid Is Nothing Then Return
        If theHGIGuid.Length < 36 Then Return
        '
        ' Error checking: Legal prefix?
        '
        m_IsValid = True ' preset the vsalid flag
        '
        m_Prefix = GetHGIPrefix(theHGIGuid)
        If Not My.Settings.HGIGuidPrefixes.Contains(Prefix) Then
            m_IsValid = False
            MsgBox(New Exception("The given HGI Guid does not contain a prefix in the my.settings collection." & vbCrLf & theHGIGuid))
            '
        End If
        '
        ' Error checking: Legal Guid?
        '
        Dim tempGuid As Guid
        Guid.TryParse(StripHGIPrefix(theHGIGuid), tempGuid)
        If tempGuid.Equals(Guid.Empty) Then
            m_IsValid = False
            MsgBox(New Exception("The given HGI Guid is not in the correct format." & vbCrLf & theHGIGuid))
            '
        Else
            m_Guid = tempGuid
            '
        End If
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
    ' *****     -Initialize()
    ' ***********************************************
    '  
    Private Sub Initialize()
        m_Guid = Guid.NewGuid
        m_IsValid = False
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -StripHGIPrefix(string):string
    ' ***********************************************
    '
    Private Function StripHGIPrefix(ByVal s As String) As String
        If s Is Nothing Then Return ""
        Try
            Dim i As Integer = s.IndexOf("-", 0)
            If i < 1 Then i = 1
            If i < 4 Then
                s = Right(s, s.Length - i)
                '
            End If
            s = s.TrimStart("-")
        Catch ex As Exception
            MsgBox(New Exception("Invalid HGI Prefix strip." & vbCrLf & s))
            '
        End Try

        Return s
    End Function
    '
    ' ***********************************************
    ' *****     -GetHGIPrefix(string):string
    ' ***********************************************
    '
    Private Function GetHGIPrefix(ByVal s As String) As String
        If s Is Nothing Then Return ""
        Try
            Dim i As Integer = s.IndexOf("-", 0)
            If i < 1 Then i = 1
            If i < 4 Then
                s = Mid(s, 1, i)
                '
            End If
        Catch ex As Exception
            MsgBox(New Exception("Invalid HGI Prefix strip." & vbCrLf & s))
            '
        End Try

        Return s
    End Function
    '
    ' ***********************************************
    ' *****     +TryParse(string, Guid):bool
    ' ***********************************************
    '
    ' Input is preserved
    ' Guid, the result, will either be empty or filled
    '
    Public Function TryParse(ByVal theInput As String) As Boolean
        '
        ' Error checking: GIGO
        '
        If theInput Is Nothing Then Return False
        '
        ' Test the input to see if it has a prefix attached. The prefix has to be in the list.
        '      T) Remove the prefix and then parse the input. 
        '      F) Return
        '
        Dim sTest As String = GetHGIPrefix(theInput)
        If Not My.Settings.HGIGuidPrefixes.Contains(sTest) Then ' remove the prefix
            m_IsValid = False
            Return m_IsValid
        End If
        sTest = StripHGIPrefix(theInput)
        '
        ' Test the input to see if it is a valid Guid.
        '      T) Strip the prefix and save the Guid. 
        '      F) Return
        '
        m_IsValid = True ' preset the valid flag
        Guid.TryParse(sTest, m_Guid)
        If m_Guid.Equals(Guid.Empty) Then
            m_IsValid = False
            '
        End If
        '
        Return m_IsValid
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
    Private m_IsValid As Boolean
    '
    ' ***********************************************
    ' *****     +Guid():string
    ' ***********************************************
    '
    Public ReadOnly Property Guid As Guid
        Get
            Return m_Guid
        End Get
    End Property
    '
    ' ***********************************************
    ' *****     +Prefix():string
    ' ***********************************************
    '
    Public ReadOnly Property Prefix As String
        Get
            Return m_Prefix
        End Get
    End Property
    '
    ' ***********************************************
    ' *****     +IsEmpty():bool
    ' ***********************************************
    '
    Public ReadOnly Property IsEmpty As Boolean
        Get
            If m_Guid.Equals(Guid.Empty) Then Return True
            Return False
        End Get
    End Property
    '
    ' ***********************************************
    ' *****     +IsValid():bool
    ' ***********************************************
    '
    Public ReadOnly Property IsValid As Boolean
        Get
            Return m_IsValid
        End Get
    End Property
End Class
