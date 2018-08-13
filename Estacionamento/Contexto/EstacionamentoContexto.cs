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