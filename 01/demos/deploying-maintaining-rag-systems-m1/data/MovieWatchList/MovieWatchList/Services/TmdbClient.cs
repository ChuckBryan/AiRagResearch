
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MovieWatchList.Models.Options;
using MovieWatchList.Models.Shared;

namespace MovieWatchList.Services
{
    /// <summary>
    /// Typed HttpClient for TMDB API requests (now playing, details, etc).
    /// </summary>
    public class TmdbClient
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBOptions _options;

        public TmdbClient(HttpClient httpClient, IOptions<TMDBOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
            if (!string.IsNullOrWhiteSpace(_options.BaseUri))
            {
                _httpClient.BaseAddress = new System.Uri(_options.BaseUri);
            }
        }

        public async Task<TmdbResponse?> GetNowPlayingMoviesAsync(int page = 1)
        {
            var url = $"movie/now_playing?api_key={_options.ApiKey}&language=en-US&page={page}";
            return await _httpClient.GetFromJsonAsync<TmdbResponse>(url);
        }

        public async Task<MovieDetailModel?> GetMovieDetailAsync(int id)
        {
            var url = $"movie/{id}?api_key={_options.ApiKey}&language=en-US";
            return await _httpClient.GetFromJsonAsync<MovieDetailModel>(url);
        }

        public async Task<CreditsResponse?> GetCreditsAsync(int movieId)
        {
            var url = $"movie/{movieId}/credits?api_key={_options.ApiKey}&language=en-US";
            return await _httpClient.GetFromJsonAsync<CreditsResponse>(url);
        }

        public async Task<ReleaseDatesResponse?> GetReleaseDatesAsync(int movieId)
        {
            var url = $"movie/{movieId}/release_dates?api_key={_options.ApiKey}";
            return await _httpClient.GetFromJsonAsync<ReleaseDatesResponse>(url);
        }
    }
}
