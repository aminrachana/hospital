namespace Hospital_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departmentdonor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        Service = c.String(),
                        DonorID = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Donors", t => t.DonorID, cascadeDelete: true)
                .Index(t => t.DonorID)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        DonorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Contact = c.Int(nullable: false),
                        Address = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DonorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "DonorID", "dbo.Donors");
            DropForeignKey("dbo.Departments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Departments", new[] { "DoctorId" });
            DropIndex("dbo.Departments", new[] { "DonorID" });
            DropTable("dbo.Donors");
            DropTable("dbo.Departments");
        }
    }
}
