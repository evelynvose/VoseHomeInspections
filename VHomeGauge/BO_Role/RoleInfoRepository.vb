Public Class RoleInfoRepository
    ' TODO - Implement PersonRole, PersonRoleInfo and PersonRoleInfoRepository classes
    '
    ' Role Name
    '
    Public Property RoleName As String
        Get
            Return m_RoleName
        End Get
        Set(value As String)
            m_RoleName = value
            m_IsDirty = True
        End Set
    End Property
End Class
