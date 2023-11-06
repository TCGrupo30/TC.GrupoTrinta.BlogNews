# Diagram
---

## Overview
---

## Architecture
---

![Architecture](Docs/Architecture.jpg)

## Techical Stack
---
- ASP.NET Core 6.0 (with .NET 7.0)
- ASP.NET WebApi Core
- ASP.NET Identity Core
- Entity Framework Core
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI
- SQL Azure
- xUnit
- Moq
- Fluent Assertions
- Polly
- Refit
- DbUp

## Design Patterns
---
- Domain Driven Design
- CQRS
- Unit Of Work
- Repository & Generic Repository
- Inversion of Control / Dependency injection
- ORM
- Mediator
- Specification Pattern
- Options Pattern

## How to run
---

- For Visual Studio: `Select profile > Run (F5)`
- For VSCode: `Select configuration > Run (F5)`
- For Terminal:
```PowerShell

dotnet build src\TC.GrupoTrinta.BlogNews.Api\TC.GrupoTrinta.BlogNews.Api.csproj
dotnet run --project src\TC.GrupoTrinta.BlogNews.Api\TC.GrupoTrinta.BlogNews.Api.csproj --launch-profile http
dotnet watch --project src\TC.GrupoTrinta.BlogNews.Api\TC.GrupoTrinta.BlogNews.Api.csproj run
```

### Testing
---
- Terminal: `dotnet test`

### Docker
---
```Docker

docker build -t blognews-docker-image .
docker run -it --rm -p 3000:80 --env ASPNETCORE_ENVIRONMENT=Development --name blopnews-docker-container blognews-docker-image
docker run -dp 3000:80 --env ASPNETCORE_ENVIRONMENT=Development --name blognews-docker-container blognews-docker-image
```


###  Docker Compose
---
```Docker

docker-compose -f docker-compose-integration.yml up
```
