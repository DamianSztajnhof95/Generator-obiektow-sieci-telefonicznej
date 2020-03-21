namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class legs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Steps", "RouteId", "dbo.Routes");
            DropIndex("dbo.Steps", new[] { "RouteId" });
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        LegId = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LegId)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId);
            
            AddColumn("dbo.Steps", "LegId", c => c.Int(nullable: false));
            CreateIndex("dbo.Steps", "LegId");
            AddForeignKey("dbo.Steps", "LegId", "dbo.Legs", "LegId", cascadeDelete: true);
            DropColumn("dbo.Steps", "RouteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Steps", "RouteId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Legs", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Steps", "LegId", "dbo.Legs");
            DropIndex("dbo.Steps", new[] { "LegId" });
            DropIndex("dbo.Legs", new[] { "RouteId" });
            DropColumn("dbo.Steps", "LegId");
            DropTable("dbo.Legs");
            CreateIndex("dbo.Steps", "RouteId");
            AddForeignKey("dbo.Steps", "RouteId", "dbo.Routes", "RouteId", cascadeDelete: true);
        }
    }
}
