echo Start restore nuget packages
dotnet restore

echo Start build project
dotnet build

echo Run project
dotnet run --project ./TheWeather.Api/TheWeather.Api.csproj