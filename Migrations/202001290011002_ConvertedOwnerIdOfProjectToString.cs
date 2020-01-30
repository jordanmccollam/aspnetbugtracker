namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertedOwnerIdOfProjectToString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Projects", new[] { "OwnerUser_Id" });
            DropColumn("dbo.Projects", "OwnerUserId");
            RenameColumn(table: "dbo.Projects", name: "OwnerUser_Id", newName: "OwnerUserId");
            AlterColumn("dbo.Projects", "OwnerUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "OwnerUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Projects", new[] { "OwnerUserId" });
            AlterColumn("dbo.Projects", "OwnerUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Projects", name: "OwnerUserId", newName: "OwnerUser_Id");
            AddColumn("dbo.Projects", "OwnerUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "OwnerUser_Id");
        }
    }
}
