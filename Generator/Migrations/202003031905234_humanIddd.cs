namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class humanIddd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Humen", "HumanType_HumanTypeId", "dbo.HumanTypes");
            DropIndex("dbo.Humen", new[] { "HumanType_HumanTypeId" });
            DropColumn("dbo.Humen", "HumanTypeId");
            RenameColumn(table: "dbo.Humen", name: "HumanType_HumanTypeId", newName: "HumanTypeId");
            AlterColumn("dbo.Humen", "HumanTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Humen", "HumanTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Humen", "HumanTypeId");
            AddForeignKey("dbo.Humen", "HumanTypeId", "dbo.HumanTypes", "HumanTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Humen", "HumanTypeId", "dbo.HumanTypes");
            DropIndex("dbo.Humen", new[] { "HumanTypeId" });
            AlterColumn("dbo.Humen", "HumanTypeId", c => c.Int());
            AlterColumn("dbo.Humen", "HumanTypeId", c => c.String());
            RenameColumn(table: "dbo.Humen", name: "HumanTypeId", newName: "HumanType_HumanTypeId");
            AddColumn("dbo.Humen", "HumanTypeId", c => c.String());
            CreateIndex("dbo.Humen", "HumanType_HumanTypeId");
            AddForeignKey("dbo.Humen", "HumanType_HumanTypeId", "dbo.HumanTypes", "HumanTypeId");
        }
    }
}
