namespace WebSiteTemplete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MediaSubTypeAndTitleAndParagraph : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaSubTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        url = c.String(),
                        UserId = c.String(maxLength: 128),
                        MediaTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MediaTypes", t => t.MediaTypeID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.MediaTypeID);
            
            CreateTable(
                "dbo.ParaGraphes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParaGrapheName = c.String(),
                        ParaGrapheAName = c.String(),
                        ParaGrapheEName = c.String(),
                        UserId = c.String(maxLength: 128),
                        TextTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TextTypes", t => t.TextTypeID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TextTypeID);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TitleName = c.String(),
                        TitleAName = c.String(),
                        TitleEName = c.String(),
                        UserId = c.String(maxLength: 128),
                        TextTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TextTypes", t => t.TextTypeID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TextTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Titles", "TextTypeID", "dbo.TextTypes");
            DropForeignKey("dbo.ParaGraphes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ParaGraphes", "TextTypeID", "dbo.TextTypes");
            DropForeignKey("dbo.MediaSubTypes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MediaSubTypes", "MediaTypeID", "dbo.MediaTypes");
            DropIndex("dbo.Titles", new[] { "TextTypeID" });
            DropIndex("dbo.Titles", new[] { "UserId" });
            DropIndex("dbo.ParaGraphes", new[] { "TextTypeID" });
            DropIndex("dbo.ParaGraphes", new[] { "UserId" });
            DropIndex("dbo.MediaSubTypes", new[] { "MediaTypeID" });
            DropIndex("dbo.MediaSubTypes", new[] { "UserId" });
            DropTable("dbo.Titles");
            DropTable("dbo.ParaGraphes");
            DropTable("dbo.MediaSubTypes");
        }
    }
}
