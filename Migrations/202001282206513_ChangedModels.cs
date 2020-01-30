namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProjects", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserProjects", "Project_Id", "dbo.Projects");
            DropIndex("dbo.UserProjects", new[] { "User_Id" });
            DropIndex("dbo.UserProjects", new[] { "Project_Id" });
            AddColumn("dbo.Issues", "AssignedToUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Issues", "OwnerUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Issues", "AssignedToUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Issues", "OwnerUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "OwnerUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "OwnerUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "User_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Project_Id", c => c.Int());
            CreateIndex("dbo.Issues", "AssignedToUser_Id");
            CreateIndex("dbo.Issues", "OwnerUser_Id");
            CreateIndex("dbo.AspNetUsers", "Project_Id");
            CreateIndex("dbo.Projects", "OwnerUser_Id");
            CreateIndex("dbo.Projects", "User_Id");
            AddForeignKey("dbo.Issues", "AssignedToUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Issues", "OwnerUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "OwnerUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects", "Id");
            AddForeignKey("dbo.Projects", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Issues", "AssignedTo");
            DropColumn("dbo.Projects", "Owner");
            DropTable("dbo.UserProjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Project_Id });
            
            AddColumn("dbo.Projects", "Owner", c => c.String());
            AddColumn("dbo.Issues", "AssignedTo", c => c.String());
            DropForeignKey("dbo.Projects", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "OwnerUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issues", "OwnerUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issues", "AssignedToUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "User_Id" });
            DropIndex("dbo.Projects", new[] { "OwnerUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Project_Id" });
            DropIndex("dbo.Issues", new[] { "OwnerUser_Id" });
            DropIndex("dbo.Issues", new[] { "AssignedToUser_Id" });
            DropColumn("dbo.AspNetUsers", "Project_Id");
            DropColumn("dbo.Projects", "User_Id");
            DropColumn("dbo.Projects", "OwnerUser_Id");
            DropColumn("dbo.Projects", "OwnerUserId");
            DropColumn("dbo.Issues", "OwnerUser_Id");
            DropColumn("dbo.Issues", "AssignedToUser_Id");
            DropColumn("dbo.Issues", "OwnerUserId");
            DropColumn("dbo.Issues", "AssignedToUserId");
            CreateIndex("dbo.UserProjects", "Project_Id");
            CreateIndex("dbo.UserProjects", "User_Id");
            AddForeignKey("dbo.UserProjects", "Project_Id", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProjects", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
