namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Checkin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checkin",
                c => new
                    {
                        CheckinId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CheckinId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Cupom",
                c => new
                    {
                        CupomId = c.Int(nullable: false, identity: true),
                        Valor = c.Double(nullable: false),
                        Tipo = c.String(unicode: false),
                        Quantidade = c.Int(nullable: false),
                        Validade = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.CupomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checkin", "PessoaId", "dbo.Pessoa");
            DropIndex("dbo.Checkin", new[] { "PessoaId" });
            DropTable("dbo.Cupom");
            DropTable("dbo.Checkin");
        }
    }
}
