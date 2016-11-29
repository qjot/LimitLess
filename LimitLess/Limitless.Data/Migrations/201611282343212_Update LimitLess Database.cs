namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLimitLessDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        last = c.String(),
                        name = c.String(),
                        title = c.String(),
                        description = c.String(),
                        allDay = c.Boolean(nullable: false),
                        maxCapacity = c.Int(nullable: false),
                        classesTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ClassesType", t => t.classesTypeId)
                .Index(t => t.classesTypeId);
            
            CreateTable(
                "dbo.ClassesType",
                c => new
                    {
                        typeId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.typeId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventId = c.Int(nullable: false, identity: true),
                        capacity = c.Int(nullable: false),
                        start = c.DateTime(nullable: false),
                        end = c.DateTime(nullable: false),
                        classesId = c.Int(nullable: false),
                        hallId = c.Int(nullable: false),
                        trainerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.eventId)
                .ForeignKey("dbo.Classes", t => t.classesId)
                .ForeignKey("dbo.Halls", t => t.hallId)
                .ForeignKey("dbo.Users", t => t.trainerId)
                .Index(t => t.classesId)
                .Index(t => t.hallId)
                .Index(t => t.trainerId);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        hallId = c.Int(nullable: false, identity: true),
                        name = c.String(),
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
                        Event_eventId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_eventId)
                .Index(t => t.Event_eventId);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Membership",
                c => new
                    {
                        membershipId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.membershipId);
            
            CreateTable(
                "dbo.Order Detail",
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
                .ForeignKey("dbo.Orders", t => t.orderId)
                .Index(t => t.orderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(),
                        username = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        address = c.String(),
                        city = c.String(),
                        state = c.String(),
                        postalCode = c.String(),
                        country = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        total = c.Decimal(precision: 18, scale: 2),
                        nip = c.String(),
                    })
                .PrimaryKey(t => t.orderId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Order Detail", "orderId", "dbo.Orders");
            DropForeignKey("dbo.Events", "trainerId", "dbo.Users");
            DropForeignKey("dbo.Users", "Event_eventId", "dbo.Events");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Events", "hallId", "dbo.Halls");
            DropForeignKey("dbo.Events", "classesId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "classesTypeId", "dbo.ClassesType");
            DropIndex("dbo.Order Detail", new[] { "orderId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Event_eventId" });
            DropIndex("dbo.Events", new[] { "trainerId" });
            DropIndex("dbo.Events", new[] { "hallId" });
            DropIndex("dbo.Events", new[] { "classesId" });
            DropIndex("dbo.Classes", new[] { "classesTypeId" });
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Orders");
            DropTable("dbo.Order Detail");
            DropTable("dbo.Membership");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Halls");
            DropTable("dbo.Events");
            DropTable("dbo.ClassesType");
            DropTable("dbo.Classes");
        }
    }
}
