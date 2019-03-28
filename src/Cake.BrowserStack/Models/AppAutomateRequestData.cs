using Cake.BrowserStack.Services;

namespace Cake.BrowserStack.Models
{
    internal class AppAutomateRequestData
    {
        public string custom_id { get; set; }

        public string url { get; set; }

        public static implicit operator JsonPart(AppAutomateRequestData data)
        {
            return new JsonPart("data", data);
        }
    }
}