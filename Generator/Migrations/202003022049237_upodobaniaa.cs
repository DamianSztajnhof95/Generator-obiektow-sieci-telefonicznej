namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upodobaniaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HumanTypeLikingHumanTypes", "HumanTypeLiking_humanTypeLikingId", "dbo.HumanTypeLikings");
            DropForeignKey("dbo.HumanTypeLikingHumanTypes", "HumanType_HumanTypeId", "dbo.HumanTypes");
            DropIndex("dbo.HumanTypeLikingHumanTypes", new[] { "HumanTypeLiking_humanTypeLikingId" });
            DropIndex("dbo.HumanTypeLikingHumanTypes", new[] { "HumanType_HumanTypeId" });
            AddColumn("dbo.HumanTypeLikings", "probability", c => c.String());
            AddColumn("dbo.HumanTypeLikings", "HumanType_HumanTypeId", c => c.Int());
            CreateIndex("dbo.HumanTypeLikings", "HumanType_HumanTypeId");
            AddForeignKey("dbo.HumanTypeLikings", "HumanType_HumanTypeId", "dbo.HumanTypes", "HumanTypeId");
            DropTable("dbo.HumanTypeLikingHumanTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HumanTypeLikingHumanTypes",
                c => new
                    {
                        HumanTypeLiking_humanTypeLikingId = c.Int(nullable: false),
                        HumanType_HumanTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HumanTypeLiking_humanTypeLikingId, t.HumanType_HumanTypeId });
            
            DropForeignKey("dbo.HumanTypeLikings", "HumanType_HumanTypeId", "dbo.HumanTypes");
            DropIndex("dbo.HumanTypeLikings", new[] { "HumanType_HumanTypeId" });
            DropColumn("dbo.HumanTypeLikings", "HumanType_HumanTypeId");
            DropColumn("dbo.HumanTypeLikings", "probability");
            CreateIndex("dbo.HumanTypeLikingHumanTypes", "HumanType_HumanTypeId");
            CreateIndex("dbo.HumanTypeLikingHumanTypes", "HumanTypeLiking_humanTypeLikingId");
            AddForeignKey("dbo.HumanTypeLikingHumanTypes", "HumanType_HumanTypeId", "dbo.HumanTypes", "HumanTypeId", cascadeDelete: true);
            AddForeignKey("dbo.HumanTypeLikingHumanTypes", "HumanTypeLiking_humanTypeLikingId", "dbo.HumanTypeLikings", "humanTypeLikingId", cascadeDelete: true);
        }
    }
}
