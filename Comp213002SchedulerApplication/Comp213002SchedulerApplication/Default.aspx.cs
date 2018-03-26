using Comp213002SchedulerApplication.App_Code.controls.util;
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
        DataSet ds = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ds = GetData();
        }
        private DataSet GetData()
        {
            //string connectionString = "Data Source=serverschedulerapplication.database.windows.net/SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=dbase;User ID=comp213;Password=Centennial2018";
            string connectionString = ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM dbo.task where userinfo_id = '" + UserInfoUtil.getLoginUser().Id + "'", myConnection);

            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e) {
            //string link = "<a href='ScheduleDetails.aspx?ID=";
            string s = e.Day.Date.ToShortDateString();
            e.Cell.Attributes.Add("onmouseover", "this.style.cursor='pointer'");

            int i = 0;
            foreach (DataRow row in ds.Tables[0].Rows) {
                i++;
                string scheduledDate = Convert.ToDateTime(row["ScheduleStart"]).ToShortDateString();
                if (scheduledDate.Equals(s)) {
                    LinkButton lb = new LinkButton();
                    //lb.ID = "lb" + i;
                    //lb.OnClientClick = "return ShowModalPopup()";
                    lb.Text = "<BR>" + row["Subject"] as String;
                    //lb.Text = "<BR>" + link + (int)row["ID"] + "'>" + row["Subject"] as String + "</a>" + "<BR>";
                    lb.Style.Add("color", "red");
                    e.Cell.Controls.Add(lb);
                }
            }
        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {

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