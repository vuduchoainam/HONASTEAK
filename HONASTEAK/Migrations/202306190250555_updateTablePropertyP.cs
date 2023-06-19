namespace HONASTEAK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTablePropertyP : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PropertyProducts");
            AlterColumn("dbo.PropertyProducts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PropertyProducts", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PropertyProducts");
            AlterColumn("dbo.PropertyProducts", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.PropertyProducts", "Id");
        }
    }
}
