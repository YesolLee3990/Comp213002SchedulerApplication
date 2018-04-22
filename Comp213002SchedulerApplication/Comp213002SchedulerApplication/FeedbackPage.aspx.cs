using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Comp213002SchedulerApplication
{
    public partial class FeedbackPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ToString());
        SqlDataAdapter ad = new SqlDataAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ad.InsertCommand = new SqlCommand("INSERT INTO [dbo].[Feedback] Values (@Name,@Email,@Subject,@Comments) ", conn);


                ad.InsertCommand.Parameters.Add("@Name", SqlDbType.NChar).Value = txtName.Text;
                ad.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                ad.InsertCommand.Parameters.Add("@Subject", SqlDbType.NChar).Value = txtSubject.Text;
                ad.InsertCommand.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = txtComments.Text;

                manmeet.Open();
                ad.InsertCommand.ExecuteNonQuery();
                manmeet.Close();
                lblMessage.Text = "Completed your feedback!";
            }

            catch (Exception ex)
            {
                Response.Write(ex);
            }
            if (lblMessage.Text == "Completed your feedback!")
            {
                txtName.Text = "";
                txtEmail.Text = "";
                txtSubject.Text = "";
                txtComments.Text = "";
            }
        }
    }
}