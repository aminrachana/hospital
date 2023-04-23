namespace Hospital_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PFName = c.String(),
                        PLName = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        HealthcardNo = c.String(),
                        ContactNo = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
