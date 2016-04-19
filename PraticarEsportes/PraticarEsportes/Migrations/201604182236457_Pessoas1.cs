namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pessoas1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoa", "Email", c => c.String(unicode: false));
            AddColumn("dbo.Pessoa", "Senha", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pessoa", "Senha");
            DropColumn("dbo.Pessoa", "Email");
        }
    }
}
