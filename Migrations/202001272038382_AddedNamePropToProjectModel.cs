namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNamePropToProjectModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Name");
        }
    }
}
