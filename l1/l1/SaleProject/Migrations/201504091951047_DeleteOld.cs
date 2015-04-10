namespace SaleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteOld : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Posts", new[] { "BlogId" });
            CreateTable(
                "dbo.ArchiveSales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Client = c.String(),
                        Goods = c.String(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId);
            
            DropTable("dbo.Blogs");
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        display_name = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            DropTable("dbo.ArchiveSales");
            CreateIndex("dbo.Posts", "BlogId");
            AddForeignKey("dbo.Posts", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
        }
    }
}
