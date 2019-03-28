using System.Threading.Tasks;
using Cake.BrowserStack.Models;
using Refit;

namespace Cake.BrowserStack.Services
{
    public class Body
    {
        public string url { get; set; }
    }

    internal interface IBrowserStackApi
    {
        [Multipart]
        [Post("/app-automate/upload")]
        Task AppAutomateUpload(StreamPart file, JsonPart data);

        [Multipart]
        [Post("/app-automate/upload")]
        Task AppAutomateUpload(JsonPart data);

        [Get("/app-automate/recent_apps")]
        Task<AppAutomateApp[]> AppAutomateRecentApps();

        [Get("/app-automate/recent_apps/{custom_id}")]
        Task<AppAutomateApp[]> AppAutomateRecentApps([AliasAs("custom_id")]string customId);

        [Get("/app-automate/recent_group_apps")]
        Task<AppAutomateApp[]> AppAutomateRecentGroupApps();

        [Delete("/app-automate/app/delete/{AppId}")]
        Task<AppAutomateResponse> AppAutomateDeleteApp([AliasAs("AppId")]string appId);

        [Multipart]
        [Post("/app-live/upload")]
        Task AppLiveUpload(StreamPart file);

    }
}