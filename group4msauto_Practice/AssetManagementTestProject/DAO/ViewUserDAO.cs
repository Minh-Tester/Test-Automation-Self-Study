
namespace AssetManagementTestProject.DAO;

public class ViewUserDAO
{
    /// <summary>
    /// To check View User - 5 properties
    /// </summary>
    public partial class ViewUserInList
    {
        public string StaffCode { get; private set; }
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string JoinedDate { get; private set; }
        public string Type { get; private set; }

        public ViewUserInList(string staffCode, string fullName,
        string userName, string joinedDate, string type)
        {
            StaffCode = staffCode;
            FullName = fullName;
            UserName = userName;
            JoinedDate = joinedDate;
            Type = type;
        }
    }
    /// <summary>
    /// To check Detailed User Info - 7 properties
    /// </summary>
    public partial class ViewDetailedUser
    {

        public string StaffCode { get; private set; }
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public string Type { get; private set; }
        public string Location { get; private set; }
        public ViewDetailedUser
        (string staffCode, string fullName, string username,
        string dateOfBirth, string gender, string type, string location)
        {
            StaffCode = staffCode;
            FullName = fullName;
            UserName = username;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Type = type;
            Location = location;
        }
    }

}
