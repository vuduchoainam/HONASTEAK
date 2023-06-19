namespace HONASTEAK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableOptionP : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OptionProducts");
            AlterColumn("dbo.OptionProducts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OptionProducts", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.OptionProducts");
            AlterColumn("dbo.OptionProducts", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.OptionProducts", "Id");
        }
    }
}
