using OpenQA.Selenium;

namespace Framework.Driver
{
    public class WebDriverManager
    {
        public static AsyncLocal<IWebDriver> Driver = new AsyncLocal<IWebDriver>();

        public static void InitDriver(String Browser, int Width, int Height)
        {
            FrameworkConfiguration frameworkConfiguration = ConfigManager.GetConfig<FrameworkConfiguration>("Framework");
            IWebDriver newDriver = null;
            if (frameworkConfiguration.ExecuteLocation!.Equals("local"))
            {
                newDriver = WebDriverCreator.CreateLocalDriver(Browser, Width, Height);
            }
            else if (frameworkConfiguration.ExecuteLocation.Equals("browserstack"))
            {
                newDriver = WebDriverCreator.CreateBrowserstackDriver(Browser, Width, Height);
            }

            if (newDriver == null)
            {
                throw new Exception($"{Browser} browser is not supported");
                Driver.Value = newDriver;
            }
        }

        public static IWebDriver GetCurrentDriver()
        {
            return Driver.Value;
        }

        public static void CloseDriver()
        {
            if (Driver.Value != null)
            {
                Driver.Value.Quit();
                Driver.Value.Dispose();
            }
            else
            {
                throw new Exception("Driver has not yet been disposed.");
            }
        }
    }
}