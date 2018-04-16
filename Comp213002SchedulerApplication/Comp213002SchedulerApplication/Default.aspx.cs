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
        DataTable rt = null;
        
        string theme;
        string font;
        string fontSize;
        string fontColor;
        private Style primaryStyle = new Style();

        private void Page_PreInit(object sender, EventArgs e)
        {
            font = (string)Session["font"];
            fontSize = (string)Session["fontSize"];
            fontColor = (string)Session["fontColor"];

            theme = (string)Session["theme"];
            if(theme==null || theme.Equals("Normal") || theme.Equals("none"))
            {
                Page.Theme = null;
            }
            else
            {
                Page.Theme = theme;
            }
            
        }



         protected void Page_Load(object sender, EventArgs e){
            dt = GetData();
            AuthProcess();
            SetCalendarDate();
            SetDailyTasks();
            GetRequestRescheduling();

            changeSettings();
        }

        public void changeSettings()
        {

            //change calendar theme
            switch (theme)
            {
                case "Normal":
                    this.Calendar1.BackColor = System.Drawing.Color.White;
                    this.Calendar1.BorderColor = System.Drawing.Color.White;
                    break;
                case "Dark":
                    this.Calendar1.BackColor = System.Drawing.Color.LightGray;
                    this.Calendar1.BorderColor = System.Drawing.Color.Black;
                    break;
                case "Blue":
                    this.Calendar1.BackColor = System.Drawing.Color.LightBlue;
                    this.Calendar1.BorderColor = System.Drawing.Color.BlueViolet;
                    break;
                case "Pink":
                    this.Calendar1.BackColor = System.Drawing.Color.LightPink;
                    this.Calendar1.BorderColor = System.Drawing.Color.DarkRed;
                    break;
                default:
                    this.Calendar1.BackColor = System.Drawing.Color.White;
                    this.Calendar1.BorderColor = System.Drawing.Color.White;
                    break;
            }
            
            if(font!=null)
            {
                if (!(font.Equals("none"))){
                    primaryStyle.Font.Name = font;
                }
                primaryStyle.Font.Name = font;
            }
            
            switch (fontSize)
            {
                case "Small":
                    primaryStyle.Font.Size = 8;
                    break;
                case "Medium":
                    primaryStyle.Font.Size = 10;
                    break;
                case "Large":
                    primaryStyle.Font.Size = 12;
                    break;
                case "XLarge":
                    primaryStyle.Font.Size = 14;
                    break;
                default:
                    break;
            }

            switch (fontColor)
            {
                case "Black":
                    primaryStyle.ForeColor = System.Drawing.Color.Black;
                    break;
                case "Red":
                    primaryStyle.ForeColor = System.Drawing.Color.Red;
                    break;
                case "Blue":
                    primaryStyle.ForeColor = System.Drawing.Color.Blue;
                    break;
                case "Green":
                    primaryStyle.ForeColor = System.Drawing.Color.Green;
                    break;
                case "White":
                    primaryStyle.ForeColor = System.Drawing.Color.White;
                    break;
                case "Yellow":
                    primaryStyle.ForeColor = System.Drawing.Color.Yellow;
                    break;
                default:
                    break;
            }

            this.btnCustomizing.ApplyStyle(primaryStyle);
            this.logoutBtn.ApplyStyle(primaryStyle);
            this.assignTaskBtn.ApplyStyle(primaryStyle);
            this.lbWelcome.ApplyStyle(primaryStyle);
            this.Calendar1.ApplyStyle(primaryStyle);

            Session["styleSetting"] = primaryStyle;
        }

        
        private void GetRequestRescheduling() {
            if (UserInfoUtil.isManager()) {
                DataTable results = DBUtil.Select("SELECT A.ID, Z.SUBJECT + ' by ' + U.USERNAME FROM TASK Z, REQUESTTRANSACTION A, USERINFO U WHERE Z.ID = A.TASKID AND A.STATUS = 'R' AND U.ID = A.ASSIGNEE AND A.assignor = '" + UserInfoUtil.getLoginUserId() + "' ");
                GridView2.DataSource = results;
                GridView2.ShowHeader = false;
                GridView2.ShowFooter = false;
                GridView2.Style["TABLE-LAYOUT"] = "fixed";
                GridView2.GridLines = GridLines.None;
                GridView2.BorderStyle = BorderStyle.None;
                GridView2.RowDataBound += GridView2_RowDataBound; ;
                GridView2.DataBind();
            }
        }

        private void GridView2_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='pointer';this.style.backgroundColor='#ffccff';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Wrap = false;
                e.Row.Cells[1].Style["overflow"] = "hidden";
                e.Row.Cells[1].Style["text-overflow"] = "ellipsis";
                e.Row.Cells[1].ToolTip = e.Row.Cells[1].Text;
                e.Row.Attributes["onclick"] = "javascript:showRequest('" + e.Row.Cells[0].Text + "');";
            }
        }

        private void SetRequestTasks() {
            DataTable results = DBUtil.Select("SELECT ID, CONVERT(VARCHAR, ROW_NUMBER() OVER(ORDER BY SUBJECT)) +'. ' + SUBJECT AS NUM FROM TASK WHERE UserInfo_ID = 1 AND CONVERT(DATETIME, '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 102) BETWEEN SCHEDULESTART AND SCHEDULEEND ");
            GridView1.DataSource = results;
            GridView1.ShowHeader = false;
            GridView1.ShowFooter = false;
            GridView1.Style["TABLE-LAYOUT"] = "fixed";
            GridView1.GridLines = GridLines.None;
            GridView1.BorderStyle = BorderStyle.None;
            GridView1.RowDataBound += GridView1_RowDataBound;
            GridView1.DataBind();
        }

        private void SetDailyTasks() {
            DataTable results = DBUtil.Select("SELECT ID, CONVERT(VARCHAR, ROW_NUMBER() OVER(ORDER BY SUBJECT)) +'. ' + SUBJECT AS NUM FROM TASK WHERE UserInfo_ID = 1 AND CONVERT(DATETIME, '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 102) BETWEEN SCHEDULESTART AND SCHEDULEEND ");
            GridView1.DataSource = results;
            GridView1.ShowHeader = false;
            GridView1.ShowFooter = false;
            GridView1.Style["TABLE-LAYOUT"] = "fixed";
            GridView1.GridLines = GridLines.None;
            GridView1.BorderStyle = BorderStyle.None;
            GridView1.RowDataBound += GridView1_RowDataBound;
            GridView1.DataBind();
        }

        private void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='pointer';this.style.backgroundColor='#ffccff';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Wrap = false;
                e.Row.Cells[1].Style["overflow"] = "hidden";
                e.Row.Cells[1].Style["text-overflow"] = "ellipsis";
                e.Row.Cells[1].ToolTip = e.Row.Cells[1].Text;
                e.Row.Attributes["onclick"] = "javascript:showUpdateStatus('" + e.Row.Cells[0].Text + "');";
            }
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
