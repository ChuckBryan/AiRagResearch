namespace MovieWatchList.Models.Shared
{
    public class ReleaseResult
    {
        public string? iso_3166_1 { get; set; }
        public List<ReleaseDateInfo>? release_dates { get; set; }
    }
}
