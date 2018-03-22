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

        List<dailyTaskHandler> taskList = new List<dailyTaskHandler>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Load();
        }

        protected void Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            
            DateTime dt = (DateTime)Session["selectedDate"];
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM dbo.task a, dbo.UserInfo b where a.Assignor = b.id and (ScheduleStart <= @dt and @dt <= ScheduleEnd)", myConnection);

            SqlParameter param_DATE = ad.SelectCommand.Parameters.Add("@dt", System.Data.SqlDbType.DateTime);
            param_DATE.Value = dt;

            myConnection.Open();
            ad.SelectCommand.ExecuteNonQuery();

            DataSet ds = new DataSet();
            ad.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dailyTaskHandler dth = new dailyTaskHandler();
                dth.taskName = (string)row["subject"];
                dth.assignor = (string)row["userName"];
                dth.priority = (string)row["Priority"];
                dth.status = (string)row["Status"];
                dth.startDate = ((System.DateTime)row["ScheduleStart"]).ToLongDateString();
                dth.endDate = ((System.DateTime)row["ScheduleEnd"]).ToShortDateString();

                taskList.Add(dth);
            }
            makeAString();

            myConnection.Close();
        }

        public void makeAString()
        {

            string vTaskName = taskList.Select(l_taskName => l_taskName.taskName).Aggregate((current, next) => current + ", " + next);
            string vAssignor = taskList.Select(l_Assignor => l_Assignor.assignor).Aggregate((current, next) => current + ", " + next);
            string vPriority = taskList.Select(l_Priority => l_Priority.priority).Aggregate((current, next) => current + ", " + next);
            string vStatus = taskList.Select(l_status => l_status.status).Aggregate((current, next) => current + ", " + next);
            string vStartDate = taskList.Select(l_startDate => l_startDate.startDate).Aggregate((current, next) => current + ", " + next);
            string vEndDate = taskList.Select(l_endDate => l_endDate.endDate).Aggregate((current, next) => current + ", " + next);

            this.lbContents.Text = "<br>Task Name : " + vTaskName;
            this.lbContents.Text += "<br>Assignor : " + vAssignor;
            this.lbContents.Text += "<br>Priority : " + vPriority;
            this.lbContents.Text += "<br>Status : " + vStatus;
            this.lbContents.Text += "<br>Schedule Start : " + vStartDate;
            this.lbContents.Text += "<br>Schedule End : " + vEndDate;
            this.lbContents.Text += "<br><br>";
        }


        public class dailyTaskHandler
        {
            public string taskName { get; set; }
            public string assignor { get; set; }
            public string priority { get; set; }
            public string status { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }

        }
    }


}