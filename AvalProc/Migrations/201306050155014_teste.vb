Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class teste
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Testes",
                Function(c) New With
                    {
                        .id = c.Int(nullable := False, identity := True),
                        .descricao = c.String()
                    }) _
                .PrimaryKey(Function(t) t.id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Testes")
        End Sub
    End Class
End Namespace
