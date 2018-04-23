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
    public partial class FeedbackList : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            
            SqlCommand comm = new SqlCommand("Select Name,Email,Subject,Comments from [dbo].[Feedback] ", conn);

            conn.Open();
            
            SqlDataReader reader = comm.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            reader.Close();
            conn.Close();
        }
    }
}