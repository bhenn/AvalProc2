Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Subcategoria")>
Public Class SubCategoria

    <Key>
    Public Property Id() As Integer

    <Required(ErrorMessage:="Obrigatório")>
    Public Property Descricao() As String

    <Required(ErrorMessage:="Obrigatório")>
    Public Property CategoriaId As Integer
    Public Property Categoria() As Categoria

    Public Property Processos As List(Of Processo)

End Class
