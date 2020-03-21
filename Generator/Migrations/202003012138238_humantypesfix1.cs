namespace Generator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class humantypesfix1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HumanTypes",
                c => new
                    {
                        HumanTypeId = c.Int(nullable: false, identity: true),
                        HumanTypeName = c.String(),
                        humanLikings = c.String(),
                    })
                .PrimaryKey(t => t.HumanTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HumanTypes");
        }
    }
}
