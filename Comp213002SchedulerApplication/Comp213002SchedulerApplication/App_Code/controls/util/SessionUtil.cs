using Comp213002SchedulerApplication.App_Code.controls.constants;
using Comp213002SchedulerApplication.App_Code.controls.models;
using System;
using System.Web.Services;
using static Comp213002SchedulerApplication.App_Code.controls.constants.ApplicationConstants;

namespace Comp213002SchedulerApplication.App_Code.controls.util {
    public class SessionUtil{
        public static bool isLogin() {
            return (UserInfo)getSessionInfo(LOGIN_SESSION_KEY) != null;
        } 
        public static object getSessionInfo(string key) {
            return System.Web.HttpContext.Current.Session[key];
        }

        public static bool expireSession() {
            bool result = true;
            try {
                System.Web.HttpContext.Current.Session.Abandon();
                System.Web.HttpContext.Current.Session.Clear();
            }
            catch(Exception e) {
                return false;
            }

            return result;
        }

        public static Result putSessionInfo(string key, object value) {
            Result result = new Result();
            try {
                if(value is UserInfo) {
                    UserInfo user = (UserInfo)value;
                    System.Web.HttpContext.Current.Session.Add(LOGIN_ID, user.Id);
                    System.Web.HttpContext.Current.Session.Add(LOGIN_USER_ID, user.UserId);
                    System.Web.HttpContext.Current.Session.Add(LOGIN_USER_NAME, user.UserName);
                    System.Web.HttpContext.Current.Session.Add(LOGIN_USER_TYPE, user.UserType);
                    System.Web.HttpContext.Current.Session.Add(LOGIN_USER_EMP_STATUS, user.EmployeeStatus);
                    System.Web.HttpContext.Current.Session.Add(LOGIN_USER_EMAIL, user.Email);
                }
                System.Web.HttpContext.Current.Session.Add(key, value);
            }
            catch(Exception e) {
                result.ErrorMsg = e.Message;
                result.Success = false;
            }
            return result;
        }
    }
}