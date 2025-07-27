# Use Linux-based .NET 9.0 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage using .NET 9.0 SDK (Linux-based)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["ProductMicroService.API/ProductMicroService.API.csproj", "ProductMicroService.API/"]
COPY ["ProductMicroService.Application/ProductMicroService.Application.csproj", "ProductMicroService.Application/"]
COPY ["ProductMicroService.Domain/ProductMicroService.Domain.csproj", "ProductMicroService.Domain/"]
COPY ["ProductMicroService.Infrastructure/ProductMicroService.Infrastructure.csproj", "ProductMicroService.Infrastructure/"]

# Restore dependencies
RUN dotnet restore "ProductMicroService.API/ProductMicroService.API.csproj"

# Copy full source
COPY . .

# Set working directory to API project
WORKDIR "/src/ProductMicroService.API"

# Build the application
RUN dotnet build "ProductMicroService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the app
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProductMicroService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroService.API.dll"]
