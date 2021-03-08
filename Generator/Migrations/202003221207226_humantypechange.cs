namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class humantypechange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Humen", "HumanTypeId", "dbo.HumanTypes");
            DropIndex("dbo.Humen", new[] { "HumanTypeId" });
            RenameColumn(table: "dbo.Humen", name: "HumanTypeId", newName: "humanType_HumanTypeId");
            AlterColumn("dbo.Humen", "humanType_HumanTypeId", c => c.Int());
            CreateIndex("dbo.Humen", "humanType_HumanTypeId");
            AddForeignKey("dbo.Humen", "humanType_HumanTypeId", "dbo.HumanTypes", "HumanTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Humen", "humanType_HumanTypeId", "dbo.HumanTypes");
            DropIndex("dbo.Humen", new[] { "humanType_HumanTypeId" });
            AlterColumn("dbo.Humen", "humanType_HumanTypeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Humen", name: "humanType_HumanTypeId", newName: "HumanTypeId");
            CreateIndex("dbo.Humen", "HumanTypeId");
            AddForeignKey("dbo.Humen", "HumanTypeId", "dbo.HumanTypes", "HumanTypeId", cascadeDelete: true);
        }
    }
}
