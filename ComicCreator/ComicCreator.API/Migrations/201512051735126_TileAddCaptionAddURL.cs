namespace ComicCreator.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TileAddCaptionAddURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tiles", "Caption", c => c.String());
            AddColumn("dbo.Tiles", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tiles", "URL");
            DropColumn("dbo.Tiles", "Caption");
        }
    }
}
