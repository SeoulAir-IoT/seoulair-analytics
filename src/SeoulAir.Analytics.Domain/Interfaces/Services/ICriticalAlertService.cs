using SeoulAir.Analytics.Domain.Dtos;

namespace SeoulAir.Analytics.Domain.Interfaces.Services
{
    public interface ICriticalAlertService : ICrudBaseService<CriticalAlertDto>, IProcessingService
    {
    }
}