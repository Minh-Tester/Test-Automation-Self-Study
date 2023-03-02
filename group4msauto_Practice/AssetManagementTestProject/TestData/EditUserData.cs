using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
namespace AssetManagementTestProject.TestData
{
    public class EditUserData : NUnitWebTestSetup
    {
        public EditUserData(string browser, int width, int height) : base(browser, width, height)
        {
        }

        public static EditUserDAO.EditUserUI InfoToBeEdited = new EditUserDAO.EditUserUI
        (
            "2000/06/13",
            Constant.GENDER_FEMALE,
            "2022/11/02",
            Constant.ROLE_STAFF
        );        
        public static EditUserDAO.EditUserUI ExpectedEditInfo = new EditUserDAO.EditUserUI(
            "13/06/2000",
            Constant.GENDER_FEMALE,
            "02/11/2000",
            Constant.ROLE_STAFF
        );
    }
}
