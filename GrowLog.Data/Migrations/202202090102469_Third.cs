namespace GrowLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plant", "FileContent", c => c.Binary());
            DropColumn("dbo.Plant", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plant", "ImageUrl", c => c.Binary(nullable: false));
            DropColumn("dbo.Plant", "FileContent");
        }
    }
}
