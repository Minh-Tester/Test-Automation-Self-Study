
public class Constant
{
    #region URLS
    public static string BASE_URL = "https://www.google.com.vn/";
    public static string BASE_API = "";
    #endregion
    #region DEFAULT ADMIN USERNAME-PW
    public const string ADMIN_USERNAME_HN = "adminhn";
    public const string ADMIN_USERNAME_HCM = "adminhcm";
    public const string ADMIN_PASSWORD = "Admin@123";
    #endregion
    #region CREATED STAFF USERNAMES-PWS
    public const string STAFF_USERNAME = "anhp4";
    public const string STAFF_PASSWORD = "Staff@1234";
    #endregion
    #region USER INFO
    public const string GENDER_MALE = "Male";
    public const string GENDER_FEMALE = "Female";
    public enum Genders
    {
        Male,
        Female
    }
    public const string ROLE_ADMIN = "Admin";
    public const string ROLE_STAFF = "Staff";
    public enum Roles
    {
        Admin,
        Staff
    }
    public const string LOCATION_HANOI = "HaNoi";
    public const string LOCATION_HCM = "HoChiMinh";
    public enum Locations
    {
        HaNoi,
        HoChiMinh
    }
    #endregion
    public const string USER_CAN_BE_DISABLED_MSG = "User can be disabled";
}

