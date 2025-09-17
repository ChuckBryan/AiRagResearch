## C# Coding Conventions

| Convention        | Description                                                                     |
| ----------------- | ------------------------------------------------------------------------------- |
| Field Naming      | Private fields use camelCase, no underscores. Public properties use PascalCase. |
| Namespaces        | Prefer file-scoped namespaces for all C# files.                                 |
| Comments          | Use XML documentation comments for public APIs.                                 |
| Consistency       | Follow .NET and project-specific style guidelines.                              |
| File Organization | One top-level type per file.                                                    |
| Usings            | Place 'using' directives outside namespace, sorted alphabetically.              |
| Bracing           | Allman style (braces on new lines).                                             |
| Access Modifiers  | Explicitly specify access modifiers.                                            |
| Nullability       | Use nullable reference types where appropriate.                                 |

## Simplicity-First Development Pattern

- Always start with the simplest working solution. For example, initially call the TMDB API directly from the web project to display movies.
- Once the basic functionality is complete and validated, incrementally refactor and improve:
  - Move API calls to a service layer or backend as needed
  - Add caching, authentication, error handling, and other enhancements
  - Refactor for maintainability, scalability, and security
- This approach ensures rapid progress, early feedback, and avoids over-engineering.
- Only add complexity when there is a clear need or benefit.

# Copilot Instructions (Concise)

- Accessibility: All new UI must be accessible. Always include alt text for images, ARIA roles/attributes for interactive elements, and follow WCAG guidelines for color contrast and keyboard navigation.
- Blazor Server for SSR, Blazor WASM for CSR; backend handles API and CRUD.
- Use `dotnet build`/`dotnet run` for build/run. Store secrets in `.env`, never commit API keys.
- Use Interactive Auto Render Mode: `dotnet new blazor --use-interactive-render-mode`.
- All config/secrets in `.env`; document keys in `default.env`.
- Use SQL Server (Docker) for watch list; query with SQL Server MCP Extension.
- TMDB API for movie data; store API key in env vars; use service layer and caching.
- Fast endpoints for popular movies/watch list; use caching; consider GraphQL for flexible queries.
- All API endpoints require authentication/authorization; validate/sanitize input; use HTTPS.
- Use feature branches, semantic commit messages (e.g., `feat:`, `fix:`, `docs:`), and small commits.
- Prompt Boost extension is always used for Copilot prompts.
- Document Blazor concepts, SSR/CSR, and architecture in comments/docs.
- Reference MCP Content7 docs for best practices.
