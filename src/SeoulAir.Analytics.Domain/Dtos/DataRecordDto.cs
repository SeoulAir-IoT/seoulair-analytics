using System;

namespace SeoulAir.Analytics.Domain.Dtos
{
    public class DataRecordDto
    {
        public DateTime MeasurementDate { get; set; }
        public ushort StationCode { get; set; }
        public AirPollutionInfoDto AirPollutionInfo { get; set; }
    }
}
