using System;
using System.IO;
using Cake.BrowserStack.Models;
using Cake.BrowserStack.Services;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Newtonsoft.Json;
using Refit;

namespace Cake.BrowserStack
{
    /// <summary>
    /// <para>BrowserStack API related cake aliases.</para>
    /// </summary>
    [CakeAliasCategory("BrowserStack")]
    public static class BrowserStackAliases
    {
        /// <summary>
        /// An API to upload the App you want to test on the BrowserStack servers
        /// </summary>
        [CakeMethodAlias]
        public static void BrowserStackAppAutomateUpload(this ICakeContext context, FilePath filePath, BrowserStackSettings settings, string customId = null)
        {
            var browserStack = BrowserStackClient.Create(settings);

            var file = context.FileSystem.GetFile(filePath);

            using (var stream = file.OpenRead())
            {
                var fileName = filePath.GetFilename().ToString();
                
                browserStack.AppAutomateUpload(new StreamPart(stream, fileName), new AppAutomateRequestData { custom_id = customId }).Wait();
            }
        }

        /// <summary>
        /// Upload app from a Public Location
        /// </summary>
        /// <remarks>
        /// If you do not have your app file on the local machine from where you are running the test and it is hosted on a
        /// different location, you can upload it to the BrowserStack servers from any public hosted location. You can achieve that
        /// by just providing the app public url in the API call to upload an app. The url should be accessible over the internet so
        /// that BrowserStack can directly upload it from that location. Use the below API call to upload app from a publicly accessible
        /// location.
        /// </remarks>
        [CakeMethodAlias]
        public static void BrowserStackAppAutomateUpload(this ICakeContext context, string url, BrowserStackSettings settings, string customId = null)
        {
            var browserStack = BrowserStackClient.Create(settings);

            browserStack.AppAutomateUpload(new AppAutomateRequestData { custom_id = customId, url = url}).Wait();
        }

        /// <summary>
        /// An API to retrieve details about your recent App uploads. The response will not include the deleted apps
        /// </summary>
        /// <param name="customId">If a customId is specified, only Apps under a specific custom_id will be returned</param>
        [CakeMethodAlias]
        public static AppAutomateApp[] BrowserStackAppAutomateRecentApps(this ICakeContext context, BrowserStackSettings settings, string customId = null)
        {
            var browserStack = BrowserStackClient.Create(settings);

            return customId == null
                ? browserStack.AppAutomateRecentApps().Result
                : browserStack.AppAutomateRecentApps(customId).Result;
        }

        /// <summary>
        /// An API to retrieve details about your recent App uploads for the entire group. The response will not include the deleted apps
        /// </summary>
        [CakeMethodAlias]
        public static AppAutomateApp[] BrowserStackAppAutomateRecentGroupApps(this ICakeContext context, BrowserStackSettings settings)
        {
            var browserStack = BrowserStackClient.Create(settings);

            return browserStack.AppAutomateRecentGroupApps().Result;
        }

        /// <summary>
        /// An API to DELETE an uploaded App
        /// </summary>
        [CakeMethodAlias]
        public static bool BrowserStackAppAutomateDeleteApp(this ICakeContext context, string appId, BrowserStackSettings settings)
        {
            var browserStack = BrowserStackClient.Create(settings);

            var result = browserStack.AppAutomateDeleteApp(appId).Result;

            return result.Success;
        }

        /// <summary>
        /// Uploads an app to App Live
        /// </summary>
        [CakeMethodAlias]
        public static void BrowserStackAppLiveUpload(this ICakeContext context, FilePath filePath, BrowserStackSettings settings)
        {
            var browserStack = BrowserStackClient.Create(settings.Username, settings.AccessKey, settings.Timeout);

            var file = context.FileSystem.GetFile(filePath);

            using (var stream = file.OpenRead())
            {
                var fileName = filePath.GetFilename().ToString();

                var part = new StreamPart(stream, fileName);

                browserStack.AppLiveUpload(part).Wait();
            }
        }
    }
}
