namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFiles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FileRef = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FileRef })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFiles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserFiles", new[] { "UserId" });
            DropTable("dbo.UserFiles");
        }
    }
}
