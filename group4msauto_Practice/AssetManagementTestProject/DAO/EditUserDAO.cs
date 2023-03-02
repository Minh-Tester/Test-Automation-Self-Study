namespace AssetManagementTestProject.DAO;

public class EditUserDAO
{
    #region EDIT USER REQUEST
    public partial class EditUserRequest
    {
        public Guid Id { get; private set; }
        public string DateOfBirth { get; private set; }
        public int Gender { get; private set; }
        public string JoinedDate { get; private set; }
        public int Role { get; private set; }
        public int AdminLocation { get; private set; }
        public EditUserRequest(Guid id, 
        string dateOfBirth, int gender, string joinedDate, 
        int role, int location)
        {
            Id = id;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            JoinedDate = joinedDate;
            Role = role;
            AdminLocation = location;
        }
    }
    public partial class EditUserUI
    {
        public string DateOfBirth { get; private set; } 
        public string Gender { get; private set; }
        public string JoinedDate { get; private set; }
        public string Role { get; private set; }
        public EditUserUI( string dateOfBirth, string gender, string joinedDate, 
        string role)
        {
            DateOfBirth = dateOfBirth;
            Gender = gender;
            JoinedDate = joinedDate;
            Role = role;
        }
    }
    #endregion
    #region EDIT USER RESPONSE
    public partial class EditUserResponse
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public Data Data { get; private set; }
        public EditUserResponse(bool status, string message, Data data)
        {
            IsSuccess = status;
            Message = message;
            Data = data;
        }
    }
    public partial class Data
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string StaffCode { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }
        public string DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public string JoinedDate { get; private set; }
        public string Role { get; private set; }
        public string Location { get; private set; }
        public Data(Guid id, string userName, string staffCode, 
        string firstName, string lastName, string fullName, string dateOfBirth,
        string gender, string joinedDate, string role, string location)
        {
            Id = id;
            Username = userName;
            StaffCode = staffCode;
            FirstName = firstName;
            LastName = lastName;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            JoinedDate = joinedDate;
            Role = role;
            Location = location;
        }
    }
    #endregion
}
