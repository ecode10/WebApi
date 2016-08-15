using Aluno.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Aluno.DAL
{
    public class iAlunoConext : DbContext
    {

        public DbSet<Disciplina> Disciplina { get; set; }

        public iAlunoConext() : base("name=iAlunoContext")
        {
            Database.SetInitializer<iAlunoConext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
    
}