namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class evento2 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "LocalID", "dbo.Local");
            DropForeignKey("dbo.Evento", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Evento", new[] { "CategoriaID" });
            DropIndex("dbo.Evento", new[] { "LocalID" });
            DropTable("dbo.Evento");
        }
    }
}
