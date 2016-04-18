namespace PraticarEsportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pessoa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Telefone = c.String(unicode: false),
                        Endereco = c.String(unicode: false),
                        CEP = c.String(unicode: false),
                        Cidade = c.String(unicode: false),
                        Estado = c.String(unicode: false),
                        Habilitado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoa");
        }
    }
}
