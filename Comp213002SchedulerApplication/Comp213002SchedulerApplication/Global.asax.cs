using Comp213002SchedulerApplication.App_Code.controls.util;
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
        //
        protected void Application_PostAuthorizeRequest() {
            HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }

        void Application_Error(object sender, EventArgs e) {
            //// Code that runs when an unhandled error occurs

            //// Get the exception object.
            //Exception exc = Server.GetLastError();

            //// Handle HTTP errors
            //if (exc.GetType() == typeof(HttpException)) {
            //    // The Complete Error Handling Example generates
            //    // some errors using URLs with "NoCatch" in them;
            //    // ignore these here to simulate what would happen
            //    // if a global.asax handler were not implemented.
            //    if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
            //        return;

            //    //Redirect HTTP errors to HttpError page
            //    Server.Transfer("HttpErrorPage.aspx");
            //}

            //// For other kinds of errors give the user some information
            //// but stay on the default page
            //Response.Write("<h2>Global Page Error</h2>\n");
            //Response.Write(
            //    "<p>" + exc.Message + "</p>\n");
            //Response.Write("Return to the <a href='Default.aspx'>" +
            //    "Default Page</a>\n");

            //// Log the exception and notify system operators
            ////ExceptionUtility.LogException(exc, "DefaultPage");
            ////ExceptionUtility.NotifySystemOps(exc);

            //// Clear the error from the server
            //Server.ClearError();
        }

        void Application_PreRequestHandlerExecute(object sender, EventArgs e) {
            string url = Request.Url.ToString();
            if (!SessionUtil.isLogin() && (url.IndexOf("Login") < 0 && url.EndsWith(".aspx"))) {
                Session["SessionExpire"] = true;
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}