using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SeoulAir.Analytics.Domain.Builders;
using SeoulAir.Analytics.Domain.Interfaces.Services;
using SeoulAir.Analytics.Domain.Options;

namespace SeoulAir.Analytics.Domain.Services
{
    public class CommandService : ICommandService
    {
        private readonly SeoulAirCommandOptions _options;
        private readonly IMicroserviceHttpRequestBuilder _requestBuilder;
        private readonly IMicroserviceUriBuilder _uriBuilder;
        private readonly IHttpClientFactory _clientFactory;

        public CommandService(IOptions<SeoulAirCommandOptions> options, IMicroserviceHttpRequestBuilder requestBuilder,
            IMicroserviceUriBuilder uriBuilder, IHttpClientFactory clientFactory)
        {
            _options = options.Value;
            _requestBuilder = requestBuilder;
            _uriBuilder = uriBuilder;
            _clientFactory = clientFactory;
        }

        public async Task<string> ExecuteCommandAsync(string commandName, params string[] parameters)
        {
            var uri = _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController("api/executioner")
                .SetEndpoint("execute");
            
            var request = _requestBuilder.Restart()
                .UseUri(uri.Build())
                .UseHttpMethod(HttpMethod.Put)
                .UseRequestBody(new { CommandName = commandName, Parameters = parameters })
                .Build();

            HttpResponseMessage response;
            using (var client = _clientFactory.CreateClient())
                response = await client.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();
            return !string.IsNullOrEmpty(responseContent) ? responseContent : null;
        }
    }
}