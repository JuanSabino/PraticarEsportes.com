namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Descricao = c.String(unicode: false),
                        DataInicio = c.DateTime(nullable: false, precision: 0),
                        DataTermino = c.DateTime(nullable: false, precision: 0),
                        Capacidade = c.String(nullable: false, unicode: false),
                        Dificuldade = c.Int(nullable: false),
                        LocalID = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        Habilitado = c.Boolean(nullable: false),
                        Pessoa_PessoaId = c.Int(),
                        Pessoa_PessoaId1 = c.Int(),
                        Pessoa_PessoaId2 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_PessoaId)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_PessoaId1)
                .ForeignKey("dbo.Local", t => t.LocalID, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_PessoaId2)
                .Index(t => t.LocalID)
                .Index(t => t.CategoriaID)
                .Index(t => t.Pessoa_PessoaId)
                .Index(t => t.Pessoa_PessoaId1)
                .Index(t => t.Pessoa_PessoaId2);
            
            CreateTable(
                "dbo.Checkin",
                c => new
                    {
                        CheckinId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        PessoaId = c.Int(nullable: false),
                        EventoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CheckinId)
                .ForeignKey("dbo.Evento", t => t.EventoId, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId)
                .Index(t => t.EventoId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Telefone = c.String(unicode: false),
                        Endereco = c.String(unicode: false),
                        CEP = c.String(unicode: false),
                        Cidade = c.String(unicode: false),
                        Estado = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                        ConfirmarSenha = c.String(unicode: false),
                        Habilitado = c.Boolean(nullable: false),
                        NomeFantasia = c.String(unicode: false),
                        RazaoSocial = c.String(unicode: false),
                        CNPJ = c.String(unicode: false),
                        TelComercial = c.String(unicode: false),
                        DataAbertura = c.DateTime(precision: 0),
                        Nome = c.String(unicode: false),
                        CPF = c.String(unicode: false),
                        DataNascimento = c.DateTime(precision: 0),
                        Profissao = c.String(unicode: false),
                        EstadoCivil = c.String(unicode: false),
                        Pontos = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Pessoa_PessoaId = c.Int(),
                        Evento_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_PessoaId)
                .ForeignKey("dbo.Evento", t => t.Evento_ID)
                .Index(t => t.Pessoa_PessoaId)
                .Index(t => t.Evento_ID);
            
            CreateTable(
                "dbo.Historico",
                c => new
                    {
                        HistoricoId = c.Int(nullable: false, identity: true),
                        Horario = c.DateTime(nullable: false, precision: 0),
                        Descricao = c.String(unicode: false),
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HistoricoId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Local",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Descricao = c.String(unicode: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Endereco = c.String(unicode: false),
                        CEP = c.String(unicode: false),
                        Cidade = c.String(unicode: false),
                        Estado = c.String(unicode: false),
                        Habilitado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cupom",
                c => new
                    {
                        CupomId = c.Int(nullable: false, identity: true),
                        Valor = c.Double(nullable: false),
                        Tipo = c.String(nullable: false, unicode: false),
                        Quantidade = c.Int(nullable: false),
                        Validade = c.DateTime(nullable: false, precision: 0),
                        EventoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CupomId)
                .ForeignKey("dbo.Evento", t => t.EventoID, cascadeDelete: true)
                .Index(t => t.EventoID);
            
            CreateTable(
                "dbo.Newsletter",
                c => new
                    {
                        NewsletterId = c.Int(nullable: false, identity: true),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.NewsletterId);
            
            CreateTable(
                "dbo.PessoaEvento",
                c => new
                    {
                        PessoaRefId = c.Int(nullable: false),
                        EventoRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PessoaRefId, t.EventoRefId })
                .ForeignKey("dbo.Pessoa", t => t.PessoaRefId, cascadeDelete: true)
                .ForeignKey("dbo.Evento", t => t.EventoRefId, cascadeDelete: true)
                .Index(t => t.PessoaRefId)
                .Index(t => t.EventoRefId);
            
            CreateTable(
                "dbo.LocalPessoa",
                c => new
                    {
                        Local_ID = c.Int(nullable: false),
                        Pessoa_PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Local_ID, t.Pessoa_PessoaId })
                .ForeignKey("dbo.Local", t => t.Local_ID, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_PessoaId, cascadeDelete: true)
                .Index(t => t.Local_ID)
                .Index(t => t.Pessoa_PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "Pessoa_PessoaId2", "dbo.Pessoa");
            DropForeignKey("dbo.Pessoa", "Evento_ID", "dbo.Evento");
            DropForeignKey("dbo.Cupom", "EventoID", "dbo.Evento");
            DropForeignKey("dbo.Pessoa", "Pessoa_PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Evento", "LocalID", "dbo.Local");
            DropForeignKey("dbo.LocalPessoa", "Pessoa_PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.LocalPessoa", "Local_ID", "dbo.Local");
            DropForeignKey("dbo.Historico", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Evento", "Pessoa_PessoaId1", "dbo.Pessoa");
            DropForeignKey("dbo.PessoaEvento", "EventoRefId", "dbo.Evento");
            DropForeignKey("dbo.PessoaEvento", "PessoaRefId", "dbo.Pessoa");
            DropForeignKey("dbo.Evento", "Pessoa_PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Checkin", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Checkin", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Evento", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.LocalPessoa", new[] { "Pessoa_PessoaId" });
            DropIndex("dbo.LocalPessoa", new[] { "Local_ID" });
            DropIndex("dbo.PessoaEvento", new[] { "EventoRefId" });
            DropIndex("dbo.PessoaEvento", new[] { "PessoaRefId" });
            DropIndex("dbo.Cupom", new[] { "EventoID" });
            DropIndex("dbo.Historico", new[] { "PessoaId" });
            DropIndex("dbo.Pessoa", new[] { "Evento_ID" });
            DropIndex("dbo.Pessoa", new[] { "Pessoa_PessoaId" });
            DropIndex("dbo.Checkin", new[] { "EventoId" });
            DropIndex("dbo.Checkin", new[] { "PessoaId" });
            DropIndex("dbo.Evento", new[] { "Pessoa_PessoaId2" });
            DropIndex("dbo.Evento", new[] { "Pessoa_PessoaId1" });
            DropIndex("dbo.Evento", new[] { "Pessoa_PessoaId" });
            DropIndex("dbo.Evento", new[] { "CategoriaID" });
            DropIndex("dbo.Evento", new[] { "LocalID" });
            DropTable("dbo.LocalPessoa");
            DropTable("dbo.PessoaEvento");
            DropTable("dbo.Newsletter");
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
