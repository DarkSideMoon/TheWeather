using Microsoft.AspNetCore.Builder;

namespace TheWeather.Api.Infrastructure
{
    public static class SwaggerApplicationBuilderExtension
    {
        public static IApplicationBuilder AddSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "The weather API");
            });

            return app;
        }
    } 
}
