using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;
using System.Globalization;

namespace AssetManagementTestProject.PageObj;
public class CreateUserPage : WebDriverAction
{
    #region BUTTONS AND TEXT FIELDS
    public readonly string BtnSave = "//span[text()='Save']";
    public readonly string BtnCancel = "//span[text()='Cancel']";
    public readonly string BtnCloseAfterCreateSuccess = "//span[text()='Close']";
    public readonly string DatePickDateOfBirth = "//input[contains(@id, 'formCreateUser_dateOfBirth')]";
    public readonly string DatePickJoinedDate = "//input[contains(@id, 'formCreateUser_joinedDate')]";
    public readonly string DropBarType = "//input[@id='formCreateUser_role']";
    public readonly string TfFirstName = "//input[contains(@id, 'formCreateUser_firstName')]";
    public readonly string TfLastName = "//input[contains(@id, 'formCreateUser_lastName')]";
    public string BtnGender = "//span[text()='{0}']";
    public string OptionType = "//div[@title='{0}']";
    #endregion
    #region ERROR MESSAGES
    public readonly string ErrorMsgInvalidName = "//div[text()='Name should only contain alphabetic: A to Z or a to z and one space between words!']";
    public readonly string ErrorMsgDOBUnder18 = "//div[text()='User is under 18. Please select a different date!']";
    public readonly string ErrorMsgJoinedDateNotLaterThanDOB = "//div[text()='Joined date must later than Date of Birth. Please select a different date!']";
    public readonly string ErrorMsgJoinDateIsWeekend = "//div[text()='Joined date must not be Saturday or Sunday. Please select a different date!']";
    #endregion
    
    public CreateUserPage() : base()
    {
    }
    public void CreateNewUser(CreateUserDAO.CreateUserUI userInfo)
    {
        SendKeys(TfFirstName, userInfo.FirstName);
        SendKeys(TfLastName,userInfo.LastName);
        SelectDateOfBirth(userInfo.DateOfBirth);
        SelectGender(userInfo.Gender); 
        SelectJoinedDate(userInfo.JoinedDate);
        SelectUserType(userInfo.Role);
        Click(BtnSave);
        Click(BtnCloseAfterCreateSuccess);
    }
    public void SendInvalidInfo(CreateUserDAO.CreateUserUI invalidUserInfo)
    {
        SendKeys(TfFirstName, invalidUserInfo.FirstName);
        SendKeys(TfLastName,invalidUserInfo.LastName);
        SelectDateOfBirth(invalidUserInfo.DateOfBirth);
        SelectJoinedDate(invalidUserInfo.JoinedDate);
        SelectUserType(invalidUserInfo.Role);
    }
    public void SelectDate(string dateTimeString, string dateField)
    {
        DateTime dateTime = DateTime.ParseExact(dateTimeString, "yyyy/MM/dd", CultureInfo.InvariantCulture);
        SendKeys(dateField, dateTime.ToString("yyyy/MM/dd"));
    }
    public void SelectDateOfBirth(string dateTimeString)
    {
        SelectDate(dateTimeString, DatePickDateOfBirth);
        PressEnter(DatePickDateOfBirth);
    }
    public void SelectJoinedDate(string dateTimeString)
    {
        SelectDate(dateTimeString, DatePickJoinedDate);
        PressEnter(DatePickJoinedDate);
    }
    public void SelectUserType(string userType)
    {
        FindElementByXpath(DropBarType).Click();
        if (userType == Constant.ROLE_ADMIN)
        {
            OptionType = string.Format(OptionType, Constant.ROLE_ADMIN);
            Click(OptionType);

        }
        else if (userType == Constant.ROLE_STAFF)
        {
            OptionType = string.Format(OptionType, Constant.ROLE_STAFF);
            Click(OptionType);
        }
    }
    public void SelectGender(string gender)
    {
        if (gender == Constant.GENDER_MALE)
        {
            BtnGender = string.Format(BtnGender, Constant.GENDER_MALE);
            FindElementByXpath(BtnGender).Click();
        }
        else
        {
            BtnGender = string.Format(BtnGender, Constant.GENDER_MALE);
            FindElementByXpath(BtnGender).Click();
        }
    }
}
