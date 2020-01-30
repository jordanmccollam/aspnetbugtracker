namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUsersPropInProjectModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Users", c => c.String());
            DropColumn("dbo.Projects", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ApplicationUserId", c => c.Int(nullable: false));
            DropColumn("dbo.Projects", "Users");
        }
    }
}
