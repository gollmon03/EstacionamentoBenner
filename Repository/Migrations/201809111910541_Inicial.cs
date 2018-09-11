namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentoFinanceiro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataVencimento = c.DateTime(nullable: false),
                        DataProcessamento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                        Tipo = c.Int(nullable: false),
                        Cpf = c.String(maxLength: 11, unicode: false),
                        Cnpj = c.String(maxLength: 14, unicode: false),
                        TipoVeiculo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoVeiculo", t => t.TipoVeiculo_Id)
                .Index(t => t.TipoVeiculo_Id);
            
            CreateTable(
                "dbo.Mensalista",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlacaVeiculo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ValorMensal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PessoaId = c.Int(nullable: false),
                        ModeloVeiculoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModeloVeiculo", t => t.ModeloVeiculoId, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId)
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
                "dbo.MovimentacaoVeiculo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataHoraEntrada = c.DateTime(nullable: false),
                        DataHoraSaida = c.DateTime(),
                        PlacaVeiculo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UsuarioId = c.Int(nullable: false),
                        ModeloVeiculoId = c.Int(nullable: false),
                        MensalistaId = c.Int(),
                        VagaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mensalista", t => t.MensalistaId)
                .ForeignKey("dbo.ModeloVeiculo", t => t.ModeloVeiculoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Vaga", t => t.VagaId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.ModeloVeiculoId)
                .Index(t => t.MensalistaId)
                .Index(t => t.VagaId);
            
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
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Setor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                        Sigla = c.String(nullable: false, maxLength: 2, unicode: false),
                        Situacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentoFinanceiro", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Mensalista", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.TabelaPreco", "TipoVeiculoId", "dbo.TipoVeiculo");
            DropForeignKey("dbo.Pessoa", "TipoVeiculo_Id", "dbo.TipoVeiculo");
            DropForeignKey("dbo.ModeloVeiculo", "TipoVeiculoId", "dbo.TipoVeiculo");
            DropForeignKey("dbo.Vaga", "SetorId", "dbo.Setor");
            DropForeignKey("dbo.MovimentacaoVeiculo", "VagaId", "dbo.Vaga");
            DropForeignKey("dbo.MovimentacaoVeiculo", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.MovimentacaoVeiculo", "ModeloVeiculoId", "dbo.ModeloVeiculo");
            DropForeignKey("dbo.MovimentacaoVeiculo", "MensalistaId", "dbo.Mensalista");
            DropForeignKey("dbo.Mensalista", "ModeloVeiculoId", "dbo.ModeloVeiculo");
            DropIndex("dbo.TabelaPreco", new[] { "TipoVeiculoId" });
            DropIndex("dbo.Vaga", new[] { "SetorId" });
            DropIndex("dbo.MovimentacaoVeiculo", new[] { "VagaId" });
            DropIndex("dbo.MovimentacaoVeiculo", new[] { "MensalistaId" });
            DropIndex("dbo.MovimentacaoVeiculo", new[] { "ModeloVeiculoId" });
            DropIndex("dbo.MovimentacaoVeiculo", new[] { "UsuarioId" });
            DropIndex("dbo.ModeloVeiculo", new[] { "TipoVeiculoId" });
            DropIndex("dbo.Mensalista", new[] { "ModeloVeiculoId" });
            DropIndex("dbo.Mensalista", new[] { "PessoaId" });
            DropIndex("dbo.Pessoa", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.DocumentoFinanceiro", new[] { "PessoaId" });
            DropTable("dbo.TabelaPreco");
            DropTable("dbo.TipoVeiculo");
            DropTable("dbo.Setor");
            DropTable("dbo.Vaga");
            DropTable("dbo.Usuario");
            DropTable("dbo.MovimentacaoVeiculo");
            DropTable("dbo.ModeloVeiculo");
            DropTable("dbo.Mensalista");
            DropTable("dbo.Pessoa");
            DropTable("dbo.DocumentoFinanceiro");
        }
    }
}
