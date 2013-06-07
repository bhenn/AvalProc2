Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class decorators
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameTable(name := "dbo.Avaliadors", newName := "Avaliador")
            AlterColumn("dbo.Avaliador", "Nome", Function(c) c.String(nullable := False))
            AlterColumn("dbo.Avaliador", "Cpf", Function(c) c.String(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Avaliador", "Cpf", Function(c) c.String())
            AlterColumn("dbo.Avaliador", "Nome", Function(c) c.String())
            RenameTable(name := "dbo.Avaliador", newName := "Avaliadors")
        End Sub
    End Class
End Namespace
