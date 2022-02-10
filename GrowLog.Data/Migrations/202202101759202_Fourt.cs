namespace GrowLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasicSchedulerContext",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BasicSchedulerContext");
        }
    }
}
