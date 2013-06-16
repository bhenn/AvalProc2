Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class avalprocessopa
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.AvaliacaoPa", "AvaliacaoId", "dbo.Avaliacao")
            DropForeignKey("dbo.AvaliacaoPa", "PaId", "dbo.pa")
            DropIndex("dbo.AvaliacaoPa", New String() { "AvaliacaoId" })
            DropIndex("dbo.AvaliacaoPa", New String() { "PaId" })
            CreateTable(
                "dbo.AvaliacaoProcessoPa",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .AvaliacaoProcessoId = c.Int(nullable := False),
                        .PaId = c.Int(nullable := False),
                        .Pontuacao = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AvaliacaoProcesso", Function(t) t.AvaliacaoProcessoId, cascadeDelete := True) _
                .ForeignKey("dbo.pa", Function(t) t.PaId, cascadeDelete := True) _
                .Index(Function(t) t.AvaliacaoProcessoId) _
                .Index(Function(t) t.PaId)
            
            DropTable("dbo.AvaliacaoPa")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.AvaliacaoPa",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .AvaliacaoId = c.Int(nullable := False),
                        .PaId = c.Int(nullable := False),
                        .Pontuacao = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            DropIndex("dbo.AvaliacaoProcessoPa", New String() { "PaId" })
            DropIndex("dbo.AvaliacaoProcessoPa", New String() { "AvaliacaoProcessoId" })
            DropForeignKey("dbo.AvaliacaoProcessoPa", "PaId", "dbo.pa")
            DropForeignKey("dbo.AvaliacaoProcessoPa", "AvaliacaoProcessoId", "dbo.AvaliacaoProcesso")
            DropTable("dbo.AvaliacaoProcessoPa")
            CreateIndex("dbo.AvaliacaoPa", "PaId")
            CreateIndex("dbo.AvaliacaoPa", "AvaliacaoId")
            AddForeignKey("dbo.AvaliacaoPa", "PaId", "dbo.pa", "Id", cascadeDelete := True)
            AddForeignKey("dbo.AvaliacaoPa", "AvaliacaoId", "dbo.Avaliacao", "Id", cascadeDelete := True)
        End Sub
    End Class
End Namespace
