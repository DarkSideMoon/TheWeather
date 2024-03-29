﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheWeather.Api.Infrastructure;
using TheWeather.Api.Middleware;
using TheWeather.Model.Common;
using TheWeather.Model.Infrastructure;

namespace TheWeather.Api
{
    public class Startup
    {
        private readonly static string AppStartedLog = "App {0} has been started";
        private readonly static string HealthEndpoint = "/health";
        private readonly static string WeatherSettings = "WeatherSettings";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();

            // Registers health checks services
            services.AddHealthChecks();

            services.AddSingleton(options => Configuration.GetSection(WeatherSettings).Get<WeatherSettings>());

            // Add own services
            services.AddWeatherClientService();

            // Add http client service
            services.AddHttpClientService();

            // Configure swagger
            services.AddSwaggerService();
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime applicationLifetime)
        {
            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHealthChecks(HealthEndpoint);

            app.UseRouting();

            app.UseCors(c => c.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Configure swagger
            app.AddSwagger();

            applicationLifetime.ApplicationStarted.Register(() =>
            {
                Log.Information(string.Format(AppStartedLog, Constants.App.Name));
            });
        }
    }
}
