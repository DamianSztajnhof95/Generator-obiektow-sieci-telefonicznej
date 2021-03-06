﻿namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przebudowa23 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Duration2", "StepId");
            DropColumn("dbo.EndLocation2", "StepId");
            DropColumn("dbo.StartLocation2", "StepId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StartLocation2", "StepId", c => c.Int(nullable: false));
            AddColumn("dbo.EndLocation2", "StepId", c => c.Int(nullable: false));
            AddColumn("dbo.Duration2", "StepId", c => c.Int(nullable: false));
        }
    }
}
