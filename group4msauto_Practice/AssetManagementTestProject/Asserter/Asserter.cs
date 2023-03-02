using AssetManagementTestProject.DAO;
using CoreFramework.DriverCore;
using FluentAssertions;

namespace AssetManagementTestProject.Asserter;

public class Asserter : WebDriverAction
{
    public Asserter() : base()
    {
    }
    #region ELEMENT DISPLAY ASSERTION
    public void AssertElementIsDisplayed(string locator)
    {
        VerifyElementIsDisplayed(locator).Should().BeTrue();
    }
    #endregion

    #region CHECK EQUALS
    public void AssertViewUserEquals(ViewUserDAO.ViewUserInList actual, ViewUserDAO.ViewUserInList expected)
    {
        AssertEquals(actual, expected);
    }
    public void AssertDetailedUserEquals(ViewUserDAO.ViewDetailedUser actual, ViewUserDAO.ViewDetailedUser expected)
    {
        AssertEquals(actual, expected);
    }


    #endregion

    #region CHECK ORDER
    public void AssertUserListAscending(List<string> list)
    {
        AssertListAscending(list);
    }
    public void AssertUserListDescending(List<string> list)
    {
        AssertListDescending(list);
    }
    #endregion
}
