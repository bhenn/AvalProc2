Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class categoria
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Categorias",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Descricao = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Categorias")
        End Sub
    End Class
End Namespace
