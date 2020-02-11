namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locomotion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Humen", "car", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Humen", "car");
        }
    }
}
