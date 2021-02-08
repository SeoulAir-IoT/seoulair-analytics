using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SeoulAir.Analytics.Domain.Options;
using SeoulAir.Analytics.Domain.Services.OptionsValidators;
using static SeoulAir.Analytics.Domain.Resources.Strings;

namespace SeoulAir.Analytics.Api.Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                var xmlDocumentationFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlDocumentationFileName));
                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc(OpenApiInfoProjectVersion, new OpenApiInfo
                {
                    Title = OpenApiInfoTitle,
                    Description = OpenApiInfoDescription,
                    Version = OpenApiInfoProjectVersion,
                    Contact = new OpenApiContact
                    {
                        Email = string.Empty,
                        Name = GitlabContactName,
                        Url = new Uri(GitlabRepoUri)
                    }
                });
            });

            return services;
        }
        
        public static IServiceCollection AddApplicationSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<MongoDbOptions>(configuration.GetSection(MongoDbOptions.AppSettingsPath));
            services.AddSingleton<IValidateOptions<MongoDbOptions>, MongoDbOptionsValidator>();
            
            services.Configure<SeoulAirCommandOptions>(configuration.GetSection(SeoulAirCommandOptions.AppSettingsPath));
            services.AddSingleton<IValidateOptions<SeoulAirCommandOptions>, SeoulAirCommandOptionsValidator>();
            
            return services;
        }
    }
}
