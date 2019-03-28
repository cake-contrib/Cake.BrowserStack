using System;
using System.IO;
using System.Linq;

namespace Cake.BrowserStack.Tests
{
    public static class Keys
    {
        const string YOUR_BROWSERSTACK_API_USERNAME = "{BROWSERSTACK_USERNAME}";
        const string YOUR_BROWSERSTACK_API_ACCESSKEY = "{BROWSERSTACK_ACCESSKEY}";
        
        static Keys()
        {
            // Check for a local file with a token first
            var localFile = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", ".browserstackcredentials");
            if (File.Exists(localFile))
            {
                var contents = File.ReadAllLines(localFile);
                BrowserStackApiUsername = contents.ElementAtOrDefault(0);
                BrowserStackApiAccessKey = contents.ElementAtOrDefault(1);
            }

            // Next check for an environment variable
            if (string.IsNullOrEmpty(BrowserStackApiUsername))
            {
                BrowserStackApiUsername = Environment.GetEnvironmentVariable("test_browserstack_api_username");
                BrowserStackApiAccessKey = Environment.GetEnvironmentVariable("test_browserstack_api_accesskey");
            }

            // Finally use the const value
            if (string.IsNullOrEmpty(BrowserStackApiUsername))
            {
                BrowserStackApiUsername = YOUR_BROWSERSTACK_API_USERNAME;
                BrowserStackApiAccessKey = YOUR_BROWSERSTACK_API_ACCESSKEY;
            }
        }
        
        public static string BrowserStackApiUsername { get; }
        public static string BrowserStackApiAccessKey { get; }
    }
}

