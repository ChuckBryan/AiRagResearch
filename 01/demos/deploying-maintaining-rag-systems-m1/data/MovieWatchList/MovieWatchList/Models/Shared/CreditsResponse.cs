namespace MovieWatchList.Models.Shared
{
    public class CreditsResponse
    {
        public List<CastMember>? cast { get; set; }
        public List<CrewMember>? crew { get; set; }
    }
}
