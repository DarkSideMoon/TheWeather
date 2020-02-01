namespace TheWeather.Service.Builder
{
    public interface IUrlBuilder
    {
        IUrlBuilder SetAppId(string apiKey);

        IUrlBuilder SetLanguage(string language);

        IUrlBuilder SetUnit(string unit);

        IUrlBuilder SetQueryParams(object values);

        string Build();
    }
}
