using System;

namespace Cake.BrowserStack
{
    /// <summary>
    /// BrowserStack Settings
    /// </summary>
    public class BrowserStackSettings
    {
        public BrowserStackSettings()
        {
        }

        public BrowserStackSettings(string username, string accessKey)
        {
            Username = username;
            AccessKey = accessKey;
        }
        /// <summary>
        /// Gets or sets the Username to access the api.
        /// </summary>
        /// <remarks>You can find this value here https://www.browserstack.com/accounts/settings</remarks>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the AccessKey to access the api
        /// </summary>
        /// <remarks>You can find this value here https://www.browserstack.com/accounts/settings</remarks>
        public string AccessKey { get; set; }

        /// <summary>
        /// gets or sets the timeout when accessing the api
        /// </summary>
        public TimeSpan? Timeout { get; set; }
    }
}