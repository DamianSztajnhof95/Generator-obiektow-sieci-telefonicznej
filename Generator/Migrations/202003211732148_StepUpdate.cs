namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StepUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Duration2", "StepId", c => c.Int(nullable: false));
            AddColumn("dbo.EndLocation2", "StepId", c => c.Int(nullable: false));
            AddColumn("dbo.StartLocation2", "StepId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StartLocation2", "StepId");
            DropColumn("dbo.EndLocation2", "StepId");
            DropColumn("dbo.Duration2", "StepId");
        }
    }
}
