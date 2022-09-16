using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieMatrix.Models;

namespace MovieMatrix
{
    public class Program
    {
        public static Fetch fetch = new Fetch();
        public static UpcomingSet upcomingSet = new UpcomingSet();
        public static PosterSet posterSet = new PosterSet();
        public static ProfileSet profileSet = new ProfileSet();
                public static Profile profile = new Profile();
        public static Movie movie = new Movie();
        public static Credits credits = new Credits();
        public static VideoSet videoSet = new VideoSet();
        public static Actor actor = new Actor();
        public static ActorMediaID mediaID = new ActorMediaID();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
