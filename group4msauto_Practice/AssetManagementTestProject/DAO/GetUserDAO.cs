namespace AssetManagementTestProject.DAO;

public class GetUserDAO
{
    public partial class GetUserResponse
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public Data Data { get; private set; }
        public GetUserResponse(bool status, string message, Data data)
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

        public Data(Guid id, string userName, string staffCode, string firstName, 
        string lastName, string fullName, string dateOfBirth, string gender,
        string joinedDate, string role, string location)
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
    public partial class GetCanDisableUser
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public GetCanDisableUser(bool status, string message)
        {
            IsSuccess = status;
            Message = message;
        }
    }

}
