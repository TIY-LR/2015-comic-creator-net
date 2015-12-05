namespace ComicCreator.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryandCover : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Cover", c => c.String());
            AddColumn("dbo.Projects", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Category");
            DropColumn("dbo.Projects", "Cover");
        }
    }
}
