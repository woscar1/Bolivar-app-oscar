using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
     public class SpotifyArtist
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Followers { get; set; }
        public string Popularity { get; set; }
        public string Type { get; set; }
    }

    public class SpotifyTrack
    {
        public string ID { get; set; }
        public string Name { get; set; }      
        public string Type { get; set; }  
    }

    public class SpotifyAlbum
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
    }

    public class SpotifyList
    {
        public List<SpotifyAlbum> SpotifyAlbum { get; set; }
        public List<SpotifyTrack> SpotifyTrack { get; set; }
        public List<SpotifyArtist> SpotifyArtist { get; set; }
    }
}