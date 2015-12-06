﻿using Newtonsoft.Json;
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
        public string  Author { get; set; }
        public string Cover { get; set; }
        public string Category { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public virtual ICollection<Tile> tiles {get; set;}
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
        public Project Project { get; set; }
        public int OrderNumber { get; set; }
    }

    [JsonObject("Project")]
    public class GetProjectInfoVM
    {
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
}