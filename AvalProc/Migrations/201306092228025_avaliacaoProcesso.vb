Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class avaliacaoProcesso
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.AvaliacaoProcesso",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .AvaliacaoId = c.Int(nullable := False),
                        .ProcessoId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Avaliacao", Function(t) t.AvaliacaoId, cascadeDelete := True) _
                .ForeignKey("dbo.Processo", Function(t) t.ProcessoId, cascadeDelete := True) _
                .Index(Function(t) t.AvaliacaoId) _
                .Index(Function(t) t.ProcessoId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.AvaliacaoProcesso", New String() { "ProcessoId" })
            DropIndex("dbo.AvaliacaoProcesso", New String() { "AvaliacaoId" })
            DropForeignKey("dbo.AvaliacaoProcesso", "ProcessoId", "dbo.Processo")
            DropForeignKey("dbo.AvaliacaoProcesso", "AvaliacaoId", "dbo.Avaliacao")
            DropTable("dbo.AvaliacaoProcesso")
        End Sub
    End Class
End Namespace
