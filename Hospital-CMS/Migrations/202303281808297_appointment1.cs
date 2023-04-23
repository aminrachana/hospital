namespace Hospital_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointment1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "DoctorId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors", "DoctorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropColumn("dbo.Appointments", "DoctorId");
        }
    }
}
