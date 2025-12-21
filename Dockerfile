# =========================
# Stage 1: Build
# =========================
FROM maven:3.9.9-eclipse-temurin-17 AS builder
# (INTENTIONALLY NOT USED – .NET service)
# This stage is NOT required for .NET

# =========================
# Stage 1 (ACTUAL): Build .NET App
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY employee-service.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /app/publish


# =========================
# Stage 2: Runtime
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

# Run as non-root (production)
RUN useradd -m appuser
USER appuser

COPY --from=build /app/publish .

EXPOSE 8082

ENTRYPOINT ["dotnet", "employee-service.dll"]
