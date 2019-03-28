using System;
using Newtonsoft.Json;

namespace Cake.BrowserStack.Models
{
    public class AppAutomateApp
    {
        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("app_version")]
        public string AppVersion { get; set; }

        [JsonProperty("app_url")]
        public string AppUrl { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("uploaded_at")]
        public string UploadedAtRaw { get; set; }

        public DateTime UploadedAt
        {
            get
            {
                var value = UploadedAtRaw;

                if (!string.IsNullOrWhiteSpace(value) && DateTime.TryParse(value.Replace("UTC", ""), out var dt))
                {
                    return dt;
                }

                return DateTime.MinValue;
            }
        }
    }
}