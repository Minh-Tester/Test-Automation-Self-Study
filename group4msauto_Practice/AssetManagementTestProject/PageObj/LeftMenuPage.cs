using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class LeftMenuPage : WebDriverAction
{
    public readonly string BtnHomeInMenu = "//a[text() = 'Home']";
    public readonly string BtnManageAssetInMenu = "//a[text() = 'Manage Asset']";
    public readonly string BtnManageAssignmentInMenu = "//a[text() = 'Manage Assignment']";
    public readonly string BtnManageReturningInMenu = "//a[text() = 'Manage Returning']";
    public readonly string BtnManageUserInMenu = "//a[text() = 'Manage User']";
    public readonly string BtnReportInMenu = "//a[text() = 'Report']";
    public LeftMenuPage() : base()
    {
    }
}

