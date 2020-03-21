namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locomotionType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Humen", "LocomotionType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Humen", "LocomotionType");
        }
    }
}
