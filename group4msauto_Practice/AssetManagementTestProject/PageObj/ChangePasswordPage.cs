using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;

public class ChangePasswordPage : WebDriverAction
{
    #region CHANGE PASSWORD
    public string BtnNavigationBar = "//div[contains(@class, 'ant-dropdown-trigger cursor-pointer')]";
    public string TfNewPw = "//input[contains(@id, 'newPassword')]";
    public string TfOldPw = "//input[contains(@id, 'oldPassword')]";
    public string BtnSaveNewPw = "//button[contains(@type, 'submit')]";
    public string BtnChangePw = "//a[contains(@href, '/change-password')]";
    public string BtnCancel = "//span[contains(text(), 'Cancel')]";
    public string HeaderChangePw = "//h1[text()='Change Password']";
    public string PathChangePw = "change-password";
    public string TextChangePwSuccessfully = "//p[text()='Your password has been changed successfully']";
    #endregion
    #region ERROR MESSAGES
    public string ErrorMessagesNewPw = "//div[contains(@id, 'newPassword_help')]";
    public string ErrorMessagesOldPw = "//div[contains(@id, 'newPassword_help')]";
    #endregion

    public ChangePasswordPage() : base()
    {
    }
    public string DisplayChangePwPopUp()
    {
        WaitToBeVisible(HeaderChangePw);
        return HeaderChangePw;
    }
    public string ReturnExpectedChangePWUrl()
    {
        return Constant.BASE_URL + PathChangePw;
    }
    public void ChangeNewPwSuccessfully(string oldPassword, string newPassword)
    {
        SendKeys(TfOldPw, oldPassword);
        SendKeys(TfNewPw, newPassword);
        Click(BtnSaveNewPw);
    }
    public void ChangeNewPwUnSuccessfully(string oldPassword, string newPassword)
    {
        SendKeys(TfOldPw, oldPassword);
        SendKeys(TfNewPw, newPassword);
    }
    public string DisplayChangePwSuccessfully()
    {
        WaitToBeVisible(HeaderChangePw);
        return TextChangePwSuccessfully;
    }
    public void SelectChangePassword()
    {
        Click(BtnNavigationBar);
        Click(BtnChangePw);

    }
    public void SelectCancel()
    {
        Click(BtnNavigationBar);
        Click(BtnChangePw);
        Click(BtnCancel);
    }
}

