namespace Estacionamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Cpf, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuario", new[] { "Cpf" });
            DropTable("dbo.Usuario");
        }
    }
}
