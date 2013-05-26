Public Class Empresa

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

    Private _cnpj As String
    Public Property Cnpj() As String
        Get
            Return _cnpj
        End Get
        Set(ByVal value As String)
            _cnpj = value
        End Set
    End Property

    Private _endereco As String
    Public Property Endereco() As String
        Get
            Return _endereco
        End Get
        Set(ByVal value As String)
            _endereco = value
        End Set
    End Property





End Class
