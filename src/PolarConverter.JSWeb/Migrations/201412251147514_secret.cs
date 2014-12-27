namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secret : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OauthTokens", "Secret", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OauthTokens", "Secret");
        }
    }
}
