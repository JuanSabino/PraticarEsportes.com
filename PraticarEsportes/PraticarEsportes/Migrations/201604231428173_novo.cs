namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checkin", "EventoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pessoa", "Senha", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Pessoa", "NomeFantasia", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.Pessoa", "RazaoSocial", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.Pessoa", "CNPJ", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Pessoa", "Nome", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.Pessoa", "CPF", c => c.String(maxLength: 11, storeType: "nvarchar"));
            CreateIndex("dbo.Checkin", "EventoId");
            AddForeignKey("dbo.Checkin", "EventoId", "dbo.Evento", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checkin", "EventoId", "dbo.Evento");
            DropIndex("dbo.Checkin", new[] { "EventoId" });
            AlterColumn("dbo.Pessoa", "CPF", c => c.String(unicode: false));
            AlterColumn("dbo.Pessoa", "Nome", c => c.String(unicode: false));
            AlterColumn("dbo.Pessoa", "CNPJ", c => c.String(unicode: false));
            AlterColumn("dbo.Pessoa", "RazaoSocial", c => c.String(unicode: false));
            AlterColumn("dbo.Pessoa", "NomeFantasia", c => c.String(unicode: false));
            AlterColumn("dbo.Pessoa", "Senha", c => c.String(unicode: false));
            DropColumn("dbo.Checkin", "EventoId");
        }
    }
}
