namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class humanId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HumanTypes", "HumanId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HumanTypes", "HumanId");
        }
    }
}
