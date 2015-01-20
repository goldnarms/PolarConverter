namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ForceGarmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "TimeZoneOffset", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TimeZoneOffset");
            DropColumn("dbo.AspNetUsers", "ForceGarmin");
        }
    }
}
