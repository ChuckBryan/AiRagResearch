# TMDB API Capabilities & Reference

This document summarizes the main features, endpoints, and usage patterns of The Movie Database (TMDB) API for rapid development and future reference.

---

## Authentication & Sessions

- **API Key**: Required for all requests. Store securely (e.g., dotnet user-secrets).
- **Session Management**:
  - Create/validate/delete sessions (user, guest, v4 token, login)
  - Request tokens for user authentication
- **Account Details**: Get public account info

## Account Features

- **Favorites**:
  - Add/remove favorite movies/TV
  - List favorite movies/TV
- **Watchlist**:
  - Add/remove movies/TV to watchlist
  - List watchlist movies/TV
- **Lists**:
  - Create, update, delete custom lists
  - Add/remove movies to lists
  - Get user lists
- **Ratings**:
  - Add/delete ratings for movies, TV, episodes
  - List rated movies/TV/episodes

## Movies

- **Discovery**:
  - Now Playing, Popular, Top Rated, Upcoming
  - Search by title, genre, keyword
- **Details**:
  - Movie details, credits, images, videos, reviews, recommendations, similar
  - Release dates, alternative titles, external IDs, keywords
  - Account states (favorite, watchlist, rated)
- **Lists**:
  - Get lists containing a movie
- **Watch Providers**:
  - Streaming providers by region

## TV Series

- **Discovery**:
  - Airing Today, On The Air, Popular, Top Rated
  - Search by title, genre, keyword
- **Details**:
  - Series, season, episode details
  - Credits, images, videos, reviews, recommendations, similar
  - Content ratings, episode groups, external IDs, keywords
  - Account states (favorite, watchlist, rated)
- **Watch Providers**:
  - Streaming providers by region

## People

- **Details**:
  - Person details, images, external IDs
  - Movie/TV credits, combined credits
  - Popular people

## Search & Trending

- **Search**:
  - Multi-type search (movie, TV, person)
  - Search by collection, company, keyword
- **Trending**:
  - Daily/weekly trending for all, movies, TV, people

## Configuration & Static Data

- **Configuration**:
  - Get image base URLs, sizes
  - Supported languages, countries, jobs, timezones
- **Certifications**:
  - Movie/TV certifications by country
- **Genres**:
  - List genres for movies/TV
- **Keywords**:
  - List/search keywords

## Change Tracking

- **Changes**:
  - Track changes for movies, TV, people

## Error Handling & Rate Limiting

- **Errors**:
  - Standardized error responses
- **Rate Limiting**:
  - API usage limits; see docs for details

---

## Usage Tips

- Always use HTTPS and secure your API key.
- Use pagination for large result sets.
- Use language and region parameters for localization.
- For authenticated endpoints, use session tokens.
- See [TMDB Docs](https://developer.themoviedb.org/docs) for full details and updates.

---

## Useful Endpoints (Examples)

| Category | Endpoint (Method)                    | Purpose                 |
| -------- | ------------------------------------ | ----------------------- |
| Movies   | /movie/now_playing (GET)             | List now playing movies |
| Movies   | /movie/popular (GET)                 | List popular movies     |
| Movies   | /movie/{id} (GET)                    | Get movie details       |
| TV       | /tv/popular (GET)                    | List popular TV shows   |
| TV       | /tv/{id} (GET)                       | Get TV show details     |
| People   | /person/popular (GET)                | List popular people     |
| People   | /person/{id} (GET)                   | Get person details      |
| Account  | /account/{id}/favorite (POST)        | Add favorite            |
| Account  | /account/{id}/watchlist (POST)       | Add to watchlist        |
| Lists    | /list (POST/GET/DELETE)              | Manage custom lists     |
| Ratings  | /movie/{id}/rating (POST/DELETE)     | Add/delete movie rating |
| Search   | /search/movie (GET)                  | Search movies           |
| Trending | /trending/{type}/{time_window} (GET) | Get trending items      |
| Config   | /configuration (GET)                 | Get API config info     |

---

## References

- [TMDB API Docs](https://developer.themoviedb.org/docs)
- [API Reference](https://developer.themoviedb.org/reference)
- [Changelog](https://developer.themoviedb.org/changelog)
- [Support Forum](https://www.themoviedb.org/talk/category/5047958519c29526b50017d6)

---

For full endpoint details, parameters, and response formats, see the official TMDB documentation.
