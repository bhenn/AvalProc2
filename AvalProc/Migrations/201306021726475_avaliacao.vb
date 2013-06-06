Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class avaliacao
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Avaliacao",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Descricao = c.String(nullable := False),
                        .EmpresaId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Empresas", Function(t) t.EmpresaId, cascadeDelete := True) _
                .Index(Function(t) t.EmpresaId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.Avaliacao", New String() { "EmpresaId" })
            DropForeignKey("dbo.Avaliacao", "EmpresaId", "dbo.Empresas")
            DropTable("dbo.Avaliacao")
        End Sub
    End Class
End Namespace
