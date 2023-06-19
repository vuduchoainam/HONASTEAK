namespace HONASTEAK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableInvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "UserId");
        }
    }
}
