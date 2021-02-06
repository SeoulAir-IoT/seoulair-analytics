using System;
using System.Linq;
using System.Threading.Tasks;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Enums;
using SeoulAir.Analytics.Domain.Interfaces.Repositories;
using SeoulAir.Analytics.Domain.Interfaces.Services;

namespace SeoulAir.Analytics.Domain.Services
{
    public class CriticalAlertService : CrudBaseService<CriticalAlertDto>, ICriticalAlertService
    {
        private readonly ICacheService<DataRecordDto> _cache;
        private readonly IAnalyticsService _analyticsService;
        
        public CriticalAlertService(ICrudBaseRepository<CriticalAlertDto> baseRepository,
            ICacheService<DataRecordDto> cache,
            IAnalyticsService analyticsService) : base(baseRepository)
        {
            _cache = cache;
            _analyticsService = analyticsService;
        }

        public async Task ProcessNewRecordAsync(DataRecordDto record)
        {
            _cache.AddNewRecord(record);
            var cacheElements = _cache.GetCache().Select(singleRecord => singleRecord.AirPollutionInfo).ToArray();

            if (cacheElements.Length < 5)
                return;
            
            var badParticles = _analyticsService.SeparateAlertingParticles(_analyticsService.Analyze(cacheElements));

            if (badParticles.Any())
            {
                var criticalAlert = new CriticalAlertDto
                {
                    BadParticles = badParticles,
                    MeasurementDate = record.MeasurementDate,
                    StationCode = record.StationCode,
                    ColorChangedTo = (LightColor) (int) badParticles.Min(particle => particle.Value),
                    DateOfColorChange = DateTime.Now,
                    StartOfBadMeasurement = _cache.OldestRecord.MeasurementDate,
                };

                await _baseRepository.AddAsync(criticalAlert);
                //TODO: CHANGE COLOR
            }
        }
    }
}