namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nocar : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Humen", "car");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Humen", "car", c => c.Boolean(nullable: false));
        }
    }
}
