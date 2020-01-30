namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChangesToDatabase : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Issues", new[] { "OwnerUser_Id" });
            DropColumn("dbo.Issues", "OwnerUserId");
            RenameColumn(table: "dbo.Issues", name: "OwnerUser_Id", newName: "OwnerUserId");
            AlterColumn("dbo.Issues", "OwnerUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Issues", "OwnerUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Issues", new[] { "OwnerUserId" });
            AlterColumn("dbo.Issues", "OwnerUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Issues", name: "OwnerUserId", newName: "OwnerUser_Id");
            AddColumn("dbo.Issues", "OwnerUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Issues", "OwnerUser_Id");
        }
    }
}
