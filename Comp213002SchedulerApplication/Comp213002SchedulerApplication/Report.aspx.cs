using Comp213002SchedulerApplication.SharedCode.controls.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Comp213002SchedulerApplication
{
    public partial class Report : Page
    {



        private void Page_PreInit(object sender, EventArgs e)
        {
            string temp = (string)Session["theme"];
            if (StyleMaker.theme == null)
            {
                if (StyleMaker.theme == null || StyleMaker.theme.Equals("No change"))
                {
                    Page.Theme = null;
                }
                else
                {
                    StyleMaker.theme = (string)Session["theme"];
                }

            }

            if (StyleMaker.theme == null || StyleMaker.theme.Equals("Normal"))
            {
                Page.Theme = null;
            }
            else
            {
                if (!temp.Equals("No change"))
                {
                    StyleMaker.theme = (string)Session["theme"];
                }
                Page.Theme = StyleMaker.theme;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            SelectedTable();

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel5.Visible = true;

            drpList.Visible = false;

            drpList1.AutoPostBack = true;
            drpList.AutoPostBack = true;

            //for userid dropbox
            if (drpList1.SelectedIndex == 1)
            {
                drpList.Visible = true;
            }

            changeSettings();
        }

        public void changeSettings()
        {
            Style primaryStyle = StyleMaker.makingStyle((string)Session["Font"], (string)Session["FontSize"], (string)Session["FontColor"]);

            if (primaryStyle!= null)
            {
                this.GridView1.ApplyStyle(primaryStyle);
                this.GridView2.ApplyStyle(primaryStyle);
                this.GridView5.ApplyStyle(primaryStyle);
                this.drpList.ApplyStyle(primaryStyle);
                this.drpList1.ApplyStyle(primaryStyle);
                this.Button2.ApplyStyle(primaryStyle);
                this.Chart1.ApplyStyle(primaryStyle);
                this.lbTable.ApplyStyle(primaryStyle);
            }
        }



        //Tried to use google chart but cannot use entity


        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public static object[] GetChartData()
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ConnectionString;
        //    con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM task", con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);

        //    List<task> data = new List<task>();
        //    //Here MyDatabaseEntities  is our dbContext
        //    using (DBSchedulerApplicationEntities1 dc = new DBSchedulerApplicationEntities1())
        //    {
        //        data = dc.tasks.ToList();
        //    }

        //    var chartData = new object[data.Count + 1];
        //    chartData[0] = new object[]{
        //            "Product Category",
        //            "Revenue Amount"
        //        };
        //    int j = 0;
        //    foreach (var i in data)
        //    {
        //        j++;
        //        chartData[j] = new object[] { i.UserInfo_ID, i.UserInfo };
        //    }

        //    return chartData;
        //}




        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gridview for userId
            Panel1.Visible = false;
            Panel2.Visible = true;
            GridView5.Visible = false;
        }

        public void Display(string data)
        {
            //Display gridview by table
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["esmsDbConnectionStr"].ConnectionString;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + data, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView5.DataSource = dt;
            GridView5.DataBind();
            con.Close();
        }
        public void SelectedTable()
        {
            //Condition for table
            SqlConnection con = new SqlConnection();

            if (drpList1.SelectedIndex == 1)
            {
                Display("UserInfo");
                Panel1.Visible = true;
                Panel2.Visible = false;

            }
            else if (drpList1.SelectedIndex == 2)
            {
                GridView5.Visible = true;
                Display("task");

            }
            else if (drpList1.SelectedIndex == 3)
            {
                GridView5.Visible = true;
                Display("requestTransaction");
            }
            else if (drpList1.SelectedIndex == 4)
            {
                GridView5.Visible = true;
                Display("Error");
            }
        }

        //For Export to Excel
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        //For Export to Excel
        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Report.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            if (drpList1.SelectedIndex == 1)
            {
                //Excel by userId
                if (drpList.SelectedIndex > 0)
                {
                    GridView2.AllowPaging = false;
                    SelectedTable();
                    GridView2.HeaderRow.Style.Add("background-color", "#ffffff");
                    for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                    {
                        GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#FF9999");
                    }
                    GridView2.RenderControl(hw);
                    Response.Write(sw.ToString());
                    Response.End();
                }
            }
            else
            {
                //Excel by table, but don't know why only usertable Excel exports with all html
                GridView5.AllowPaging = false;
                SelectedTable();
                GridView5.HeaderRow.Style.Add("background-color", "#ffffff");
                for (int i = 0; i < GridView5.HeaderRow.Cells.Count; i++)
                {
                    GridView5.HeaderRow.Cells[i].Style.Add("background-color", "#FF9999");
                }
                GridView5.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.End();
            }
        }

    }
}