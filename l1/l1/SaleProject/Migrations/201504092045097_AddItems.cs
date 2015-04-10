namespace SaleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItems : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ArchiveSales", newName: "ArchiveRecords");
            AlterColumn("dbo.ArchiveRecords", "Date", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArchiveRecords", "Date", c => c.String());
            RenameTable(name: "dbo.ArchiveRecords", newName: "ArchiveSales");
        }
    }
}
