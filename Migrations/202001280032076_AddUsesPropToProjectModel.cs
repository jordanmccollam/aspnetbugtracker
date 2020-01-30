namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsesPropToProjectModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ApplicationUserId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ApplicationUserId");
        }
    }
}
