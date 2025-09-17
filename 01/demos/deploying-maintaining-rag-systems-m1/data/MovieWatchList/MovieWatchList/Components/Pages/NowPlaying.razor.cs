using Microsoft.AspNetCore.Components;
using MovieWatchList.Services;
using System.Text.Json;
using MovieWatchList.Models.Shared;

namespace MovieWatchList.Components.Pages
{
    public partial class NowPlaying : ComponentBase
    {
        [Inject]
        private TmdbClient TmdbClient { get; set; } = default!;

        private int? selectedMovieId;
        private bool isBladeOpen;
        private List<Movie>? movies;

        private void ShowBlade(int movieId)
        {
            Console.WriteLine($"ShowBlade called with movieId: {movieId}");
            selectedMovieId = movieId;
            isBladeOpen = true;
            Console.WriteLine($"After setting isBladeOpen: {isBladeOpen}, selectedMovieId: {selectedMovieId}");
            StateHasChanged();
        }

        private void CloseBlade()
        {
            isBladeOpen = false;
            selectedMovieId = null;
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            var tmdbResponse = await TmdbClient.GetNowPlayingMoviesAsync();
            movies = tmdbResponse?.results ?? new List<Movie>();
        }

        // ...existing code...
    }
}
