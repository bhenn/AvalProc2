Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class avaliadorTipoAvaliacaoAvaliador
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.TipoAvaliador",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Descricao = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.AvaliacaoAvaliador",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .AvaliadorId = c.Int(nullable := False),
                        .TipoAvaliadorId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Avaliadors", Function(t) t.AvaliadorId, cascadeDelete := True) _
                .ForeignKey("dbo.TipoAvaliador", Function(t) t.TipoAvaliadorId, cascadeDelete := True) _
                .Index(Function(t) t.AvaliadorId) _
                .Index(Function(t) t.TipoAvaliadorId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.AvaliacaoAvaliador", New String() { "TipoAvaliadorId" })
            DropIndex("dbo.AvaliacaoAvaliador", New String() { "AvaliadorId" })
            DropForeignKey("dbo.AvaliacaoAvaliador", "TipoAvaliadorId", "dbo.TipoAvaliador")
            DropForeignKey("dbo.AvaliacaoAvaliador", "AvaliadorId", "dbo.Avaliadors")
            DropTable("dbo.AvaliacaoAvaliador")
            DropTable("dbo.TipoAvaliador")
        End Sub
    End Class
End Namespace
