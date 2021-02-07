using System.Collections.Generic;
using System.Linq;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Enums;
using SeoulAir.Analytics.Domain.Interfaces.Services;

namespace SeoulAir.Analytics.Domain.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private static readonly double[] So2ThresholdValues = {0.02, 0.05, 0.15, 1};
        private static readonly double[] No2ThresholdValues = {0.03, 0.06, 0.2, 2};
        private static readonly double[] CoThresholdValues = {2, 9, 15, 50};
        private static readonly double[] O3ThresholdValues = {0.03, 0.09, 0.15, 0.5};
        private static readonly double[] Pm10ThresholdValues = {30, 80, 150, 600};
        private static readonly double[] Pm25ThresholdValues = {15, 35, 75, 500};
        
        public AnalysisResult Analyze(AirPollutionInfoDto airPollutionInfo)
        {
            AnalysisResult result = new AnalysisResult();
            for (int i = 0; i < 3; i++)
            {
                if (airPollutionInfo.So2 > So2ThresholdValues[i])
                    result.ParticleStatus[nameof(airPollutionInfo.So2)] += 1;
                if (airPollutionInfo.Co > CoThresholdValues[i])
                    result.ParticleStatus[nameof(airPollutionInfo.Co)] += 1;
                if (airPollutionInfo.No2 > No2ThresholdValues[i])
                    result.ParticleStatus[nameof(airPollutionInfo.No2)] += 1;
                if (airPollutionInfo.O3 > O3ThresholdValues[i])
                    result.ParticleStatus[nameof(airPollutionInfo.O3)] += 1;
                if (airPollutionInfo.Pm10 > Pm10ThresholdValues[i])
                    result.ParticleStatus[nameof(airPollutionInfo.Pm10)] += 1;
                if (airPollutionInfo.Pm25 > Pm25ThresholdValues[i])
                    result.ParticleStatus[nameof(airPollutionInfo.Pm25)] += 1;
            }

            return result;
        }

        public AnalysisResult Analyze(IEnumerable<AirPollutionInfoDto> airPollutionInfos)
        {
            return Analyze(CalculateAverageValues(airPollutionInfos));
        }

        private AirPollutionInfoDto CalculateAverageValues(IEnumerable<AirPollutionInfoDto> airPollutionInfoDtos)
        {
            AirPollutionInfoDto result = new AirPollutionInfoDto();
            foreach (AirPollutionInfoDto dto in airPollutionInfoDtos)
            {
                result.Co += dto.Co;
                result.No2 += dto.No2;
                result.O3 += dto.O3;
                result.Pm10 += dto.Pm10;
                result.Pm25 += dto.Pm25;
            }

            int numOfElements = airPollutionInfoDtos.Count();
            result.Co /= numOfElements;
            result.No2 /= numOfElements;
            result.O3 /= numOfElements;
            result.Pm10 /= numOfElements;
            result.Pm25 /= numOfElements;
            result.So2 /= numOfElements;
            return result;
        }

        public Dictionary<string, AirParticleStatus> SeparateAlertingParticles(AnalysisResult analysisResult)
        {
            var badParticles = new Dictionary<string, AirParticleStatus>(analysisResult.ParticleStatus);

            foreach (KeyValuePair<string, AirParticleStatus> keyValuePair in badParticles)
                if (keyValuePair.Value == AirParticleStatus.Good || keyValuePair.Value == AirParticleStatus.Normal)
                    badParticles.Remove(keyValuePair.Key);

            return badParticles;
        }
    }
}