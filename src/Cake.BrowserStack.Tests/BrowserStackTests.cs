using System;
using Cake.BrowserStack.Tests.Fakes;
using Cake.Core.IO;
using Xunit;

namespace Cake.BrowserStack.Tests
{
    public class BrowserStackTests : IDisposable
    {
        private readonly FakeCakeContext _context;
        private readonly string _username = Keys.BrowserStackApiUsername;
        private readonly string _accessKey = Keys.BrowserStackApiAccessKey;

        public BrowserStackTests()
        {
            _context = new FakeCakeContext();
        }

        BrowserStackSettings GetSettings()
        {
            return new BrowserStackSettings
            {
                Username = _username,
                AccessKey = _accessKey
            };
        }

        [Fact(Skip = "need apk")]
        public void AppAutomateUpload()
        {
            var settings = GetSettings();

            var filePath = new FilePath(@"test-app.apk");

            _context.CakeContext.BrowserStackAppAutomateUpload(filePath, settings, "id");
        }

        [Fact(Skip = "WIP")]
        public void AppAutomateUpload_Url()
        {
            var settings = GetSettings();

            //_context.CakeContext.BrowserStackAppAutomateUpload("https://github.com/appium/sample-apps/blob/master/pre-built/selendroid-test-app.apk?raw=true", settings);
        }

        [Fact]
        public void AppAutomateRecentApps()
        {
            var settings = GetSettings();

            var result = _context.CakeContext.BrowserStackAppAutomateRecentApps(settings);

            Assert.NotNull(result);
        }

        [Fact]
        public void AppAutomateRecentGroupApps()
        {
            var settings = GetSettings();

            var result = _context.CakeContext.BrowserStackAppAutomateRecentGroupApps(settings);
        }

        [Fact(Skip = "Don't delete app")]
        public void AppAutomateDeleteApp()
        {
            var settings = GetSettings();

            _context.CakeContext.BrowserStackAppAutomateDeleteApp("appId", settings);
        }

        [Fact]
        public void AppLiveUpload()
        {
            var settings = GetSettings();

            var filePath = new FilePath(@"test-app.apk");

            _context.CakeContext.BrowserStackAppLiveUpload(filePath, settings);
        }

        public void Dispose()
        {
            _context.DumpLogs();
        }
    }
}
