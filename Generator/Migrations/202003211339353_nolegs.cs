namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nolegs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Steps", "LegId", "dbo.Legs");
            DropForeignKey("dbo.Legs", "RouteId", "dbo.Routes");
            DropIndex("dbo.Legs", new[] { "RouteId" });
            DropIndex("dbo.Steps", new[] { "LegId" });
            AddColumn("dbo.Steps", "RouteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Steps", "RouteId");
            AddForeignKey("dbo.Steps", "RouteId", "dbo.Routes", "RouteId", cascadeDelete: true);
            DropColumn("dbo.Steps", "LegId");
            DropTable("dbo.Legs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        LegId = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LegId);
            
            AddColumn("dbo.Steps", "LegId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Steps", "RouteId", "dbo.Routes");
            DropIndex("dbo.Steps", new[] { "RouteId" });
            DropColumn("dbo.Steps", "RouteId");
            CreateIndex("dbo.Steps", "LegId");
            CreateIndex("dbo.Legs", "RouteId");
            AddForeignKey("dbo.Legs", "RouteId", "dbo.Routes", "RouteId", cascadeDelete: true);
            AddForeignKey("dbo.Steps", "LegId", "dbo.Legs", "LegId", cascadeDelete: true);
        }
    }
}
