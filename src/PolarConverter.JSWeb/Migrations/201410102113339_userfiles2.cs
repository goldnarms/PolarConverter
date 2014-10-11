namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userfiles2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFiles", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserFiles", "Name");
        }
    }
}
