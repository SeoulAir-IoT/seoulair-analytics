using System;
using SeoulAir.Analytics.Domain.Options;

namespace SeoulAir.Analytics.Domain.Builders
{
    public interface IMicroserviceUriBuilder
    {
        IMicroserviceUriBuilder UseMicroserviceUrlOptions(MicroserviceUrlOptions microserviceOptions);
        IMicroserviceUriBuilder UseController(string controllerName);
        IMicroserviceUriBuilder SetEndpoint(string endpoint);
        IMicroserviceUriBuilder AddQueryParameter<TParameter>(string parameterName, TParameter value);
        IMicroserviceUriBuilder AddPathParameter(string value);
        IMicroserviceUriBuilder Restart();
        Uri Build();
    }
}
