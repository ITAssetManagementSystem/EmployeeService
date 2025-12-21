# Employee Service

## Purpose
Manages employees in IT Asset Management system.

## Tech Stack
- .NET 8
- PostgreSQL
- Entity Framework Core

## Run Locally
1. Install .NET 8 SDK
2. Create PostgreSQL DB
3. Run `dotnet run`

## APIs
- POST /employees
- GET /employees
- GET /employees/{code}

## Config
- Connection string via environment variables

## Cloud
Same container works in AKS with env-based config.
