using Microsoft.Extensions.Options;
using SeoulAir.Analytics.Domain.Options;

namespace SeoulAir.Analytics.Domain.Services.OptionsValidators
{
    public class SeoulAirCommandOptionsValidator : MicroserviceUrlValidator, IValidateOptions<SeoulAirCommandOptions>
    {
        public ValidateOptionsResult Validate(string name, SeoulAirCommandOptions options)
        {
            return base.Validate(name, options);
        }
    }
}
