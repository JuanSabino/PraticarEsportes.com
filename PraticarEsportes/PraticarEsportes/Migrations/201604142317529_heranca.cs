namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heranca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoa", "NomeFantasia", c => c.String(unicode: false));
            AddColumn("dbo.Pessoa", "RazaoSocial", c => c.String(unicode: false));
            AddColumn("dbo.Pessoa", "CNPJ", c => c.String(unicode: false));
            AddColumn("dbo.Pessoa", "TelComercial", c => c.String(unicode: false));
            AddColumn("dbo.Pessoa", "DataAbertura", c => c.DateTime(precision: 0));
            AddColumn("dbo.Pessoa", "Nome", c => c.String(unicode: false));
            AddColumn("dbo.Pessoa", "CPF", c => c.String(unicode: false));
            AddColumn("dbo.Pessoa", "DataNascimento", c => c.DateTime(precision: 0));
            AddColumn("dbo.Pessoa", "Profissao", c => c.String(unicode: false));
            AddColumn("dbo.Pessoa", "EstadoCivil", c => c.String(unicode: false));
            AddColumn("dbo.Pessoa", "Pontos", c => c.Int());
            AddColumn("dbo.Pessoa", "Discriminator", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pessoa", "Discriminator");
            DropColumn("dbo.Pessoa", "Pontos");
            DropColumn("dbo.Pessoa", "EstadoCivil");
            DropColumn("dbo.Pessoa", "Profissao");
            DropColumn("dbo.Pessoa", "DataNascimento");
            DropColumn("dbo.Pessoa", "CPF");
            DropColumn("dbo.Pessoa", "Nome");
            DropColumn("dbo.Pessoa", "DataAbertura");
            DropColumn("dbo.Pessoa", "TelComercial");
            DropColumn("dbo.Pessoa", "CNPJ");
            DropColumn("dbo.Pessoa", "RazaoSocial");
            DropColumn("dbo.Pessoa", "NomeFantasia");
        }
    }
}
