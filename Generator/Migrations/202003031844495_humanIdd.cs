namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class humanIdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Humen", "HumanTypeId", c => c.String());
            DropColumn("dbo.HumanTypes", "HumanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HumanTypes", "HumanId", c => c.Int(nullable: false));
            DropColumn("dbo.Humen", "HumanTypeId");
        }
    }
}
