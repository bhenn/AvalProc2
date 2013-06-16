Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("AvaliacaoProcessoPa")>
Public Class Avaliacao_Processo_Pa
    <Key>
    Public Property Id() As Integer

    Public Property AvaliacaoProcessoId As Integer
    Public Property AvaliacaoProcesso As Avaliacao_Processo

    Public Property PaId As Integer
    Public Property Pa As Pa

    Public Property Pontuacao As String

End Class
