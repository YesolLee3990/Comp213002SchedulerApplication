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
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }
        //private DataSet GetData()
        private DataTable GetData() {
            //string connectionString = "Data Source=serverschedulerapplication.database.windows.net/SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=dbase;User ID=comp213;Password=Centennial2018";
            //string connectionString = ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ConnectionString;
            //SqlConnection myConnection = new SqlConnection(connectionString);
            //SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM dbo.task", myConnection);

            //DataSet ds = new DataSet();
            //ad.Fill(ds);
            //return ds;

            return DBUtil.Select("SELECT * FROM DBO.TASK");
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

            DataTable dt = GetData();
            string link = "<a href='ScheduleDetails.aspx?ID=";
            string s = e.Day.Date.ToShortDateString();

            foreach (DataRow row in dt.Rows)
            {
                string scheduledDate = Convert.ToDateTime(row["ScheduleStart"]).ToShortDateString();
                if (scheduledDate.Equals(s))
                {
                    LinkButton lb = new LinkButton();
                    lb.Text = "<BR>" + link + (int)row["ID"] + "'>" + row["Subject"] as String + "</a>" + "<BR>";
                    //lb.BackColor = System.Drawing.Color.Red;
                    lb.Style.Add("color", "red");
                    e.Cell.Controls.Add(lb);
                }
            }



        }
    }
}