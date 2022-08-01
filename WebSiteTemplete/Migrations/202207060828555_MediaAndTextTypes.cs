namespace WebSiteTemplete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MediaAndTextTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MediaTypeName = c.String(),
                        MediaTypeAName = c.String(),
                        MediaTypeEName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TextTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TextTypeName = c.String(),
                        TextTypeAName = c.String(),
                        TextTypeEName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TextTypes");
            DropTable("dbo.MediaTypes");
        }
    }
}
