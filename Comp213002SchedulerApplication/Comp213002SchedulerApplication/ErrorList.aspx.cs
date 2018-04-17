using Comp213002SchedulerApplication.AppCode.controls.util;
using Comp213002SchedulerApplication.SharedCode.controls.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp213002SchedulerApplication {
    public partial class ErrorList : System.Web.UI.Page {
        public DataTable dt;
        public DataTable userList;

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

        protected void Page_Load(object sender, EventArgs e) {
            SetUserList();
            string sql = BuildSearchSql();
            dt = DBUtil.Select(sql);
            changeSettings();
        }

        public void changeSettings()
        {
            Style primaryStyle = StyleMaker.makingStyle((string)Session["Font"], (string)Session["FontSize"], (string)Session["FontColor"]);

            if (primaryStyle != null)
            {
                this.Label1.ApplyStyle(primaryStyle);
                this.Label2.ApplyStyle(primaryStyle);
                this.Label3.ApplyStyle(primaryStyle);
                this.Label4.ApplyStyle(primaryStyle);
                this.Label4.Font.Size = 16;
            }
        }

        private void SetUserList() {
            userList = DBUtil.Select("SELECT * FROM USERINFO");
        }
        private string BuildSearchSql() {
            SessionUtil.putSessionInfo("searchCondition", Request.QueryString);

            string errorMsg = Request["errorMsg"];
            string errorDate = Request["errorDate"];
            string userId = Request["userId"];
            string conditions = "";

            if (!String.IsNullOrEmpty(errorMsg)) conditions += " AND A.ERRORMSG LIKE '%" + errorMsg.Trim() + "%' ";
            if (!String.IsNullOrEmpty(errorDate)) conditions += " AND CONVERT(char(10), A.CREATEDATE, 120) = '" + errorDate + "' ";
            if (!String.IsNullOrEmpty(userId) && userId!="A") conditions += " AND A.USERID = '" + userId + "' ";

            string sql = "select A.ID, B.USERNAME, "
                + " CONVERT(VARCHAR(10), A.CREATEDATE, 120) AS 'CREATEDATE', A.ERRORMSG FROM ERROR A, USERINFO B "
                + "WHERE A.USERID = B.ID " + conditions + " order by A.CREATEDATE desc";

            return sql;
        }
    }
}