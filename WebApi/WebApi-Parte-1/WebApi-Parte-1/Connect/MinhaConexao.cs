using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApi_Parte_1.Models;

namespace WebApi_Parte_1.Connect
{
    public class MinhaConexao : DbContext
    {
        public MinhaConexao()
            : base("name=MinhaConexao")
        {
            Database.SetInitializer<MinhaConexao>(null);
        }

        public DbSet<Disciplinas> Disciplinas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        
    }
}