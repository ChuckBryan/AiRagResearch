using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MovieWatchList.Services;
using MovieWatchList.Models.Shared;
using System.Text.Json;

namespace MovieWatchList.Components.Shared
{
    public partial class MovieDetailBlade : ComponentBase
    {
        [Parameter]
        public int? MovieId { get; set; }
        [Parameter]
        public bool IsOpen { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }

        [Inject]
        private TmdbClient TmdbClient { get; set; } = default!;
        [Inject]
        private IJSRuntime JSRuntime { get; set; } = default!;

        private MovieDetailModel? movie;
        private bool previousIsOpen = false;
        private DotNetObjectReference<MovieDetailBlade>? objRef;
        private bool isJsInitialized = false;
        private ElementReference offcanvasRef;
        private int? lastLoadedMovieId;
        private string? director;
        private List<string>? topActors;
        private string? mpaaRating;

        protected override async Task OnParametersSetAsync()
        {
            Console.WriteLine($"MovieDetailBlade.OnParametersSetAsync - IsOpen: {IsOpen}, MovieId: {MovieId}");

            if (IsOpen && MovieId.HasValue)
            {
                try
                {
                    Console.WriteLine($"Fetching movie details for id {MovieId}...");
                    if (lastLoadedMovieId != MovieId)
                    {
                        // reset to show spinner when switching movies
                        movie = null;
                        director = null;
                        topActors = null;
                    }
                    // Fetch main details
                    movie = await TmdbClient.GetMovieDetailAsync(MovieId.Value);
                    if (movie != null)
                    {
                        Console.WriteLine($"Movie details loaded: {movie?.title}");
                        lastLoadedMovieId = MovieId;
                    }
                    // Fetch credits for director and actors
                    var credits = await TmdbClient.GetCreditsAsync(MovieId.Value);
                    if (credits != null)
                    {
                        director = credits.crew?.FirstOrDefault(c => c.job == "Director")?.name;
                        topActors = credits.cast?.OrderBy(a => a.order).Take(3).Select(a => a.name ?? string.Empty).ToList();
                        Console.WriteLine($"Director: {director}, Starring: {string.Join(", ", topActors ?? new List<string>())}");
                    }
                    // Fetch release info for MPAA rating
                    var releaseInfo = await TmdbClient.GetReleaseDatesAsync(MovieId.Value);
                    if (releaseInfo != null)
                    {
                        var usRelease = releaseInfo.results?.FirstOrDefault(r => r.iso_3166_1 == "US");
                        var cert = usRelease?.release_dates?.FirstOrDefault()?.certification;
                        if (!string.IsNullOrWhiteSpace(cert) && new[] { "G", "PG", "PG-13", "R", "X" }.Contains(cert))
                        {
                            mpaaRating = cert;
                        }
                        else
                        {
                            mpaaRating = null;
                        }
                        Console.WriteLine($"MPAA Rating: {mpaaRating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching movie details: {ex.Message}");
                }
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Console.WriteLine($"OnAfterRenderAsync - firstRender: {firstRender}, isOpen: {IsOpen}, previousIsOpen: {previousIsOpen}");

            // Initialize JS only when the blade is opening (avoids interop during initial load/prerender)
            if (!isJsInitialized && IsOpen)
            {
                try
                {
                    Console.WriteLine("Initializing offcanvas JS on open");
                    objRef ??= DotNetObjectReference.Create(this);
                    await JSRuntime.InvokeVoidAsync("initOffcanvas", objRef, offcanvasRef);
                    isJsInitialized = true;
                    Console.WriteLine("Offcanvas JS initialized");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Offcanvas JS init failed (will retry on next render): {ex.Message}");
                }
            }

            if (IsOpen != previousIsOpen)
            {
                previousIsOpen = IsOpen;
                Console.WriteLine($"IsOpen changed -> {IsOpen}");
            }
        }

        [JSInvokable]
        public async Task HandleOffcanvasHidden()
        {
            // This will be called when the offcanvas is hidden by Bootstrap
            Console.WriteLine("Offcanvas hidden event triggered");
            await OnClose.InvokeAsync();
        }

        private async Task CloseBlade()
        {
            await OnClose.InvokeAsync();
        }

    }
}
