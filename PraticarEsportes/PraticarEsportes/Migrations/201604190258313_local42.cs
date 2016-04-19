namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class local42 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Local", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Local");
            DropColumn("dbo.Local", "IDTeste");
            AddPrimaryKey("dbo.Local", "ID");
        }
    }
}
