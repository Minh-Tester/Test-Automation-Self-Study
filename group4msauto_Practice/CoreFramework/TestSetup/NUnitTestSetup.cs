using CoreFramework.Configs;
using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using CoreFramework.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace CoreFramework.NUnitTestSetup;

[TestFixtureSource(typeof(CrossBrowserData), 
    nameof(CrossBrowserData.BrowserConfigurations))] //Chuyền 1 list browser để tự động chạy

public class NUnitTestSetup 
{
    protected WebDriverAction? DriverBaseAction;
    private string Device = "PC";
    private string Category = "TestProject";
    protected ConfigManager? ConfigManager_;

    public readonly string Browser;
    public readonly int Width;
    public readonly int Height;

    public NUnitTestSetup(string browser, int width, int height) //constructor
    {
        Browser = browser;
        Width = width; //chieu dai
        Height = height; //chieu rong
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        HtmlReport.CreateReport();
        HtmlReport.CreateTest(TestContext.CurrentContext.Test.ClassName).AssignDevice(Device).AssignCategory(Category);
    }

    [SetUp]
    public void SetUp()
    {
        WebDriverManager.InitDriver(Browser, Width, Height);
        HtmlReport.CreateNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
        //WebDriverManager.InitDriver("chrome");
    }

    [TearDown]
    public void TearDown()
    {
        WebDriverManager.CloseDriver();
        TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus.Equals(TestStatus.Passed))
        {
            HtmlReport.Pass("PASSED: Test case passed");
        }
        else
        {
            HtmlReport.Fail("FAILED: Test errors: " + TestContext.CurrentContext.Result.Message, DriverBaseAction.TakeScreenShot());
        }
    }
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        HtmlReport.Flush();
    }
}

