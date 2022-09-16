
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieMatrix.Models;

namespace MovieMatrix.Pages {

    public class IndexModel : PageModel {        
        
        // Search:
        public List<string> posterURLs = new List<string>();
        public List<string> overviews = new List<string>();
        public List<string> movieIDs = new List<string>();
        
        public int UPCOMING_MAX_RESULTS = 0;
        public int MAX_RESULTS = 0;

        // Movie Details:
        public string movieTitle = "";
        public string tagline = "";
        public string homepage = "";
        public int budget;
        public long revenue;
        public string backdropPath = "";
        public string fullsizedPoster = "";
        public string releaseDate = "";
        public string overview = "";

        // Cast:
        public List<string> castNames = new List<string>();
        public List<string> castIDs = new List<string>();
        public List<string> castPics = new List<string>();

        public List<string> externalID = new List<string>();


        // Videos:
        public List<string> videoIDs = new List<string>();
        public int MAX_VIDEO_COUNT = 0;

        public async Task OnGet() {
            await Program.fetch.Upcoming();
            foreach(Poster upcoming in Program.upcomingSet.results) {
                posterURLs.Add(upcoming.poster_path);
                overviews.Add(upcoming.overview);
                movieIDs.Add(upcoming.id.ToString());
        
            }
            if(Program.upcomingSet.results.Count >= 10)
                UPCOMING_MAX_RESULTS = 10;
            else
                UPCOMING_MAX_RESULTS = Program.upcomingSet.results.Count;
        } // OnGet()

        public async Task OnPostSearch(string search) {
            await Program.fetch.Search(search);
            foreach(Poster p in Program.posterSet.results) {
                posterURLs.Add(p.poster_path);
                overviews.Add(p.overview);
                movieIDs.Add(p.id.ToString());
             
            }
            if(Program.posterSet.results.Count >= 10)
                MAX_RESULTS = 10;
            else
                MAX_RESULTS = Program.posterSet.results.Count;
        } // OnPostSearch()

        public async Task OnPostGetDetails(string movieID) {
            await Program.fetch.GetDetails(movieID);
            movieTitle = Program.movie.title;
            tagline = Program.movie.tagline;
            homepage = Program.movie.homepage;
            budget = Program.movie.budget;
            revenue = Program.movie.revenue;
            backdropPath = Program.movie.backdrop_path;
            fullsizedPoster = Program.movie.poster_path;
            releaseDate = Program.movie.release_date.Substring(0, 4);
            overview = Program.movie.overview;
            await GetCast(movieID);
            await GetVideos(movieID);
        } // OnPostGetDetails()

        public async Task GetCast(string movieID) {
            await Program.fetch.GetCast(movieID);
            foreach(Cast cast in Program.credits.cast){
                castNames.Add(cast.name);
                castIDs.Add(cast.id.ToString());
                castPics.Add(cast.profile_path);
                
              
            }
        } // GetCast()

        public async Task GetVideos(string movieID) {
            await Program.fetch.GetVideos(movieID);
            foreach (Video video in Program.videoSet.results) {
                videoIDs.Add(video.key);
            }
            if(videoIDs.Count >= 1)
                MAX_VIDEO_COUNT = 1;
            else
                MAX_VIDEO_COUNT = Program.posterSet.results.Count;
        } // GetCast()



        public void OnPostGetActorDetails(string castID) {
            Response.Redirect("./Actor?id=" + castID);
        } // OnPostGetActorDetails()

            
 
        
    } // class
} // namespace



  