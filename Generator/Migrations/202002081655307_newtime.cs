namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Humen",
               c => new
               {
                   HumanId = c.Int(nullable: false, identity: true),
                   HumanType = c.String(),
               })
               .PrimaryKey(t => t.HumanId);

            CreateTable(
                "dbo.Pozycjas",
                c => new
                {
                    PozycjaId = c.Int(nullable: false, identity: true),
                    Lat = c.Double(nullable: false),
                    Lng = c.Double(nullable: false),
                    actualTime = c.Time(nullable: false),
                    HumanId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PozycjaId)
                .ForeignKey("dbo.Humen", t => t.HumanId, cascadeDelete: true)
                .Index(t => t.HumanId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Pozycjas", "HumanId", "dbo.Humen");
            DropIndex("dbo.Pozycjas", new[] { "HumanId" });
            DropTable("dbo.Pozycjas");
            DropTable("dbo.Humen");
            DropTable("dbo.Miejsces");
        }
    
}
}
