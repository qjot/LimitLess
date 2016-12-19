namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserAndAddLog : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Users", "firstName", c => c.String());
            AddColumn("dbo.Users", "lastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "lastName");
            DropColumn("dbo.Users", "firstName");
            DropTable("dbo.Logs");
        }
    }
}
