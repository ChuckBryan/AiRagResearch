using MovieWatchList.Client.Pages;
using MovieWatchList.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<MovieWatchList.Services.TmdbClient>(client =>
{
    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
});

// Register TMDBOptions using the options pattern
builder.Services.Configure<MovieWatchList.Models.Options.TMDBOptions>(
    builder.Configuration.GetSection("TMDB"));

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MovieWatchList.Client._Imports).Assembly);

app.Run();
