﻿Imports System.Data.Entity

Public Class AvalProcContexto : Inherits DbContext

    Public Property Empresas As DbSet(Of Empresa)

    Public Property Avaliadores As DbSet(Of Avaliador)

    Public Property Categorias As DbSet(Of Categoria)

    Public Property SubCategorias As DbSet(Of SubCategoria)

    Public Property Usuarios As DbSet(Of Usuario)

    Public Property Pas As DbSet(Of Pa)

    Public Property Mps As DbSet(Of Mp)

End Class
