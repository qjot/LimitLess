namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "birthday", c => c.DateTime());
            AddColumn("dbo.Users", "joinDate", c => c.DateTime());
            AddColumn("dbo.Users", "renewalDate", c => c.DateTime());
            AddColumn("dbo.Users", "lastPayment", c => c.DateTime());
            AddColumn("dbo.Users", "membershipId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "membershipId");
            AddForeignKey("dbo.Users", "membershipId", "dbo.Membership", "membershipId");
            AddColumn("dbo.AspNetUsers", "birthday", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "joinDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "renewalDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "lastPayment", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "membershipId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "membershipId");
            AddForeignKey("dbo.AspNetUsers", "membershipId", "dbo.Membership", "membershipId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "membershipId", "dbo.Membership");
            DropIndex("dbo.Users", new[] { "membershipId" });
            DropColumn("dbo.Users", "membershipId");
            DropColumn("dbo.Users", "lastPayment");
            DropColumn("dbo.Users", "renewalDate");
            DropColumn("dbo.Users", "joinDate");
            DropColumn("dbo.Users", "birthday");

            DropForeignKey("dbo.AspNetUsers", "membershipId", "dbo.Membership");
            DropIndex("dbo.AspNetUsers", new[] { "membershipId" });
            DropColumn("dbo.AspNetUsers", "membershipId");
            DropColumn("dbo.AspNetUsers", "lastPayment");
            DropColumn("dbo.AspNetUsers", "renewalDate");
            DropColumn("dbo.AspNetUsers", "joinDate");
            DropColumn("dbo.AspNetUsers", "birthday");
        }
    }
}
