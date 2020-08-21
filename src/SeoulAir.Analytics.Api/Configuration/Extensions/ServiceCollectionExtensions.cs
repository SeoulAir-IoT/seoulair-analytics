using Microsoft.Extensions.DependencyInjection;

namespace SeoulAir.Analytics.Api.Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            return services;
        }
    }
}
