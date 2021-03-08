namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class humantypesfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Humen", "HumanType_HumanTypeId", "dbo.HumanTypes");
            DropIndex("dbo.Humen", new[] { "HumanType_HumanTypeId" });
            AddColumn("dbo.Humen", "HumanType", c => c.String());
            DropColumn("dbo.Humen", "HumanType_HumanTypeId");
            DropTable("dbo.HumanTypes");
        }
        
        public override void Down()
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
            DropColumn("dbo.Humen", "HumanType");
            CreateIndex("dbo.Humen", "HumanType_HumanTypeId");
            AddForeignKey("dbo.Humen", "HumanType_HumanTypeId", "dbo.HumanTypes", "HumanTypeId");
        }
    }
}
