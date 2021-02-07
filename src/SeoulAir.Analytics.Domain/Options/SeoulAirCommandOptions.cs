namespace SeoulAir.Analytics.Domain.Options
{
    public class SeoulAirCommandOptions : MicroserviceUrlOptions
    {
        public static string AppSettingsPath { get; } 
            = "MicroserviceUrlOptions:SeoulAir.Command";
    }
}
