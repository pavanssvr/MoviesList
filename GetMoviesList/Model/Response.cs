using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GetMoviesList.Model
{
    public class Response
    {
        public List<Item> Items { get; set; }
       
    }

    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class Credits
    {
        public int Id { get; set; }
        public List<Casts> Cast { get; set; }
    }

    public class Casts
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Character { get; set; }

        //[JsonIgnore]
        public string known_for_department { get; set; }
        //[JsonIgnore]
        public int Order { get; set; }
    }

    public class MovieDetails
    {
        public Item Movie { get; set; }
        public IEnumerable<Casts> Credits { get; set; }
    }
}
