namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovimentacaoVeiculo", "DataHoraEntrada", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovimentacaoVeiculo", "DataHoraEntrada", c => c.DateTime(nullable: false));
        }
    }
}
