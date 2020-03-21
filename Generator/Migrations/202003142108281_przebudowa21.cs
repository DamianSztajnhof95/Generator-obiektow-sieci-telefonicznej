namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przebudowa21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "HumanId", "dbo.Humen");
            DropIndex("dbo.Positions", new[] { "HumanId" });
            AddColumn("dbo.Duration2", "StepId", c => c.Int(nullable: false));
            AddColumn("dbo.EndLocation2", "StepId", c => c.Int(nullable: false));
            AddColumn("dbo.StartLocation2", "StepId", c => c.Int(nullable: false));
            DropTable("dbo.Positions");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.PositionId);
            
            DropColumn("dbo.StartLocation2", "StepId");
            DropColumn("dbo.EndLocation2", "StepId");
            DropColumn("dbo.Duration2", "StepId");
            CreateIndex("dbo.Positions", "HumanId");
            AddForeignKey("dbo.Positions", "HumanId", "dbo.Humen", "HumanId", cascadeDelete: true);
        }
    }
}
