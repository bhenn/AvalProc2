Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class pasEmps
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.pa",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Nome = c.String(nullable := False),
                        .Descricao = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.mp",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Nome = c.String(nullable := False),
                        .Descricao = c.String(nullable := False),
                        .PaId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.pa", Function(t) t.PaId, cascadeDelete := True) _
                .Index(Function(t) t.PaId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.mp", New String() { "PaId" })
            DropForeignKey("dbo.mp", "PaId", "dbo.pa")
            DropTable("dbo.mp")
            DropTable("dbo.pa")
        End Sub
    End Class
End Namespace
