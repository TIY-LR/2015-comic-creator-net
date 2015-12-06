namespace ComicCreator.API.Models
{
    using Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ComicCreatorDB : DbContext
    {
        // Your context has been configured to use a 'ComicCreatorDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ComicCreator.API.Models.ComicCreatorDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ComicCreatorDB' 
        // connection string in the application configuration file.
        public ComicCreatorDB()
            : base("name=ComicCreatorDB")
        {
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComicCreatorDB, Configuration>());
        }

        public System.Data.Entity.DbSet<ComicCreator.API.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<ComicCreator.API.Models.Tile> Tiles { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}