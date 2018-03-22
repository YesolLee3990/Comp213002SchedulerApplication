using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp213002SchedulerApplication
{
    public partial class reschedulePopup : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Load();
        }

        protected void Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            
            DateTime dt = (DateTime)Session["selectedDate"];
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM dbo.task a, dbo.UserInfo b where a.Assignor = b.id and (ScheduleStart <= @dt and @dt >= ScheduleEnd)", myConnection);

            SqlParameter param_DATE = ad.SelectCommand.Parameters.Add("@dt", System.Data.SqlDbType.DateTime);
            param_DATE.Value = dt;

            myConnection.Open();
            ad.SelectCommand.ExecuteNonQuery();

            DataSet ds = new DataSet();
            ad.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.lbContents.Text = "<br>Task Name : " + row["subject"];
                this.lbContents.Text += ("<br>Assignor : " + row["userName"]);
                this.lbContents.Text += ("<br>Priority : " + row["Priority"]);
                this.lbContents.Text += ("<br>Status : " + row["Status"]);
                this.lbContents.Text += ("<br>Schedule Start : " + row["ScheduleStart"]);
                this.lbContents.Text += ("<br>Schedule End : " + row["ScheduleEnd"]);
                this.lbContents.Text += "<br><br>";
            }
            myConnection.Close();
        }
    }
}