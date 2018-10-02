namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipousuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Papel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Papel");
        }
    }
}
