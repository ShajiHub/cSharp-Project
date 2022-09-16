
using System.Net.Http;
using System.Threading.Tasks; // async & await!
using System.Text.Json; // JSON data
using MovieMatrix.Models;

namespace MovieMatrix {
    public class Fetch {
        public HttpClient client = new HttpClient();
        public const string API_KEY = "9a8fde2120e2062afc2f02945d1634e1";
        public string Data { get; set; }
        public string Videos { get; set; }
        public string Details { get; set; }
        public string Credits { get; set; }


        public async Task Upcoming() {
            ClearHeaders();

            // Does a movie search
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/upcoming?api_key=" + API_KEY + "&language=en-US&page=1");

            if(response.IsSuccessStatusCode) {
                // response.Headers.ToString();
                Data = await response.Content.ReadAsStringAsync();
                Program.upcomingSet = JsonSerializer.Deserialize<UpcomingSet>(Data);
            }
            else {
                Data = null;
            }
        }

        public async Task Search(string searchQuery) {
            ClearHeaders();

            // Does a movie search
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/search/movie?api_key=" + API_KEY + "&query=" + searchQuery);

            if(response.IsSuccessStatusCode) {
                // response.Headers.ToString();
                Data = await response.Content.ReadAsStringAsync();
                Program.posterSet = JsonSerializer.Deserialize<PosterSet>(Data);
            }
            else {
                Data = null;
            }
        } // Search()

        public async Task GetDetails(string movieID) {
            ClearHeaders();

            // Gets movie details
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" +
                    movieID + "?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                // response.Headers.ToString();
                Data = await response.Content.ReadAsStringAsync();
                Program.movie = JsonSerializer.Deserialize<Movie>(Data);
            }
            else {
                Data = null;
            }
        }

        public async Task GetCast(string movieID) {
            ClearHeaders();

            // Gets cast and crew for a movie
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" +
                    movieID + "/credits?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.credits = JsonSerializer.Deserialize<Credits>(Data);
            }
            else {
                Data = null;
            }
        }

        public async Task GetVideos(string movieID) {
            ClearHeaders();

            // Gets cast and crew for a movie
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" +
                    movieID + "/videos?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.videoSet = JsonSerializer.Deserialize<VideoSet>(Data);
            }
            else {
                Data = null;
            }
        }

        public async Task GetActorDetails(string castID) {
            // from the tmdb api: 
            // https://api.themoviedb.org/3/person/{person_id}?api_key=<<api_key>>&language=en-US
            ClearHeaders();

            // Gets cast and crew for a movie
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/person/" +
                    castID + "?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.actor = JsonSerializer.Deserialize<Actor>(Data);
            }
            else {
                Data = null;
            }
        }

        //actor more

            public async Task GetActorImages(string castID) {
            // from the tmdb api: 
            //https://api.themoviedb.org/3/person/10297/images?api_key=9a8fde2120e2062afc2f02945d1634e1
            ClearHeaders();

            // Gets cast and crew for a movie
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/person/" +
                    castID + "/images?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.profileSet = JsonSerializer.Deserialize<ProfileSet>(Data);
            }
            else {
                Data = null;
            }
        }




        public void ClearHeaders() {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(
                    "applicationException/json"));
        } // ClearHeaders()

    } // class
} // namespace