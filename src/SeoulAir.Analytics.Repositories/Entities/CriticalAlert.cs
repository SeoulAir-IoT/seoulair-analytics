using System;
using SeoulAir.Analytics.Domain.Enums;
using SeoulAir.Analytics.Repositories.Attributes;

namespace SeoulAir.Analytics.Repositories.Entities
{
    [BsonCollection("CriticalAlert")]
    public class CriticalAlert : Alert
    {
        public DateTime StartOfBadMeasurement { get; set; }
        public LightColor ColorChangedTo { get; set; }
        public DateTime DateOfColorChange { get; set; }
    }
}