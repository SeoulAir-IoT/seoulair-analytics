using Microsoft.Extensions.DependencyInjection;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Interfaces.Services;

namespace SeoulAir.Analytics.Domain.Services.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<ICacheService<DataRecordDto>, CacheService<DataRecordDto>>();
            services.AddScoped<IAnalyticsService, AnalyticsService>();
            services.AddScoped<ICrudBaseService<AlertDto>, CrudBaseService<AlertDto>>();
            services.AddScoped<IAlertService, AlertService>();
            services.AddScoped<ICriticalAlertService, CriticalAlertService>();
            services.AddScoped<ICrudBaseService<CriticalAlertDto>, CrudBaseService<CriticalAlertDto>>();

            return services;
        }
    }
}