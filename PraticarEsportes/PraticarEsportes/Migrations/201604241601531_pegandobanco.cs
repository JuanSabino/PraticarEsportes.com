namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pegandobanco : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Categoria",
            //    c => new
            //        {
            //            CategoriaID = c.Int(nullable: false, identity: true),
            //            Nome = c.String(nullable: false, unicode: false),
            //        })
            //    .PrimaryKey(t => t.CategoriaID);
            
            //CreateTable(
            //    "dbo.Evento",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Nome = c.String(nullable: false, unicode: false),
            //            Descricao = c.String(unicode: false),
            //            DataInicio = c.DateTime(nullable: false, precision: 0),
            //            DataTermino = c.DateTime(nullable: false, precision: 0),
            //            Capacidade = c.String(nullable: false, unicode: false),
            //            Dificuldade = c.Int(nullable: false),
            //            LocalID = c.Int(nullable: false),
            //            CategoriaID = c.Int(nullable: false),
            //            PessoaId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
            //    .ForeignKey("dbo.Local", t => t.LocalID, cascadeDelete: true)
            //    .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
            //    .Index(t => t.LocalID)
            //    .Index(t => t.CategoriaID)
            //    .Index(t => t.PessoaId);
            
            //CreateTable(
            //    "dbo.Checkin",
            //    c => new
            //        {
            //            CheckinId = c.Int(nullable: false, identity: true),
            //            Data = c.DateTime(nullable: false, precision: 0),
            //            PessoaId = c.Int(nullable: false),
            //            EventoId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CheckinId)
            //    .ForeignKey("dbo.Evento", t => t.EventoId, cascadeDelete: true)
            //    .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
            //    .Index(t => t.PessoaId)
            //    .Index(t => t.EventoId);
            
            //CreateTable(
            //    "dbo.Pessoa",
            //    c => new
            //        {
            //            PessoaId = c.Int(nullable: false, identity: true),
            //            Telefone = c.String(unicode: false),
            //            Endereco = c.String(unicode: false),
            //            CEP = c.String(unicode: false),
            //            Cidade = c.String(unicode: false),
            //            Estado = c.String(unicode: false),
            //            Email = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
            //            Senha = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
            //            Habilitado = c.Boolean(nullable: false),
            //            NomeFantasia = c.String(maxLength: 255, storeType: "nvarchar"),
            //            RazaoSocial = c.String(maxLength: 255, storeType: "nvarchar"),
            //            CNPJ = c.String(maxLength: 50, storeType: "nvarchar"),
            //            TelComercial = c.String(unicode: false),
            //            DataAbertura = c.DateTime(precision: 0),
            //            Nome = c.String(maxLength: 255, storeType: "nvarchar"),
            //            CPF = c.String(maxLength: 11, storeType: "nvarchar"),
            //            DataNascimento = c.DateTime(precision: 0),
            //            Profissao = c.String(unicode: false),
            //            EstadoCivil = c.String(unicode: false),
            //            Pontos = c.Int(),
            //            Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
            //        })
            //    .PrimaryKey(t => t.PessoaId);
            
            //CreateTable(
            //    "dbo.Historico",
            //    c => new
            //        {
            //            HistoricoId = c.Int(nullable: false, identity: true),
            //            Horario = c.DateTime(nullable: false, precision: 0),
            //            Descricao = c.String(unicode: false),
            //            PessoaId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.HistoricoId)
            //    .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
            //    .Index(t => t.PessoaId);
            
            //CreateTable(
            //    "dbo.Local",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Nome = c.String(nullable: false, unicode: false),
            //            Descricao = c.String(unicode: false),
            //            Latitude = c.Double(nullable: false),
            //            Longitude = c.Double(nullable: false),
            //            Habilitado = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.Cupom",
            //    c => new
            //        {
            //            CupomId = c.Int(nullable: false, identity: true),
            //            Valor = c.Double(nullable: false),
            //            Tipo = c.String(unicode: false),
            //            Quantidade = c.Int(nullable: false),
            //            Validade = c.DateTime(nullable: false, precision: 0),
            //        })
            //    .PrimaryKey(t => t.CupomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Evento", "LocalID", "dbo.Local");
            DropForeignKey("dbo.Historico", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Checkin", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Checkin", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Evento", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Historico", new[] { "PessoaId" });
            DropIndex("dbo.Checkin", new[] { "EventoId" });
            DropIndex("dbo.Checkin", new[] { "PessoaId" });
            DropIndex("dbo.Evento", new[] { "PessoaId" });
            DropIndex("dbo.Evento", new[] { "CategoriaID" });
            DropIndex("dbo.Evento", new[] { "LocalID" });
            DropTable("dbo.Cupom");
            DropTable("dbo.Local");
            DropTable("dbo.Historico");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Checkin");
            DropTable("dbo.Evento");
            DropTable("dbo.Categoria");
        }
    }
}
