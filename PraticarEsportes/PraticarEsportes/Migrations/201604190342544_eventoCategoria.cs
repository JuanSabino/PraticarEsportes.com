namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventoCategoria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evento", "CategoriaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Evento", "CategoriaID");
            AddForeignKey("dbo.Evento", "CategoriaID", "dbo.Categoria", "CategoriaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Evento", new[] { "CategoriaID" });
            DropColumn("dbo.Evento", "CategoriaID");
        }
    }
}
