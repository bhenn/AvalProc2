Public Class Avaliador

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _nome As String
    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property

    Private _cpf As String
    Public Property Cpf() As String
        Get
            Return _cpf
        End Get
        Set(ByVal value As String)
            _cpf = value
        End Set
    End Property




End Class
