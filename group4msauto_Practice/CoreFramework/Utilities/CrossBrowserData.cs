using CoreFramework.Configs;
using NUnit.Framework;
using System.Collections;

namespace CoreFramework.Utilities
{
    public class CrossBrowserData
    {
        public static IEnumerable LatestConfigurations
        {
            get
            {
                //chrome
                yield return new TestFixtureData("chrome", 1920, 1080);
               
                yield return new TestFixtureData("chrome", 1360, 720);
                yield return new TestFixtureData("firefox", 1920, 1080);
            }
            
        }

        public static IEnumerable SimpleConfiguration
        {
            get
            {
                yield return new TestFixtureData("chrome", 1920, 1080);

            }
        }

        public static IEnumerable BrowserConfigurations()
        {
            string browserDefault = ConfigManager.GetConfig<BrowserConfig>("BrowserConfig").BrowserConfigType;
            string browserTypeNunit = TestContext.Parameters.Get("browserTypeNunit", browserDefault);
            var browserTypeDotNet = Environment.GetEnvironmentVariable("BrowserConfig");

            if (browserTypeNunit.Equals("simple")|| browserTypeDotNet.Equals("simple"))
            {
                return SimpleConfiguration;
            }
            else
            {
                return LatestConfigurations;
            }
        }
    }
}
