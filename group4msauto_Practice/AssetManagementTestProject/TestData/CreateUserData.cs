using AssetManagementTestProject.DAO;
namespace AssetManagementTestProject.TestData
{
    public class CreateUserData
    {
        #region SEND POST REQUEST TO CREATE NEW ADMIN/STAFF
        public static CreateUserDAO.CreateUserRequest NEW_ADMIN_HN = new CreateUserDAO.CreateUserRequest
        (
            "Anh",
            "Pham",
            "2000-06-12",
            (int)Constant.Genders.Male,
            "2022-11-01",
            (int)Constant.Roles.Admin,
            (int)Constant.Locations.HaNoi
        );
        public static CreateUserDAO.CreateUserUI NEW_ADMIN_UI = new CreateUserDAO.CreateUserUI
        (
            "Anh",
            "Pham",
            "2000/06/12",
            Constant.GENDER_MALE,
            "2022/11/01",
            Constant.ROLE_ADMIN
        );
        public static CreateUserDAO.CreateUserUI INVALID_INFO = new CreateUserDAO.CreateUserUI
        (
            "Anh111",
            "Pham111",
            "2022/12/07",
            Constant.GENDER_MALE,
            "2022/12/04",
            Constant.ROLE_ADMIN
        );
        #endregion
    }
}
