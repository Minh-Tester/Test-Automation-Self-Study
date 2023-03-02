using AssetManagementTestProject.DAO;
using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace AssetManagementTestProject.DataFromUI;
public class UserDataFromUI : WebDriverAction
{
    public UserDataFromUI() : base()
    {
    }
    public ViewUserDAO.ViewUserInList GetUserInfoFromGrid(string rowLocator, string cellLocator, int index)
    {
        // To check view user list
        List<string> valuesFromCells = GetTextFromAllCellsOfOneRow
            (rowLocator, cellLocator, index);

        ViewUserDAO.ViewUserInList user = new ViewUserDAO.ViewUserInList(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4]
            );
        return user;
    }
    public List<ViewUserDAO.ViewUserInList> ReturnUserList(string rowLocator, string cellLocator)
    {
        // Return all user info from a table (assuming that there is no empty row)
        int i = 0;
        List<ViewUserDAO.ViewUserInList> listOfUsers = new List<ViewUserDAO.ViewUserInList>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            ViewUserDAO.ViewUserInList user = GetUserInfoFromGrid(rowLocator, cellLocator, i + 1);
            listOfUsers.Add(user);
            i++;
        }
        return listOfUsers;
    }
    public List<string> ReturnUserListStaffCode(List<ViewUserDAO.ViewUserInList> userList)
    {
        List<string> staffCodeFromUserList = new List<string>();
        foreach (ViewUserDAO.ViewUserInList user in userList)
        {
            staffCodeFromUserList.Add(user.StaffCode);
        }
        return staffCodeFromUserList;

    }
    public List<string> ReturnUserListFullName(List<ViewUserDAO.ViewUserInList> userList)
    {
        List<string> staffCodeFromUserList = new List<string>();
        foreach (ViewUserDAO.ViewUserInList user in userList)
        {
            staffCodeFromUserList.Add(user.FullName);
        }
        return staffCodeFromUserList;

    }
    public List<string> ReturnUserListJoinedDate(List<ViewUserDAO.ViewUserInList> userList)
    {
        List<string> staffCodeFromUserList = new List<string>();
        foreach (ViewUserDAO.ViewUserInList user in userList)
        {
            staffCodeFromUserList.Add(user.JoinedDate);
        }
        return staffCodeFromUserList;

    }
    public List<string> ReturnUserListType(List<ViewUserDAO.ViewUserInList> userList)
    {
        List<string> staffCodeFromUserList = new List<string>();
        foreach (ViewUserDAO.ViewUserInList user in userList)
        {
            staffCodeFromUserList.Add(user.Type);
        }
        return staffCodeFromUserList;

    }
    public ViewUserDAO.ViewDetailedUser ReturnDetailedInfo(string locators)
    {
        List<string> valuesFromCells = new List<string>();
        IList<IWebElement> cellElems = FindElementsByXpath(locators);
        foreach (IWebElement elem in cellElems)
        {
            valuesFromCells.Add(elem.Text);
        }
        ViewUserDAO.ViewDetailedUser userDetailedInfo = new ViewUserDAO.ViewDetailedUser(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4],
            valuesFromCells[5],
            valuesFromCells[6]
        );
        return userDetailedInfo;
    }
}

