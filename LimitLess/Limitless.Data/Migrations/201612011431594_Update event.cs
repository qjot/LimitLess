namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateevent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "description", c => c.String());
            AddColumn("dbo.Events", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "allDay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "allDay");
            DropColumn("dbo.Events", "date");
            DropColumn("dbo.Events", "description");
        }
    }
}
