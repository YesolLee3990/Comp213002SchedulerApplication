using Comp213002SchedulerApplication.AppCode.controls.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
            try
            {
                if (!IsPostBack)
                {
                    taskList = new List<dailyTaskHandler>();
                    Load();
                }
            }catch(Exception ex)
            {
                string xx = ex.StackTrace;
            }
            
        }

        protected new void Load()
        {
            try
            {


                string connectionString = ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(connectionString);

                DateTime dt = (DateTime)Session["selectedDate"];
                SqlDataAdapter ad = new SqlDataAdapter("SELECT a.ID, a.Subject, a.UserInfo_ID, a.Assignor,b.UserName, a.Priority, a.Status, a.ScheduleStart, a.ScheduleEnd FROM dbo.task a, dbo.UserInfo b where a.Assignor = b.id and (ScheduleStart <= @dt and @dt <= ScheduleEnd)", myConnection);

                SqlParameter param_DATE = ad.SelectCommand.Parameters.Add("@dt", System.Data.SqlDbType.DateTime);
                param_DATE.Value = dt;

                myConnection.Open();
                ad.SelectCommand.ExecuteNonQuery();

                DataSet ds = new DataSet();
                ad.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dailyTaskHandler dth = new dailyTaskHandler();
                    dth.taskID = "" + (int)row["ID"];
                    dth.taskName = (string)row["subject"];
                    dth.assignee = "" + (int)row["UserInfo_ID"];
                    dth.assignorID = "" + (int)row["assignor"];
                    dth.assignor = (string)row["userName"];
                    dth.priority = (string)row["Priority"];
                    dth.status = (string)row["Status"];
                    dth.startDate = ((System.DateTime)row["ScheduleStart"]).ToString("yyyy/MM/dd").Replace('-', '/');
                    dth.endDate = ((System.DateTime)row["ScheduleEnd"]).ToString("yyyy/MM/dd").Replace('-', '/');

                    taskList.Add(dth);
                }

                makeDropDownList();
                makeAString();


                myConnection.Close();
            }
            catch (Exception ex)
            {
                string x = ex.StackTrace;
            }
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

            if (taskList.Count == 0)
            {
                this.lbContents.Text = "You do not have any tasks.";
                return;
            }
            if (this.ddTaskList.SelectedValue == "ALL")
            {
                vTaskName = taskList.Select(l_taskName => l_taskName.taskName).Aggregate((current, next) => current + ", " + next);
                vAssignor = taskList.Select(l_Assignor => l_Assignor.assignor).Aggregate((current, next) => current + ", " + next);
                vPriority = taskList.Select(l_Priority => l_Priority.priority).Aggregate((current, next) => current + ", " + next);
                vStatus = taskList.Select(l_status => l_status.status).Aggregate((current, next) => current + ", " + next);
                vStartDate = "-";
                vEndDate = "-";
                
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
            this.txtSdateValue.Text = vStartDate;
            this.txtEdateValue.Text = vEndDate;
            this.lbContents.Text += "<br><br>";
        }


        public class dailyTaskHandler
        {
            public string taskID { get; set; }
            public string taskName { get; set; }
            public string assignee { get; set; }
            public string assignor { get; set; }
            public string assignorID { get; set; }
            public string priority { get; set; }
            public string status { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }

        }

        protected void ddTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                makeAString();
            }catch(Exception ex)
            {
                string x = ex.StackTrace;
            }
            
        }

        protected void ButtonRequest_Click(object sender, EventArgs e)
        {
            string format = "yyyy/MM/dd";
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime sDate;
            DateTime eDate;

            if (this.ddTaskList.SelectedValue.Equals("ALL"))
            {
                if (this.cBoxDayOff.Checked)
                {
                    this.lbErrorMsg.Text = "Category 'ALL' but day-off request";
                }else
                {
                    this.lbErrorMsg.Text = "Specify the task you want to make a change dates.";
                    return;
                }
            }else
            {
                sDate = DateTime.ParseExact(this.txtSdateValue.Text, format, provider);
                eDate = DateTime.ParseExact(this.txtEdateValue.Text, format, provider);

                if (DateTime.Compare(sDate, eDate) > 0)
                {
                    this.lbErrorMsg.Text = "End date is ealier than start date.";

                    return;
                }

                string sDateStr = taskList.Where(x => x.taskName == this.ddTaskList.SelectedValue).Select(s => s.startDate).SingleOrDefault();
                string eDateStr = taskList.Where(x => x.taskName == this.ddTaskList.SelectedValue).Select(s => s.endDate).SingleOrDefault();

                if (this.cBoxDayOff.Checked || !(sDateStr.Equals(this.txtSdateValue.Text)) || !(eDateStr.Equals(this.txtEdateValue.Text)))
                {
                    this.lbErrorMsg.Text = "Change has been made!";
                }
                else
                {
                    this.lbErrorMsg.Text = "There is no change. Please check it again.";
                    return;
                }
            }

            insertX();


        }
        public void insertX()
        {
            try
            {
                int assingee = int.Parse(taskList.Where(x => x.taskName == this.ddTaskList.SelectedValue).Select(s => s.assignee).SingleOrDefault());
                int assingor = int.Parse(taskList.Where(x => x.taskName == this.ddTaskList.SelectedValue).Select(s => s.assignorID).SingleOrDefault());
                Char dayOff = 'F';
                if (this.cBoxDayOff.Checked)
                {
                    dayOff = 'T';
                }
                string originalSDateStr = taskList.Where(x => x.taskName == this.ddTaskList.SelectedValue).Select(s => s.startDate).SingleOrDefault();
                string originalEDateStr = taskList.Where(x => x.taskName == this.ddTaskList.SelectedValue).Select(s => s.endDate).SingleOrDefault();
                string newSDate = this.txtSdateValue.Text;
                string newEDate = this.txtEdateValue.Text;
                string comment = this.txtComment.Text;
                int taskID = int.Parse(taskList.Where(x => x.taskName == this.ddTaskList.SelectedValue).Select(s => s.taskID).SingleOrDefault());

                string connectionString = ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(connectionString);
                string sql = "INSERT INTO dbo.requestTransaction VALUES(NEXT VALUE FOR dbo.SEQrequestTransaction, "
                    + "@assingee, @assingor, @dayOff, @originalSDateStr, @originalEDateStr, @newSDate, @newEDate, @comment, @updateTime, @taskID)";

                SqlDataAdapter ad = new SqlDataAdapter("", myConnection);

                SqlParameter param1 = ad.SelectCommand.Parameters.Add("@assingee", System.Data.SqlDbType.Int);
                param1.Value = assingee;
                SqlParameter param2 = ad.SelectCommand.Parameters.Add("@assingor", System.Data.SqlDbType.Int);
                param2.Value = assingor;
                SqlParameter param3 = ad.SelectCommand.Parameters.Add("@dayOff", System.Data.SqlDbType.Char);
                param3.Value = dayOff;
                SqlParameter param4 = ad.SelectCommand.Parameters.Add("@originalSDateStr", System.Data.SqlDbType.VarChar);
                param4.Value = originalSDateStr;
                SqlParameter param5 = ad.SelectCommand.Parameters.Add("@originalEDateStr", System.Data.SqlDbType.VarChar);
                param5.Value = originalEDateStr;
                SqlParameter param6 = ad.SelectCommand.Parameters.Add("@newSDate", System.Data.SqlDbType.VarChar);
                param6.Value = newSDate;
                SqlParameter param7 = ad.SelectCommand.Parameters.Add("@newEDate", System.Data.SqlDbType.VarChar);
                param7.Value = newEDate;
                SqlParameter param8 = ad.SelectCommand.Parameters.Add("@comment", System.Data.SqlDbType.VarChar);
                param8.Value = comment;
                SqlParameter param9 = ad.SelectCommand.Parameters.Add("@updateTime", System.Data.SqlDbType.DateTime);
                param9.Value = DateTime.Now;
                SqlParameter param10 = ad.SelectCommand.Parameters.Add("@taskID", System.Data.SqlDbType.Int);
                param10.Value = taskID;




                ad.SelectCommand.CommandText = sql;
                myConnection.Open();
                ad.SelectCommand.ExecuteNonQuery();

                myConnection.Close();
                this.lbErrorMsg.Text = "request sent successfully!";
            }
            catch(Exception ex)
            {
                string x = ex.StackTrace;
                
            }
            



            
        }

        protected void txtSdateValue_TextChanged(object sender, EventArgs e)
        {
            
        }
    }


}