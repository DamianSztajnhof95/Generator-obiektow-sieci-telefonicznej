namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pozycjas", "HumanId", "dbo.Humen");
            DropIndex("dbo.Pozycjas", new[] { "HumanId" });
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        actualTime = c.Time(nullable: false, precision: 7),
                        HumanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Humen", t => t.HumanId, cascadeDelete: true)
                .Index(t => t.HumanId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.String(nullable: false, maxLength: 128),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        Name = c.String(),
                        visitCount = c.Int(nullable: false),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            AddColumn("dbo.HumanTypes", "numberOfLocations", c => c.Int(nullable: false));
            DropTable("dbo.Miejsces");
            DropTable("dbo.Pozycjas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pozycjas",
                c => new
                    {
                        PozycjaId = c.Int(nullable: false, identity: true),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        actualTime = c.Time(nullable: false, precision: 7),
                        HumanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PozycjaId);
            
            CreateTable(
                "dbo.Miejsces",
                c => new
                    {
                        MiejsceId = c.String(nullable: false, maxLength: 128),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        Name = c.String(),
                        visitCount = c.Int(nullable: false),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.MiejsceId);
            
            DropForeignKey("dbo.Positions", "HumanId", "dbo.Humen");
            DropIndex("dbo.Positions", new[] { "HumanId" });
            DropColumn("dbo.HumanTypes", "numberOfLocations");
            DropTable("dbo.Locations");
            DropTable("dbo.Positions");
            CreateIndex("dbo.Pozycjas", "HumanId");
            AddForeignKey("dbo.Pozycjas", "HumanId", "dbo.Humen", "HumanId", cascadeDelete: true);
        }
    }
}
