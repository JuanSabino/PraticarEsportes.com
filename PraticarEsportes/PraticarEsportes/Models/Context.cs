using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
namespace PraticarEsportes.Models
{
    public class Context : DbContext
    {
        public Context() : base("PraticarEsportes")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cupom> Cupons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
