using API.Entities;
using System.Text;
using static API.Entities.SpotifySearch;
using Newtonsoft.Json;
using RestSharp;

namespace API.conectionsSpotify
{
    public class Conection
    {
        /// <summary>
        /// objeto que devuelve el servico de token de spotify
        /// </summary>
        public static Token token { get; set; }

        /// <summary>
        /// retorna token
        /// </summary>
        /// <returns>el token</returns>
        public static string Token(){
            if(token == null) return "No se genero token";
            return token.access_token;
        }

        /// <summary>
        /// genera el token 
        /// </summary>
        /// <returns></returns>
        public static async Task GetTokenAsync() 
        {
            #region SecretVault
            string clientID = "3ba79cb151694effaed0fe412c708a13";

            string clientSecret = "c981acbb0d1144de8b3bc804c41847b0";
            #endregion

            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(clientID + ":" + clientSecret));

            List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            };

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");
            HttpContent content = new FormUrlEncodedContent(args);

            HttpResponseMessage resp = await client.PostAsync("https://accounts.spotify.com/api/token", content);
            string msg = await resp.Content.ReadAsStringAsync();

            token = JsonConvert.DeserializeObject<Token>(msg);           
            
        }

        /// <summary>
        /// Busca en la BD de spty por artista, album o canción
        /// </summary>
        /// <param name="searchWord"> palabra para buscar</param>
        /// <returns></returns>
        public static SpotifyResult SearchSpotify(string searchWord)
        {
            
            var client = new RestClient("https://api.spotify.com/v1/search?offset=0&limit=7");
            client.AddDefaultHeader("Authorization", $"Bearer {token.access_token}");
            var request = new RestRequest($"?q={searchWord}&type=artist,album,track", Method.Get);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<SpotifyResult>(response.Content);
                return result;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// arma el objeto con los artistas, albumes y canciones
        /// </summary>
        /// <param name="buscar"></param>
        /// <returns></returns>
        public static List<SpotifyList> TxtSearch_SpotifyList(string buscar)
        {

             var result = SearchSpotify(buscar);

            if (result == null)
            {
                return null;
            }
           
            var spotifyAlbum = TxtSearch_Album(result.albums.items);
            var spotifyTrack = TxtSearch_Track(result.tracks.items);
            var spotifyArtist = TxtSearch_Artist(result.artists.items);

            var listSpoty = new List<SpotifyList>(); 

            var SpotifyList = new SpotifyList
            {
                SpotifyAlbum = spotifyAlbum,
                SpotifyTrack = spotifyTrack,
                SpotifyArtist = spotifyArtist
            };

            listSpoty.Add(SpotifyList);

            return listSpoty;
        }

        /// <summary>
        /// arma el objeto con los albumes
        /// </summary>
        /// <param name="albumItems">busca por album </param>
        /// <returns></returns>
        public static List<SpotifyAlbum> TxtSearch_Album(List<Item> albumItems)
        {          
            var listAlbum = new List<SpotifyAlbum>();

            foreach (var item in albumItems)
            {
                listAlbum.Add(new SpotifyAlbum()
                {
                    ID = item.id,
                    Image = item.images.Any() ? item.images[0].url : "https://user-images.githubusercontent.com/24848110/33519396-7e56363c-d79d-11e7-969b-09782f5ccbab.png",
                    Name = item.name,
                    Type = item.type                 
                });
            }

            return listAlbum;
        }

        /// <summary>
        /// arma el objeto con los artistas
        /// </summary>
        /// <param name="artistItems">busca por artista</param>
        /// <returns></returns>
        public static List<SpotifyArtist> TxtSearch_Artist(List<Item> artistItems)
        {
            
            var listArtist = new List<SpotifyArtist>();

            foreach (var item in artistItems)
            {
                listArtist.Add(new SpotifyArtist()
                {
                    ID = item.id,
                    Image = item.images.Any() ? item.images[0].url : "https://user-images.githubusercontent.com/24848110/33519396-7e56363c-d79d-11e7-969b-09782f5ccbab.png",
                    Name = item.name,
                    Popularity = $"{item.popularity}% popularidad",
                    Type = item.type                   
                });
            }
            
            return listArtist;
        }

        /// <summary>
        /// arma el objeto con las canciones
        /// </summary>
        /// <param name="trackItems">busca por cancion </param>
        /// <returns></returns>
        public static List<SpotifyTrack> TxtSearch_Track(List<Item> trackItems)
        {

            var listtrack = new List<SpotifyTrack>();

            foreach (var item in trackItems)
            {
                listtrack.Add(new SpotifyTrack()
                {
                    ID = item.id,
                    Name = item.name,
                    Type = item.type                     
                });
            }

            return listtrack;
        }           
    }
}