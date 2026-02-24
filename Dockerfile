# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy only the project files needed (not Tests)
COPY Api/Api.csproj Api/
COPY Application/Application.csproj Application/
COPY Core/Core.csproj Core/
COPY Infrastructure/Infrastructure.csproj Infrastructure/

# Restore just the Api project (it will restore dependencies automatically)
WORKDIR /app/Api
RUN dotnet restore

# Copy source code (exclude Tests folder)
WORKDIR /app
COPY Api/ Api/
COPY Application/ Application/
COPY Core/ Core/
COPY Infrastructure/ Infrastructure/

# Build and publish
WORKDIR /app/Api
RUN dotnet publish -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Expose port (Railway sets this via environment variable)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Api.dll"]