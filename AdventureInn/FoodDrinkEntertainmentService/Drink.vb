Public Class Drink
    Private _Name As String
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    Private _Alcoholism As String
    Public ReadOnly Property Alcoholism As String
        Get
            Return _Alcoholism
        End Get
    End Property
    Private _Subtype As String
    Public ReadOnly Property Subtype As String
        Get
            Return _Subtype
        End Get
    End Property
    Private _Fanciness As String
    Public ReadOnly Property Fanciness As String
        Get
            Return _Fanciness
        End Get
    End Property
    Private _Alignment As String
    Public ReadOnly Property Alignment As String
        Get
            Return _Alignment
        End Get
    End Property
End Class
