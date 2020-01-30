namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertingIssueModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Issues", new[] { "Project_Id" });
            RenameColumn(table: "dbo.Issues", name: "Project_Id", newName: "ProjectId");
            AddColumn("dbo.Issues", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Issues", "Type", c => c.String(nullable: false));
            AddColumn("dbo.Issues", "Description", c => c.String());
            AddColumn("dbo.Issues", "AssignedTo", c => c.String());
            AddColumn("dbo.Issues", "OwnerUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Issues", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Issues", "ProjectId");
            CreateIndex("dbo.Issues", "OwnerUserId");
            AddForeignKey("dbo.Issues", "OwnerUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Issues", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Issues", "OwnerUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Issues", new[] { "OwnerUserId" });
            DropIndex("dbo.Issues", new[] { "ProjectId" });
            AlterColumn("dbo.Issues", "ProjectId", c => c.Int());
            DropColumn("dbo.Issues", "OwnerUserId");
            DropColumn("dbo.Issues", "AssignedTo");
            DropColumn("dbo.Issues", "Description");
            DropColumn("dbo.Issues", "Type");
            DropColumn("dbo.Issues", "Name");
            RenameColumn(table: "dbo.Issues", name: "ProjectId", newName: "Project_Id");
            CreateIndex("dbo.Issues", "Project_Id");
            AddForeignKey("dbo.Issues", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
