﻿Imports System.Data.Entity

Public Class AvalProcContexto : Inherits DbContext

    Public Property Empresas As DbSet(Of Empresa)

    Public Property Avaliadores As DbSet(Of Avaliador)

    Public Property Categorias As DbSet(Of Categoria)

    Public Property SubCategorias As DbSet(Of SubCategoria)

    Public Property Usuarios As DbSet(Of Usuario)

    Public Property Pas As DbSet(Of Pa)

    Public Property Avaliacoes As DbSet(Of Avaliacao)

    Public Property TipoAvaliadores As DbSet(Of TipoAvaliador)

    Public Property AvaliacaoAvaliadores As DbSet(Of Avaliacao_Avaliador)

    Public Property Testes As DbSet(Of Teste)

    Public Property Processos As DbSet(Of Processo)

    Public Property AvaliacoesProcessos As DbSet(Of Avaliacao_Processo)

    Public Property AvaliacoesProcessosPas As DbSet(Of Avaliacao_Processo_Pa)

    Public Property Pontuacoes As DbSet(Of Pontuacao)

End Class
