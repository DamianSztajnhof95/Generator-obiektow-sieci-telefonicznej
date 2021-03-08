namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class humantypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HumanTypes",
                c => new
                    {
                        HumanTypeId = c.Int(nullable: false, identity: true),
                        HumanTypeName = c.String(),
                        humanLikings = c.String(),
                    })
                .PrimaryKey(t => t.HumanTypeId);
            
            AddColumn("dbo.Humen", "HumanType_HumanTypeId", c => c.Int());
            CreateIndex("dbo.Humen", "HumanType_HumanTypeId");
            AddForeignKey("dbo.Humen", "HumanType_HumanTypeId", "dbo.HumanTypes", "HumanTypeId");
            DropColumn("dbo.Humen", "HumanType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Humen", "HumanType", c => c.String());
            DropForeignKey("dbo.Humen", "HumanType_HumanTypeId", "dbo.HumanTypes");
            DropIndex("dbo.Humen", new[] { "HumanType_HumanTypeId" });
            DropColumn("dbo.Humen", "HumanType_HumanTypeId");
            DropTable("dbo.HumanTypes");
        }
    }
}
