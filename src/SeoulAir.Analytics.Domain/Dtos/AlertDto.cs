using System;
using System.Collections.Generic;
using SeoulAir.Analytics.Domain.Enums;

namespace SeoulAir.Analytics.Domain.Dtos
{
    public class AlertDto : BaseDtoWithId
    {
        public DateTime MeasurementDate { get; set; }
        public ushort StationCode { get; set; }
        public Dictionary<string, AirParticleStatus> BadParticles { get; set; }
    }
}