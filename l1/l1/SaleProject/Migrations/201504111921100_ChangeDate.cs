namespace SaleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArchiveRecords", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArchiveRecords", "Date", c => c.String());
        }
    }
}
