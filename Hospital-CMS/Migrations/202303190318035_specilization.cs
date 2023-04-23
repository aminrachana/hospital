namespace Hospital_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class specilization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specilizations",
                c => new
                    {
                        SpecilizationId = c.Int(nullable: false, identity: true),
                        SpecilizationName = c.String(),
                    })
                .PrimaryKey(t => t.SpecilizationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Specilizations");
        }
    }
}
