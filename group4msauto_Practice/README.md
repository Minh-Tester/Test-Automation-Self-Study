## Introduction

This is the Automation code base for the 2nd phase of The Rookies Program

## Project Structure

The project is organized as the structure below

- **Data**: Includes data-driven files
- **Projects**:
  - CoreFW contains all base methods of test/driver interaction
  - TestProject contains all test cases, page objects, DAOs, etc.
- **Pages**: Includes pages
  - ChangePassword1stTimePage.cs
  - ChangePasswordPage.cs
  - CreateUserPage.cs
  - DetailedUserInfoPage.cs
  - EditUserInfoPage.cs
  - HomePage.cs
  - LeftMenuPage.cs
  - LoginPage.cs
  - LogoutPopup.cs
  - ManageUserPage.cs

- **Results**: Includes test results/reports after executing tests
- **Tests**: Includes all tests scripts divided by features
  - Asset
  - Assignment
  - Login
  - Report
  - User

## Coding Convention

Examples for pages

```cs

LoginPage.cs

using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;

public class LoginPage : WebDriverAction
{
    private readonly string usernameTextLocator = "//label[contains(@title, 'Username')]"; // for testing
    private readonly string tfUsername = "//input[contains(@id, 'username')]";
    private readonly string tfPassword = "//input[contains(@id, 'password')]";
    private readonly string btnLogin = "//button[contains(@type, 'submit')]";

    public LoginPage() : base()
    {
    }

    public void Login(string userName, string password)
    {
        SendKeys_(tfUsername, userName);
        SendKeys_(tfPassword, password);
        Click(btnLogin);
    }
}
```

Tests examples

```cs
LoginTest.cs


using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class LoginTest : NUnitWebTestSetup
{
    [Test]
    public void TestFirstLogin()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD);
        HomePage.VerifyFirstLogin();
        HomePage.ChangePwFirstTimeLogIn();
        LogoutPopup.LogOutOfPage();
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.CHANGED_ADMIN_PASSWORD);
        Asserter.AssertStringEquals(HomePage.VerifyCorrectRedirection(), Constant.BASE_URL);

    }
}
```
