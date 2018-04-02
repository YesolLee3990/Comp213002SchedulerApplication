using System;
using System.Collections.Generic;
using System.Web;

namespace Comp213002SchedulerApplication.AppCode.controls.constants {
    public class ApplicationConstants {
        public static int userLockTime = 3; // minutes
        public static String MAIN = "MAIN";
        public static string REGISTER = "REGISTER";
        public static string LOGIN_SESSION_KEY = "loginUserInfo";

        // Do use user information in session for webservice & common pages
        public static string LOGIN_USER_ID = "loginUserId";
        public static string LOGIN_ID = "loginId";
        public static string LOGIN_USER_NAME = "loginUserName";
        public static string LOGIN_USER_TYPE = "loginUserType";
        public static string LOGIN_USER_EMP_STATUS = "loginUserEmpStatus";
        public static string LOGIN_USER_EMAIL = "loginUserEamil";
    }
}