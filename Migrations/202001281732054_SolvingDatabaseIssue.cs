namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolvingDatabaseIssue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Issues", new[] { "Project_Id" });
            AlterColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Issues", "Project_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Issues", "Project_Id", c => c.Int());
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Issues", "Project_Id");
            AddForeignKey("dbo.Issues", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
