namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class local2 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Local", "Estado", c => c.String(unicode: false));
            AddColumn("dbo.Local", "Cidade", c => c.String(unicode: false));
            AddColumn("dbo.Local", "CEP", c => c.String(unicode: false));
            AddColumn("dbo.Local", "Endereco", c => c.String(unicode: false));
            AddColumn("dbo.Local", "CidadeId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Local");
            AlterColumn("dbo.Local", "Nome", c => c.String(unicode: false));
            DropColumn("dbo.Local", "ID");
            AddPrimaryKey("dbo.Local", "CidadeId");
        }
    }
}
