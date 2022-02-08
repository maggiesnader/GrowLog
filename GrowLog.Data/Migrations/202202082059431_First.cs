namespace GrowLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plant", "FileName", c => c.String());
            AddColumn("dbo.Plant", "FileContent", c => c.Binary());
            DropColumn("dbo.Plant", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plant", "Photo", c => c.String());
            DropColumn("dbo.Plant", "FileContent");
            DropColumn("dbo.Plant", "FileName");
        }
    }
}
