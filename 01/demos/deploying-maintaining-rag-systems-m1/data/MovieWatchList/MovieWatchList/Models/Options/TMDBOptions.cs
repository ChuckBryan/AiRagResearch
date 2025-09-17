namespace MovieWatchList.Models.Options
{
    /// <summary>
    /// Options for TMDB API configuration.
    /// </summary>
    public class TMDBOptions
    {
        public string ApiKey { get; set; } = string.Empty;
        public string BaseUri { get; set; } = "https://api.themoviedb.org/3/";
    }
}
