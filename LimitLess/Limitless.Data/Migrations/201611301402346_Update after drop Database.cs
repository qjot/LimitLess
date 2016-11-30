namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateafterdropDatabase : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.ClassesType",
                c => new
                    {
                        classesTypeId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.classesTypeId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventId = c.Int(nullable: false, identity: true),
                        capacity = c.Int(nullable: false),
                        start = c.DateTime(nullable: false),
                        end = c.DateTime(nullable: false),
                        classesTypeId = c.Int(),
                        hallId = c.Int(nullable: false),
                        trainerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.eventId)
                .ForeignKey("dbo.ClassesType", t => t.classesTypeId)
                .ForeignKey("dbo.Halls", t => t.hallId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.trainerId)
                .Index(t => t.classesTypeId)
                .Index(t => t.hallId)
                .Index(t => t.trainerId);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        hallId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        maxCapacity = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.hallId);

            
            //CreateIndex("dbo.Users", "eventId");
            //AddForeignKey("dbo.Users", "eventId", "dbo.Event", "eventId");
            //.ForeignKey("dbo.Membership", t => t.membershipId)
            //.ForeignKey("dbo.Events", t => t.Event_eventId)
            //.Index(t => t.membershipId)
            //.Index(t => t.Event_eventId);

            
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        orderDetailId = c.Int(nullable: false),
                        orderId = c.Int(nullable: false),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        unitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Short(nullable: false),
                        discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.Orders", t => t.orderId, cascadeDelete: true)
                .Index(t => t.orderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(),
                        username = c.String(nullable: false),
                        firstName = c.String(nullable: false, maxLength: 30),
                        lastName = c.String(nullable: false, maxLength: 30),
                        address = c.String(nullable: false),
                        city = c.String(nullable: false),
                        state = c.String(),
                        postalCode = c.String(nullable: false),
                        country = c.String(nullable: false),
                        phone = c.String(),
                        email = c.String(nullable: false),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nip = c.String(),
                    })
                .PrimaryKey(t => t.orderId);
            
            
        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "orderId", "dbo.Orders");
            DropForeignKey("dbo.Events", "trainerId", "dbo.Users");
            DropForeignKey("dbo.Users", "Event_eventId", "dbo.Events");
            DropForeignKey("dbo.Events", "hallId", "dbo.Halls");
            DropForeignKey("dbo.Events", "classesTypeId", "dbo.ClassesType");
            DropIndex("dbo.OrderDetails", new[] {"orderId"});
            DropIndex("dbo.Users", new[] {"Event_eventId"});
            DropIndex("dbo.Events", new[] {"trainerId"});
            DropIndex("dbo.Events", new[] {"hallId"});
            DropIndex("dbo.Events", new[] {"classesTypeId"});
            DropIndex("dbo.Classes", new[] {"classesTypeId"});
            DropTable("dbo.Membership");
            DropTable("dbo.Users");
            DropTable("dbo.Halls");
            DropTable("dbo.Events");
            DropTable("dbo.ClassesType");
        }
    }
}
