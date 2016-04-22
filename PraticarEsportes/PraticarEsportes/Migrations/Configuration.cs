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
            //IList<Categoria> categorias = new List<Categoria>();
            //categorias.Add(new Categoria() { Nome = "Caminhada" });
            //categorias.Add(new Categoria() { Nome = "Corrida" });
            //categorias.Add(new Categoria() { Nome = "Academia" });
            //categorias.Add(new Categoria() { Nome = "Futebol" });
            //categorias.Add(new Categoria() { Nome = "Volei" });
            //categorias.Add(new Categoria() { Nome = "Natação" });
            //categorias.Add(new Categoria() { Nome = "Ciclismo" });
            //categorias.Add(new Categoria() { Nome = "Slackline" });

            //foreach (Categoria categoria in categorias)
            //{
            //    context.Categoria.AddOrUpdate(x => x.CategoriaID, categoria);
            //}

            //IList<Local> locais = new List<Local>();
            //locais.Add(new Local() { Nome = "Clube Literário", Descricao = "Teste", Latitude = -22.670000076293945, Longitude = -45.0099983215332, Habilitado = true });
            //locais.Add(new Local() { Nome = "Estádio Municipal", Descricao = "Teste", Latitude = -22.662254511777707, Longitude = -45.013641715049744, Habilitado = true });
            //locais.Add(new Local() { Nome = "Cachoeira Futebol Clube", Descricao = "Teste", Latitude = -22.666729458183095, Longitude = -45.009371638298035, Habilitado = true });
            //locais.Add(new Local() { Nome = "Parque Ecológico", Descricao = "Teste", Latitude = -22.66237331755043, Longitude = -45.01147717237472, Habilitado = true });
            //locais.Add(new Local() { Nome = "Praça Avenida Antônio Marota", Descricao = "Teste", Latitude = -22.672758524628314, Longitude = -45.00627905130386, Habilitado = true });

            //foreach (Local local in locais)
            //{
            //    context.Local.AddOrUpdate(x => x.ID, local);
            //}

            IList<Evento> eventos = new List<Evento>();
            eventos.Add(new Evento() { Nome = "Futeba da Galera", Descricao = "Teste", DataInicio = Convert.ToDateTime("2016-04-18 00:00:00"), DataTermino = Convert.ToDateTime("2016-04-18 00:00:00"), Capacidade = "20", Dificuldade = 1, LocalID = 2, CategoriaID = 16 });
            eventos.Add(new Evento() { Nome = "Teste2", Descricao = "Teste", DataInicio = Convert.ToDateTime("2016-04-19 00:00:00"), DataTermino = Convert.ToDateTime("2016-04-19 00:00:00"), Capacidade = "15", Dificuldade = 2, LocalID = 2, CategoriaID = 16 });

            foreach (Evento evento in eventos)
            {
                context.Evento.AddOrUpdate(x => x.ID, evento);
            }

        }

    }
}
