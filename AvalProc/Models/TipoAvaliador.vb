Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("TipoAvaliador")>
Public Class TipoAvaliador

    <Key>
    Public Property Id() As Integer
    Public Property Descricao() As String

    'Lista de Avaliações em que o tipo de avaliador aparece
    Public Property AvaliacaoAvaliadores() As List(Of Avaliacao_Avaliador)

End Class
