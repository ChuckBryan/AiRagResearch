# Movie Details Blade (Offcanvas) - Technical Overview

## Purpose

The Movie Details Blade provides a modern, interactive slide-out panel ("blade") for displaying detailed information about a selected movie. It uses Bootstrap's Offcanvas component for a responsive, accessible UI and is integrated with Blazor Server for secure data fetching and robust SSR/CSR support.

## Architecture

- **Component:** `MovieDetailBlade.razor` (Blazor Razor Component)
- **UI Framework:** Bootstrap Offcanvas
- **Interop:** JavaScript interop for event handling and Offcanvas control
- **Data Source:** TMDB API (via server-side HttpClient)
- **Parent:** Used in `NowPlaying.razor` to show details for a selected movie

## How It Works

### 1. Triggering the Blade

- The movie grid in `NowPlaying.razor` displays movie posters as Bootstrap cards.
- Clicking a card sets the selected movie ID and opens the blade by toggling a boolean (`isBladeOpen`).
- The card also includes Bootstrap's data attributes (`data-bs-toggle="offcanvas"`, `data-bs-target="#movieDetailOffcanvas"`) to trigger the Offcanvas via Bootstrap's data API.

### 2. Blade Component Lifecycle

- The blade is rendered as a Bootstrap Offcanvas panel, anchored to the right side of the viewport.
- The component receives three parameters:
  - `MovieId`: The ID of the selected movie
  - `IsOpen`: Boolean indicating if the blade should be open
  - `OnClose`: Event callback to notify parent when the blade is closed

### 3. Data Fetching

- When `IsOpen` and `MovieId` are set, the blade fetches movie details from the TMDB API using server-side HttpClient.
- The API key is securely stored in configuration and never exposed to the client.
- While data is loading, a Bootstrap spinner is shown.
- Once loaded, the blade displays the movie poster, title, release date, rating, and summary.

### 4. Offcanvas Control & JS Interop

- The blade uses JavaScript interop to initialize the Offcanvas and listen for the `hidden.bs.offcanvas` event.
- When the Offcanvas is closed (via the close button or outside click), the JS event triggers a C# callback (`HandleOffcanvasHidden`), which updates the parent state.
- The close button uses both Bootstrap's `data-bs-dismiss="offcanvas"` and a Blazor event callback for robust closing behavior.

### 5. SSR/CSR Compatibility

- The blade is designed to work with Blazor Server's SSR and interactive rendering modes.
- JS interop is gated to only run after hydration and when the blade is actually opening, preventing errors during prerender.
- All data fetching is server-side, so API keys remain secure and requests are not visible in the browser's network tab.

## Key Files

- `Components/Pages/NowPlaying.razor`: Movie grid, blade trigger, state management
- `Components/Shared/MovieDetailBlade.razor`: Offcanvas blade, data fetch, interop
- `wwwroot/js/offcanvas.js`: JS interop for Offcanvas control and event handling

## Error Handling & Logging

- Console logging is used for lifecycle events, data fetches, and interop errors.
- The blade resets its state and spinner when switching movies.
- Robust error handling ensures the UI remains stable even if the TMDB API fails or is misconfigured.

## Extensibility

- The blade can be extended to show additional movie info, actions (e.g., add to watchlist), or related content.
- The architecture supports swapping to a modal, drawer, or other UI pattern with minimal changes.

---

For further details, see the source code in the referenced files or contact the project maintainer.
