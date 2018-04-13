using Comp213002SchedulerApplication.AppCode.controls.constants;
using Comp213002SchedulerApplication.AppCode.controls.models;

namespace Comp213002SchedulerApplication.AppCode.controls.util {
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
            object obj = SessionUtil.getSessionInfo(ApplicationConstants.LOGIN_ID);
            if (obj == null) return 0;
            return (int)obj;
        }

        public static bool isManager() {
            return GetLoginUserType() == 'M' || GetLoginUserType() == 'A';
        }

        public static bool isAdmin() {
            return GetLoginUserType() == 'A';
        }

        public static bool isNormalUser() {
            return GetLoginUserType() == 'N';
        }

        private static char GetLoginUserType() {
            object obj = SessionUtil.getSessionInfo(ApplicationConstants.LOGIN_USER_TYPE);
            if (obj == null) return '\0';
            else return (char)obj;
        }

        public static UserInfo getUserInfo(int key) {
            return DBUtil.SelectOneById<UserInfo>(key);
        }
    }
}