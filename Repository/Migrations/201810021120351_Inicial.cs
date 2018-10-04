namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovimentacaoVeiculo", "Gerado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuario", "Papel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Papel");
            DropColumn("dbo.MovimentacaoVeiculo", "Gerado");
        }
    }
}
