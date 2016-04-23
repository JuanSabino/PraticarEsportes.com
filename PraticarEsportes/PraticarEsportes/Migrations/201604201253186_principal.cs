namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class principal : DbMigration
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Local", t => t.LocalID, cascadeDelete: true)
                .Index(t => t.LocalID)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Local",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Descricao = c.String(unicode: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Habilitado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Checkin",
                c => new
                    {
                        CheckinId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CheckinId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checkin", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Evento", "LocalID", "dbo.Local");
            DropForeignKey("dbo.Evento", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Checkin", new[] { "PessoaId" });
            DropIndex("dbo.Evento", new[] { "CategoriaID" });
            DropIndex("dbo.Evento", new[] { "LocalID" });
            DropTable("dbo.Cupom");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Checkin");
            DropTable("dbo.Local");
            DropTable("dbo.Evento");
            DropTable("dbo.Categoria");
        }
    }
}
