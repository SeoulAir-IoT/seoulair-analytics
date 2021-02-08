using System.Collections.Generic;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Enums;

namespace SeoulAir.Analytics.Domain.Interfaces.Services
{
    public interface IAnalyticsService
    {
        AnalysisResult Analyze(AirPollutionInfoDto airPollutionInfo);
        AnalysisResult Analyze(IEnumerable<AirPollutionInfoDto> airPollutionInfos);
        Dictionary<string, AirParticleStatus> SeparateAlertingParticles(AnalysisResult analysisResult);
    }
}
