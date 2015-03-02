namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProviderUsername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OauthTokens", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OauthTokens", "Username");
        }
    }
}
