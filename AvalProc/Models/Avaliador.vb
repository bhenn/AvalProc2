Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Avaliador")>
Public Class Avaliador
    <Key>
    Public Property Id() As Integer

    <RequiredAttribute(ErrorMessage:="Obrigatório")>
    Public Property Nome() As String

    <RequiredAttribute(ErrorMessage:="Obrigatório")>
    Public Property Cpf() As String

    Public Property AvaliacaoAvaliadores As List(Of Avaliacao_Avaliador)

End Class
