namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upodobania : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HumanTypeLikings",
                c => new
                    {
                        humanTypeLikingId = c.Int(nullable: false, identity: true),
                        humanTypeLikingName = c.String(),
                    })
                .PrimaryKey(t => t.humanTypeLikingId);
            
            CreateTable(
                "dbo.HumanTypeLikingHumanTypes",
                c => new
                    {
                        HumanTypeLiking_humanTypeLikingId = c.Int(nullable: false),
                        HumanType_HumanTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HumanTypeLiking_humanTypeLikingId, t.HumanType_HumanTypeId })
                .ForeignKey("dbo.HumanTypeLikings", t => t.HumanTypeLiking_humanTypeLikingId, cascadeDelete: true)
                .ForeignKey("dbo.HumanTypes", t => t.HumanType_HumanTypeId, cascadeDelete: true)
                .Index(t => t.HumanTypeLiking_humanTypeLikingId)
                .Index(t => t.HumanType_HumanTypeId);
            
            AddColumn("dbo.Humen", "HumanType_HumanTypeId", c => c.Int());
            CreateIndex("dbo.Humen", "HumanType_HumanTypeId");
            AddForeignKey("dbo.Humen", "HumanType_HumanTypeId", "dbo.HumanTypes", "HumanTypeId");
            DropColumn("dbo.Humen", "HumanType");
            DropColumn("dbo.HumanTypes", "humanLikings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HumanTypes", "humanLikings", c => c.String());
            AddColumn("dbo.Humen", "HumanType", c => c.String());
            DropForeignKey("dbo.Humen", "HumanType_HumanTypeId", "dbo.HumanTypes");
            DropForeignKey("dbo.HumanTypeLikingHumanTypes", "HumanType_HumanTypeId", "dbo.HumanTypes");
            DropForeignKey("dbo.HumanTypeLikingHumanTypes", "HumanTypeLiking_humanTypeLikingId", "dbo.HumanTypeLikings");
            DropIndex("dbo.HumanTypeLikingHumanTypes", new[] { "HumanType_HumanTypeId" });
            DropIndex("dbo.HumanTypeLikingHumanTypes", new[] { "HumanTypeLiking_humanTypeLikingId" });
            DropIndex("dbo.Humen", new[] { "HumanType_HumanTypeId" });
            DropColumn("dbo.Humen", "HumanType_HumanTypeId");
            DropTable("dbo.HumanTypeLikingHumanTypes");
            DropTable("dbo.HumanTypeLikings");
        }
    }
}
