namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Weight", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "StravaEmail", c => c.String());
            AddColumn("dbo.AspNetUsers", "ForceGarmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PreferKg", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsMale", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "TimeZoneOffset", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "TimeZoneOffset");
            DropColumn("dbo.AspNetUsers", "IsMale");
            DropColumn("dbo.AspNetUsers", "PreferKg");
            DropColumn("dbo.AspNetUsers", "ForceGarmin");
            DropColumn("dbo.AspNetUsers", "StravaEmail");
            DropColumn("dbo.AspNetUsers", "Weight");
        }
    }
}
