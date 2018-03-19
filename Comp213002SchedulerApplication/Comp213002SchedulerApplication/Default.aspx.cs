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
        private DataSet GetData()
        {
            //string connectionString = "Data Source=serverschedulerapplication.database.windows.net/SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=dbase;User ID=comp213;Password=Centennial2018";
            string connectionString = ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM dbo.task", myConnection);

            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

            DataSet ds = GetData();
            string link = "<a href='ScheduleDetails.aspx?ID=";
            string s = e.Day.Date.ToShortDateString();

            foreach (DataRow row in ds.Tables[0].Rows)
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