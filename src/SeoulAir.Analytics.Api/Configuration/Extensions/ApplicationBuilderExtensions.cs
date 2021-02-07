﻿using Microsoft.AspNetCore.Builder;
using static SeoulAir.Analytics.Domain.Resources.Strings;

namespace SeoulAir.Analytics.Api.Configuration.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint(string.Format(SwaggerEndpoint, OpenApiInfoProjectVersion),
                    OpenApiInfoProjectName);
                config.RoutePrefix = string.Empty;
                config.DocumentTitle = OpenApiInfoTitle;
            });
            app.UseSwagger();

            return app;
        }
    }
}
