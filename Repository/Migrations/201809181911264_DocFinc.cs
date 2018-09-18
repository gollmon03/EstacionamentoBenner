namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocFinc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentoFinanceiro", "Tipo", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.DocumentoFinanceiro", "Status", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.DocumentoFinanceiro", "NumeroDocumento", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocumentoFinanceiro", "NumeroDocumento");
            DropColumn("dbo.DocumentoFinanceiro", "Status");
            DropColumn("dbo.DocumentoFinanceiro", "Tipo");
        }
    }
}
