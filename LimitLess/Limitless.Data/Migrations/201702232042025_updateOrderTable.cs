namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "paymentTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.PaymentTypes", "paymentTypeName", c => c.String());
            CreateIndex("dbo.Orders", "paymentTypeId");
            AddForeignKey("dbo.Orders", "paymentTypeId", "dbo.PaymentTypes", "paymentTypeId", cascadeDelete: true);
            DropColumn("dbo.PaymentTypes", "paymentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaymentTypes", "paymentType", c => c.String());
            DropForeignKey("dbo.Orders", "paymentTypeId", "dbo.PaymentTypes");
            DropIndex("dbo.Orders", new[] { "paymentTypeId" });
            DropColumn("dbo.PaymentTypes", "paymentTypeName");
            DropColumn("dbo.Orders", "paymentTypeId");
        }
    }
}
