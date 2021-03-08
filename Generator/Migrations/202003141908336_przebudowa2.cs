namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przebudowa2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Steps", "actualTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Steps", "actualTime");
        }
    }
}
