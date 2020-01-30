namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedBasicProjectModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Owner = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "ProjectIds", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Project_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Project_Id");
            AddForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects");
            DropIndex("dbo.AspNetUsers", new[] { "Project_Id" });
            DropColumn("dbo.AspNetUsers", "Project_Id");
            DropColumn("dbo.AspNetUsers", "ProjectIds");
            DropTable("dbo.Projects");
        }
    }
}
