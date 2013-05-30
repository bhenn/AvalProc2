Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("mp")>
Public Class Mp
    <Key>
    Public Property Id() As Integer

    <Required(ErrorMessage:="Nome é obrigatório")> _
    Public Property Nome() As String

    <Required(ErrorMessage:="Descrição é obrigatória")>
    <Display(Name:="Descrição")>
    Public Property Descricao() As String

    Public Property PaId() As Integer

    Public Property Pa() As Pa


End Class
