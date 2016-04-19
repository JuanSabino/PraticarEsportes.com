namespace PraticarEsportes.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PraticarEsportes.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PraticarEsportes.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PraticarEsportes.Models.Context context)
        {
            //IList<Evento> eventos = new List<Evento>();
            //eventos.Add(new Evento() { Nome = "Espírito Santo"});
        }
    }
}
