using Comp213002SchedulerApplication.App_Code.controls.constants;
using Comp213002SchedulerApplication.App_Code.controls.models;
using System;
using System.Web.Services;

namespace Comp213002SchedulerApplication.App_Code.controls.util {
    public class SessionUtil{
        
        public static object getSessionInfo(string key) {
            return System.Web.HttpContext.Current.Session[key];
        }

        public static Result putSessionInfo(string key, object value) {
            Result result = new Result();
            try {
                System.Web.HttpContext.Current.Session.Add(key, value);
            }catch(Exception e) {
                result.ErrorMsg = e.Message;
                result.Success = false;
            }
            return result;
        }
    }
}