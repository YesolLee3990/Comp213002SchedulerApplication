using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp213002SchedulerApplication.AppCode.controls.util {
    public class MUtil {
        public static string LOGIN_FAIL = "Incorrect information";
        public static string LOGIN_FAIL_3TIMES = "3 times login error. \nAccount will be locked for a while.";
        public static string LOGIN_ACCOUNT_LOCKED = "Account is locked. Please access later.";
        public static string LOGIN_SUCCESS = "Login successfully.";
        public static string COM_SAVE_SUCCESS = "Saved successfully.";
        public static string COM_SAVE_DELETE = "Deleted successfully.";
        public static string DUPLICATE_USERID = "There is same userid in the database. Choose other one.";
        public static string COM_SURE = "Are you sure?";
    }
}