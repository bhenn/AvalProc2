Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class testekendo
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.TesteKendoes",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Descricao = c.String(),
                        .Nome = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.TesteKendoes")
        End Sub
    End Class
End Namespace
