namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cupomEvento2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cupom", "Tipo", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cupom", "Tipo", c => c.String(unicode: false));
        }
    }
}
