using AssetManagementTestProject.DAO;
using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;
namespace AssetManagementTestProject.Services;
public class AssetManagementAPIServices
{
    #region AUTHORIZATION
    private string userLoginPath = "api/authentication";
    private APIResponse LoginRequest(string username, string password)
    {
        string body = "{\"username\":\"" + username + "\",\"password\": \"" + password + "\"}";
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API + userLoginPath)
               .AddHeader("Content-Type", "application/json")
               .AddHeader("Accept-Encoding", "none")
               .AddHeader("Accept", "*/*")
               .AddHeader("Connection", "keep-alive")
               .SetBody(body)
               .Post();
        return response;
    }
    public string ReturnLoginToken(string username, string password)
    {
        APIResponse response = LoginRequest(username, password);
        Assert.True(response.responseStatusCode.Equals("OK"));
        LoginDAO.LoginPostResponse? loginResponse = JsonConvert.DeserializeObject
            <LoginDAO.LoginPostResponse>(response.responseBody);
        return loginResponse.Data.Token;
    }
    #endregion
    #region CREATE NEW USER
    private string createUserPath = "api/users";
    private APIResponse CreateNewUserRequest(CreateUserDAO.CreateUserRequest newUser, string token)
    {
        string body = JsonConvert.SerializeObject(newUser);
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API + createUserPath)
               .AddHeader("Authorization", token)
               .AddHeader("Content-Type", "application/json")
               .AddHeader("Accept-Encoding", "none")
               .AddHeader("Accept", "*/*")
               .AddHeader("Connection", "keep-alive")
               .SetBody(body)
               .Post();
        return response;
    }
    public CreateUserDAO.CreateUserResponse ReturnNewUser
    (CreateUserDAO.CreateUserRequest newUserRequest, string token)
    {
        APIResponse response = CreateNewUserRequest(newUserRequest, token);
        Assert.True(response.responseStatusCode.Equals("OK"));
        CreateUserDAO.CreateUserResponse? newUser = JsonConvert.DeserializeObject
            <CreateUserDAO.CreateUserResponse>(response.responseBody);
        return newUser;
    }
    #endregion
    #region GET USER 
    private string returnUserPath = "api/users/{0}";
    private APIResponse GetUserRequest(string userId, string token)
    {
        string requestPath = string.Format(returnUserPath, userId);
        APIResponse response = new APIRequest()
                .SetURL(Constant.BASE_API + requestPath)
                .AddHeader("Authorization", token)
                .AddHeader("Accept-Encoding", "none")
                .AddHeader("Accept", "*/*")
                .AddHeader("Connection", "keep-alive")
                .Get();
        return response;
    }
    public GetUserDAO.GetUserResponse ReturnSelectedUser(string userId, string token)
    {
        APIResponse response = GetUserRequest(userId, token);
        Assert.True(response.responseStatusCode.Equals("OK"));
        GetUserDAO.GetUserResponse? selectedUser = JsonConvert.DeserializeObject
        <GetUserDAO.GetUserResponse>(response.responseBody);
        return selectedUser;
    }
    #endregion
    #region EDIT USER
    private string editUserPath = "api/users";
    private APIResponse EditUserRequest
    (EditUserDAO.EditUserRequest editUser, string token)
    {
        string body = JsonConvert.SerializeObject(editUser);
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API + editUserPath)
               .AddHeader("Authorization", token)
               .AddHeader("Content-Type", "application/json")
               .AddHeader("Accept-Encoding", "none")
               .AddHeader("Accept", "*/*")
               .AddHeader("Connection", "keep-alive")
               .SetBody(body)
               .Put();
        return response;
    }
    public EditUserDAO.EditUserResponse ReturnEditUserResponse
    (EditUserDAO.EditUserRequest editUser, string token)
    {
        APIResponse response = EditUserRequest(editUser, token);
        Assert.True(response.responseStatusCode.Equals("OK"));
        EditUserDAO.EditUserResponse? editedUser = JsonConvert.DeserializeObject
            <EditUserDAO.EditUserResponse>(response.responseBody);
        return editedUser;
    }
    #endregion
    
    #region CHECK IF USER CAN BE DISABLE AND DISABLE USER
    private string checkIfDisablePath = "api/users/disable-availability/{0}";
    private APIResponse GetDisableUserRequest(string userId, string token)
    {
        string requestPath = string.Format(checkIfDisablePath, userId);
        APIResponse response = new APIRequest()
                .SetURL(Constant.BASE_API + requestPath)
                .AddHeader("Authorization", token)
                .AddHeader("Accept-Encoding", "none")
                .AddHeader("Accept", "*/*")
                .AddHeader("Connection", "keep-alive")
                .Get();
        return response;
    }
    public GetUserDAO.GetCanDisableUser ReturnCanDisableUser(string userId, string token)
    {
        APIResponse response = GetDisableUserRequest(userId, token);
        Assert.True(response.responseStatusCode.Equals("OK"));
        GetUserDAO.GetCanDisableUser? selectedUser = JsonConvert.DeserializeObject
        <GetUserDAO.GetCanDisableUser>(response.responseBody);
        return selectedUser;
    }

    private string disableUserPath = "api/users/disable";
    private APIResponse DisableUserRequest
    (DisableUserDAO.DisableUserRequest disableUser, string token)
    {
        string body = JsonConvert.SerializeObject(disableUser);
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API + disableUserPath)
               .AddHeader("Authorization", token)
               .AddHeader("Content-Type", "application/json")
               .AddHeader("Accept-Encoding", "none")
               .AddHeader("Accept", "*/*")
               .AddHeader("Connection", "keep-alive")
               .SetBody(body)
               .Put();
        return response;
    }
    public DisableUserDAO.DisableUserResponse ReturnDisableUserResponse
    (DisableUserDAO.DisableUserRequest disableUser, string token)
    {
        APIResponse response = DisableUserRequest(disableUser, token);
        Assert.True(response.responseStatusCode.Equals("OK"));
        DisableUserDAO.DisableUserResponse? message = JsonConvert.DeserializeObject
            <DisableUserDAO.DisableUserResponse>(response.responseBody);
        return message;
    }
    #endregion
}
