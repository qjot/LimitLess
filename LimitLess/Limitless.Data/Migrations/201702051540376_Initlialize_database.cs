namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initlialize_database : DbMigration
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
                        description = c.String(),
                        start = c.DateTime(nullable: false),
                        date = c.DateTime(nullable: false),
                        end = c.DateTime(nullable: false),
                        allDay = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        birthday = c.DateTime(),
                        joinDate = c.DateTime(),
                        renewalDate = c.DateTime(),
                        lastPayment = c.DateTime(),
                        firstName = c.String(),
                        lastName = c.String(),
                        address1 = c.String(),
                        address2 = c.String(),
                        city = c.String(),
                        state = c.String(),
                        postalCode = c.String(),
                        membershipId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Event_eventId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Membership", t => t.membershipId)
                .ForeignKey("dbo.Events", t => t.Event_eventId)
                .Index(t => t.membershipId)
                .Index(t => t.Event_eventId);
            
            CreateTable(
                "dbo.userClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Membership",
                c => new
                    {
                        membershipId = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 500),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.membershipId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Roles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        logId = c.Int(nullable: false, identity: true),
                        Thread = c.String(),
                        Level = c.String(),
                        Logger = c.String(),
                        Message = c.String(),
                        Exception = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        userID = c.String(),
                        userName = c.String(),
                        additionalInfo = c.String(),
                    })
                .PrimaryKey(t => t.logId);
            
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ClassesType", t => t.classesTypeId, cascadeDelete: true)
                .Index(t => t.classesTypeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.userClaims", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "IdentityRole_Id", "dbo.Roles");
            DropForeignKey("dbo.Classes", "classesTypeId", "dbo.ClassesType");
            DropForeignKey("dbo.OrderDetails", "orderId", "dbo.Orders");
            DropForeignKey("dbo.Events", "trainerId", "dbo.Users");
            DropForeignKey("dbo.Users", "Event_eventId", "dbo.Events");
            DropForeignKey("dbo.Users", "membershipId", "dbo.Membership");
            DropForeignKey("dbo.Events", "hallId", "dbo.Halls");
            DropForeignKey("dbo.Events", "classesTypeId", "dbo.ClassesType");
            DropIndex("dbo.Classes", new[] { "classesTypeId" });
            DropIndex("dbo.OrderDetails", new[] { "orderId" });
            DropIndex("dbo.UserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.UserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.userClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Users", new[] { "Event_eventId" });
            DropIndex("dbo.Users", new[] { "membershipId" });
            DropIndex("dbo.Events", new[] { "trainerId" });
            DropIndex("dbo.Events", new[] { "hallId" });
            DropIndex("dbo.Events", new[] { "classesTypeId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Classes");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Logs");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Membership");
            DropTable("dbo.UserLogins");
            DropTable("dbo.userClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Halls");
            DropTable("dbo.Events");
            DropTable("dbo.ClassesType");
        }
    }
}
