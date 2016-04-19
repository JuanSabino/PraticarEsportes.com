namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class local43 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Local");
        }
    }
}
