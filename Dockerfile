# مرحله اول: Base Image برای اجرا
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# مرحله دوم: Build Image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# کپی csproj ها (برای کش بهتر)
COPY ["ProductMicroService/ProductMicroService.API/ProductMicroService.API.csproj", "ProductMicroService.API/"]
COPY ["ProductMicroService/ProductMicroService.Application/ProductMicroService.Application.csproj", "ProductMicroService.Application/"]
COPY ["ProductMicroService/ProductMicroService.Domain/ProductMicroService.Domain.csproj", "ProductMicroService.Domain/"]
COPY ["ProductMicroService/ProductMicroService.Infrastructure/ProductMicroService.Infrastructure.csproj", "ProductMicroService.Infrastructure/"]
COPY ["ProductMicroService/ProductMicroService.Utilities/ProductMicroService.Utilities.csproj", "ProductMicroService.Utilities/"]

# بازیابی پکیج‌ها
RUN dotnet restore "ProductMicroService.API/ProductMicroService.API.csproj"

# کپی کامل سورس کد
COPY . .

# مسیر کاری پروژه API
WORKDIR "/src/ProductMicroService.API"

# بیلد پروژه
RUN dotnet build "ProductMicroService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# مرحله سوم: Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProductMicroService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# مرحله نهایی: Runtime Image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroService.API.dll"]
