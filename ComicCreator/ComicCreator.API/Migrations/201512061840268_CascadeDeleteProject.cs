namespace ComicCreator.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDeleteProject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tiles", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Tiles", new[] { "Project_Id" });
            AlterColumn("dbo.Tiles", "Project_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tiles", "Project_Id");
            AddForeignKey("dbo.Tiles", "Project_Id", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tiles", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Tiles", new[] { "Project_Id" });
            AlterColumn("dbo.Tiles", "Project_Id", c => c.Int());
            CreateIndex("dbo.Tiles", "Project_Id");
            AddForeignKey("dbo.Tiles", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
