using System.Linq;
using System.Threading.Tasks;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Interfaces.Repositories;
using SeoulAir.Analytics.Domain.Interfaces.Services;

namespace SeoulAir.Analytics.Domain.Services
{
    public class AlertService : CrudBaseService<AlertDto>, IAlertService
    {
        private readonly IAnalyticsService _analyticsService;

        public AlertService(IAnalyticsService analyticsService, IAlertRepository alertRepository) 
            : base(alertRepository)
        {
            _analyticsService = analyticsService;
        }
        
        public async Task ProcessNewRecordAsync(DataRecordDto record)
        {
            var badParticles = _analyticsService.SeparateAlertingParticles(
                _analyticsService.Analyze(record.AirPollutionInfo));

            if (badParticles.Any())
            {
                var alert = new AlertDto()
                {
                    MeasurementDate = record.MeasurementDate,
                    StationCode = record.StationCode,
                    BadParticles = badParticles
                };
                
                await _baseRepository.AddAsync(alert);
            }
        }
    }
}