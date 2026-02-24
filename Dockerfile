# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj files and restore
COPY *.sln ./
COPY Api/Api.csproj Api/
COPY Application/Application.csproj Application/
COPY Core/Core.csproj Core/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish Api/Api.csproj -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Railway provides PORT environment variable
ENV ASPNETCORE_URLS=http://+:$PORT

ENTRYPOINT ["dotnet", "Api.dll"]