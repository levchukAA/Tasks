namespace SaleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Example : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArchiveRecords", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArchiveRecords", "Date", c => c.Int(nullable: false));
        }
    }
}
