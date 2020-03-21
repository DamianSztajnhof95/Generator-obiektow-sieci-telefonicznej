namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HumanTypes", "color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HumanTypes", "color");
        }
    }
}
