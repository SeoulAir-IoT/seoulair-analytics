using AutoMapper;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Interfaces.Repositories;
using SeoulAir.Analytics.Repositories.Entities;

namespace SeoulAir.Analytics.Repositories
{
    public class CriticalAlertRepository : CrudBaseRepository<CriticalAlertDto, CriticalAlert>, ICriticalAlertRepository
    {
        public CriticalAlertRepository(IMapper mapper, IMongoDbContext dbContext) : base(mapper, dbContext)
        {
        }
    }
}
