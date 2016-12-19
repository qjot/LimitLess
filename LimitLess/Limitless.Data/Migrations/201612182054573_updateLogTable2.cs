namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLogTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logs", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logs", "Date", c => c.String());
        }
    }
}
