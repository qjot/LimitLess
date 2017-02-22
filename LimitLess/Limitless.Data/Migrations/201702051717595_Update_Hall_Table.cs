namespace Limitless.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Hall_Table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Halls", "userId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Halls", "userId", c => c.Int(nullable: false));
        }
    }
}
