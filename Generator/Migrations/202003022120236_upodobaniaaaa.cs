namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upodobaniaaaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HumanTypeLikings", "HumanType_HumanTypeId", "dbo.HumanTypes");
            DropIndex("dbo.HumanTypeLikings", new[] { "HumanType_HumanTypeId" });
            RenameColumn(table: "dbo.HumanTypeLikings", name: "HumanType_HumanTypeId", newName: "humanTypeId");
            AlterColumn("dbo.HumanTypeLikings", "humanTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.HumanTypeLikings", "humanTypeId");
            AddForeignKey("dbo.HumanTypeLikings", "humanTypeId", "dbo.HumanTypes", "HumanTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HumanTypeLikings", "humanTypeId", "dbo.HumanTypes");
            DropIndex("dbo.HumanTypeLikings", new[] { "humanTypeId" });
            AlterColumn("dbo.HumanTypeLikings", "humanTypeId", c => c.Int());
            RenameColumn(table: "dbo.HumanTypeLikings", name: "humanTypeId", newName: "HumanType_HumanTypeId");
            CreateIndex("dbo.HumanTypeLikings", "HumanType_HumanTypeId");
            AddForeignKey("dbo.HumanTypeLikings", "HumanType_HumanTypeId", "dbo.HumanTypes", "HumanTypeId");
        }
    }
}
