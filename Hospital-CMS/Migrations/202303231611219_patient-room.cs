namespace Hospital_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientroom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "RoomId");
            AddForeignKey("dbo.Patients", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Patients", new[] { "RoomId" });
            DropColumn("dbo.Patients", "RoomId");
        }
    }
}
