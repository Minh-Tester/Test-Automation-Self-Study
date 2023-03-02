namespace AssetManagementTestProject.DAO;

public class DisableUserDAO
{
    #region DISABLE USER REQUEST
    public partial class DisableUserRequest
    {
        public Guid Id { get; private set; }
        public int Location { get; private set; }

        public DisableUserRequest(Guid id, int location)
        {
            Id = id;
            Location = location;
        }
    }
    #endregion
    #region DISABLE USER RESPONSE BODY
    public partial class DisableUserResponse
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public DisableUserResponse(bool status, string message)
        {
            IsSuccess = status;
            Message = message;
        }
    }
    #endregion
}
