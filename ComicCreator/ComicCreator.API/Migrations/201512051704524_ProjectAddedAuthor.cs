namespace ComicCreator.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectAddedAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Author");
        }
    }
}
