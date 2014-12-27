namespace PolarConverter.JSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subscriptionid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "SubscriptionId", c => c.String());
            AlterColumn("dbo.Subscriptions", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Subscriptions", "UserId");
            AddForeignKey("dbo.Subscriptions", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Subscriptions", new[] { "UserId" });
            AlterColumn("dbo.Subscriptions", "UserId", c => c.String());
            DropColumn("dbo.Subscriptions", "SubscriptionId");
        }
    }
}
