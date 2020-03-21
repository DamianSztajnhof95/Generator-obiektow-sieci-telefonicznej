namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przebudowa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Duration2",
                c => new
                    {
                        Duration2Id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        value = c.Int(nullable: false),
                        StepId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Duration2Id);
            
            CreateTable(
                "dbo.EndLocation2",
                c => new
                    {
                        EndLocation2Id = c.Int(nullable: false, identity: true),
                        lat = c.Double(nullable: false),
                        lng = c.Double(nullable: false),
                        StepId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EndLocation2Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        HumanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.Humen", t => t.HumanId, cascadeDelete: true)
                .Index(t => t.HumanId);
            
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
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        StepId = c.Int(nullable: false, identity: true),
                        LegId = c.Int(nullable: false),
                        duration_Duration2Id = c.Int(),
                        end_location_EndLocation2Id = c.Int(),
                        start_location_StartLocation2Id = c.Int(),
                    })
                .PrimaryKey(t => t.StepId)
                .ForeignKey("dbo.Duration2", t => t.duration_Duration2Id)
                .ForeignKey("dbo.EndLocation2", t => t.end_location_EndLocation2Id)
                .ForeignKey("dbo.StartLocation2", t => t.start_location_StartLocation2Id)
                .ForeignKey("dbo.Legs", t => t.LegId, cascadeDelete: true)
                .Index(t => t.LegId)
                .Index(t => t.duration_Duration2Id)
                .Index(t => t.end_location_EndLocation2Id)
                .Index(t => t.start_location_StartLocation2Id);
            
            CreateTable(
                "dbo.StartLocation2",
                c => new
                    {
                        StartLocation2Id = c.Int(nullable: false, identity: true),
                        lat = c.Double(nullable: false),
                        lng = c.Double(nullable: false),
                        StepId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StartLocation2Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "HumanId", "dbo.Humen");
            DropForeignKey("dbo.Legs", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Steps", "LegId", "dbo.Legs");
            DropForeignKey("dbo.Steps", "start_location_StartLocation2Id", "dbo.StartLocation2");
            DropForeignKey("dbo.Steps", "end_location_EndLocation2Id", "dbo.EndLocation2");
            DropForeignKey("dbo.Steps", "duration_Duration2Id", "dbo.Duration2");
            DropIndex("dbo.Steps", new[] { "start_location_StartLocation2Id" });
            DropIndex("dbo.Steps", new[] { "end_location_EndLocation2Id" });
            DropIndex("dbo.Steps", new[] { "duration_Duration2Id" });
            DropIndex("dbo.Steps", new[] { "LegId" });
            DropIndex("dbo.Legs", new[] { "RouteId" });
            DropIndex("dbo.Routes", new[] { "HumanId" });
            DropTable("dbo.StartLocation2");
            DropTable("dbo.Steps");
            DropTable("dbo.Legs");
            DropTable("dbo.Routes");
            DropTable("dbo.EndLocation2");
            DropTable("dbo.Duration2");
        }
    }
}
