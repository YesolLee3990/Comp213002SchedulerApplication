using Comp213002SchedulerApplication.App_Code.controls.constants;
using Comp213002SchedulerApplication.App_Code.controls.models;

namespace Comp213002SchedulerApplication.App_Code.controls.util {
    public class UserInfoUtil {
        public static UserInfo getLoginUser() {
            UserInfo user = (UserInfo)SessionUtil.getSessionInfo(ApplicationConstants.LOGIN_SESSION_KEY);

            // temporary Code
            if (user == null) {
                user = new UserInfo();
                user.Id = 3;
                user.UserId = "manager1";
                user.UserType = 'M';
                user.EmployeeStatus = 'W';
            }
            return user;
        }

        public static int getLoginUserId() {
            return (int)SessionUtil.getSessionInfo(ApplicationConstants.LOGIN_ID);
        }

        public static bool isManager() {
            return (char)SessionUtil.getSessionInfo(ApplicationConstants.LOGIN_USER_NAME) == 'M';
        }

        public static bool isAdmin() {
            return (char)SessionUtil.getSessionInfo(ApplicationConstants.LOGIN_USER_NAME) == 'A';
        }

        public static bool isNormalUser() {
            return (char)SessionUtil.getSessionInfo(ApplicationConstants.LOGIN_USER_NAME) == 'N';
        }

        public static UserInfo getUserInfo(int key) {
            return DBUtil.SelectOneById<UserInfo>(key);
        }
    }
}