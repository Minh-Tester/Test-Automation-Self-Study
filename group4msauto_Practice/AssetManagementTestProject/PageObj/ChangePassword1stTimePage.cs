using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class ChangePassword1stTimePage : WebDriverAction
{
    #region FIRST TIME LOGIN
    public string BtnSaveFirstLoginNewPw = "//button[contains(@type, 'submit')]";
    public string HeaderChangePw1stTime = "//h1[text()='Change Password']";
    public string PathChangePw1stTime = "change-password-first-time";
    public string TextChangePw1stTime = "//p[text()='You have to change your password to continue.']";
    public string TfFirstLoginNewPw = "//input[contains(@id, 'newPassword')]";
    #endregion
    public ChangePassword1stTimePage() : base()
    {
    }
    public string AskChangePwFirstLogin()
    {
        WaitToBeVisible(HeaderChangePw1stTime); // Wait for the page to log in before verifying
        return TextChangePw1stTime;
    }
    public void ChangePwFirstTimeLogIn(string newPassword)
    {
        SendKeys(TfFirstLoginNewPw, newPassword);
        Click(BtnSaveFirstLoginNewPw);
    }
}
