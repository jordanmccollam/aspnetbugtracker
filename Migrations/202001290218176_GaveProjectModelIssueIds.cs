namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GaveProjectModelIssueIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "IssuesId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "IssuesId");
        }
    }
}
