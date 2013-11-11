Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class tudo
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Empresas",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Nome = c.String(),
                        .Cnpj = c.String(),
                        .Endereco = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
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
            
            CreateTable(
                "dbo.AvaliacaoAvaliador",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .AvaliadorId = c.Int(nullable := False),
                        .TipoAvaliadorId = c.Int(nullable := False),
                        .AvaliacaoId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Avaliador", Function(t) t.AvaliadorId, cascadeDelete := True) _
                .ForeignKey("dbo.TipoAvaliador", Function(t) t.TipoAvaliadorId, cascadeDelete := True) _
                .ForeignKey("dbo.Avaliacao", Function(t) t.AvaliacaoId, cascadeDelete := True) _
                .Index(Function(t) t.AvaliadorId) _
                .Index(Function(t) t.TipoAvaliadorId) _
                .Index(Function(t) t.AvaliacaoId)
            
            CreateTable(
                "dbo.Avaliador",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Nome = c.String(nullable := False),
                        .Cpf = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.TipoAvaliador",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Descricao = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.Categorias",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Descricao = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.Subcategoria",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Descricao = c.String(nullable := False),
                        .CategoriaId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Categorias", Function(t) t.CategoriaId, cascadeDelete := True) _
                .Index(Function(t) t.CategoriaId)
            
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
            
            CreateTable(
                "dbo.AvaliacaoProcesso",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .AvaliacaoId = c.Int(nullable := False),
                        .ProcessoId = c.Int(nullable := False),
                        .NivelCapacidade = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Avaliacao", Function(t) t.AvaliacaoId, cascadeDelete := True) _
                .ForeignKey("dbo.Processo", Function(t) t.ProcessoId, cascadeDelete := True) _
                .Index(Function(t) t.AvaliacaoId) _
                .Index(Function(t) t.ProcessoId)
            
            CreateTable(
                "dbo.AvaliacaoProcessoPa",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .AvaliacaoProcessoId = c.Int(nullable := False),
                        .PaId = c.Int(nullable := False),
                        .Pontuacao = c.String(),
                        .Observacao = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AvaliacaoProcesso", Function(t) t.AvaliacaoProcessoId, cascadeDelete := True) _
                .ForeignKey("dbo.pa", Function(t) t.PaId, cascadeDelete := True) _
                .Index(Function(t) t.AvaliacaoProcessoId) _
                .Index(Function(t) t.PaId)
            
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
                "dbo.Usuarios",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Email = c.String(),
                        .Senha = c.String(),
                        .SenhaSalt = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.Testes",
                Function(c) New With
                    {
                        .id = c.Int(nullable := False, identity := True),
                        .descricao = c.String()
                    }) _
                .PrimaryKey(Function(t) t.id)
            
            CreateTable(
                "dbo.Pontuacaos",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Valor = c.String(),
                        .Nome = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.AvaliacaoProcessoPa", New String() { "PaId" })
            DropIndex("dbo.AvaliacaoProcessoPa", New String() { "AvaliacaoProcessoId" })
            DropIndex("dbo.AvaliacaoProcesso", New String() { "ProcessoId" })
            DropIndex("dbo.AvaliacaoProcesso", New String() { "AvaliacaoId" })
            DropIndex("dbo.Processo", New String() { "SubCategoriaId" })
            DropIndex("dbo.Subcategoria", New String() { "CategoriaId" })
            DropIndex("dbo.AvaliacaoAvaliador", New String() { "AvaliacaoId" })
            DropIndex("dbo.AvaliacaoAvaliador", New String() { "TipoAvaliadorId" })
            DropIndex("dbo.AvaliacaoAvaliador", New String() { "AvaliadorId" })
            DropIndex("dbo.Avaliacao", New String() { "EmpresaId" })
            DropForeignKey("dbo.AvaliacaoProcessoPa", "PaId", "dbo.pa")
            DropForeignKey("dbo.AvaliacaoProcessoPa", "AvaliacaoProcessoId", "dbo.AvaliacaoProcesso")
            DropForeignKey("dbo.AvaliacaoProcesso", "ProcessoId", "dbo.Processo")
            DropForeignKey("dbo.AvaliacaoProcesso", "AvaliacaoId", "dbo.Avaliacao")
            DropForeignKey("dbo.Processo", "SubCategoriaId", "dbo.Subcategoria")
            DropForeignKey("dbo.Subcategoria", "CategoriaId", "dbo.Categorias")
            DropForeignKey("dbo.AvaliacaoAvaliador", "AvaliacaoId", "dbo.Avaliacao")
            DropForeignKey("dbo.AvaliacaoAvaliador", "TipoAvaliadorId", "dbo.TipoAvaliador")
            DropForeignKey("dbo.AvaliacaoAvaliador", "AvaliadorId", "dbo.Avaliador")
            DropForeignKey("dbo.Avaliacao", "EmpresaId", "dbo.Empresas")
            DropTable("dbo.Pontuacaos")
            DropTable("dbo.Testes")
            DropTable("dbo.Usuarios")
            DropTable("dbo.pa")
            DropTable("dbo.AvaliacaoProcessoPa")
            DropTable("dbo.AvaliacaoProcesso")
            DropTable("dbo.Processo")
            DropTable("dbo.Subcategoria")
            DropTable("dbo.Categorias")
            DropTable("dbo.TipoAvaliador")
            DropTable("dbo.Avaliador")
            DropTable("dbo.AvaliacaoAvaliador")
            DropTable("dbo.Avaliacao")
            DropTable("dbo.Empresas")
        End Sub
    End Class
End Namespace
