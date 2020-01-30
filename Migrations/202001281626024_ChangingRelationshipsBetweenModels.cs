namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingRelationshipsBetweenModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Issues", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Issues", new[] { "ProjectId" });
            DropIndex("dbo.AspNetUsers", new[] { "Project_Id" });
            RenameColumn(table: "dbo.Issues", name: "ProjectId", newName: "Project_Id");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Project_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Project_Id);
            
            AddColumn("dbo.Issues", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Issues", "Project_Id", c => c.Int());
            CreateIndex("dbo.Issues", "Project_Id");
            AddForeignKey("dbo.Issues", "Project_Id", "dbo.Projects", "Id");
            DropColumn("dbo.AspNetUsers", "ProjectIds");
            DropColumn("dbo.AspNetUsers", "Project_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Project_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ProjectIds", c => c.Int(nullable: false));
            DropForeignKey("dbo.Issues", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.UserProjects", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.UserProjects", "User_Id", "dbo.Users");
            DropIndex("dbo.UserProjects", new[] { "Project_Id" });
            DropIndex("dbo.UserProjects", new[] { "User_Id" });
            DropIndex("dbo.Issues", new[] { "Project_Id" });
            AlterColumn("dbo.Issues", "Project_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Issues", "Type");
            DropTable("dbo.UserProjects");
            DropTable("dbo.Users");
            RenameColumn(table: "dbo.Issues", name: "Project_Id", newName: "ProjectId");
            CreateIndex("dbo.AspNetUsers", "Project_Id");
            CreateIndex("dbo.Issues", "ProjectId");
            AddForeignKey("dbo.Issues", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
