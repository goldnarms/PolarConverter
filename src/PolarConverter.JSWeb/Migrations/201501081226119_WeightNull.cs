namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WeightNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Weight", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Weight", c => c.Double(nullable: false));
        }
    }
}
