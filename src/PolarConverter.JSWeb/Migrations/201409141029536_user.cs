namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "StravaEmail");
            DropColumn("dbo.AspNetUsers", "ForceGarmin");
            DropColumn("dbo.AspNetUsers", "TimeZoneOffset");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "TimeZoneOffset", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "ForceGarmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "StravaEmail", c => c.String());
        }
    }
}
