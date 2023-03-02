using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class LoginPage : WebDriverAction
{
    public readonly string TfUsername = "//input[contains(@id, 'username')]";
    public readonly string TfPassword = "//input[contains(@id, 'password')]";
    public readonly string BtnLogin = "//button[contains(@type, 'submit')]";
    public readonly string BtnViewDecryptedPassword = "//span[contains(@class, 'anticon-eye')]";
    public LoginPage() : base()
    {
    }
    public void Login(string userName, string password)
    {
        ///Click Eye icon to view if password is inputed correctly before login
        SendKeys(TfUsername, userName);
        SendKeys(TfPassword, password);
        Click(BtnViewDecryptedPassword);
        Click(BtnLogin);

    }
}
