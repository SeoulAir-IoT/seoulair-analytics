﻿using System;

namespace SeoulAir.Analytics.Domain.Dtos
{
    public class RawDataInstanceDto
    {
        public DateTime MeasurementDate { get; set; }

        public StationInfoDto StationInfo { get; set; }

        public AirPollutionInfoDto AirPollutionInfo { get; set; }
    }
}
