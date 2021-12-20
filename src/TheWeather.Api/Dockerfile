FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/TheWeather.Api/TheWeather.Api.csproj", "src/TheWeather.Api/"]
COPY ["src/TheWeather.Service/TheWeather.Service.csproj", "src/TheWeather.Service/"]
COPY ["src/TheWeather.Model/TheWeather.Model.csproj", "src/TheWeather.Model/"]
RUN dotnet restore "src/TheWeather.Api/TheWeather.Api.csproj"

COPY . .
WORKDIR "/src/src/TheWeather.Api"
RUN dotnet build "TheWeather.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheWeather.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheWeather.Api.dll"]