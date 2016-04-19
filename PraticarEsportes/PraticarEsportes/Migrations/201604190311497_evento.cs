namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class evento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Descricao = c.String(unicode: false),
                        DataInicio = c.DateTime(nullable: false, precision: 0),
                        DataTermino = c.DateTime(nullable: false, precision: 0),
                        Capacidade = c.String(nullable: false, unicode: false),
                        Dificuldade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Evento");
        }
    }
}
