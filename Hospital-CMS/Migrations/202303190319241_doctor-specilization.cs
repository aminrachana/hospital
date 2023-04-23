namespace Hospital_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctorspecilization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "SpecilizationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "SpecilizationId");
            AddForeignKey("dbo.Doctors", "SpecilizationId", "dbo.Specilizations", "SpecilizationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecilizationId", "dbo.Specilizations");
            DropIndex("dbo.Doctors", new[] { "SpecilizationId" });
            DropColumn("dbo.Doctors", "SpecilizationId");
        }
    }
}
