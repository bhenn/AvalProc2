Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("AvaliacaoProcesso")>
Public Class Avaliacao_Processo
    <Key>
    Public Property Id() As Integer

    Public Property AvaliacaoId As Integer
    Public Property Avaliacao As Avaliacao

    Public Property ProcessoId As Integer
    Public Property Processo As Processo

    'Pas
    Public Property AvaliacaoProcessoPas As List(Of Avaliacao_Processo_Pa)

    Public Property NivelCapacidade As String

End Class
