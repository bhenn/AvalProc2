Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class avaliacaoPA
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.AvaliacaoPa",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .AvaliacaoId = c.Int(nullable := False),
                        .PaId = c.Int(nullable := False),
                        .Pontuacao = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Avaliacao", Function(t) t.AvaliacaoId, cascadeDelete := True) _
                .ForeignKey("dbo.pa", Function(t) t.PaId, cascadeDelete := True) _
                .Index(Function(t) t.AvaliacaoId) _
                .Index(Function(t) t.PaId)
            
            AddColumn("dbo.pa", "Avaliacao_Id", Function(c) c.Int())
            AddForeignKey("dbo.pa", "Avaliacao_Id", "dbo.Avaliacao", "Id")
            CreateIndex("dbo.pa", "Avaliacao_Id")
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.AvaliacaoPa", New String() { "PaId" })
            DropIndex("dbo.AvaliacaoPa", New String() { "AvaliacaoId" })
            DropIndex("dbo.pa", New String() { "Avaliacao_Id" })
            DropForeignKey("dbo.AvaliacaoPa", "PaId", "dbo.pa")
            DropForeignKey("dbo.AvaliacaoPa", "AvaliacaoId", "dbo.Avaliacao")
            DropForeignKey("dbo.pa", "Avaliacao_Id", "dbo.Avaliacao")
            DropColumn("dbo.pa", "Avaliacao_Id")
            DropTable("dbo.AvaliacaoPa")
        End Sub
    End Class
End Namespace
