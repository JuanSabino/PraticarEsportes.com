namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cupomEvento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cupom", "EventoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Cupom", "EventoID");
            AddForeignKey("dbo.Cupom", "EventoID", "dbo.Evento", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cupom", "EventoID", "dbo.Evento");
            DropIndex("dbo.Cupom", new[] { "EventoID" });
            DropColumn("dbo.Cupom", "EventoID");
        }
    }
}
