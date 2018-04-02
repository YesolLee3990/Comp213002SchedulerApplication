using Comp213002SchedulerApplication.AppCode.controls.models;
using Comp213002SchedulerApplication.AppCode.controls.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Comp213002SchedulerApplication
{
    public partial class _Default : Page
    {
        DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            dt = GetData();
            AuthProcess();
            SetCalendarDate();
        }

        private void SetCalendarDate() {
            var date = Request.QueryString["date"];
            if(!String.IsNullOrEmpty(date)) {
                Calendar1.TodaysDate = DateTime.ParseExact(date.Substring(0, 10), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); ;
            }
        }

        private void AuthProcess() {
            // Assign Button Setting
            //if (!UserInfoUtil.isManager()) {
            //    assignTaskBtn.Visible = false;
            //}

            //UserInfo loginUser = (UserInfo)UserInfoUtil.getLoginUser();
            //loginInfoLabel.Text = loginUser.UserName + "(" + loginUser.UserId + ")";
            //logoutBtn.Click += LogOut;
        }

        private void LogOut(object sender, EventArgs e) {
            //SessionUtil.expireSession();
            //Response.Cookies.Clear();
            //Response.Redirect("~/Login.aspx");
        }

        private DataTable GetData()
        {
            return DBUtil.Select("SELECT * FROM dbo.task where userinfo_id = '" + UserInfoUtil.getLoginUser().Id + "'");
        }

        /**
         * Add task (linkbutton) on the calendar
         */
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e) {
            //string link = "<a href='ScheduleDetails.aspx?ID=";
            string s = e.Day.Date.ToShortDateString();
            e.Cell.Attributes.Add("onmouseover", "this.style.cursor='pointer'");

            int i = 0;
            foreach (DataRow row in dt.Rows) {
                i++;
                string scheduledDate = Convert.ToDateTime(row["ScheduleStart"]).ToShortDateString();
                if (scheduledDate.Equals(s)) {
                    AddTaskButtonOnCalendar(e, row);
                }
            }
        }

        private static void AddTaskButtonOnCalendar(DayRenderEventArgs e, DataRow row) {
            LinkButton lb = new LinkButton();
            lb.Text = "<BR>" + row["Subject"] as String;
            lb.Attributes.Add("onclick", "showUpdateStatus('" + row["ID"] + "');");

            if ((string)row["STATUS"] == "F") {
                lb.Style.Add("color", "black");
            } else {
                // normal
                if (((DateTime)row["ScheduleEnd"]).CompareTo(DateTime.Now) > 0) {
                    switch ((string)row["STATUS"]) {
                        case "S":
                            lb.Style.Add("color", "green");
                            break;
                        default:
                        lb.Style.Add("color", "blue");
                            break;
                    }
                    // delayed
                } else {
                    lb.Style.Add("color", "red");
                }
            }
            
            e.Cell.Controls.Add(lb);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.ModalPopupExtender1.Show();
            DateTime dt = this.Calendar1.SelectedDate;
            //send login-information later.
            Session.Add("selectedDate", dt);
        }
    }
}