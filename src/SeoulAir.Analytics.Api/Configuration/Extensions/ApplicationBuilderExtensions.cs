using Microsoft.AspNetCore.Builder;

namespace SeoulAir.Analytics.Api.Configuration.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json","SeoulAir.Analytics API V1");
                config.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
