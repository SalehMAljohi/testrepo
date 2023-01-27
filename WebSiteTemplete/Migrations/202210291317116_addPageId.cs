namespace WebSiteTemplete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPageId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContentInfoes", "PageID", c => c.Int());
            CreateIndex("dbo.ContentInfoes", "PageID");
            AddForeignKey("dbo.ContentInfoes", "PageID", "dbo.PageInfoes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentInfoes", "PageID", "dbo.PageInfoes");
            DropIndex("dbo.ContentInfoes", new[] { "PageID" });
            DropColumn("dbo.ContentInfoes", "PageID");
        }
    }
}
