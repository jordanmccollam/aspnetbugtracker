namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUsersPropInProjectModel4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Users", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Users");
        }
    }
}
