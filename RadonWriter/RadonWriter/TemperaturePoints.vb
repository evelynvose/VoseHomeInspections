
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class TemperaturePoints(Of TemperaturePoint)
    Implements IList(Of TemperaturePoint)


    ' **********************************************
    ' ****
    ' ******    Members
    ' ****
    ' **********************************************
    '
    Private m_Count As Integer
    Private m_Capacity As Integer = 16
    Private m_BackingStore(0 To m_Capacity - 1) As TemperaturePoint



    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    Private Sub ResizeIfNeeded()
        If m_Capacity = m_Count Then
            m_Capacity *= 2
            ReDim Preserve m_BackingStore(0 To m_Capacity - 1)
        End If
    End Sub

    Public Sub Add(ByVal item As TemperaturePoint) Implements System.Collections.Generic.ICollection(Of TemperaturePoint).Add
        ResizeIfNeeded()

        m_BackingStore(m_Count) = item
        m_Count += 1
    End Sub

    Public Sub Clear() Implements System.Collections.Generic.ICollection(Of TemperaturePoint).Clear
        m_Count = 0
    End Sub

    Public Function Contains(ByVal item As TemperaturePoint) As Boolean Implements System.Collections.Generic.ICollection(Of TemperaturePoint).Contains
        Return IndexOf(item) <> -1
    End Function

    Public Sub CopyTo(ByVal array() As TemperaturePoint, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of TemperaturePoint).CopyTo
        If array Is Nothing Then
            Throw New ArgumentNullException("array")
        End If
        If arrayIndex + Me.Count > array.Length Then
            Throw New ArgumentException("array")
        End If
        For i As Integer = 0 To Me.Count - 1
            array(arrayIndex + i) = Me(i)
        Next i
    End Sub

    Public Function Remove(ByVal item As TemperaturePoint) As Boolean Implements System.Collections.Generic.ICollection(Of TemperaturePoint).Remove
        Dim index As Integer = Me.IndexOf(item)
        If index = -1 Then
            Return False
        Else
            RemoveAt(index)
            Return True
        End If
    End Function

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of TemperaturePoint) Implements System.Collections.Generic.IEnumerable(Of TemperaturePoint).GetEnumerator
        Return New MyListEnumerator(Me)
    End Function

    Public Function IndexOf(ByVal item As TemperaturePoint) As Integer Implements System.Collections.Generic.IList(Of TemperaturePoint).IndexOf
        Return Array.IndexOf(m_BackingStore, item)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal item As TemperaturePoint) Implements System.Collections.Generic.IList(Of TemperaturePoint).Insert
        ResizeIfNeeded()

        m_Count += 1

        For i As Integer = Me.Count - 1 To index + 1 Step -1
            Me(i) = Me(i - 1)
        Next i

        Me(index) = item
    End Sub

    Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.Generic.IList(Of TemperaturePoint).RemoveAt
        If index >= Me.Count Then
            Throw New ArgumentOutOfRangeException("index")
        End If

        For i As Integer = index To Me.Count - 2
            Me(i) = Me(i + 1)
        Next i

        m_Count -= 1
    End Sub

    Private Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return New MyListEnumerator(Me)
    End Function



    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of TemperaturePoint).Count
        Get
            Return m_Count
        End Get
    End Property


    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of TemperaturePoint).IsReadOnly
        Get
            Return False
        End Get
    End Property


    Default Public Property Item(ByVal index As Integer) As TemperaturePoint Implements System.Collections.Generic.IList(Of TemperaturePoint).Item
        Get
            If index >= Me.Count Then
                Throw New ArgumentOutOfRangeException("index")
            End If
            Return m_BackingStore(index)
        End Get
        Set(ByVal value As TemperaturePoint)
            If index >= Me.Count Then
                Throw New ArgumentOutOfRangeException("index")
            End If
            m_BackingStore(index) = value
        End Set
    End Property


    ' **********************************************
    ' ****
    ' ******    Class
    ' ****
    ' **********************************************
    ' 
    Private Class MyListEnumerator
        Implements IEnumerator(Of TemperaturePoint)

        ' **********************************************
        ' ****
        ' ******    members
        ' ****
        ' **********************************************
        '
        Private m_Parent As TemperaturePoints(Of TemperaturePoint)
        Private m_Index As Integer = -1

        ' **********************************************
        ' ****
        ' ******    Constructor
        ' ****
        ' **********************************************
        '
        Friend Sub New(ByVal parent As TemperaturePoints(Of TemperaturePoint))
            m_Parent = parent
        End Sub




        ' **********************************************
        ' ****
        ' ******    Methods
        ' ****
        ' **********************************************
        ' 
        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            If m_Index < m_Parent.Count - 1 Then
                m_Index += 1
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            m_Index = -1
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            'Not required.
        End Sub





        ' **********************************************
        ' ****
        ' ******    Properties
        ' ****
        ' **********************************************
        '
        Public ReadOnly Property Current() As TemperaturePoint Implements System.Collections.Generic.IEnumerator(Of TemperaturePoint).Current
            Get
                If m_Index = -1 Then
                    Throw New InvalidOperationException()
                End If

                Return m_Parent(m_Index)
            End Get
        End Property

        Private ReadOnly Property Current1() As Object Implements System.Collections.IEnumerator.Current
            Get
                Return Me.Current
            End Get
        End Property


    End Class


End Class
