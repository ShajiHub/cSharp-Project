
using System.Collections.Generic;

namespace MovieMatrix.Models {

    public class PosterSet {
        public int page { get; set; }
        public List<Poster> results { get; set; } // a collection of Poster objects
        public int total_pages { get; set; }
        public int total_results { get; set; }
    } // class
} // namespace