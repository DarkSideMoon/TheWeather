using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheWeather.Api.Infrastructure;
using TheWeather.Api.Middleware;
using TheWeather.Model.Infrastructure;

namespace TheWeather.Api
{
    public class Startup
    {
        private readonly static string HealthEndpoint = "/health";
        private readonly static string WeatherSettings = "WeatherSettings";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHealthChecks();

            services.Configure<WeatherSettings>(options => Configuration.GetSection(WeatherSettings).Bind(options));

            // Add own services
            services.AddWeatherClientService();

            // Configure swagger
            services.AddSwaggerService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHealthChecks(HealthEndpoint);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Configure swagger
            app.AddSwagger();
        }
    }
}
