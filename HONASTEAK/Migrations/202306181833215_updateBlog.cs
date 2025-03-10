﻿namespace HONASTEAK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Published = c.Boolean(nullable: false),
                        Author = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blogs");
        }
    }
}
