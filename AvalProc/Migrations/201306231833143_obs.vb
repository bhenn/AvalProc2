Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class obs
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.AvaliacaoProcessoPa", "Observacao", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.AvaliacaoProcessoPa", "Observacao")
        End Sub
    End Class
End Namespace
