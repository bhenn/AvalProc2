Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class processos
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameTable(name := "dbo.SubCategorias", newName := "Subcategoria")
            CreateTable(
                "dbo.Processo",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Descricao = c.String(nullable := False),
                        .SubCategoriaId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Subcategoria", Function(t) t.SubCategoriaId, cascadeDelete := True) _
                .Index(Function(t) t.SubCategoriaId)
            
            AlterColumn("dbo.Subcategoria", "Descricao", Function(c) c.String(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.Processo", New String() { "SubCategoriaId" })
            DropForeignKey("dbo.Processo", "SubCategoriaId", "dbo.Subcategoria")
            AlterColumn("dbo.Subcategoria", "Descricao", Function(c) c.String())
            DropTable("dbo.Processo")
            RenameTable(name := "dbo.Subcategoria", newName := "SubCategorias")
        End Sub
    End Class
End Namespace
