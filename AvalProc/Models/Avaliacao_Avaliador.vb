Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("AvaliacaoAvaliador")>
Public Class Avaliacao_Avaliador
    <Key>
    Public Property Id() As Integer

    Public Property AvaliadorId() As Integer
    Public Property Avaliador() As Avaliador

    Public Property TipoAvaliadorId() As Integer
    Public Property TipoAvaliador As TipoAvaliador

    Public Property AvaliacaoId As Integer
    Public Property Avaliacao As Avaliacao


End Class
