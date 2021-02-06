using System;
using SeoulAir.Analytics.Domain.Enums;

namespace SeoulAir.Analytics.Domain.Dtos
{
    public class CriticalAlertDto : AlertDto
    {
        public DateTime StartOfBadMeasurement { get; set; }
        public LightColor ColorChangedTo { get; set; }
        public DateTime DateOfColorChange { get; set; }
    }
}