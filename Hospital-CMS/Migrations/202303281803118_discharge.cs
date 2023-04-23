namespace Hospital_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discharge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discharges",
                c => new
                    {
                        DischargeId = c.Int(nullable: false, identity: true),
                        CheckOut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DischargeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Discharges");
        }
    }
}
