using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace Cake.BrowserStack.Services
{
    internal static class BrowserStackClient
    {
        private const string BaseUrl = "https://api-cloud.browserstack.com";

        public static IBrowserStackApi Create(BrowserStackSettings settings)
        {
            return Create(settings.Username, settings.AccessKey, settings.Timeout);
        }

        public static IBrowserStackApi Create(string username, string password, TimeSpan? timeout = null)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };

            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl),
                Timeout = timeout.GetValueOrDefault(TimeSpan.FromMinutes(20))
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{username}:{password}")));

            return RestService.For<IBrowserStackApi>(client);
        }
    }
}
