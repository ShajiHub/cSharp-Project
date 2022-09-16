
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieMatrix.Models;


namespace MovieMatrix.Pages {
    public class ActorModel : PageModel { 

      //  public string name;
        //castBio
        public string castName;
        public string castIDs;
        public string castPics;
        public string castBio;
        public string castDOB;
        public string castOrigin;
        public string castImg;
     //  public List<string> castImg = new List<string>();
        
        //
        public string movieTitle;
        public string tagline;
        public string homepage;
        public string moviePoster;

       


        public async Task OnGet(string id) {

            await Program.fetch.GetActorDetails(id);
        
                castName = Program.actor.name;
                castIDs = Program.actor.id.ToString();
                castPics = Program.actor.profile_path;
                castBio = Program.actor.biography;
                castDOB = Program.actor.birthday;
                castOrigin = Program.actor.place_of_birth;
            
        }


        public async Task GetActorImages(string id) {
            await Program.fetch.GetCast(id);
        //    foreach(Cast cast in Program.credits.cast){

            //foreach(Poster p in Program.posterSet.results)
             foreach(Profile profile in Program.profileSet.profiles){
              //  castNames.Add(cast.name);
               // castIDs.Add(cast.id.ToString());
                castImg = Program.profile.file_path;
            }
        }
            

        
    } // class
} // namespace

