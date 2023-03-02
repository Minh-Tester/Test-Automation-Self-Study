using CoreFramework.Configs;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace CoreFramework.DriverCore;

public class WebDriverManager
{
    private static AsyncLocal<IWebDriver> driver = new AsyncLocal<IWebDriver>();

    public static IWebDriver? CreateLocalDriver(string browser,
 int screenWidth , int screenHeight )
    {
        IWebDriver? LocalDriver = null;
        switch (browser)
        {
            case "chrome":
                //ChromeOptions options = new ChromeOptions();
                //options.AddArgument("--headless");
                LocalDriver = new ChromeDriver();
                break;
            case "firefox":
                LocalDriver = new FirefoxDriver();
                break;
            case "safari":
                LocalDriver = new SafariDriver();
                break;
        }
        LocalDriver.Manage().Window.Size = new System.Drawing.Size(screenWidth, screenHeight);
        LocalDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        return LocalDriver;
    }

    public static void InitDriver(string browser, int width, int height)
    {
        string frameworkConfiguration = ConfigManager.GetConfig<FrameworkConfiguration>("Framework").ExecuteLocation;

        if (frameworkConfiguration.Equals("local"))
        {
            IWebDriver newDriver = CreateLocalDriver(browser, width, height);
            if (newDriver == null)
            {
                throw new Exception($"{browser} browser is not supported");
            }

            driver.Value = newDriver;
        }

        //else if (frameworkConfiguration.ExecuteLocation.Equals("browserstack"))
        //{
        //    newDriver = CreateBrowserstackDriver(browser, width, height);
        //}




    }
    public static IWebDriver GetCurrentDriver()
    {
        return driver.Value;
    }
    public static void CloseDriver()
    {
        if (driver.Value != null)
        {
            driver.Value.Quit();
            driver.Value.Dispose();
        }
    }
}

