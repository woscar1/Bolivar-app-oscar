using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class SpotifySearch
    {
       public class Followers
        {
            public int Total { get; set; }
        }

        public class ImageSP
        {
            public string url { get; set; }            
        }

        public class Item
        {
            public Followers followers { get; set; }
            public string id { get; set; }
            public List<ImageSP> images { get; set; }
            public string name { get; set; }
            public int popularity { get; set; }
            public string type { get; set; }
         
        }

        public class Artists
        {
            public string href { get; set; }
            public List<Item> items { get; set; }
            public int limit { get; set; }
            public string next { get; set; }
            public int offset { get; set; }
            public object previous { get; set; }
            public int total { get; set; }
        }

        public class Tracks
        {
            public string href { get; set; }
            public List<Item> items { get; set; }
            public int limit { get; set; }            
        }

        public class Album
        {
            public string href { get; set; }
            public List<Item> items { get; set; }
            public int limit { get; set; }
            public string next { get; set; }
            public int offset { get; set; }
            public object previous { get; set; }
            public int total { get; set; }
        }

        public class SpotifyResult
        {
            public Artists artists { get; set; }
            public Tracks tracks { get; set; }
            public Album albums { get; set; }

        }
    }
}