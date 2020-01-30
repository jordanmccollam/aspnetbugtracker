namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedReferencesToSecondUserModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "User_Id", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "User_Id" });
            DropColumn("dbo.Projects", "User_Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Projects", "User_Id", c => c.Int());
            CreateIndex("dbo.Projects", "User_Id");
            AddForeignKey("dbo.Projects", "User_Id", "dbo.Users", "Id");
        }
    }
}
