Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class retiradoalgumacoisa
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.AvaliacaoProcesso", "NivelCapacidade", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.AvaliacaoProcesso", "NivelCapacidade")
        End Sub
    End Class
End Namespace
