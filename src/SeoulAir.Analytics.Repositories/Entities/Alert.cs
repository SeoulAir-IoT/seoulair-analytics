using System;
using System.Collections.Generic;
using SeoulAir.Analytics.Domain.Enums;
using SeoulAir.Analytics.Repositories.Attributes;

namespace SeoulAir.Analytics.Repositories.Entities
{
    [BsonCollection("Alert")]
    public class Alert : BaseEntityWithId
    {
        public DateTime MeasurementDate { get; set; }
        public ushort StationCode { get; set; }
        public Dictionary<string, AirParticleStatus> BadParticles { get; set; }
    }
}