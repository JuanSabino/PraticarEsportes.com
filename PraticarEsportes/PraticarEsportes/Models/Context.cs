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

        public DbSet<Local> Locais { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Checkin> Checkins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<PraticarEsportes.Models.Cupom> Cupoms { get; set; }
    }
}
