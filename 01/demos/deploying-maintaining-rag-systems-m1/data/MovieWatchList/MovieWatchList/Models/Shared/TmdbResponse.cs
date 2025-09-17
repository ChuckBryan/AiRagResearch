using System.Collections.Generic;

namespace MovieWatchList.Models.Shared
{
    public class TmdbResponse
    {
        public List<Movie> results { get; set; } = new();
    }

    public class Movie
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? release_date { get; set; }
        public string? overview { get; set; }
        public string? poster_path { get; set; }
    }
}
