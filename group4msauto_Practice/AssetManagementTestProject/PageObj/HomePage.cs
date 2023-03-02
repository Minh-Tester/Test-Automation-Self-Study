using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class HomePage : WebDriverAction
{
    public string BtnNavigationBar = "//div[contains(@class, 'ant-dropdown-trigger cursor-pointer')]";
    public string BtnChangePw = "//a[contains(@href, '/change-password')]";
    public string BtnLogout = "//a[contains(@href, '/logout')]";
    public string HeaderHomePage = "//h1[contains(@class, 'text-red-600')]";

    public string SearchText = "//input[contains(@aria-label, 'Tìm kiếm')]";

    #region MY ASSIGNMENT LIST
    public string HeaderMyAssignment = "//h1[text()='My Assignment']";
    public string BtnAcceptAssignment = "(//span[contains(@aria-label, 'check')])[1]";
    public string BtnDeclineAssignment = "(//span[contains(@aria-label, 'close')])[1]";
    public string BtnRequestReturnAsset = "(//span[contains(@aria-label, 'undo')])[1]";
    #endregion

    public HomePage() : base()
    {
    }
    public void SelectLogout()
    {
        Click(BtnNavigationBar);
        Click(BtnLogout);
    }

    public void InputValue(string value)
    {
        Click(SearchText);
        SendKeys(SearchText, value);
        PressEnter(SearchText);
    }

}
