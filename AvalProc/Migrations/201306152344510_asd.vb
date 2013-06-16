Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class asd
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.pa", "Avaliacao_Id", "dbo.Avaliacao")
            DropIndex("dbo.pa", New String() { "Avaliacao_Id" })
            DropColumn("dbo.pa", "Avaliacao_Id")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.pa", "Avaliacao_Id", Function(c) c.Int())
            CreateIndex("dbo.pa", "Avaliacao_Id")
            AddForeignKey("dbo.pa", "Avaliacao_Id", "dbo.Avaliacao", "Id")
        End Sub
    End Class
End Namespace
