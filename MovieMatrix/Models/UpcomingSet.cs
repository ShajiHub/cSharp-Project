
using System.Collections.Generic;

namespace MovieMatrix.Models {

    public class UpcomingSet {
        public Dates dates { get; set; }
        public int page { get; set; }
        public List<Poster> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

     public class Dates {
        public string maximum { get; set; }
        public string minimum { get; set; }
    }
}