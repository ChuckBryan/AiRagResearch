# Product Requirements Document (PRD)

## Movie Watch List (Tabular Format)

### 1. Overview
A web application for discovering popular movies and managing a personal watch list stored in SQL Server.

---

### 2. Goals & Features
| Goal/Feature                | Description                                                                                 |
|-----------------------------|---------------------------------------------------------------------------------------------|
| Movie Discovery             | Display popular/now playing movies from TMDb API                                            |
| Watch List Management       | Add, view, and remove movies from personal watch list (SQL Server)                          |
| Counter Component Refactor  | Refactor Counter page to use Blazor WASM + backend API for DB access                        |
| API Endpoints               | Implement endpoints for counter value get/update, watch list CRUD                           |
| Authentication & Security   | Secure API endpoints, require authentication, protect against vulnerabilities               |
| Responsive UI               | Desktop and mobile support                                                                  |
| Centralized Configuration   | Use .env for all environment variables, update onboarding docs                              |

---

### 3. TMDb API Integration
| Endpoint                        | Purpose/Usage                          | Auth Required |
|----------------------------------|----------------------------------------|---------------|
| GET /movie/now_playing           | List movies currently in theaters      | Yes           |
| GET /movie/popular               | List popular movies (fallback)         | Yes           |
| GET /movie/{movie_id}            | Get movie details                      | Yes           |
| GET /movie/{movie_id}/credits    | Get cast and crew                      | Yes           |
| GET /movie/{movie_id}/reviews    | Get reviews                            | Yes           |
| GET /configuration               | Get image base URLs/sizes              | Yes           |

Reference: [TMDb API Docs](https://developer.themoviedb.org/reference/intro/getting-started)

---

### 4. Watch List Data Model
| Field      | Type    | Description                |
|------------|---------|---------------------------|
| Movie ID   | int     | TMDb movie identifier     |
| Title      | string  | Movie title               |
| Metadata   | JSON    | Additional movie details  |

---

### 5. Security Requirements
| Requirement                                 | Details                                                      |
|---------------------------------------------|--------------------------------------------------------------|
| Auth & Authorization                        | All API endpoints require authentication                     |
| Input Validation                            | Validate/sanitize user input (client & server)               |
| Secure Config                               | Do not expose secrets/config to client                       |
| HTTPS                                       | All client-server communication must use HTTPS               |
| Least Privilege                             | Restrict DB/API access                                      |
| Dependency Updates                          | Regularly update dependencies for security                   |
| Logging & Monitoring                        | Log/monitor security events and errors                       |
| Web Vulnerabilities                         | Protect against SQLi, XSS, CSRF, etc.                       |

---

### 6. Configuration Strategy
| Aspect                | Approach/Tool                | Details                                                      |
|-----------------------|------------------------------|--------------------------------------------------------------|
| Centralized Config    | .env file                    | Store all env variables in root .env                         |
| Documentation         | default.env                  | Document available variables for contributors                |
| Docker Compose        | .env + ${KEY} syntax         | Pass env vars into containers                                |
| .NET Local Dev        | DotNetEnv NuGet              | Load .env variables in development                           |
| .NET Production       | Real env vars                | Use environment variables, not .env files                    |
| Config Access         | System.Environment           | Use GetEnvironmentVariable or config provider                |
| Static Config         | appsettings.json              | Only for non-secret, static config                           |

---

### 7. Non-Functional Requirements
| Requirement           | Details                                                          |
|----------------------|------------------------------------------------------------------|
| Responsive UI        | Works on desktop and mobile                                       |
| Fast Performance     | Fast loading and API response times                               |
| Secure Storage       | Securely store and access user data                               |

---

### 8. Open Questions
| Question                                         | Status/Notes                      |
|--------------------------------------------------|-----------------------------------|
| Does TMDb provide "currently playing" movies?    | Confirm via API docs              |
| Will user authentication be required?             | Yes (for API endpoints)           |
| Multi-user support or single user?                | TBD                              |
