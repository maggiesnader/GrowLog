namespace GrowLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fifth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Plant", "HarvestSeasonStart");
            DropColumn("dbo.Plant", "HarvestSeasonEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plant", "HarvestSeasonEnd", c => c.DateTime());
            AddColumn("dbo.Plant", "HarvestSeasonStart", c => c.DateTime());
        }
    }
}
