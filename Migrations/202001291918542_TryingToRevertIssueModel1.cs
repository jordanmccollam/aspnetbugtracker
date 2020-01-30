namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryingToRevertIssueModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Issues", new[] { "ProjectId" });
            RenameColumn(table: "dbo.Issues", name: "ProjectId", newName: "Project_Id");
            AlterColumn("dbo.Issues", "Project_Id", c => c.Int());
            CreateIndex("dbo.Issues", "Project_Id");
            AddForeignKey("dbo.Issues", "Project_Id", "dbo.Projects", "Id");
            DropColumn("dbo.Issues", "Name");
            DropColumn("dbo.Issues", "Description");
            DropColumn("dbo.Issues", "AssignedTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Issues", "AssignedTo", c => c.String());
            AddColumn("dbo.Issues", "Description", c => c.String());
            AddColumn("dbo.Issues", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Issues", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Issues", new[] { "Project_Id" });
            AlterColumn("dbo.Issues", "Project_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Issues", name: "Project_Id", newName: "ProjectId");
            CreateIndex("dbo.Issues", "ProjectId");
            AddForeignKey("dbo.Issues", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
