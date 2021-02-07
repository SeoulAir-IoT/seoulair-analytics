using System.Threading.Tasks;
using SeoulAir.Analytics.Domain.Dtos;

namespace SeoulAir.Analytics.Domain.Interfaces.Services
{
    public interface IProcessingService
    {
        Task ProcessNewRecordAsync(DataRecordDto record);
    }
}
