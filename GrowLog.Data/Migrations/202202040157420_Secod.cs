namespace GrowLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Secod : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Plant", name: "LocID", newName: "LocationID");
            RenameIndex(table: "dbo.Plant", name: "IX_LocID", newName: "IX_LocationID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Plant", name: "IX_LocationID", newName: "IX_LocID");
            RenameColumn(table: "dbo.Plant", name: "LocationID", newName: "LocID");
        }
    }
}
