namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUsersPropInProjectModal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "Users");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Users", c => c.String());
        }
    }
}
