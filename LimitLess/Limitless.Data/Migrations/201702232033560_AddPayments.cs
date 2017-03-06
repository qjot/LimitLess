namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPayments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "classesTypeId", "dbo.ClassesType");
            DropForeignKey("dbo.OrderDetails", "orderId", "dbo.Orders");
            DropIndex("dbo.Classes", new[] { "classesTypeId" });
            DropPrimaryKey("dbo.Orders");
            CreateTable(
                "dbo.PaymentDatas",
                c => new
                    {
                        paymentDataId = c.Int(nullable: false, identity: true),
                        paymentTypeId = c.Int(nullable: false),
                        value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.paymentDataId)
                .ForeignKey("dbo.PaymentTypes", t => t.paymentTypeId, cascadeDelete: true)
                .Index(t => t.paymentTypeId);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        paymentTypeId = c.Int(nullable: false, identity: true),
                        paymentType = c.String(),
                    })
                .PrimaryKey(t => t.paymentTypeId);
            
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        paymentDetailsId = c.Int(nullable: false, identity: true),
                        orderId = c.Int(nullable: false),
                        paymentDataId = c.Int(nullable: false),
                        paymentDate = c.DateTime(),
                        value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.paymentDetailsId)
                .ForeignKey("dbo.PaymentDatas", t => t.paymentDataId, cascadeDelete: true)
                .Index(t => t.paymentDataId);
            
            AlterColumn("dbo.Orders", "orderId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Orders", "orderId");
            CreateIndex("dbo.Orders", "orderId");
            AddForeignKey("dbo.Orders", "orderId", "dbo.PaymentDetails", "paymentDetailsId");
            AddForeignKey("dbo.OrderDetails", "orderId", "dbo.Orders", "orderId", cascadeDelete: true);
            DropTable("dbo.Classes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        last = c.String(),
                        name = c.String(nullable: false, maxLength: 50),
                        title = c.String(),
                        description = c.String(nullable: false, maxLength: 500),
                        allDay = c.Boolean(nullable: false),
                        maxCapacity = c.Int(nullable: false),
                        classesTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.OrderDetails", "orderId", "dbo.Orders");
            DropForeignKey("dbo.PaymentDetails", "paymentDataId", "dbo.PaymentDatas");
            DropForeignKey("dbo.Orders", "orderId", "dbo.PaymentDetails");
            DropForeignKey("dbo.PaymentDatas", "paymentTypeId", "dbo.PaymentTypes");
            DropIndex("dbo.PaymentDetails", new[] { "paymentDataId" });
            DropIndex("dbo.PaymentDatas", new[] { "paymentTypeId" });
            DropIndex("dbo.Orders", new[] { "orderId" });
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "orderId", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.PaymentDetails");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.PaymentDatas");
            AddPrimaryKey("dbo.Orders", "orderId");
            CreateIndex("dbo.Classes", "classesTypeId");
            AddForeignKey("dbo.OrderDetails", "orderId", "dbo.Orders", "orderId", cascadeDelete: true);
            AddForeignKey("dbo.Classes", "classesTypeId", "dbo.ClassesType", "classesTypeId", cascadeDelete: true);
        }
    }
}
