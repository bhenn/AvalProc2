﻿Public Class Categoria

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _descricao As String
    Public Property Descricao() As String
        Get
            Return _descricao
        End Get
        Set(ByVal value As String)
            _descricao = value
        End Set
    End Property

    Private _subcategorias As List(Of SubCategoria)
    Public Property SubCategorias() As List(Of SubCategoria)
        Get
            Return _subcategorias
        End Get
        Set(ByVal value As List(Of SubCategoria))
            _subcategorias = value
        End Set
    End Property



End Class
