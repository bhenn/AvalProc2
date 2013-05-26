Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class subcategoria
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.SubCategorias",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Descricao = c.String(),
                        .Categoria_Id = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Categorias", Function(t) t.Categoria_Id) _
                .Index(Function(t) t.Categoria_Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.SubCategorias", New String() { "Categoria_Id" })
            DropForeignKey("dbo.SubCategorias", "Categoria_Id", "dbo.Categorias")
            DropTable("dbo.SubCategorias")
        End Sub
    End Class
End Namespace
