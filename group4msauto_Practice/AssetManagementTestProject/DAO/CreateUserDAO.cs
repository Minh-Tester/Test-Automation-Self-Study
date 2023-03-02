namespace AssetManagementTestProject.DAO;

public class CreateUserDAO
{
    #region CREATE USER WITH API AND VIA UI
    public partial class CreateUserRequest
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string DateOfBirth { get; private set; }
        public int Gender { get; private set; }
        public string JoinedDate { get; private set; }
        public int Role { get; private set; }
        public int Location { get; private set; }
        public CreateUserRequest(string firstName, string lastName, 
        string dateOfBirth, int gender, string joinedDate, 
        int role, int location )
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            JoinedDate = joinedDate;
            Role = role;
            Location = location;
        }
    }

    public partial class CreateUserUI
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public string JoinedDate { get; private set; }
        public string Role { get; private set; }
        public CreateUserUI(string firstName, string lastName, 
        string dateOfBirth, string gender, string joinedDate, 
        string role)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            JoinedDate = joinedDate;
            Role = role;
        }
    }
    #endregion
    #region CREATE USER RESPONSE BODY
    public partial class CreateUserResponse
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public Data Data { get; private set; }
        public CreateUserResponse(bool status, string message, Data data)
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

