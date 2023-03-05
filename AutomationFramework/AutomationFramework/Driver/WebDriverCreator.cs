using NLog.Targets;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Drawing;
using Size = System.Drawing.Size;

namespace Framework.Driver
{
    public class WebDriverCreator
    {
        public static IWebDriver CreateLocalDriver(string browser, int screenWidth, int screenHeight)
        {
            IWebDriver? Driver = null;
            switch (browser)
            {
                case "chrome":
                    ChromeOptions optionChrome = new ChromeOptions();
                    string downloadPath = FilePathKind.GetFullPath(HtmlReportDirectory.REPORT_FOLDER_PATH);
                    optionChrome.AddUserProfilePreference("download.default_directory", downloadPath);
                    optionChrome.AddUserProfilePreference("download.prompt_for_download", false);
                    optionChrome.AddUserProfilePreference("download.directory_upgrade", true);
                    Driver = new ChromeDriver(optionChrome);
                    break;
                case "firefox":
                    FirefoxOptions optionFirefox = new FirefoxOptions();
                    optionFirefox.AddArguments();
                    Driver = new FirefoxDriver(optionFirefox);
                    break;
                case "edge":
                    Driver = new EdgeDriver();
                    break;
            }
            if (screenWidth == null && screenHeight == null)
            {
                Driver!.Manage().Window.Maximize();
            }
            else if (screenWidth != null && screenHeight != null)
            {
                Driver!.Manage().Window.Size = new Size(screenWidth, screenHeight);
            }
            Driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return Driver;
        }

        public static IWebDriver CreateBrowserstackDriver(string browser, int screenWidth, int screenHeight)
        {
            IWebDriver? Driver = null;
            switch(browser)
            {
                case "chrome":
                    ChromeOptions optionChrome = new ChromeOptions();
                    optionChrome.AddArguments();
                    Driver = new ChromeDriver(optionChrome);
                    break;
                case "firefox":
                    FirefoxOptions optionFirerox = new FirefoxOptions();
                    optionFirerox.AddArguments();
                    Driver = new FirefoxDriver(optionFirerox);
                    break;
                case "edge":
                    Driver = new EdgeDriver();
                    break;
            }
            if (screenWidth == null && screenHeight == null)
            {
                Driver!.Manage().Window.Maximize();
            }
            else if (screenWidth != null && screenHeight != null)
            {
                Driver!.Manage().Window.Size = new Size(screenWidth, screenHeight);
            }
            Driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return Driver;
        }
    }
}
