namespace Hospital_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctorsupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "LicenceNo", c => c.Long(nullable: false));
            AlterColumn("dbo.Doctors", "ContactNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "ContactNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "LicenceNo", c => c.Int(nullable: false));
        }
    }
}
