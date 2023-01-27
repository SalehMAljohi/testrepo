namespace WebSiteTemplete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContentName = c.String(),
                        ContentAName = c.String(),
                        ContentEName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PageDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        MediaTypeID = c.Int(),
                        PageID = c.Int(),
                        ContentID = c.Int(),
                        MediaSubTypeID = c.Int(),
                        TextTypeID = c.Int(),
                        ParaGraphesID = c.Int(),
                        TitleID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ContentInfoes", t => t.ContentID)
                .ForeignKey("dbo.MediaSubTypes", t => t.MediaSubTypeID)
                .ForeignKey("dbo.MediaTypes", t => t.MediaTypeID)
                .ForeignKey("dbo.PageInfoes", t => t.PageID)
                .ForeignKey("dbo.ParaGraphes", t => t.ParaGraphesID)
                .ForeignKey("dbo.TextTypes", t => t.TextTypeID)
                .ForeignKey("dbo.Titles", t => t.TitleID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.MediaTypeID)
                .Index(t => t.PageID)
                .Index(t => t.ContentID)
                .Index(t => t.MediaSubTypeID)
                .Index(t => t.TextTypeID)
                .Index(t => t.ParaGraphesID)
                .Index(t => t.TitleID);
            
            CreateTable(
                "dbo.PageInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PageName = c.String(),
                        PageAName = c.String(),
                        PageEName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageDetails", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PageDetails", "TitleID", "dbo.Titles");
            DropForeignKey("dbo.PageDetails", "TextTypeID", "dbo.TextTypes");
            DropForeignKey("dbo.PageDetails", "ParaGraphesID", "dbo.ParaGraphes");
            DropForeignKey("dbo.PageDetails", "PageID", "dbo.PageInfoes");
            DropForeignKey("dbo.PageDetails", "MediaTypeID", "dbo.MediaTypes");
            DropForeignKey("dbo.PageDetails", "MediaSubTypeID", "dbo.MediaSubTypes");
            DropForeignKey("dbo.PageDetails", "ContentID", "dbo.ContentInfoes");
            DropIndex("dbo.PageDetails", new[] { "TitleID" });
            DropIndex("dbo.PageDetails", new[] { "ParaGraphesID" });
            DropIndex("dbo.PageDetails", new[] { "TextTypeID" });
            DropIndex("dbo.PageDetails", new[] { "MediaSubTypeID" });
            DropIndex("dbo.PageDetails", new[] { "ContentID" });
            DropIndex("dbo.PageDetails", new[] { "PageID" });
            DropIndex("dbo.PageDetails", new[] { "MediaTypeID" });
            DropIndex("dbo.PageDetails", new[] { "UserId" });
            DropTable("dbo.PageInfoes");
            DropTable("dbo.PageDetails");
            DropTable("dbo.ContentInfoes");
        }
    }
}
