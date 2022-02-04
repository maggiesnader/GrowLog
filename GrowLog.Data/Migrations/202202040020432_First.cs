namespace GrowLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plant", "HarvestSeason", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plant", "HarvestSeason", c => c.Time(nullable: false, precision: 7));
        }
    }
}
