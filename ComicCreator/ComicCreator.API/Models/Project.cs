using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicCreator.API.Models
{
    public class Project
    {
        public Project()
        {
            tiles = new List<Tile>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Category { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public virtual ICollection<Tile> tiles { get; set; }
    }
    public class Tile
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string URL { get; set; }
        public float PositionX = 0.0f;
        public float PositionY = 0.0f;
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public virtual Project Project { get; set; }
        public int OrderNumber { get; set; }
    }

    [JsonObject(Title = "Project")]
    public class GetProjectInfoVM
    {
        public GetProjectInfoVM(Project p)
        {
            Id = p.Id;
            Author = p.Author;
            Category = p.Category;
            Cover = p.Cover;
            DateCreated = p.DateCreated;
            DateUpdated = p.DateUpdated;
            tiles = p.tiles.Select(x => x.Id).ToList();
        }
        public GetProjectInfoVM()
        {
            tiles = new List<int>();


        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Category { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public virtual ICollection<int> tiles { get; set; }
    }

    [JsonObject(Title = "Tile")]
    public class GetTileInfoVM
    {
        public GetTileInfoVM(Tile p)
        {
            Id = p.Id;
            Caption = p.Caption;
            URL = p.URL;
            PositionX = p.PositionX;
            PositionY = p.PositionY;
            DateCreated = p.DateCreated;
            DateUpdated = p.DateUpdated;
            OrderNumber = p.OrderNumber;
            Project = p.project.Select(x => x.Id);
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Category { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public virtual int Project { get; set; }
    }
}
