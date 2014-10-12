namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userFileReference : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserFiles");
            AddColumn("dbo.UserFiles", "Reference", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UserFiles", "Activity", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserFiles", new[] { "UserId", "Reference" });
            DropColumn("dbo.UserFiles", "FileRef");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserFiles", "FileRef", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.UserFiles");
            DropColumn("dbo.UserFiles", "Activity");
            DropColumn("dbo.UserFiles", "Reference");
            AddPrimaryKey("dbo.UserFiles", new[] { "UserId", "FileRef" });
        }
    }
}
