namespace GrowLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plant", "ImageUrl", c => c.Binary(nullable: false));
            DropColumn("dbo.Plant", "FileName");
            DropColumn("dbo.Plant", "FileContent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plant", "FileContent", c => c.Binary());
            AddColumn("dbo.Plant", "FileName", c => c.String());
            DropColumn("dbo.Plant", "ImageUrl");
        }
    }
}
