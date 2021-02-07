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
        private readonly ICommandService _commandService;

        public CriticalAlertService(ICrudBaseRepository<CriticalAlertDto> baseRepository,
            ICacheService<DataRecordDto> cache,
            IAnalyticsService analyticsService,
            ICommandService commandService) : base(baseRepository)
        {
            _cache = cache;
            _analyticsService = analyticsService;
            _commandService = commandService;
        }

        public async Task ProcessNewRecordAsync(DataRecordDto record)
        {
            _cache.AddNewRecord(record.StationCode, record);
            var cacheElements = _cache.GetCache(record.StationCode)
                .Select(singleRecord => singleRecord.AirPollutionInfo).ToArray();

            if (cacheElements.Length < 5)
                return;

            var analyzeResult = _analyticsService.Analyze(cacheElements);
            var badParticles = _analyticsService.SeparateAlertingParticles(analyzeResult);
            if (badParticles.Any())
            {
                var criticalAlert = new CriticalAlertDto
                {
                    BadParticles = badParticles,
                    MeasurementDate = record.MeasurementDate,
                    StationCode = record.StationCode,
                    ColorChangedTo = (LightColor) (int) badParticles.Max(particle => particle.Value),
                    DateOfColorChange = DateTime.Now,
                    StartOfBadMeasurement = _cache.GetOldestRecord(record.StationCode).MeasurementDate,
                };
                await _baseRepository.AddAsync(criticalAlert);
                await ChangeColor(criticalAlert.StationCode, criticalAlert.ColorChangedTo);
            }
            else
            {
                await ChangeColor(record.StationCode,
                    (LightColor) (int) analyzeResult.ParticleStatus.Max(particle => particle.Value));
            }
        }

        private async Task ChangeColor(ushort stationCode, LightColor changedColor)
        {
            await _commandService.ExecuteCommandAsync("signal-light-on", stationCode.ToString());
            await _commandService.ExecuteCommandAsync("change-light-color", stationCode.ToString(),
                changedColor.ToString());
        }
    }
}