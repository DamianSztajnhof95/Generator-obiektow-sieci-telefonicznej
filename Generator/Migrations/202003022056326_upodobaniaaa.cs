namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upodobaniaaa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HumanTypeLikings", "probability", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HumanTypeLikings", "probability", c => c.String());
        }
    }
}
