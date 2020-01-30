namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FiddlingWithProjectModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "IssuesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "IssuesId", c => c.Int(nullable: false));
        }
    }
}
