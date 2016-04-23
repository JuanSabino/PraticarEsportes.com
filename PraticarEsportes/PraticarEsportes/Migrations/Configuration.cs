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
            IList<Categoria> categorias = new List<Categoria>();
            categorias.Add(new Categoria() { Nome = "Caminhada" });
            categorias.Add(new Categoria() { Nome = "Corrida" });
            categorias.Add(new Categoria() { Nome = "Academia" });
            categorias.Add(new Categoria() { Nome = "Futebol" });
            categorias.Add(new Categoria() { Nome = "Volei" });
            categorias.Add(new Categoria() { Nome = "Natação" });
            categorias.Add(new Categoria() { Nome = "Ciclismo" });
            categorias.Add(new Categoria() { Nome = "Slackline" });

            foreach (Categoria categoria in categorias)
            {
                context.Categoria.AddOrUpdate(x => x.CategoriaID, categoria);
            }

            IList<Local> locais = new List<Local>();
            locais.Add(new Local() { Nome = "Clube Literário", Descricao = "Teste", Latitude = -22.670000076293945, Longitude = -45.0099983215332, Habilitado = true });
            locais.Add(new Local() { Nome = "Estádio Municipal", Descricao = "Teste", Latitude = -22.662254511777707, Longitude = -45.013641715049744, Habilitado = true });
            locais.Add(new Local() { Nome = "Cachoeira Futebol Clube", Descricao = "Teste", Latitude = -22.666729458183095, Longitude = -45.009371638298035, Habilitado = true });
            locais.Add(new Local() { Nome = "Parque Ecológico", Descricao = "Teste", Latitude = -22.66237331755043, Longitude = -45.01147717237472, Habilitado = true });
            locais.Add(new Local() { Nome = "Praça Avenida Antônio Marota", Descricao = "Teste", Latitude = -22.672758524628314, Longitude = -45.00627905130386, Habilitado = true });

            foreach (Local local in locais)
            {
                context.Local.AddOrUpdate(x => x.ID, local);
            }


            IList<Estabelecimento> estabelecimentos = new List<Estabelecimento>();
            estabelecimentos.Add(new Estabelecimento() { CEP = "12000-000", Cidade = "Guaratingueta", CNPJ = "448728787857", DataAbertura = DateTime.Now, Email = "teste1@teste.com", Endereco = "blablabla", Estado = "SP", Habilitado = true, NomeFantasia = "Teste 1", RazaoSocial = "Teste 1", Senha = "123", TelComercial = "254545", Telefone = "4545545" });
            estabelecimentos.Add(new Estabelecimento() { CEP = "12000-000", Cidade = "Guaratingueta", CNPJ = "448728787858", DataAbertura = DateTime.Now, Email = "teste2@teste.com", Endereco = "blablabla", Estado = "SP", Habilitado = true, NomeFantasia = "Teste 2", RazaoSocial = "Teste 2", Senha = "123", TelComercial = "254545", Telefone = "4545545" });

            foreach (Estabelecimento estabelecimento in estabelecimentos)
            {
                context.Pessoas.AddOrUpdate(x => x.PessoaId, estabelecimento);
            }


            IList<Praticante> praticantes = new List<Praticante>();
            praticantes.Add( new Praticante() { Estado="SP", Endereco="ksdkasljd", Email="teste3@teste.com", DataNascimento= DateTime.Now, CPF="78914789875", CEP="", Cidade="12000000", EstadoCivil="Solteiro",Habilitado=true, Nome="Teste 3", Pontos=0, Profissao="Programeiro", Senha="123", Telefone="454845"  } );
            praticantes.Add(new Praticante() { Estado = "SP", Endereco = "ksdkasljd", Email = "teste4@teste.com", DataNascimento = DateTime.Now, CPF = "78914789876", CEP = "", Cidade = "12000000", EstadoCivil = "Solteiro", Habilitado = true, Nome = "Teste 4", Pontos = 0, Profissao = "Programeiro", Senha = "123", Telefone = "454845" });

            foreach (Praticante praticante in praticantes)
            {
                context.Pessoas.AddOrUpdate(x => x.PessoaId, praticante);
            }

            //IList<Evento> eventos = new List<Evento>();
            //eventos.Add(new Evento() { Nome = "Futeba da Galera", Descricao = "Teste", DataInicio = Convert.ToDateTime("2016-04-18 00:00:00"), DataTermino = Convert.ToDateTime("2016-04-18 00:00:00"), Capacidade = "20", Dificuldade = 1, LocalID = 2, CategoriaID = 17 });
            //eventos.Add(new Evento() { Nome = "Teste2", Descricao = "Teste", DataInicio = Convert.ToDateTime("2016-04-19 00:00:00"), DataTermino = Convert.ToDateTime("2016-04-19 00:00:00"), Capacidade = "15", Dificuldade = 2, LocalID = 2, CategoriaID = 17 });

            //foreach (Evento evento in eventos)
            //{
            //    context.Evento.AddOrUpdate(x => x.ID, evento);
            //}

        }

    }
}
