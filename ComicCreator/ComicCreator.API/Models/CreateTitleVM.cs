using Newtonsoft.Json;

namespace ComicCreator.API.Models
{
    [JsonObject(Title = "tile")] 
    public class CreateTitleVM
    {
        public int Project
        {
            get; set;
        }
        public string Caption
        {
            get; set;
        }

        public int OrderNumber
        {
            get; set;
        }

        public string URL
        {
            get; set;
        }
       
    }
}