namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedIssueModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Issues", new[] { "AssignedToUser_Id" });
            DropColumn("dbo.Issues", "AssignedToUserId");
            RenameColumn(table: "dbo.Issues", name: "AssignedToUser_Id", newName: "AssignedToUserId");
            AlterColumn("dbo.Issues", "AssignedToUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Issues", "AssignedToUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Issues", new[] { "AssignedToUserId" });
            AlterColumn("dbo.Issues", "AssignedToUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Issues", name: "AssignedToUserId", newName: "AssignedToUser_Id");
            AddColumn("dbo.Issues", "AssignedToUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Issues", "AssignedToUser_Id");
        }
    }
}
