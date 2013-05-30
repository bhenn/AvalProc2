Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("pa")>
Public Class Pa
    <Key>
    Public Property Id() As Integer

    <Required(ErrorMessage:="Nome é obrigatório")> _
    Public Property Nome() As String

    <Required(ErrorMessage:="Descrição é obrigatória")> _
    <Display(Name:="Descrição")> _
    Public Property Descricao() As String

    Public Property Pas() As List(Of Mp)

End Class
