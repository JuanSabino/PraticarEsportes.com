namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Local : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Local",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Descricao = c.String(unicode: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Endereco = c.String(unicode: false),
                        CEP = c.String(unicode: false),
                        Cidade = c.String(unicode: false),
                        Estado = c.String(unicode: false),
                        Habilitado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Local");
        }
    }
}
