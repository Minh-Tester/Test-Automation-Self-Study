using System.Globalization;
using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class EditUserInfoPage : WebDriverAction
{
    public readonly string DatePickDateOfBirth = "//input[contains(@id, 'dateOfBirth')]";
    public readonly string DatePickJoinedDate = "//input[contains(@id, 'joinedDate')]";
    public string OptionType = "//div[@title='{0}']";
    public readonly string DropBarType = "//span[@class='ant-select-selection-item']";
    public readonly string BtnSave = "//span[text()='Save']";
    public readonly string  BtnCancel = "//span[text()='Cancel']";
    public readonly string BtnCloseAfterCreateSuccess = "//span[text()='Close']";
    public string BtnClearDOB = "(//span[@class='anticon anticon-close-circle'])[1]";
    public string BtnClearJoinedDate = "(//span[@class='anticon anticon-close-circle'])[2]";
    public string BtnGender = "//span[text()=' {0} ']";
    public readonly string HeaderEditUser = "//h1[text()='Edit User']";
    public EditUserInfoPage() : base()
    {
    }
    public string ReturnEditUserHeader()
    {
        return HeaderEditUser;
    }
    public void EditUserInfo(EditUserDAO.EditUserUI userInfo)
    {
        EditDateOfBirth(userInfo.DateOfBirth);
        EditGender(userInfo.Gender); 
        EditJoinedDate(userInfo.JoinedDate);
        EditUserType(userInfo.Role);
        Click(BtnSave);
        Click(BtnCloseAfterCreateSuccess);
    }
    public void EditDate(string dateTimeString, string dateField)
    {
        DateTime dateTime = DateTime.ParseExact(dateTimeString, "yyyy/MM/dd", CultureInfo.InvariantCulture);
        SendKeys(dateField, dateTime.ToString("yyyy/MM/dd"));
    }
    public void EditDateOfBirth(string dateTimeString)
    {
        FindElementByXpath(BtnClearDOB).Click();
        EditDate(dateTimeString, DatePickDateOfBirth);
        PressEnter(DatePickDateOfBirth);
    }
    public void EditJoinedDate(string dateTimeString)
    {
        FindElementByXpath(BtnClearJoinedDate).Click();
        EditDate(dateTimeString, DatePickJoinedDate);
        PressEnter(DatePickJoinedDate);
    }
    public void EditUserType(string userType)
    {
        FindElementByXpath(DropBarType).Click();
        if (userType == Constant.ROLE_ADMIN)
        {
            OptionType = string.Format(OptionType, Constant.ROLE_ADMIN);
            FindElementByXpath(OptionType).Click();

        }
        else if (userType == Constant.ROLE_STAFF)
        {
            OptionType = string.Format(OptionType, Constant.ROLE_STAFF);
            FindElementByXpath(OptionType).Click();
        }
    }
    public void EditGender(string gender)
    {
        if (gender == Constant.GENDER_MALE)
        {
            BtnGender = string.Format(BtnGender, Constant.GENDER_MALE);
            FindElementByXpath(BtnGender).Click();
        }
        else
        {
            BtnGender = string.Format(BtnGender, Constant.GENDER_FEMALE);
            FindElementByXpath(BtnGender).Click();
        }
    }
}

