namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventoLocal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evento", "LocalID", c => c.Int(nullable: false));
            CreateIndex("dbo.Evento", "LocalID");
            AddForeignKey("dbo.Evento", "LocalID", "dbo.Local", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "LocalID", "dbo.Local");
            DropIndex("dbo.Evento", new[] { "LocalID" });
            DropColumn("dbo.Evento", "LocalID");
        }
    }
}
