namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderDetails : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OrderDetails");
            AddColumn("dbo.OrderDetails", "membershipId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "userId", c => c.String(maxLength: 128));
            AlterColumn("dbo.OrderDetails", "orderDetailId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OrderDetails", "orderDetailId");
            CreateIndex("dbo.OrderDetails", "membershipId");
            CreateIndex("dbo.Orders", "userId");
            AddForeignKey("dbo.OrderDetails", "membershipId", "dbo.Membership", "membershipId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "userId", "dbo.Users", "Id");
            DropColumn("dbo.OrderDetails", "productId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "productId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Orders", "userId", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "membershipId", "dbo.Membership");
            DropIndex("dbo.Orders", new[] { "userId" });
            DropIndex("dbo.OrderDetails", new[] { "membershipId" });
            DropPrimaryKey("dbo.OrderDetails");
            AlterColumn("dbo.OrderDetails", "orderDetailId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "userId");
            DropColumn("dbo.OrderDetails", "membershipId");
            AddPrimaryKey("dbo.OrderDetails", "productId");
        }
    }
}
