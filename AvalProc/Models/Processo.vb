Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Processo")>
Public Class Processo

    <Key>
    Public Property Id As Integer

    <RequiredAttribute(ErrorMessage:="Obrigatório")>
    <Display(Name:="Descrição")> _
    Public Property Descricao As String

    <RequiredAttribute(ErrorMessage:="Obrigatório")>
    Public Property SubCategoriaId As Integer
    Public Property SubCategoria As SubCategoria

    Public Property AvaliacoesProcessos As List(Of Avaliacao_Processo)

End Class
