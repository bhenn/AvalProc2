Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class usuario
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Usuarios",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Email = c.String(),
                        .Senha = c.String(),
                        .SenhaSalt = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Usuarios")
        End Sub
    End Class
End Namespace
