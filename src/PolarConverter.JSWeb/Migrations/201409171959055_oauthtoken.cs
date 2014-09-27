namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oauthtoken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OauthTokens",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ProviderType = c.Int(nullable: false),
                        Token = c.String(),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProviderType })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OauthTokens", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.OauthTokens", new[] { "UserId" });
            DropTable("dbo.OauthTokens");
        }
    }
}
