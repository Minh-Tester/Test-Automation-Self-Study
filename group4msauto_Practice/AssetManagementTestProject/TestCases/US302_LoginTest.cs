using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestCases;


public class US302_LoginTest : NUnitWebTestSetup
{
    public US302_LoginTest(string browser, int width, int height) : base(browser, width, height)
    {
    }

    [Test]
    [Category("GoogleTest")]
    public void TC01_UserLoginSuccess()
    {

        HomePage.InputValue("Hello");
    }
    

}
