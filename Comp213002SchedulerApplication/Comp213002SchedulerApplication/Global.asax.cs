using Comp213002SchedulerApplication.AppCode.controls.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Comp213002SchedulerApplication {
    public class Global : HttpApplication {
        void Application_Start(object sender, EventArgs e) {
            // Code that runs on application startup
            RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}");
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configure(config => {
                config.MapHttpAttributeRoutes();
                config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            });
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.MapPageRoute("",
                "Category/{action}/{categoryName}",
                "~/categoriespage.aspx");
        }
        //
        protected void Application_PostAuthorizeRequest() {
            HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }

        void Application_Error(object sender, EventArgs e) {

            try { 
                int loginUserId = UserInfoUtil.getLoginUserId();
                if (loginUserId == 0) loginUserId = 1;

                Exception ex = Server.GetLastError();
                string msg = ex.Message + "\n" + ex.InnerException.StackTrace.Replace('\'', '"');
                if (msg.Length > 1000) msg = msg.Substring(0, 1000);

                DBUtil.Execute("INSERT INTO ERROR (USERID, ERRORMSG) VALUES ('" + loginUserId + "', '" + msg + "')");
            }
            catch (Exception err) {
                Console.WriteLine(err);
            }

            //// Clear the error from the server
            //Server.ClearError();
        }

        void Application_PreRequestHandlerExecute(object sender, EventArgs e) {
            string url = Request.Url.ToString();
            SessionCheck(url);
        }

        private void SessionCheck(string url) {
            if (!SessionUtil.isLogin() && (url.IndexOf("Login") < 0 && url.EndsWith(".aspx"))) {
                Session["SessionExpire"] = true;
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}