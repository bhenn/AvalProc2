Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class avaliador
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Avaliadors",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Nome = c.String(),
                        .Cpf = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Avaliadors")
        End Sub
    End Class
End Namespace
