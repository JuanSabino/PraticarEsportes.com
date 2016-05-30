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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_PessoaId)
                .ForeignKey("dbo.Local", t => t.LocalID, cascadeDelete: true)
                .Index(t => t.LocalID)
                .Index(t => t.CategoriaID)
                .Index(t => t.Pessoa_PessoaId);
            
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
                    })
                .PrimaryKey(t => t.PessoaId);
            
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
                        Tipo = c.String(unicode: false),
                        Quantidade = c.Int(nullable: false),
                        Validade = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.CupomId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "LocalID", "dbo.Local");
            DropForeignKey("dbo.Historico", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.PessoaEvento", "EventoRefId", "dbo.Evento");
            DropForeignKey("dbo.PessoaEvento", "PessoaRefId", "dbo.Pessoa");
            DropForeignKey("dbo.Evento", "Pessoa_PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Checkin", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Checkin", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Evento", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.PessoaEvento", new[] { "EventoRefId" });
            DropIndex("dbo.PessoaEvento", new[] { "PessoaRefId" });
            DropIndex("dbo.Historico", new[] { "PessoaId" });
            DropIndex("dbo.Checkin", new[] { "EventoId" });
            DropIndex("dbo.Checkin", new[] { "PessoaId" });
            DropIndex("dbo.Evento", new[] { "Pessoa_PessoaId" });
            DropIndex("dbo.Evento", new[] { "CategoriaID" });
            DropIndex("dbo.Evento", new[] { "LocalID" });
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
