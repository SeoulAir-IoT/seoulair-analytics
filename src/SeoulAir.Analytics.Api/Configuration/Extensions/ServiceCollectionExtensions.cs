using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SeoulAir.Analytics.Domain.Options;
using SeoulAir.Analytics.Domain.Services.OptionsValidators;

namespace SeoulAir.Analytics.Api.Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            return services;
        }
        
        public static IServiceCollection AddApplicationSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<MongoDbOptions>(configuration.GetSection(MongoDbOptions.AppSettingsPath));
            services.AddSingleton<IValidateOptions<MongoDbOptions>, MongoDbOptionsValidator>();
            
            return services;
        }
    }
}
