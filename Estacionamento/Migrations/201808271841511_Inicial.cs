namespace Estacionamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                        ModeloVeiculoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModeloVeiculo", t => t.ModeloVeiculoId, cascadeDelete: true)
                .Index(t => t.Cpf, unique: true)
                .Index(t => t.ModeloVeiculoId);
            
            CreateTable(
                "dbo.ModeloVeiculo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(nullable: false, maxLength: 60, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                        TipoVeiculoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoVeiculo", t => t.TipoVeiculoId, cascadeDelete: true)
                .Index(t => t.TipoVeiculoId);
            
            CreateTable(
                "dbo.TipoVeiculo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TabelaPreco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                        ValorHora = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoVeiculoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoVeiculo", t => t.TipoVeiculoId, cascadeDelete: true)
                .Index(t => t.TipoVeiculoId);
            
            CreateTable(
                "dbo.Setor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                        Sigla = c.String(nullable: false, maxLength: 2, unicode: false),
                        Situacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Sigla, unique: true);
            
            CreateTable(
                "dbo.Vaga",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Situacao = c.Int(nullable: false),
                        SetorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Setor", t => t.SetorId, cascadeDelete: true)
                .Index(t => t.SetorId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                        Login = c.String(nullable: false, maxLength: 30, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Cpf, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaga", "SetorId", "dbo.Setor");
            DropForeignKey("dbo.TabelaPreco", "TipoVeiculoId", "dbo.TipoVeiculo");
            DropForeignKey("dbo.ModeloVeiculo", "TipoVeiculoId", "dbo.TipoVeiculo");
            DropForeignKey("dbo.Cliente", "ModeloVeiculoId", "dbo.ModeloVeiculo");
            DropIndex("dbo.Usuario", new[] { "Cpf" });
            DropIndex("dbo.Vaga", new[] { "SetorId" });
            DropIndex("dbo.Setor", new[] { "Sigla" });
            DropIndex("dbo.TabelaPreco", new[] { "TipoVeiculoId" });
            DropIndex("dbo.ModeloVeiculo", new[] { "TipoVeiculoId" });
            DropIndex("dbo.Cliente", new[] { "ModeloVeiculoId" });
            DropIndex("dbo.Cliente", new[] { "Cpf" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Vaga");
            DropTable("dbo.Setor");
            DropTable("dbo.TabelaPreco");
            DropTable("dbo.TipoVeiculo");
            DropTable("dbo.ModeloVeiculo");
            DropTable("dbo.Cliente");
        }
    }
}
