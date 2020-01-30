namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertingProjectModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Owner", c => c.String());
            DropColumn("dbo.Projects", "Users");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Users", c => c.String());
            AlterColumn("dbo.Projects", "Owner", c => c.String(nullable: false));
        }
    }
}
