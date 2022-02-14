namespace GrowLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plant", "LocationName", c => c.String());
            DropColumn("dbo.Plant", "FileContent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plant", "FileContent", c => c.Binary());
            DropColumn("dbo.Plant", "LocationName");
        }
    }
}
