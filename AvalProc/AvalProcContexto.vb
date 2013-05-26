Imports System.Data.Entity

Public Class AvalProcContexto : Inherits DbContext

    Public Property Empresas As DbSet(Of Empresa)

    Public Property Avaliadores As DbSet(Of Avaliador)

    Public Property Categorias As DbSet(Of Categoria)

End Class
