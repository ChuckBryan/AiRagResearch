namespace MovieWatchList.Models.Shared
{
    public class MovieDetailModel
    {
        public string? title { get; set; }
        public string? release_date { get; set; }
        public string? overview { get; set; }
        public string? poster_path { get; set; }
        public double? vote_average { get; set; }
    }
}
