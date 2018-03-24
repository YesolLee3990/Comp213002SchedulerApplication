using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Comp213002SchedulerApplication
{
    public partial class Login : System.Web.UI.Page
    {


        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isAuthenticated = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;

            SqlCommand com = new SqlCommand("SELECT * FROM UserInfo", conn);



            if (Session["User"] != null)
            {
                // nologin.Visible = false;
                Username.Text = (string)(Session["User"]);
                //login.Visible = true;
            }

            if (isAuthenticated == true)
            {
                //nologin.Visible = false;
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            /*Check user credentical and login*/

            SqlCommand checkUser = new SqlCommand("Select UserId FROM [dbo].[UserInfo] WHERE UserId = @username", conn);
            SqlCommand checkPassword = new SqlCommand("Select Password FROM [dbo].[UserInfo] WHERE Password = @password", conn);

            checkUser.Parameters.Add("@username", SqlDbType.NVarChar);
            checkUser.Parameters["@username"].Value = loginUsernameTB.Text;

            checkPassword.Parameters.Add("@password", SqlDbType.NVarChar);
            checkPassword.Parameters["@password"].Value = loginPasswordTB.Text;


            try
            {
                conn.Open();
                string username = checkUser.ExecuteScalar().ToString();

                if (username != null && String.Equals(username, loginUsernameTB.Text))
                {
                    object returnValue = checkPassword.ExecuteScalar();
                    if (returnValue == null)
                    {
                        return;
                    }
                    string password = returnValue.ToString();

                    if (password != null && String.Equals(password, loginPasswordTB.Text))
                    {
                        FormsAuthentication.SetAuthCookie(username, false);
                        //nologin.Visible = false;
                        Session["User"] = loginUsernameTB.Text;
                        Response.Redirect("~/WebForm1.aspx");

                    }

                }
                else
                {
                    WarningLblLogin.Text = "No username was found";
                }

            }
            catch (Exception exception)
            {
                WarningLblLogin.Text = exception.Message.ToString();
            }
            finally
            {
                conn.Close();
            }


        }
    }
}