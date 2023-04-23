namespace Hospital_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointment2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "RoomId");
            AddForeignKey("dbo.Appointments", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Appointments", new[] { "RoomId" });
            DropColumn("dbo.Appointments", "RoomId");
        }
    }
}
