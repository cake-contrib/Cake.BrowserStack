using Newtonsoft.Json;

namespace Cake.BrowserStack.Models
{
    internal class AppAutomateResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}