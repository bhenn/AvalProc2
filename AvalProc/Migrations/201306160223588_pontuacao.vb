Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class pontuacao
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Pontuacaos",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Valor = c.String(),
                        .Nome = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Pontuacaos")
        End Sub
    End Class
End Namespace
