namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class legs1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Legs", "RouteId", "dbo.Routes");
            DropIndex("dbo.Routes", new[] { "HumanId" });
            DropIndex("dbo.Legs", new[] { "RouteId" });
            AddColumn("dbo.Legs", "HumanId", c => c.Int(nullable: false));
            CreateIndex("dbo.Legs", "HumanId");
            DropColumn("dbo.Legs", "RouteId");
            DropTable("dbo.Routes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        HumanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteId);
            
            AddColumn("dbo.Legs", "RouteId", c => c.Int(nullable: false));
            DropIndex("dbo.Legs", new[] { "HumanId" });
            DropColumn("dbo.Legs", "HumanId");
            CreateIndex("dbo.Legs", "RouteId");
            CreateIndex("dbo.Routes", "HumanId");
            AddForeignKey("dbo.Legs", "RouteId", "dbo.Routes", "RouteId", cascadeDelete: true);
        }
    }
}
