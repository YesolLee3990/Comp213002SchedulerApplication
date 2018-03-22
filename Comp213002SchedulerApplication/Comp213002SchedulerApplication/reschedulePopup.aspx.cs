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

        private static List<dailyTaskHandler> taskList = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                taskList = new List<dailyTaskHandler>();
                Load();
            }
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
            
            makeDropDownList();
            makeAString();


            myConnection.Close();
        }

        public void makeDropDownList()
        {
            var tempVar = taskList.Select(l_taskName => l_taskName.taskName);
            List<string> dataSource = tempVar.ToList();
            dataSource.Add("ALL");
            this.ddTaskList.DataSource = dataSource;
            this.ddTaskList.DataBind();
        }

        public void makeAString()
        {
            string vTaskName;            string vAssignor;
            string vPriority;            string vStatus;
            string vStartDate;            string vEndDate;

            if (this.ddTaskList.SelectedValue == "ALL")
            {
                vTaskName = taskList.Select(l_taskName => l_taskName.taskName).Aggregate((current, next) => current + ", " + next);
                vAssignor = taskList.Select(l_Assignor => l_Assignor.assignor).Aggregate((current, next) => current + ", " + next);
                vPriority = taskList.Select(l_Priority => l_Priority.priority).Aggregate((current, next) => current + ", " + next);
                vStatus = taskList.Select(l_status => l_status.status).Aggregate((current, next) => current + ", " + next);
                vStartDate = taskList.Select(l_startDate => l_startDate.startDate).Aggregate((current, next) => current + ", " + next);
                vEndDate = taskList.Select(l_endDate => l_endDate.endDate).Aggregate((current, next) => current + ", " + next);
            }else{
                string item = this.ddTaskList.SelectedValue;
                vTaskName = item;
                vAssignor = taskList.Where(x => x.taskName == item).Select(s => s.assignor).SingleOrDefault();
                vPriority = taskList.Where(x => x.taskName == item).Select(s => s.priority).SingleOrDefault();
                vStatus = taskList.Where(x => x.taskName == item).Select(s => s.status).SingleOrDefault();
                vStartDate = taskList.Where(x => x.taskName == item).Select(s => s.startDate).SingleOrDefault();
                vEndDate = taskList.Where(x => x.taskName == item).Select(s => s.endDate).SingleOrDefault();
            }
            

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

        protected void ddTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int xxx = 10;
            makeAString();
        }
    }


}