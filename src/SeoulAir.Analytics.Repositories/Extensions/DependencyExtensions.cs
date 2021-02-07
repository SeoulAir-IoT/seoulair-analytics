using Microsoft.Extensions.DependencyInjection;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Interfaces.Repositories;
using SeoulAir.Analytics.Repositories.Entities;

namespace SeoulAir.Analytics.Repositories.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            
            services.AddScoped<IAlertRepository, AlertRepository>();
            services.AddScoped<ICriticalAlertRepository, CriticalAlertRepository>();
            
            services.AddSingleton<ICrudBaseRepository<AlertDto>, CrudBaseRepository<AlertDto, Alert>>();
            services.AddSingleton<ICrudBaseRepository<CriticalAlertDto>,
                CrudBaseRepository<CriticalAlertDto, CriticalAlert>>();
            
            return services;
        }
    }
}
