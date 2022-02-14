namespace GrowLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eighth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Plant", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plant", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
