Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class retiradoMP
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.mp", "PaId", "dbo.pa")
            DropIndex("dbo.mp", New String() { "PaId" })
            DropTable("dbo.mp")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.mp",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Nome = c.String(nullable := False),
                        .Descricao = c.String(nullable := False),
                        .PaId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateIndex("dbo.mp", "PaId")
            AddForeignKey("dbo.mp", "PaId", "dbo.pa", "Id", cascadeDelete := True)
        End Sub
    End Class
End Namespace
