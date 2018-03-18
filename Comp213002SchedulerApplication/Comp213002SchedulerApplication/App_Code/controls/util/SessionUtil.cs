using Comp213002SchedulerApplication.App_Code.controls.constants;
using Comp213002SchedulerApplication.App_Code.controls.types;

namespace Comp213002SchedulerApplication.App_Code.controls.util {
    public class SessionUtil{
        public static object getSessionInfo(string key) {
            return System.Web.HttpContext.Current.Session[key];
        }
    }
}