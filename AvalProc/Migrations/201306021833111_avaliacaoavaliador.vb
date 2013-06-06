Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class avaliacaoavaliador
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.AvaliacaoAvaliador", "AvaliacaoId", Function(c) c.Int(nullable := False))
            AddForeignKey("dbo.AvaliacaoAvaliador", "AvaliacaoId", "dbo.Avaliacao", "Id", cascadeDelete := True)
            CreateIndex("dbo.AvaliacaoAvaliador", "AvaliacaoId")
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.AvaliacaoAvaliador", New String() { "AvaliacaoId" })
            DropForeignKey("dbo.AvaliacaoAvaliador", "AvaliacaoId", "dbo.Avaliacao")
            DropColumn("dbo.AvaliacaoAvaliador", "AvaliacaoId")
        End Sub
    End Class
End Namespace
