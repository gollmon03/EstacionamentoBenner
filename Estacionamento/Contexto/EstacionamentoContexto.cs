using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Estacionamento.Models;

namespace Estacionamento.Contexto
{
    public class EstacionamentoContexto : DbContext
    {
        public EstacionamentoContexto() : base ("EstacionamentoDB")
        {
                
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ModeloVeiculo> ModeloVeiculos { get; set; }
        public DbSet<TabelaPreco> TabelaPrecos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            
        }



    }
}