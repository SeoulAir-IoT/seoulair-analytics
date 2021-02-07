using System.Collections.Generic;
using SeoulAir.Analytics.Domain.Enums;

namespace SeoulAir.Analytics.Domain.Dtos
{
    public class AnalysisResult
    {
        public Dictionary<string, AirParticleStatus> ParticleStatus { get; }

        public AnalysisResult()
        {
            ParticleStatus = new Dictionary<string, AirParticleStatus>(6)
            {
                {nameof(AirPollutionInfoDto.Co), AirParticleStatus.Good},
                {nameof(AirPollutionInfoDto.No2), AirParticleStatus.Good},
                {nameof(AirPollutionInfoDto.O3), AirParticleStatus.Good},
                {nameof(AirPollutionInfoDto.Pm10), AirParticleStatus.Good},
                {nameof(AirPollutionInfoDto.Pm25), AirParticleStatus.Good},
                {nameof(AirPollutionInfoDto.So2), AirParticleStatus.Good}
            };
        }
    }
}
