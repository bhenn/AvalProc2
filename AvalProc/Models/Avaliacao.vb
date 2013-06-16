Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Avaliacao")>
Public Class Avaliacao

    <Key>
    Public Property Id() As Integer

    <Required(ErrorMessage:="Descrição é obrigatória")> _
    <Display(Name:="Descrição")> _
    Public Property Descricao() As String

    'Empresa
    Public Property EmpresaId() As Integer
    Public Property Empresa() As Empresa

    'Avaliadores
    Public Property AvaliacaoAvaliadores As List(Of Avaliacao_Avaliador)



End Class
