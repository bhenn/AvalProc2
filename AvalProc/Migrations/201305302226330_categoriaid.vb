Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class categoriaid
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.SubCategorias", "Categoria_Id", "dbo.Categorias")
            DropIndex("dbo.SubCategorias", New String() { "Categoria_Id" })
            RenameColumn(table := "dbo.SubCategorias", name := "Categoria_Id", newName := "CategoriaId")
            AddForeignKey("dbo.SubCategorias", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete := True)
            CreateIndex("dbo.SubCategorias", "CategoriaId")
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.SubCategorias", New String() { "CategoriaId" })
            DropForeignKey("dbo.SubCategorias", "CategoriaId", "dbo.Categorias")
            RenameColumn(table := "dbo.SubCategorias", name := "CategoriaId", newName := "Categoria_Id")
            CreateIndex("dbo.SubCategorias", "Categoria_Id")
            AddForeignKey("dbo.SubCategorias", "Categoria_Id", "dbo.Categorias", "Id")
        End Sub
    End Class
End Namespace
