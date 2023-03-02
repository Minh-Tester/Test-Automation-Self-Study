using CoreFramework.DriverCore;
namespace AssetManagementTestProject.PageObj
{
    public class LogoutPopupPage : WebDriverAction
    {
        public readonly string BtnCancel = "//span[text() = 'Cancel']";
        public readonly string BtnClose = "//span[contains(@aria-label, 'close')]";
        public readonly string BtnLogout = "//span[text() = 'Log Out']";
        public LogoutPopupPage() : base()
        {
        }
        public void LogOutOfPage()
        {
            Click(BtnLogout);
        }

        public void CancelLogOutOfPage()
        {
            Click(BtnCancel);
        }
    }
}

