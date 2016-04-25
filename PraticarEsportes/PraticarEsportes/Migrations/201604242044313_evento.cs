namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class evento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evento", "Habilitado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evento", "Habilitado");
        }
    }
}
