using Comp213002SchedulerApplication.App_Code.controls.constants;
using Comp213002SchedulerApplication.App_Code.controls.models;

namespace Comp213002SchedulerApplication.App_Code.controls.util {
    public class UserInfoUtil {
        public static UserInfo getLoginUser() {
            Task a = new Task();
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

        public static bool isManager() {
            return getLoginUser().UserType == 'M';
        }

        public static bool isAdmin() {
            return getLoginUser().UserType == 'A';
        }

        public static bool isNormalUser() {
            return getLoginUser().UserType == 'N';
        }
    }
}